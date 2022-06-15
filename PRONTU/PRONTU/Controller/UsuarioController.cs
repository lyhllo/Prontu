using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using MySql.Data.MySqlClient;

namespace PRONTU.Controller
{
    public class UsuarioController
    {
        public static bool Login (string u, string s)
        {
            Connection c = new Connection();

            string sql = "SELECT * FROM usuario WHERE cpf='" + u + "' AND senha='" + s + "';";

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

        public static bool CadastraUsuario(
            string Usuario,
            string Cpf,
            string Email,
            string Senha,
            string Nome,
            string RegProf,
            string Profissao,
            string Especialidade,
            string Telefone,
            string Rua,
            string Numero,
            string Complemento,
            string Bairro,
            string Cidade,
            string Estado)
        {
            try
            {
                Connection c = new Connection();

                string sql1 = "INSERT INTO endereco (" +
                    "telefone," +
                    "rua," +
                    "numero," +
                    "complemento," +
                    "bairro," +
                    "cidade," +
                    "estado)" +
                    " VALUES ('" + Telefone + "'," +
                    "'" + Rua + "'," +
                    "'" + Numero + "'," +
                    "'" + Complemento + "'," +
                    "'" + Bairro + "'," +
                    "'" + Cidade + "'," +
                    "'" + Estado + "');";

                Console.WriteLine(sql1);

                c.NonQuery(sql1);

                string sql2 = "SELECT MAX(id_endereco) FROM endereco;";
                MySqlDataReader rdr = c.QueryData(sql2);

                string Endereco = "";

                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        Endereco = rdr[0].ToString();
                    }
                }

                Console.WriteLine(sql2);

                c.Close();
                Connection c2 = new Connection();

                string sql3 = "INSERT INTO usuario_sistema (" +
                    "usuario," +
                    "cpf," +
                    "email," +
                    "senha," +
                    "nome," +
                    "registro_prof," +
                    "profissao," +
                    "especialidade," +
                    "endereco)" +
                    " VALUES ('" + Usuario + "','" + Cpf + "','" + Email + "','" + Senha + "','" + Nome + "','" + RegProf + "','" + Profissao + "','" + Especialidade + "'," + Endereco + ");";

                Console.WriteLine(sql3);

                c2.NonQuery(sql3);

                c2.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
