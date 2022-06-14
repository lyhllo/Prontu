using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRONTU
{
    public partial class Atendimento : Form
    {
        public DateTime diaHora { get; set; }
        public int id_pcte { get; set; }
        public Atendimento()
        {
            InitializeComponent();
        }

        public void CarregaTela(DateTime _diaHora, int _idPcte)
        {
            txtData.Text = _diaHora.ToString();
            txtId.Text = _idPcte.ToString();
        }
    }
}
