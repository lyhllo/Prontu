using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PRONTU.Model;

namespace PRONTU.Controller
{
    internal class PacienteCadastroController
    {
        private Connection c;
        private string sql;
        private MySqlDataReader rdr;
        public bool CadastraPaciente(CadastroModel _cadastro)
        {
            int _novo_id_Contato = NovoIdContato();
            int _novo_id_Paciente = NovoIdPaciente();
            try
            {
                c = new Connection();

                sql = "INSERT INTO contato (" +
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

        private int NovoIdPaciente()
        {
            try
            {
                c = new Connection();
                int _id = 0;

                sql = "SELECT max(paciente.id_paciente) + 1" +
                    "    FROM paciente " +
                    "   WHERE paciente.id_usuario = 1";

                rdr = c.QueryData(sql);

                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        _id = Convert.ToInt32(rdr["id_paciente"]);
                    }
                }

                c.Close();

                return _id;
            }
            catch (Exception ex)
            {
                
                return _id;
            }
        }
    }
}
