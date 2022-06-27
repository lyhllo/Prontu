using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using MySql.Data.MySqlClient;
using PRONTU.Model;

namespace PRONTU.Controller
{
    public class UsuarioController
    {
        public static bool Sessao_ativa;
        private static string Cpf_sessao;
        private static int Id_usuario;

        public static bool ExisteUsuario ()
        {

            Connection c = new Connection();
            string sql = "SELECT * from usuario";
            try
            {
                object result = c.Query(sql);
                if(result != null)
                {
                    return true;
                } else
                {
                    return false;
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool Login (string cpf, string senha)
        {
            Connection c = new Connection();

            string sql = "SELECT * FROM usuario WHERE cpf='" + cpf + "' AND senha='" + senha + "';";

            object result = c.Query(sql);

            if (result != null)
            {
                Cpf_sessao = cpf;
                Sessao_ativa = true;
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

                string sql = "UPDATE usuario SET codigo_recuperacao = '" + codigo + "' WHERE email='" + email + "';";

                //object result = c.Query(sql);

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

        public static bool CadastraNovoUsuario(UsuarioModel usuario)
        {
            try
            {
                Connection c = new Connection();
                string sql1 = "SELECT MAX(id_usuario) FROM usuario;";
                MySqlDataReader rdr = c.QueryData(sql1);

                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        usuario.Id_usuario = Convert.ToInt32(rdr[0]) + 1;
                    }
                }
                c.Close();

                c = new Connection();

                string sql2 = "INSERT INTO usuario (id_usuario, nome_usuario,cpf, registro_prof, profissao, especialidade, senha, logradouro,numero,bairro,complemento,cidade,uf,telefone,email) VALUES" +
                    "(" + usuario.Id_usuario + "," +
                    "'" + usuario.Nome + "'," +
                    "'" + usuario.Cpf + "'," +
                    "'" + usuario.Registro_profissional + "'," +
                    "'" + usuario.Profissao + "'," +
                    "'" + usuario.Especialidade + "'," +
                    "'" + usuario.Senha+"'," +
                    "'" + usuario.Logradouro + "'," +
                    "'" + usuario.Numero + "'," +
                    "'" + usuario.Bairro + "'," +
                    "'" + usuario.Complemento + "'," +
                    "'" + usuario.Cidade + "'," +
                    "'" + usuario.Uf + "'," +
                    "'" + usuario.Telefone + "'," +
                    "'" + usuario.Email + "');";

                c.NonQuery(sql2);
                c.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;    
        }

        public static UsuarioModel BuscaDadosUsuario()
        {
            UsuarioModel usuario = new UsuarioModel();
            Connection c = new Connection();

            string sql = "SELECT " +
                "usuario.id_usuario," +
                "usuario.nome_usuario," +
                "usuario.cpf, " +
                "usuario.registro_prof, " +
                "usuario.profissao, " +
                "usuario.especialidade, " +
                "usuario.logradouro, " +
                "usuario.numero, " +
                "usuario.bairro, " +
                "usuario.complemento, " +
                "usuario.cidade, " +
                "usuario.uf, " +
                "usuario.telefone, " +
                "usuario.email " +
                "FROM usuario " +
                "WHERE usuario.cpf = "+ Cpf_sessao +";";

            Console.WriteLine(sql);

            try
            {
                MySqlDataReader rdr = c.QueryData(sql);
                while (rdr.Read())
                {
                    usuario.Id_usuario = Convert.ToInt32(rdr[0]);
                    usuario.Nome = rdr[1].ToString();
                    usuario.Cpf = rdr[2].ToString();
                    usuario.Registro_profissional = rdr[3].ToString();
                    usuario.Profissao = rdr[4].ToString();
                    usuario.Especialidade = rdr[5].ToString();
                    usuario.Logradouro = rdr[6].ToString();
                    usuario.Numero = rdr[7].ToString();
                    usuario.Bairro = rdr[8].ToString();
                    usuario.Complemento = rdr[9].ToString();
                    usuario.Cidade = rdr[10].ToString();
                    usuario.Uf = rdr[11].ToString();
                    usuario.Telefone = rdr[12].ToString();
                    usuario.Email = rdr[13].ToString();
                }
                rdr.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            c.Close();
            Id_usuario = usuario.Id_usuario;
            return usuario;
        }

        public static bool AtualizaUsuario(UsuarioModel usuario)
        {
            Connection c = new Connection();
            string sql = "UPDATE usuario " +
                "SET nome_usuario = '" + usuario.Nome + "'," +
                "cpf = '" + usuario.Cpf + "'," +
                "registro_prof = '" + usuario.Registro_profissional + "'," +
                "profissao = '" + usuario.Profissao + "'," +
                "especialidade = '" + usuario.Especialidade + "'," +
                "logradouro = '" + usuario.Logradouro +"'," +
                "numero = '" + usuario.Numero +"'," +
                "bairro = '" + usuario.Bairro +"'," +
                "complemento = '" + usuario.Complemento +"'," +
                "cidade = '" + usuario.Cidade+"'," +
                "uf = '" + usuario.Uf +"'," +
                "telefone = '" + usuario.Telefone + "'," +
                "email = '" + usuario.Email + "'" +
                " WHERE id_usuario = "+Id_usuario;
            try
            {
                c.NonQuery(sql);
                return true;
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool AlteraSenha(string senha)
        {
            try
            {
                Connection c = new Connection();
                string sql = "UPDATE usuario SET senha = '"+senha+"' WHERE id_usuario = "+Id_usuario+";";
                c.NonQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
    }
}
