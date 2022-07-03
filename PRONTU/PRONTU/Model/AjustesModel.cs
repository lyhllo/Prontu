using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRONTU.Model
{
    public class AjustesModel
    {
        public int id_usuario { get; set; }
        public int id_agenda { get; set; }
        public int formato_minutos { get; set; }
        public bool mostrar_valor { get; set; }
        public bool marcador_pagamento { get; set; }
        public bool marcador_comparecimento { get; set; }

    }
}
