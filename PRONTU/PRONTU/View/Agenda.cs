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
    public partial class Agenda : Form
    {
        

        public Agenda()
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                dgHorarios.Rows.Add(i + 1);
            }
        }

        public Form ReferenciaHome { get; set; }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRemoverAgendamento_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            Home novo = (Home)ReferenciaHome;
            novo.AbrirAtendimento(DateTime.Now, 1);            
        }

        private void teste()
        {
            
        }
    }
}
