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
    public partial class ConfirmaExclusao : Form
    {
        public ConfirmaExclusao()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (UsuarioController.ConfirmaSenha(txtSenha.Text))
            {
                if(UsuarioController.ExcluiUsuario())
                {
                    MessageBox.Show("Usuário excluído com sucesso. O sistema será fechado.");
                    Application.Restart();
                }
            }
            else
            {
                MessageBox.Show("Senha incorreta.");
            }
        }

        private void ConfirmaExclusao_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
