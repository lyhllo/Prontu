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
                    MessageBox.Show("Usuário excluído com sucesso.");
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Senha incorreta.");
            }
        }

        public static void fechaAplicacao()
        {
                for (int i = 0; i < Application.OpenForms.Count; ++i)
                    Application.OpenForms[i].Close();
        }

        private void ConfirmaExclusao_Load(object sender, EventArgs e)
        {

        }
    }
}
