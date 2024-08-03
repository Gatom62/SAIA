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
    public class DAOCorreoRecuperacion: DTOCorreoRecuperacion
    {
        private SmtpClient smtpClient;
        protected void inicializeSmtpClient()
        {
            smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(remintenteCorreo, password);
            smtpClient.Host = host;
            smtpClient.Port = port;
            smtpClient.EnableSsl = ssl;
        }

        public void sendMail(string subject, string body, List<string> destinatarioCorreo)
        {
            var mailMessage = new MailMessage();
            try
            {
                mailMessage.From = new MailAddress(remintenteCorreo);
                foreach (string mail in destinatarioCorreo)
                {
                    mailMessage.To.Add(mail);
                }
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.Priority = MailPriority.Normal;
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                mailMessage.Dispose();
                smtpClient.Dispose();
            }
        }
        public string recoverPassword(string usuarioSolicitado)
        {
            using (var command = new SqlCommand())
            {
                command.Connection = getConnection();
                command.CommandText = @" SELECT e.Nombre, e.Correo, u.Contraseña FROM Empleados e  INNER JOIN Usuarios u ON e.Usuario = u.Usuario WHERE u.Usuario COLLATE SQL_Latin1_General_CP1_CS_AS = @username OR e.Correo COLLATE SQL_Latin1_General_CP1_CS_AS = @correo";
                command.Parameters.AddWithValue("@username", usuarioSolicitado);
                command.Parameters.AddWithValue("@correo", usuarioSolicitado);
                command.CommandType = System.Data.CommandType.Text;
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string nombreUsuario = reader.GetString(0);
                    string correoUsuario = reader.GetString(1);

                    // Generar una contraseña temporal
                    string contraseñaTemporal = GenerarContraseñaTemporal();

                    // Encriptar la nueva contraseña temporal
                    Encryp encryp = new Encryp();
                    string contraseñaTemporalEncriptada = encryp.Encriptar(contraseñaTemporal);

                    // Actualizar la base de datos con la nueva contraseña temporal
                    reader.Close();
                    command.CommandText = "UPDATE Usuarios SET Contraseña = @newPassword WHERE Usuario = @username";
                    command.Parameters.AddWithValue("@newPassword", contraseñaTemporalEncriptada);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Enviar la nueva contraseña temporal por correo
                        var mailService = new DAODCSoporte();
                        mailService.sendMail(
                            subject: "SAIA: Solicitud de recuperación de contraseña",
                            body: $"Hola, {nombreUsuario}\nUsted solicitó recuperar su contraseña. \nLa nueva contraseña es: {contraseñaTemporal}\nRevise su correo.",
                            destinatarioCorreo: new List<string> { correoUsuario }
                        );

                        return $"Hola, {nombreUsuario}\nUsted solicitó recuperar su contraseña. Por favor revise su correo: {correoUsuario}";
                    }
                    else
                    {
                        return "Ocurrió un error al actualizar la contraseña.";
                    }
                }
                else
                {
                    return "Lo sentimos, no tiene una cuenta con ese correo o nombre de usuario.";
                }

            }
        }
        private string GenerarContraseñaTemporal()
        {
            const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random random = new Random();
            StringBuilder result = new StringBuilder(8);
            for (int i = 0; i < 8; i++)
            {
                result.Append(caracteresPermitidos[random.Next(caracteresPermitidos.Length)]);
            }
            return result.ToString();
        }
    }
}
