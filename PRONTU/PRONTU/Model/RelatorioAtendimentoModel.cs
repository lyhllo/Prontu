﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRONTU.Model
{
    public class RelatorioAtendimentoModel
    {
        public string Nome { get; set; }
        public DateTime Horario{ get; set; }
        public string Convenio { get; set; }
        public double Valor_pago {get; set; }
        public bool Pagto { get; set; }
        public bool Presenca { get; set; }

    }
}
