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
        public bool CadastraPaciente(int _id_contato, CadastroModel _cadastro)
        {
            int _novo_id_Paciente = NovoIdPaciente();
            try
            {
                c = new Connection();

                sql = "INSERT INTO paciente" +
                    "       VALUES ( 1," +
                                   _novo_id_Paciente + ", " +
                                   _id_contato + ", " +
                                   _cadastro.Nome + ", " +
                                   _cadastro.Cpf + ", " +
                                   _cadastro.Dt_nasc + ", " +
                                   _cadastro.Responsavel_CPF + ", " +
                                   _cadastro.Responsavel_Nome + ", " +
                                   _cadastro.Data_Cadastro + ", " +
                                   _cadastro.Convenio + ", " +
                                   _cadastro.Convenio_Codigo + ", " +
                                   _cadastro.Observacoes + ") ";

                c.NonQuery(sql);

                c.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CadastraContato(CadastroModel _cadastro)
        {
            int _novo_id_Contato = NovoIdContato();
            try
            {
                c = new Connection();

                sql = "INSERT INTO contato" +
                    "       VALUES( 1," +
                                    _novo_id_Contato + ", " +
                                    _cadastro.Logradouro + ", " +
                                    _cadastro.Numero + ", " +
                                    _cadastro.Bairro + ", " +
                                    _cadastro.Complemento + ", " +
                                    _cadastro.Cidade + ", " +
                                    _cadastro.UF + ", " +
                                    _cadastro.Telefone + ", " +
                                    _cadastro.Email + ") ";

                c.NonQuery(sql);

                c.Close();

                if (CadastraPaciente(_novo_id_Contato, _cadastro))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }

        public int NovoIdPaciente()
        {
            int _id = 0;
            try
            {
                c = new Connection();

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

        private int NovoIdContato()
        {
            int _id = 0;
            try
            {
                c = new Connection();

                sql = "SELECT max(contato.id_contato) + 1" +
                    "    FROM contato " +
                    "   WHERE contato.id_usuario = 1";

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
       
        public static bool AtualizaPaciente(CadastroModel _cadastro)
        {
            int Id_Paciente = _cadastro.Id_Paciente;
       
            Connection c = new Connection();
            string sql = "UPDATE paciente " +
                "SET nome = '" + _cadastro.Nome + "'," +
                "cpf = '" + _cadastro.Cpf + "'," +
                "dt_nasc = '" + _cadastro.Dt_nasc+ "'," +
                "responsavel_cpf = '" + _cadastro.Responsavel_CPF + "'," +
                "responsavel_nome = '" + _cadastro.Responsavel_Nome + "'," +
                "responsavel_cpf = '" + _cadastro.Responsavel_CPF + "'," +
                "data_cadastro = '" + _cadastro.Data_Cadastro + "'," +
                "convenio = '" + _cadastro.Convenio + "'," +
                "convenio_codigo = '" + _cadastro.Convenio_Codigo + "'," +
                 " WHERE id_paciente = " + Id_Paciente+ ";" +
                 "UPDATE contato " +
                 "SET logradouro = '" + _cadastro.Logradouro + "'," +
                "numero = '" + _cadastro.Numero + "'," +
                "bairro = '" + _cadastro.Bairro + "'," +
                "complemento = '" + _cadastro.Complemento + "'," +
                "cidade = '" + _cadastro.Cidade + "'," +
                "uf = '" + _cadastro.UF + "'," +
                "telefone = '" + _cadastro.Telefone + "'," +
                "email = '" + _cadastro.Email + "'" +
                " WHERE id_contato = " + _cadastro.Id_contato;
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

        public static bool ExcluirPaciente(int id)
        {
            try
            {
                Connection c = new Connection();

                string sql = "DELETE from prontu.paciente WHERE id_usuario = '" + id +  "';";
                string sql2 = "DELETE from prontu.contato WHERE id_usuario = '" + id + "';";
                object result = c.Query(sql);
                object result2 = c.Query(sql2);
                c.NonQuery(sql);
                c.NonQuery(sql2);

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