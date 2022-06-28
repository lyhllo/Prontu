using PRONTU.Controller;
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
    public partial class Relatorios : Form
    {
        public Relatorios()
        {
            InitializeComponent();
            gbAtendimento.Visible = false;
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            string rb = "";
            rb = gbTipos.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text;

            MessageBox.Show(rb);

        }

        private void CheckedChangedTipo(object sender, EventArgs e)
        {
            string rb = "";
            rb = gbTipos.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text;
            
            if(rb.Equals("Relatório de atendimentos"))
            {
                gbAtendimento.Visible = true;
            }
            else
            {
                gbAtendimento.Visible = false;
            }
        }
    }
}
