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

        private int NovoIdPaciente()
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
    }
}
