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

        private static string Cpf_sessao;
        private static int Id_usuario;
        private static int Id_contato;

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
                string sql = "INSERT INTO usuario (nome_usuario,cpf, registro_prof, profissao, especialidade, senha) VALUES" +
                    "('" + usuario.Nome + "'," +
                    "'" + usuario.Cpf + "'," +
                    "'" + usuario.Registro_profissional + "'," +
                    "'" + usuario.Profissao + "'," +
                    "'" + usuario.Especialidade + "'," +
                    "'"+usuario.Senha+"');";
                c.NonQuery(sql);
                c.Close();

                c = new Connection();
                string sql2 = "SELECT MAX(id_usuario) FROM usuario;";
                MySqlDataReader rdr = c.QueryData(sql2);
                

                string Id_novo_usuario = "";

                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        Id_novo_usuario = rdr[0].ToString();
                    }
                }
                c.Close();

                c = new Connection();
                string sql3 = "INSERT INTO contato (id_usuario,id_contato,logradouro,numero,bairro,complemento,cidade,uf,telefone,email) VALUES " +
                    "("+ Id_novo_usuario +"," +
                    "" + Id_novo_usuario + "," +
                    "'"+usuario.Contato.Logradouro+"'," +
                    "'"+usuario.Contato.Numero+"'," +
                    "'"+usuario.Contato.Bairro+"'," +
                    "'"+usuario.Contato.Complemento+"'," +
                    "'"+usuario.Contato.Cidade+"'," +
                    "'"+usuario.Contato.Uf+"'," +
                    "'"+usuario.Contato.Telefone+"'," +
                    "'"+usuario.Contato.Email+"');";
                Console.WriteLine(sql3);
                c.NonQuery(sql3);
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
                "contato.id_contato, " +
                "contato.logradouro, " +
                "contato.numero, " +
                "contato.bairro, " +
                "contato.complemento, " +
                "contato.cidade, " +
                "contato.uf, " +
                "contato.telefone, " +
                "contato.email " +
                "FROM contato " +
                "LEFT JOIN usuario " +
                "ON (usuario.id_usuario = contato.id_contato) " +
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
                    Console.WriteLine(Convert.ToInt32(rdr[6]).ToString());
                    usuario.Contato.Id_contato = Convert.ToInt32(rdr[6]);
                    usuario.Contato.Logradouro = rdr[7].ToString();
                    usuario.Contato.Numero = rdr[8].ToString();
                    usuario.Contato.Bairro = rdr[9].ToString();
                    usuario.Contato.Complemento = rdr[10].ToString();
                    usuario.Contato.Cidade = rdr[11].ToString();
                    usuario.Contato.Uf = rdr[12].ToString();
                    usuario.Contato.Telefone = rdr[13].ToString();
                    usuario.Contato.Email = rdr[14].ToString(); 
                }
                rdr.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            c.Close();
            Id_usuario = usuario.Id_usuario;
            Id_contato = usuario.Contato.Id_contato;
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
                "especialidade = '" + usuario.Especialidade + "'" +
                " WHERE id_usuario = " + Id_usuario + ";" +
                "UPDATE contato " +
                "SET logradouro = '" + usuario.Contato.Logradouro +"'," +
                "numero = '" + usuario.Contato.Numero +"'," +
                "bairro = '" + usuario.Contato.Bairro +"'," +
                "complemento = '" + usuario.Contato.Complemento +"'," +
                "cidade = '" + usuario.Contato.Cidade+"'," +
                "uf = '" + usuario.Contato.Uf +"'," +
                "telefone = '" + usuario.Contato.Telefone + "'," +
                "email = '" + usuario.Contato.Email + "'" +
                " WHERE id_contato = "+Id_contato;
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
