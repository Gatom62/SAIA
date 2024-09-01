using AgroServicios.Controlador;
using AgroServicios.Modelo.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Text;
using System;
using System.Windows.Forms;
using System.IO;

namespace AgroServicios.Modelo.DAO
{
    // Clase DAOCorreoRecuperacion que hereda de DTOCorreoRecuperacion
    public class DAOCorreoRecuperacion : DTOCorreoRecuperacion
    {
        // Declaración de un cliente SMTP privado para enviar correos electrónicos
        private SmtpClient smtpClient;

        // Método protegido para inicializar el cliente SMTP
        protected void inicializeSmtpClient()
        {
           
            // Crear una nueva instancia de SmtpClient
            smtpClient = new SmtpClient();

            // Configura las credenciales del cliente SMTP (correo del remitente y contraseña)
            smtpClient.Credentials = new NetworkCredential(remintenteCorreo, password);

            // Configura el servidor SMTP (host) que se utilizará para enviar el correo
            smtpClient.Host = host;

            // Configura el puerto del servidor SMTP
            smtpClient.Port = port;

            // Habilita SSL para asegurar la conexión al servidor SMTP
            smtpClient.EnableSsl = ssl;
        }


        // Método público para enviar un correo electrónico
        public void sendMail(string subject, string body, List<string> destinatarioCorreo)
        {
            // Crear una nueva instancia de MailMessage para el correo a enviar
            var mailMessage = new MailMessage();
            try
            {
                // Establece la dirección del remitente del correo
                mailMessage.From = new MailAddress(remintenteCorreo);

                // Añade cada destinatario al mensaje de correo
                foreach (string mail in destinatarioCorreo)
                {
                    mailMessage.To.Add(mail);
                }

                // Configura el asunto del correo
                mailMessage.Subject = subject;
                // Configura el cuerpo del correo
                mailMessage.Body = body;
                // Establece la prioridad del correo como normal
                mailMessage.Priority = MailPriority.Normal;

                // Envía el correo utilizando el cliente SMTP configurado previamente
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre una excepción durante el envío del correo
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Libera los recursos utilizados por el mensaje de correo y el cliente SMTP
                mailMessage.Dispose();
                smtpClient.Dispose();
            }
        }

        // Método público para recuperar la contraseña de un usuario
        public string recoverPassword(string usuarioSolicitado)
        {
            using (var command = new SqlCommand())
            {
                // Configura la conexión SQL para el comando
                command.Connection = getConnection();
                // Configura la consulta SQL para obtener el nombre, correo y contraseña del usuario
                command.CommandText = @"SELECT e.Nombre, e.Correo, u.Contraseña FROM Empleados e  
                                        INNER JOIN Usuarios u ON e.Usuario = u.Usuario 
                                        WHERE u.Usuario COLLATE SQL_Latin1_General_CP1_CS_AS = @username 
                                        OR e.Correo COLLATE SQL_Latin1_General_CP1_CS_AS = @correo";
                // Añade los parámetros a la consulta
                command.Parameters.AddWithValue("@username", usuarioSolicitado);
                command.Parameters.AddWithValue("@correo", usuarioSolicitado);
                command.CommandType = System.Data.CommandType.Text;

                // Ejecuta la consulta y lee los resultados
                SqlDataReader reader = command.ExecuteReader();

                // Si se encuentra un registro coincidente
                if (reader.Read())
                {
                    // Obtiene el nombre y el correo del usuario desde la base de datos
                    string nombreUsuario = reader.GetString(0);
                    string correoUsuario = reader.GetString(1);

                    // Genera una nueva contraseña temporal aleatoria
                    string contraseñaTemporal = GenerarContraseñaTemporal();

                    // Crea una instancia de la clase Encryp para encriptar la contraseña
                    Encryp encryp = new Encryp();
                    string contraseñaTemporalEncriptada = encryp.Encriptar(contraseñaTemporal);

                    // Cierra el reader antes de ejecutar otra consulta
                    reader.Close();

                    // Actualiza la base de datos con la nueva contraseña encriptada
                    command.CommandText = "UPDATE Usuarios SET Contraseña = @newPassword WHERE Usuario = @username";
                    command.Parameters.AddWithValue("@newPassword", contraseñaTemporalEncriptada);

                    // Ejecuta la actualización y verifica si se realizó con éxito
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Si la actualización fue exitosa, envía la nueva contraseña por correo
                        var mailService = new DAODCSoporte();
                        mailService.sendMail(
                            subject: "SAIA: Solicitud de recuperación de contraseña",
                            body: $"Hola, {nombreUsuario}\nUsted solicitó recuperar su contraseña. \nLa nueva contraseña es: {contraseñaTemporal}\nRevise su correo.",
                            destinatarioCorreo: new List<string> { correoUsuario }
                        );

                        // Censura el correo del usuario antes de mostrarlo en el mensaje
                        string correoCensurado = CensurarCorreo(correoUsuario);

                        // Retorna un mensaje indicando que el correo fue enviado y muestra el correo censurado
                        return $"Hola, {nombreUsuario}\nUsted solicitó recuperar su contraseña. Por favor revise su correo: {correoCensurado}";
                    }
                    else
                    {
                        // Retorna un mensaje indicando que ocurrió un error al actualizar la contraseña
                        return "Ocurrió un error al actualizar la contraseña.";
                    }
                }
                else
                {
                    // Retorna un mensaje indicando que no se encontró una cuenta con el usuario o correo especificado
                    return "Lo sentimos, no tiene una cuenta con ese correo o nombre de usuario.";
                }
            }
        }
        public void sendMailWithAttachment(string subject, string body, List<string> destinatarioCorreo, string attachmentPath)
        {
            if (destinatarioCorreo == null || destinatarioCorreo.Count == 0)
            {
                // No hay destinatarios, no se realiza el envío
                return;
            }

            var mailMessage = new MailMessage();
            try
            {
                mailMessage.From = new MailAddress(remintenteCorreo);

                foreach (string mail in destinatarioCorreo)
                {
                    if (IsValidEmail(mail))
                    {
                        mailMessage.To.Add(mail);
                    }
                }

                if (mailMessage.To.Count == 0)
                {
                    // No se añadieron destinatarios válidos, no se realiza el envío
                    return;
                }

                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.Priority = MailPriority.Normal;

                // Añadir el archivo adjunto
                if (!string.IsNullOrEmpty(attachmentPath) && File.Exists(attachmentPath))
                {
                    Attachment attachment = new Attachment(attachmentPath);
                    mailMessage.Attachments.Add(attachment);
                }

                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                // Solo se muestra el mensaje si hay un error real
                MessageBox.Show("Ocurrió un error al enviar el correo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                mailMessage.Dispose();
                smtpClient.Dispose();
            }
        }

        // Método auxiliar para validar correos electrónicos
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }



        // Método privado para censurar un correo electrónico
        private string CensurarCorreo(string correo)
        {
            // Divide el correo en dos partes: antes y después del símbolo '@'
            var partesCorreo = correo.Split('@');

            // Verifica si el correo tiene un formato válido (debe tener dos partes)
            if (partesCorreo.Length != 2)
            {
                throw new ArgumentException("El correo no es válido.");
            }

            // Obtén los primeros tres caracteres antes del '@'
            string primerosCaracteres = partesCorreo[0].Substring(0, 3);

            // Crea la parte censurada del correo con asteriscos, cubriendo el resto de los caracteres
            string parteCensurada = new string('*', partesCorreo[0].Length - 3);

            // Reconstruye el correo censurado
            string correoCensurado = primerosCaracteres + parteCensurada + "@" + partesCorreo[1];

            // Retorna el correo censurado
            return correoCensurado;
        }

        // Método privado para generar una contraseña temporal aleatoria
        private string GenerarContraseñaTemporal()
        {
            // Define los caracteres permitidos en la contraseña temporal
            const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            // Genera un número aleatorio
            Random random = new Random();
            // Crea un StringBuilder para construir la contraseña temporal
            StringBuilder result = new StringBuilder(8);
            for (int i = 0; i < 8; i++)
            {
                // Añade caracteres aleatorios al resultado
                result.Append(caracteresPermitidos[random.Next(caracteresPermitidos.Length)]);
            }
            // Retorna la contraseña temporal generada
            return result.ToString();
        }
    }
}

