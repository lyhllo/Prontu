using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using PRONTU.Controller;

namespace PRONTU.View
{
    public partial class EsqueciMinhaSenha : Form
    {
        Thread nt;

        string email;

        public EsqueciMinhaSenha()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // Receber código
        {
            email = textBox1.Text;
            try
            {
                if (UsuarioController.EsqueciMinhaSenha(email))
                {
                    MessageBox.Show("Email contendo código de recuperação enviado para " + email);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Email não encontrado.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string codigo = textBox2.Text;

            if (UsuarioController.ValidaCodigoRecuperacao(codigo))
            {
                MessageBox.Show("Código validado com sucesso!");
                Close();
                nt = new Thread(() => startNovaSenha(email));
                nt.SetApartmentState(ApartmentState.STA);
                nt.Start();
            } 
            else
            {
                MessageBox.Show("Código inválido.");
            }
        }

        private void startNovaSenha(string email)
        {
            Application.Run(new NovaSenha(email));
        }
    }
}
