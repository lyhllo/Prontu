using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PRONTU.Model;

namespace PRONTU.Queries.AgendaQueries
{
    internal class AgendaQueries
    {
        private Connection c;
        private string sql;

        public List<AgendaModel> BuscaAgendamentosDoDia(int _id_usuario, DateTime _dia)
        {
            c = new Connection();

            var _agenda = new List<AgendaModel>();

            sql = "SELECT atendimento.horario," +
                  "       paciente.id_paciente," +
                  "       paciente.nome," +
                  "       paciente.cpf," +
                  "       paciente.dt_nasc," +
                  "       if(atendimento.convenio is not null, atendimento.convenio, paciente.convenio) convenio," +
                  "       paciente.observacoes," +
                  "       atendimento.valor_pago," +
                  "       atendimento.pagto," +
                  "       atendimento.reg_presenca" +
                  "  FROM atendimento" +
                  "  LEFT JOIN paciente" +
                  "       ON(paciente.id_paciente = atendimento.id_paciente AND paciente.id_usuario = atendimento.id_usuario)" +
                  " WHERE atendimento.id_usuario = " + _id_usuario +
                  "   AND DATE(atendimento.horario) = DATE('" + _dia.ToString("u") +"')" +
                  " ORDER BY atendimento.horario ";

            MySqlDataReader rdr = c.QueryData(sql);

            if (rdr != null)
            {
                while (rdr.Read())
                {
                    AgendaModel agendaModel = new AgendaModel();
                    agendaModel.Horario = Convert.ToDateTime(rdr["horario"]);
                    agendaModel.Id_pcte = Convert.ToInt32(rdr["id_paciente"]);
                    agendaModel.Nome = Convert.ToString(rdr["nome"]);
                    agendaModel.Cpf = Convert.ToString(rdr["cpf"]);
                    agendaModel.Dt_nasc = Convert.ToDateTime(rdr["dt_nasc"]);
                    agendaModel.Convenio = Convert.ToString(rdr["convenio"]);
                    agendaModel.Observacoes = Convert.ToString(rdr["observacoes"]);
                    agendaModel.Valor_pago = Convert.ToDouble(rdr["valor_pago"]);
                    if (rdr["pagto"] != DBNull.Value)
                    {
                        agendaModel.Pago = Convert.ToBoolean(rdr["pagto"]);
                    }
                    else
                    {
                        agendaModel.Pago = null;
                    }
                    if (rdr["reg_presenca"] != DBNull.Value)
                    {
                        agendaModel.Presenca = Convert.ToBoolean(rdr["reg_presenca"]);
                    }
                    else
                    {
                        agendaModel.Presenca = null;
                    }

                    _agenda.Add(agendaModel);
                }
            }

            c.Close();
            return _agenda;
        }
    }
}
