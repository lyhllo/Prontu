using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRONTU.Controller
{
    internal class PacienteCadastroController
    {
        public static bool CadastraPaciente(
           String COntato,
            String DataCadastro,
            string Nome,
            string Cpf,
            string Responsavel,
            string Convenio,
            string DataNasc,
            string CpfResp,
            string ConvenioCodigo,
            string Telefone,
            string Logradouro,
            string Rua,
            string Complemento,
            string Cidade,
            string Numero,
            string Email,
            string Bairro,
            string Uf,
            long ObsGerais)
        {
            try
            {
                Connection c = new Connection();

                string sql1 = "INSERT INTO contato (" +
                    "logradouro," +
                    "numero," +
                    "bairro," +
                    "complemento," +
                    "cidade," +
                    "uf," +
                    "telefone," +
                    "email)" +
                    " VALUES ('" + Logradouro + "'," +
                    "'" + Rua + "'," +
                    "'" + Numero + "'," +
                    "'" + Bairro + "'," +
                    "'" + Complemento + "'," +
                    "'" + Cidade + "'," +
                    "'" + Uf + "'," +
                    "'" + Telefone +"',"+
                    "'" +  Email + "');";

                Console.WriteLine(sql1);

                c.NonQuery(sql1);

                string sql2 = "SELECT MAX(id_contato) FROM contato;";
                MySqlDataReader rdr = c.QueryData(sql2);

                string Contato = "";

                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        Contato = rdr[0].ToString();
                    }
                }

                Console.WriteLine(sql2);

                c.Close();
                Connection c2 = new Connection();

                string sql3 = "INSERT INTO paciente (" +
                    "nome," +
                    "cpf," +
                    "data_nasc," +
                    "responsavel_cpf," +
                    "responsavel_nome," +
                    "data_cadastro," +
                    "convenio," +
                    "convenio_codigo," +
                    "observacoes," +
                    "contato)" +
                    " VALUES ('" + Nome + "','" + Cpf + "','" + DataNasc + "','" + CpfResp + "','" + Responsavel + "','" + DataCadastro + "','" + Convenio + "','" + ConvenioCodigo + "'," + ConvenioCodigo + "'," + ObsGerais + "'," + Contato+"); ";

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
