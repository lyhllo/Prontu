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
            try
            {
                c = new Connection();

                sql = "INSERT INTO paciente" +
                    "       VALUES ( " +
                                    Home.ajustesUsuario.id_usuario  + ",  " +
                                    _cadastro.Id_Paciente           + ",  " +
                    "   '" +        _cadastro.Nome                  + "', " +
                    "   '" +        _cadastro.Cpf                   + "', " ;

                if (_cadastro.Dt_nasc != null)
                    sql += "'" + _cadastro.Dt_nasc.Value.ToString("yyyy-MM-dd") + "',";
                else
                    sql += "null, ";

                sql +=
                    "   '" +        _cadastro.Responsavel_CPF       + "', " +
                    "   '" +        _cadastro.Responsavel_Nome      + "', " +
                    "   '" +        _cadastro.Convenio              + "', " +
                    "   '" +        _cadastro.Convenio_Codigo       + "', " +
                    "   '" +        _cadastro.Observacoes           + "', " +
                    "   '" +        _cadastro.Logradouro            + "', " +
                    "   '" +        _cadastro.Numero                + "', " +
                    "   '" +        _cadastro.Bairro                + "', " +
                    "   '" +        _cadastro.Complemento           + "', " +
                    "   '" +        _cadastro.Cidade                + "', " +
                    "   '" +        _cadastro.UF                    + "', " +
                    "   '" +        _cadastro.Telefone              + "', " +
                    "   '" +        _cadastro.Email                 + "', " +
                    "   '" +        _cadastro.CEP                   + "') " ;

                c.NonQuery(sql);

                c.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditaPaciente(CadastroModel _cadastro)
        {
            try
            {
                c = new Connection();

                sql = "UPDATE paciente" +
                    "     SET paciente.nome             = '" + _cadastro.Nome                   + "', " +
                    "         paciente.cpf              = '" + _cadastro.Cpf                    + "', ";

                if (_cadastro.Dt_nasc != null)
                    sql += "paciente.dt_nasc = '" + _cadastro.Dt_nasc.Value.ToString("yyyy-MM-dd") + "', ";
                else
                    sql += "paciente.dt_nasc = null, ";

                sql +=
                    "         paciente.responsavel_cpf  = '" + _cadastro.Responsavel_CPF        + "', " +
                    "         paciente.responsavel_nome = '" + _cadastro.Responsavel_Nome       + "', " +
                    "         paciente.convenio         = '" + _cadastro.Convenio               + "', " +
                    "         paciente.convenio_codigo  = '" + _cadastro.Convenio_Codigo        + "', " +
                    "         paciente.observacoes      = '" + _cadastro.Observacoes            + "', " +
                    "         paciente.logradouro       = '" + _cadastro.Logradouro             + "', " +
                    "         paciente.numero           = '" + _cadastro.Numero                 + "', " +
                    "         paciente.bairro           = '" + _cadastro.Bairro                 + "', " +
                    "         paciente.complemento      = '" + _cadastro.Complemento            + "', " +
                    "         paciente.cidade           = '" + _cadastro.Cidade                 + "', " +
                    "         paciente.uf               = '" + _cadastro.UF                     + "', " +
                    "         paciente.telefone         = '" + _cadastro.Telefone               + "', " +
                    "         paciente.email            = '" + _cadastro.Email                  + "', " +
                    "         paciente.cep              = '" + _cadastro.CEP                    + "'  " +
                    "   WHERE paciente.id_usuario       = "  + Home.ajustesUsuario.id_usuario   + "   " +
                    "     AND paciente.id_paciente      = "  + _cadastro.Id_Paciente ;

                c.NonQuery(sql);

                c.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ExcluiPaciente(int _idPaciente)
        {
            try
            {
                AgendaController _ac = new AgendaController();
                List<int> _atendimentos = _ac.SelecionaIdAtendimentos(_idPaciente);

                c = new Connection();
                c.BeginTransaction();

                if (_atendimentos.Count > 0)
                {
                    sql = "DELETE FROM prontuario" +
                    "       WHERE prontuario.id_usuario = " + Home.ajustesUsuario.id_usuario +
                    "         AND prontuario.id_atendimento IN ( ";

                    for (int i = 0; i < _atendimentos.Count; i++)
                    {
                        if (i < _atendimentos.Count - 1)
                            sql += _atendimentos[i] + ", ";
                        else
                            sql += _atendimentos[i] + ")";
                    }

                    c.NonQuery(sql);
                }

                sql = "DELETE FROM atendimento" +
                    "   WHERE atendimento.id_usuario = " + Home.ajustesUsuario.id_usuario +
                    "     AND atendimento.id_paciente = " + _idPaciente;

                c.NonQuery(sql);

                sql = "DELETE FROM paciente" +
                    "   WHERE paciente.id_usuario = " + Home.ajustesUsuario.id_usuario +
                    "     AND paciente.id_paciente = " + _idPaciente;

                c.NonQuery(sql);

                c.transaction.Commit();
                c.Close();
                return true;
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

                sql = "SELECT max(paciente.id_paciente) as id" +
                    "    FROM paciente " +
                    "   WHERE paciente.id_usuario = " + Home.ajustesUsuario.id_usuario;

                rdr = c.QueryData(sql);

                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        _id = Convert.ToInt32(rdr["id"]);
                    }
                }

                c.Close();

                return _id + 1;
            }
            catch (Exception ex)
            {

                return _id;
            }
        }


        public List<CadastroModel> BuscaCadastrosPacientes()
        {
            try
            {
                c = new Connection();

                var _cadastro = new List<CadastroModel>();

                sql = "SELECT paciente.id_paciente      ," +
                      "       paciente.nome             ," +
                      "       paciente.cpf              ," +
                      "		  paciente.dt_nasc          ," +
                      "		  paciente.responsavel_cpf  ," +
                      "		  paciente.responsavel_nome ," +
                      "		  paciente.convenio         ," +
                      "		  paciente.convenio_codigo  ," +
                      "		  paciente.observacoes      ," +
                      "		  paciente.logradouro       ," +
                      "		  paciente.numero           ," +
                      "		  paciente.bairro           ," +
                      "		  paciente.complemento      ," +
                      "		  paciente.cidade           ," +
                      "		  paciente.uf               ," +
                      "		  paciente.telefone         ," +
                      "		  paciente.email            ," +
                      "		  paciente.cep               " +
                      "  FROM paciente                   " +
                      " WHERE paciente.id_usuario =      " + Home.ajustesUsuario.id_usuario +
                      " ORDER BY paciente.nome           " ;

                MySqlDataReader rdr = c.QueryData(sql);

                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        CadastroModel cadastroModel = new CadastroModel();
                        cadastroModel.Id_Paciente = Convert.ToInt32(rdr["id_paciente"]);

                        cadastroModel.Nome = Convert.ToString(rdr["nome"]);

                        if (rdr["cpf"] != DBNull.Value)
                        {
                            cadastroModel.Cpf = Convert.ToString(rdr["cpf"]);
                        }
                        else
                        {
                            cadastroModel.Cpf = "";
                        }

                        if (rdr["dt_nasc"] != DBNull.Value)
                        {
                            cadastroModel.Dt_nasc = Convert.ToDateTime(rdr["dt_nasc"]);
                        }
                        else
                        {
                            cadastroModel.Dt_nasc = null;
                        }

                        if (rdr["responsavel_cpf"] != DBNull.Value)
                        {
                            cadastroModel.Responsavel_CPF = Convert.ToString(rdr["responsavel_cpf"]);
                        }
                        else
                        {
                            cadastroModel.Responsavel_CPF = "";
                        }

                        if (rdr["responsavel_nome"] != DBNull.Value)
                        {
                            cadastroModel.Responsavel_Nome = Convert.ToString(rdr["responsavel_nome"]);
                        }
                        else
                        {
                            cadastroModel.Responsavel_Nome = "";
                        }

                        if (rdr["convenio"] != DBNull.Value)
                        {
                            cadastroModel.Convenio = Convert.ToString(rdr["convenio"]);
                        }
                        else
                        {
                            cadastroModel.Convenio = "";
                        }

                        if (rdr["convenio_codigo"] != DBNull.Value)
                        {
                            cadastroModel.Convenio_Codigo = Convert.ToString(rdr["convenio_codigo"]);
                        }
                        else
                        {
                            cadastroModel.Convenio_Codigo = "";
                        }

                        if (rdr["observacoes"] != DBNull.Value)
                        {
                            cadastroModel.Observacoes = Convert.ToString(rdr["observacoes"]);
                        }
                        else
                        {
                            cadastroModel.Observacoes = "";
                        }

                        if (rdr["logradouro"] != DBNull.Value)
                        {
                            cadastroModel.Logradouro = Convert.ToString(rdr["logradouro"]);
                        }
                        else
                        {
                            cadastroModel.Logradouro = "";
                        }

                        if (rdr["numero"] != DBNull.Value)
                        {
                            cadastroModel.Numero = Convert.ToString(rdr["numero"]);
                        }
                        else
                        {
                            cadastroModel.Numero = "";
                        }

                        if (rdr["bairro"] != DBNull.Value)
                        {
                            cadastroModel.Bairro = Convert.ToString(rdr["bairro"]);
                        }
                        else
                        {
                            cadastroModel.Bairro = "";
                        }

                        if (rdr["complemento"] != DBNull.Value)
                        {
                            cadastroModel.Complemento = Convert.ToString(rdr["complemento"]);
                        }
                        else
                        {
                            cadastroModel.Complemento = "";
                        }

                        if (rdr["cidade"] != DBNull.Value)
                        {
                            cadastroModel.Cidade = Convert.ToString(rdr["cidade"]);
                        }
                        else
                        {
                            cadastroModel.Cidade = "";
                        }

                        if (rdr["uf"] != DBNull.Value)
                        {
                            cadastroModel.UF = Convert.ToString(rdr["uf"]);
                        }
                        else
                        {
                            cadastroModel.UF = "";
                        }

                        if (rdr["telefone"] != DBNull.Value)
                        {
                            cadastroModel.Telefone = Convert.ToString(rdr["telefone"]);
                        }
                        else
                        {
                            cadastroModel.Telefone = "";
                        }

                        if (rdr["email"] != DBNull.Value)
                        {
                            cadastroModel.Email = Convert.ToString(rdr["email"]);
                        }
                        else
                        {
                            cadastroModel.Email = "";
                        }

                        if (rdr["cep"] != DBNull.Value)
                        {
                            cadastroModel.CEP = Convert.ToString(rdr["cep"]);
                        }
                        else
                        {
                            cadastroModel.CEP = "";
                        }

                        _cadastro.Add(cadastroModel);
                    }
                }

                c.Close();
                return _cadastro;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }

        public CadastroModel BuscaCadastroPorId(int _idPaciente)
        {
            try
            {
                c = new Connection();

                CadastroModel _cadastro = new CadastroModel();

                sql = "SELECT paciente.id_paciente      ," +
                      "       paciente.nome             ," +
                      "       paciente.cpf              ," +
                      "		  paciente.dt_nasc          ," +
                      "		  paciente.responsavel_cpf  ," +
                      "		  paciente.responsavel_nome ," +
                      "		  paciente.convenio         ," +
                      "		  paciente.convenio_codigo  ," +
                      "		  paciente.observacoes      ," +
                      "		  paciente.logradouro       ," +
                      "		  paciente.numero           ," +
                      "		  paciente.bairro           ," +
                      "		  paciente.complemento      ," +
                      "		  paciente.cidade           ," +
                      "		  paciente.uf               ," +
                      "		  paciente.telefone         ," +
                      "		  paciente.email            ," +
                      "		  paciente.cep               " +
                      "  FROM paciente                   " +
                      " WHERE paciente.id_usuario  =     " + Home.ajustesUsuario.id_usuario +
                      "   AND paciente.id_paciente =     " + _idPaciente;

                MySqlDataReader rdr = c.QueryData(sql);

                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        _cadastro.Id_Paciente = Convert.ToInt32(rdr["id_paciente"]);

                        _cadastro.Nome = Convert.ToString(rdr["nome"]);

                        if (rdr["cpf"] != DBNull.Value)
                        {
                            _cadastro.Cpf = Convert.ToString(rdr["cpf"]);
                        }
                        else
                        {
                            _cadastro.Cpf = "";
                        }

                        if (rdr["dt_nasc"] != DBNull.Value)
                        {
                            _cadastro.Dt_nasc = Convert.ToDateTime(rdr["dt_nasc"]);
                        }
                        else
                        {
                            _cadastro.Dt_nasc = null;
                        }

                        if (rdr["responsavel_cpf"] != DBNull.Value)
                        {
                            _cadastro.Responsavel_CPF = Convert.ToString(rdr["responsavel_cpf"]);
                        }
                        else
                        {
                            _cadastro.Responsavel_CPF = "";
                        }

                        if (rdr["responsavel_nome"] != DBNull.Value)
                        {
                            _cadastro.Responsavel_Nome = Convert.ToString(rdr["responsavel_nome"]);
                        }
                        else
                        {
                            _cadastro.Responsavel_Nome = "";
                        }

                        if (rdr["convenio"] != DBNull.Value)
                        {
                            _cadastro.Convenio = Convert.ToString(rdr["convenio"]);
                        }
                        else
                        {
                            _cadastro.Convenio = "";
                        }

                        if (rdr["convenio_codigo"] != DBNull.Value)
                        {
                            _cadastro.Convenio_Codigo = Convert.ToString(rdr["convenio_codigo"]);
                        }
                        else
                        {
                            _cadastro.Convenio_Codigo = "";
                        }

                        if (rdr["observacoes"] != DBNull.Value)
                        {
                            _cadastro.Observacoes = Convert.ToString(rdr["observacoes"]);
                        }
                        else
                        {
                            _cadastro.Observacoes = "";
                        }

                        if (rdr["logradouro"] != DBNull.Value)
                        {
                            _cadastro.Logradouro = Convert.ToString(rdr["logradouro"]);
                        }
                        else
                        {
                            _cadastro.Logradouro = "";
                        }

                        if (rdr["numero"] != DBNull.Value)
                        {
                            _cadastro.Numero = Convert.ToString(rdr["numero"]);
                        }
                        else
                        {
                            _cadastro.Numero = "";
                        }

                        if (rdr["bairro"] != DBNull.Value)
                        {
                            _cadastro.Bairro = Convert.ToString(rdr["bairro"]);
                        }
                        else
                        {
                            _cadastro.Bairro = "";
                        }

                        if (rdr["complemento"] != DBNull.Value)
                        {
                            _cadastro.Complemento = Convert.ToString(rdr["complemento"]);
                        }
                        else
                        {
                            _cadastro.Complemento = "";
                        }

                        if (rdr["cidade"] != DBNull.Value)
                        {
                            _cadastro.Cidade = Convert.ToString(rdr["cidade"]);
                        }
                        else
                        {
                            _cadastro.Cidade = "";
                        }

                        if (rdr["uf"] != DBNull.Value)
                        {
                            _cadastro.UF = Convert.ToString(rdr["uf"]);
                        }
                        else
                        {
                            _cadastro.UF = "";
                        }

                        if (rdr["telefone"] != DBNull.Value)
                        {
                            _cadastro.Telefone = Convert.ToString(rdr["telefone"]);
                        }
                        else
                        {
                            _cadastro.Telefone = "";
                        }

                        if (rdr["email"] != DBNull.Value)
                        {
                            _cadastro.Email = Convert.ToString(rdr["email"]);
                        }
                        else
                        {
                            _cadastro.Email = "";
                        }

                        if (rdr["cep"] != DBNull.Value)
                        {
                            _cadastro.CEP = Convert.ToString(rdr["cep"]);
                        }
                        else
                        {
                            _cadastro.CEP = "";
                        }

                    }
                }

                c.Close();
                return _cadastro;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }
    }
}