using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRONTU.Model
{
    public class AgendaModel
    {
        public int Id_pcte { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime? Dt_nasc { get; set; }
        public string Convenio_pcte { get; set; }
        public string Observacoes { get; set; }
        public int Id_atendimento { get; set; }
        public DateTime Horario { get; set; }
        public string Convenio_atendimento { get; set; }
        public double Valor_pago { get; set; }
        public bool? Pagto { get; set; }
        public bool? Reg_presenca { get; set; }
        public int? Id_prontuario { get; set; }
        public string Avaliacao { get; set; }
        public string Condutas { get; set; }

    }
}
