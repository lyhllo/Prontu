using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace PRONTU.Controller
{
    public class UsuarioController
    {
        public static bool Login (string u, string s)
        {
            Connection c = new Connection();

            string sql = "SELECT * FROM usuario_sistema WHERE usuario='" + u + "' AND senha='" + s + "';";

            object result = c.Query(sql);

            if (result != null)
            {
                c.Close();
                return true;
            }
            else
            {
                c.Close();
                return false;
            }
        }

        public static bool EsqueciMinhaSenha(string emailRecuperacao)
        {
            string codigo = GeraCodigo();
            UpdateCodigoRecuperacao(emailRecuperacao, codigo);

            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("no-reply@prontu.com.br");
                message.To.Add(new MailAddress(emailRecuperacao));
                message.Subject = "Código de recuperação";
                message.IsBodyHtml = true;  
                message.Body = "<p>Código de verificação: "+codigo+"</p>";
                smtp.Port = 58700;
                smtp.Host = "mail.n13.galafassi.com.br"; 
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("teste@n13.galafassi.com.br", "");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                return true;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public static string GeraCodigo()
        {
            Random random = new Random();
            string randomCode = random.Next(999999).ToString();
            return randomCode;
        }

        public static void UpdateCodigoRecuperacao(string email, string codigo)
        {
            try
            {
                Connection c = new Connection();

                string sql = "UPDATE usuario_sistema SET codigo_recuperacao = '" + codigo + "' WHERE email='" + email + "';";

                object result = c.Query(sql);

                c.NonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public static bool ValidaCodigoRecuperacao(string codigo)
        {
            Connection c = new Connection();

            string sql = "SELECT * FROM usuario_sistema WHERE codigo_recuperacao='"+codigo+"';";

            object result = c.Query(sql);

            if (result != null)
            {
                c.Close();
                return true;
            }
            else
            {
                c.Close();
                return false;
            }
        }

        public static bool AtualizaSenha(string email, string senha)
        {
            try
            {
                Connection c = new Connection();

                string sql = "UPDATE usuario_sistema SET senha = '" + senha + "' WHERE email='" + email + "';";

                object result = c.Query(sql);

                c.NonQuery(sql);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
