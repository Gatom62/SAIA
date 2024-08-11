using AgroServicios.Controlador;
using AgroServicios.Modelo.DTO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Text;
using System;
using System.Windows.Forms;

namespace AgroServicios.Modelo.DAO
{
    // Clase DAOCorreoRecuperacion que hereda de DTOCorreoRecuperacion
    public class DAOCorreoRecuperacion : DTOCorreoRecuperacion
    {
        // Declaración de un cliente SMTP privado
        private SmtpClient smtpClient;

        // Método protegido para inicializar el cliente SMTP
        protected void inicializeSmtpClient()
        {
            smtpClient = new SmtpClient();
            // Configura las credenciales del cliente SMTP (correo y contraseña)
            smtpClient.Credentials = new NetworkCredential(remintenteCorreo, password);
            // Configura el servidor SMTP (host)
            smtpClient.Host = host;
            // Configura el puerto del servidor SMTP
            smtpClient.Port = port;
            // Habilita SSL para la seguridad en el envío de correos
            smtpClient.EnableSsl = ssl;
        }

        // Método público para enviar un correo electrónico
        public void sendMail(string subject, string body, List<string> destinatarioCorreo)
        {
            // Crea un nuevo mensaje de correo
            var mailMessage = new MailMessage();
            try
            {
                // Establece la dirección del remitente
                mailMessage.From = new MailAddress(remintenteCorreo);
                // Agrega cada destinatario al mensaje
                foreach (string mail in destinatarioCorreo)
                {
                    mailMessage.To.Add(mail);
                }
                // Configura el asunto del correo
                mailMessage.Subject = subject;
                // Configura el cuerpo del correo
                mailMessage.Body = body;
                // Establece la prioridad del correo (normal)
                mailMessage.Priority = MailPriority.Normal;
                // Envía el correo usando el cliente SMTP
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre una excepción
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Libera los recursos utilizados por el mensaje y el cliente SMTP
                mailMessage.Dispose();
                smtpClient.Dispose();
            }
        }

        // Método público para recuperar la contraseña de un usuario
        public string recoverPassword(string usuarioSolicitado)
        {
            using (var command = new SqlCommand())
            {
                // Configura la conexión de SQL
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

                if (reader.Read())
                {
                    // Obtiene el nombre y correo del usuario
                    string nombreUsuario = reader.GetString(0);
                    string correoUsuario = reader.GetString(1);

                    // Genera una nueva contraseña temporal
                    string contraseñaTemporal = GenerarContraseñaTemporal();

                    // Crea una instancia de la clase Encryp para encriptar la contraseña
                    Encryp encryp = new Encryp();
                    string contraseñaTemporalEncriptada = encryp.Encriptar(contraseñaTemporal);

                    // Actualiza la base de datos con la nueva contraseña encriptada
                    reader.Close();
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

                        // Retorna un mensaje indicando que el correo fue enviado
                        return $"Hola, {nombreUsuario}\nUsted solicitó recuperar su contraseña. Por favor revise su correo: {correoUsuario}";
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

