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
            // para testes ------------------------
            txtData.Text = _diaHora.ToString("d");
            txtHora.Text = _diaHora.ToString("t");
            txtNome.Text = "Ana Maria Joana";
            txtDocumento.Text = "001.002.003-99";
            txtNascimento.Text = "20/10/1990";
            txtConvenio.Text = "Unimed";
            txtValor.Text = "R$ 80,00";
            //-------------------------------------
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Atendimento registrado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
