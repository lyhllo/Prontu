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

    public partial class NovaSenha : Form
    {

        string email;
        Thread nt;

        public NovaSenha(string email)
        {
            this.email = email;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string senha1 = textBox1.Text;
            string senha2 = textBox2.Text;

            if (senha1 == senha2)
            {
                if (UsuarioController.AtualizaSenha(email,senha1))
                {
                    MessageBox.Show("Senha alterada com sucesso!");
                    Close();
                }
                else
                {
                    MessageBox.Show("Erro na alteração de senha.");
                }
            }
            else
            {
                MessageBox.Show("As senhas não conferem.");
            }
            
        }
    }
}
