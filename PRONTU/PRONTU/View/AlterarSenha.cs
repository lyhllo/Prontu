using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRONTU.Controller;

namespace PRONTU.View
{
    public partial class AlterarSenha : Form
    {
        public AlterarSenha()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtSenha1.Text == txtSenha2.Text)
            {
                if (UsuarioController.AlteraSenha(txtSenha1.Text))
                {
                    MessageBox.Show("Senha alterada com sucesso.");
                    Close();
                }
                else
                {
                    MessageBox.Show("Falha na alteração de senha.");
                }
            } else
            {
                MessageBox.Show("As senhas não correspondem.");
            }
            
        }
    }
}
