﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRONTU.Model;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PRONTU.Controller.AgendaController
{
    internal class AgendaController
    {
        private Connection c;
        private string sql;

        public List<AgendaModel> BuscaAgendamentosDoDia(int _id_usuario, DateTime _dia)
        {
            try
            {
                c = new Connection();

                var _agenda = new List<AgendaModel>();

                sql = "SELECT paciente.id_paciente," +
                      "       paciente.nome," +
                      "       paciente.cpf," +
                      "       paciente.dt_nasc," +
                      "       paciente.convenio as convenio_paciente," +
                      "       paciente.observacoes," +
                      "       atendimento.id_atendimento," +
                      "       atendimento.horario," +
                      "       atendimento.convenio as convenio_atendimento," +
                      "       atendimento.valor_pago," +
                      "       atendimento.pagto," +
                      "       atendimento.reg_presenca," +
                      "       prontuario.id_prontuario," +
                      "       prontuario.avaliacao," +
                      "       prontuario.condutas" +
                      "  FROM atendimento" +
                      "  LEFT JOIN paciente" +
                      "       ON(paciente.id_paciente = atendimento.id_paciente AND" +
                      "          paciente.id_usuario = atendimento.id_usuario)" +
                      "  LEFT JOIN prontuario" +
                      "       ON(prontuario.id_usuario = atendimento.id_usuario AND" +
                      "          prontuario.id_atendimento = atendimento.id_atendimento)" +
                      " WHERE atendimento.id_usuario = " + _id_usuario +
                      "   AND DATE(atendimento.horario) = DATE('" + _dia.ToString("u") + "')" +
                      " ORDER BY atendimento.horario ";

                MySqlDataReader rdr = c.QueryData(sql);

                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        AgendaModel agendaModel = new AgendaModel();
                        agendaModel.Id_pcte = Convert.ToInt32(rdr["id_paciente"]);
                        agendaModel.Nome = Convert.ToString(rdr["nome"]);

                        if (rdr["cpf"] != DBNull.Value)
                        {
                            agendaModel.Cpf = Convert.ToString(rdr["cpf"]);
                        }
                        else
                        {
                            agendaModel.Cpf = null;
                        }

                        if (rdr["dt_nasc"] != DBNull.Value)
                        {
                            agendaModel.Dt_nasc = Convert.ToDateTime(rdr["dt_nasc"]);
                        }
                        else
                        {
                            agendaModel.Dt_nasc = null;
                        }

                        if (rdr["convenio_paciente"] != DBNull.Value)
                        {
                            agendaModel.Convenio_pcte = Convert.ToString(rdr["convenio_paciente"]);
                        }
                        else
                        {
                            agendaModel.Convenio_pcte = null;
                        }

                        if (rdr["observacoes"] != DBNull.Value)
                        {
                            agendaModel.Observacoes = Convert.ToString(rdr["observacoes"]);
                        }
                        else
                        {
                            agendaModel.Observacoes = null;
                        }

                        agendaModel.Id_atendimento = Convert.ToInt32(rdr["id_atendimento"]);

                        agendaModel.Horario = Convert.ToDateTime(rdr["horario"]);

                        if (rdr["convenio_atendimento"] != DBNull.Value)
                        {
                            agendaModel.Convenio_atendimento = Convert.ToString(rdr["convenio_atendimento"]);
                        }
                        else
                        {
                            agendaModel.Convenio_atendimento = null;
                        }

                        if (rdr["valor_pago"] != DBNull.Value)
                        {
                            agendaModel.Valor_pago = Convert.ToDouble(rdr["valor_pago"]);
                        }
                        else
                        {
                            agendaModel.Valor_pago = 0;
                        }

                        if (rdr["pagto"] != DBNull.Value)
                        {
                            agendaModel.Pagto = Convert.ToBoolean(rdr["pagto"]);
                        }
                        else
                        {
                            agendaModel.Pagto = null;
                        }

                        if (rdr["reg_presenca"] != DBNull.Value)
                        {
                            agendaModel.Reg_presenca = Convert.ToBoolean(rdr["reg_presenca"]);
                        }
                        else
                        {
                            agendaModel.Reg_presenca = null;
                        }

                        if (rdr["id_prontuario"] != DBNull.Value)
                        {
                            agendaModel.Id_prontuario = Convert.ToInt32(rdr["id_prontuario"]);
                        }
                        else
                        {
                            agendaModel.Id_prontuario = null;
                        }

                        if (rdr["avaliacao"] != DBNull.Value)
                        {
                            agendaModel.Avaliacao = Convert.ToString(rdr["avaliacao"]);
                        }
                        else
                        {
                            agendaModel.Avaliacao = null;
                        }

                        if (rdr["condutas"] != null)
                        {
                            agendaModel.Condutas = Convert.ToString(rdr["condutas"]);
                        }
                        else
                        {
                            agendaModel.Condutas = null;
                        }

                        _agenda.Add(agendaModel);
                    }
                }

                c.Close();
                return _agenda;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            
        }

        public Boolean RemoverAgendamento(int _idAtendimento)
        {
            try
            {
                c = new Connection();

                sql = " DELETE FROM atendimento" +
                    "    WHERE atendimento.id_usuario = 1 " +
                    "      AND atendimento.id_atendimento = " + _idAtendimento;

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

        public Boolean RegistrarFalta(int _idAtendimento, bool _falta)
        {
            try
            {
                c = new Connection();

                sql = " UPDATE atendimento" +
                    "      SET atendimento.reg_presenca = " + _falta +
                    "    WHERE atendimento.id_usuario = 1 " +
                    "      AND atendimento.id_atendimento = " + _idAtendimento;

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

        public Boolean RegistrarPagto(int _idAtendimento, double _valor, bool _pago)
        {
            try
            {
                c = new Connection();

                sql = " UPDATE atendimento" +
                    "      SET atendimento.pagto = " + _pago + "," +
                    "          atendimento.valor_pago = " + _valor.ToString(System.Globalization.CultureInfo.InvariantCulture) +
                    "    WHERE atendimento.id_usuario = 1 " +
                    "      AND atendimento.id_atendimento = " + _idAtendimento;

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

        public bool RegistrarAtendimento(int _idUsuario, int _idAtendimento,int _idProntuario, string _convenio, string _valorPago, 
                                        bool _statusPagto, string _avaliacao, string _condutas)
        {
            if (!AtualizaAtendimento(_idUsuario, _idAtendimento, _convenio, _valorPago, _statusPagto))
            {
                MessageBox.Show("Ocorreu um erro ao atualizar os dados do atendimento", "Atendimento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(!AtualizaProntuario(_idUsuario, _idProntuario, _idAtendimento, _avaliacao, _condutas))
            {
                MessageBox.Show("Ocorreu um erro ao atualizar os dados do prontuário", "Atendimento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public bool AtualizaAtendimento(int _idUsuario, int _idAtendimento, string _convenio, string _valorPago, bool _statusPagto)
        {
            c = new Connection();

            try
            {
                sql = " UPDATE atendimento SET convenio = '" + _convenio + "'," +
                                             " valor_pago = " + _valorPago + "," +
                                             " pagto = " + _statusPagto + "," +
                                             " reg_presenca = 1 " +
                       " WHERE id_usuario = " + _idUsuario +
                         " AND id_atendimento = " + _idAtendimento;

                c.NonQuery(sql);
                c.Close();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool AtualizaProntuario(int _idUsuario, int _idProntuario, int _idAtendimento, string _avaliacao, string _condutas)
        {
            c = new Connection();
            
            try
            {
                if (_idProntuario > 0)
                {
                    sql = "UPDATE prontuario SET avaliacao = '" + _avaliacao + "'," +
                                               " condutas = '" + _condutas + "'" +
                          " WHERE id_usuario = " + _idUsuario +
                            " AND id_prontuario = " + _idProntuario;
                }
                else
                {
                    int _novoIdProntuario = RetornaNovoIdProntuario(_idUsuario);
                    if(_novoIdProntuario == 0)
                    {
                        return false;
                    }

                    sql = " INSERT INTO prontuario (id_usuario, id_prontuario, id_atendimento, avaliacao, condutas) " +
                          " VALUES (" + _idUsuario + "," + _novoIdProntuario + "," + _idAtendimento + ",'" + _avaliacao + "','" + _condutas + "')";
                }

                c.NonQuery(sql);
                c.Close();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public int RetornaNovoIdProntuario(int _idUsuario)
        {
            int _idProntuario;

            try
            {
                Connection c = new Connection();

                string sql = "SELECT MAX(id_prontuario) FROM prontuario WHERE id_usuario = " + _idUsuario;

                object obj = c.Query(sql);
                string result = obj.ToString();
                if (!result.Equals(""))
                {
                    _idProntuario = Convert.ToInt32(result.ToString());
                }
                else
                {
                    _idProntuario = 0;
                }

                c.Close();
            }
            catch
            {
                return 0;
            }

            return _idProntuario + 1;
        }
    }
}