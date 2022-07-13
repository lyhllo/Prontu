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
using PRONTU.Model;
using PRONTU.Controller;

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
            
        }

        private void startLogin()
        {
            Application.Run(new Login());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UsuarioModel usuario = new UsuarioModel();
            usuario.Nome = txtNome.Text;
            usuario.Cpf = txtCpf.Text;
            usuario.Registro_profissional = txtRegistroProfissional.Text;
            usuario.Profissao = txtProfissao.Text;
            usuario.Especialidade = txtEspecialidade.Text;
            usuario.Logradouro = txtLogradouro.Text;
            usuario.Numero = txtNumero.Text;
            usuario.Bairro = txtBairro.Text;
            usuario.Logradouro = txtComplemento.Text;
            usuario.Cidade = txtCidade.Text;
            usuario.Uf = txtUf.Text;
            usuario.Telefone = txtTelefone.Text;
            usuario.Email = txtEmail.Text;
            if (Validacao.ValidaCpf(usuario.Cpf))
            {
                if (Validacao.ValidaEmail(usuario.Email))
                {
                    if (txtSenha1.Text == txtSenha2.Text)
                    {
                        usuario.Senha = txtSenha1.Text;
                        if (UsuarioController.CadastraNovoUsuario(usuario))
                        {
                            MessageBox.Show("Usuário cadastrado com sucesso.");
                            if (UsuarioController.Sessao_ativa == false)
                            {
                                nt = new Thread(startLogin);
                                nt.SetApartmentState(ApartmentState.STA);
                                nt.Start();
                            }
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Falha no cadastro do usuário.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("As senhas não correspondem.");
                    }
                }
                else
                {
                    MessageBox.Show("Email inválido.");
                }
            }
            else
            {
                MessageBox.Show("CPF inválido.");
            }
                
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
