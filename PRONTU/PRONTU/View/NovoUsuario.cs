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

        private void startHome()
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
            usuario.Contato.Logradouro = txtLogradouro.Text;
            usuario.Contato.Numero = txtNumero.Text;
            usuario.Contato.Bairro = txtBairro.Text;
            usuario.Contato.Logradouro = txtComplemento.Text;
            usuario.Contato.Cidade = txtCidade.Text;
            usuario.Contato.Uf = txtUf.Text;
            usuario.Contato.Telefone = txtTelefone.Text;
            usuario.Contato.Email = txtEmail.Text;
            if (Validacao.ValidaCpf(usuario.Cpf))
            {
                if (Validacao.ValidaEmail(usuario.Contato.Email))
                {
                    if (txtSenha1.Text == txtSenha2.Text)
                    {
                        usuario.Senha = txtSenha1.Text;
                        if (UsuarioController.CadastraNovoUsuario(usuario))
                        {
                            MessageBox.Show("Usuário cadastrado com sucesso.");
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
    }
}
