using MySql.Data.MySqlClient;
using PRONTU.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRONTU.Controller
{
    internal class RelatorioAtendimentoController
    {
        private Connection c;
        private string sql;

        public List<String> RetornarPacientesAtendimento(int _idUsuario)
        {
            try
            {
                c = new Connection();

                var _paciente = new List<String>();

                sql = "SELECT distinct paciente.nome" +
                      "  FROM paciente" +
                      "  LEFT JOIN atendimento" +
                      "    ON (atendimento.id_paciente = paciente.id_paciente AND" +
                      "        atendimento.id_usuario = paciente.id_usuario)" +
                      " WHERE atendimento.id_usuario = " + _idUsuario +
                      " ORDER BY paciente.nome";

                MySqlDataReader rdr = c.QueryData(sql);

                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        RelatorioAtendimentoModel relatorioModel = new RelatorioAtendimentoModel();

                        relatorioModel.Nome = Convert.ToString(rdr["nome"]);

                        _paciente.Add(relatorioModel.Nome);

                    }
                }

                c.Close();
                return _paciente;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public List<RelatorioAtendimentoModel> RetornarAtendimentos(int _idUsuario, DateTime _dataInicial, DateTime _dataFinal, string _nomePaciente)
        {
            try
            {
                c = new Connection();

                var _atendimentos = new List<RelatorioAtendimentoModel>();

                sql = "SELECT paciente.nome," +
                      "       atendimento.horario," +
                      "       atendimento.convenio," +
                      "       atendimento.valor_pago," +
                      "       prontuario.avaliacao," +
                      "       prontuario.condutas" +
                      "  FROM atendimento" +
                      "  LEFT JOIN paciente " +
                      "    ON (paciente.id_paciente = atendimento.id_paciente AND" +
                      "        paciente.id_usuario = atendimento.id_usuario)" +
                      "  LEFT JOIN prontuario " +
                      "    ON (prontuario.id_atendimento = atendimento.id_atendimento AND" +
                      "        prontuario.id_usuario = atendimento.id_usuario)" +
                      "  WHERE atendimento.id_usuario = " + _idUsuario +
                      "    AND DATE(atendimento.horario) BETWEEN DATE('" + _dataInicial.ToString("u") + "') AND DATE('" + _dataFinal.ToString("u") + "')";
                     
                if(!_nomePaciente.Equals("Todos os pacientes"))
                {
                    sql += " AND paciente.nome = '" + _nomePaciente + "'";
                }

                sql += " ORDER BY paciente.nome";

                MySqlDataReader rdr = c.QueryData(sql);

                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        RelatorioAtendimentoModel relatorioAtendimento = new RelatorioAtendimentoModel();

                        relatorioAtendimento.Nome = Convert.ToString(rdr["nome"]);
                        relatorioAtendimento.Horario = Convert.ToDateTime(rdr["horario"]);

                        if (rdr["valor_pago"] != DBNull.Value)
                        {
                            relatorioAtendimento.Valor_pago = Convert.ToDouble(rdr["valor_pago"]);
                        }
                        else
                        {
                            relatorioAtendimento.Valor_pago = 0;
                        }

                        if (rdr["convenio"] != DBNull.Value)
                        {
                            relatorioAtendimento.Convenio = Convert.ToString(rdr["convenio"]);
                        }
                        else
                        {
                            relatorioAtendimento.Convenio = "";
                        }

                        if (rdr["avaliacao"] != DBNull.Value)
                        {
                            relatorioAtendimento.Avaliacao = Convert.ToString(rdr["avaliacao"]);
                        }
                        else
                        {
                            relatorioAtendimento.Avaliacao = "";
                        }

                        if (rdr["condutas"] != DBNull.Value)
                        {
                            relatorioAtendimento.Condutas = Convert.ToString(rdr["condutas"]);
                        }
                        else
                        {
                            relatorioAtendimento.Condutas = "";
                        }

                        _atendimentos.Add(relatorioAtendimento);
                    }
                }

                c.Close();

                return _atendimentos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }
    }
}
