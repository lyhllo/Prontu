using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRONTU.Model;

namespace PRONTU.Queries
{
    internal class AgendaQueries
    {
        Connection c;
        public List<AgendaModel> BuscaAgendamentosDoDia(int _id_usuario, DateTime _dia)
        {
            c = new Connection();

            var _agenda = new List<AgendaModel>();
            
            string sql = "SELECT agenda.horario," +
                         "       paciente.id_paciente," +
                         "       paciente.nome," +
                         "       paciente.cpf," +
                         "       paciente.dt_nasc," +
                         "       paciente.convenio," +
                         "       paciente.observacoes," +
                         "       atendimento.valor_pago," +
                         "       atendimento.pagto," +
                         "       atendimento.reg_presenca" +
                         "  FROM agenda" +
                         "  LEFT JOIN atendimento" +
                         "       ON(agenda.id_agenda = atendimento.id_agenda AND agenda.id_usuario = atendimento.id_usuario)" +
                         "  LEFT JOIN paciente" +
                         "       ON(paciente.id_paciente = atendimento.id_paciente AND paciente.id_usuario = atendimento.id_usuario)" +
                         " WHERE agenda.id_usuario = " + _id_usuario +
                         "   AND DATE(agenda.horario) = DATE('" + _dia +"') ";

            object result = c.Query(sql);

            /*foreach (object res in result)
            {
                _agenda.Add(agenda);
            }*/

            return _agenda;
        }
    }
}
