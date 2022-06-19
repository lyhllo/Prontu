using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRONTU.Model
{
    internal class AgendaModel
    {
        public DateTime Horario { get; set; }
        public int Id_pcte { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime? Dt_nasc { get; set; }
        public string Convenio { get; set; }
        public string Observacoes { get; set; }

        public double? Valor_pago { get; set; }
        public bool? Pago { get; set; }
        public bool? Presenca { get; set; }
        public string Avaliacao { get; set; }
        public string Condutas { get; set; }

    }
}
