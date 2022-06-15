using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace PRONTU.View
{
    public partial class NovoUsuario : Form
    {
        Thread nt;
        public NovoUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cadastro feito com sucesso.");
            Close();
            nt = new Thread(startHome);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void startHome()
        {
            Application.Run(new Login());
        }
    }
}
