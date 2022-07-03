using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRONTU.Model;
using PRONTU.Controller;
using PRONTU.View;
using System.Threading;

namespace PRONTU
{
    public partial class Usuario : Form
    {
        Thread nt;
        public Usuario()
        {
            InitializeComponent();
            UsuarioModel Usuario = UsuarioController.BuscaDadosUsuario();
            mostra_dados_formulario(Usuario);
            somente_leitura(true);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
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
                    if (UsuarioController.AtualizaUsuario(usuario))
                    {
                        MessageBox.Show("Usuário atualizado com sucesso.");
                        somente_leitura(true);
                    }
                    else
                    {
                        MessageBox.Show("Falha ao atualizar usuário.");
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

        private void mostra_dados_formulario (UsuarioModel usuario)
        {
            txtNome.Text = usuario.Nome;
            txtCpf.Text = usuario.Cpf;
            txtRegistroProfissional.Text = usuario.Registro_profissional;
            txtProfissao.Text = usuario.Profissao;
            txtEspecialidade.Text = usuario.Especialidade;
            txtLogradouro.Text = usuario.Logradouro;
            txtNumero.Text = usuario.Numero;
            txtBairro.Text = usuario.Bairro;
            txtComplemento.Text = usuario.Logradouro;
            txtCidade.Text = usuario.Cidade;
            txtUf.Text = usuario.Uf;
            txtTelefone.Text = usuario.Telefone;
            txtEmail.Text = usuario.Email;
        }

        private void somente_leitura(bool b)
        {
            txtNome.ReadOnly = b;
            txtCpf.ReadOnly = b;
            txtRegistroProfissional.ReadOnly = b;
            txtProfissao.ReadOnly = b;
            txtEspecialidade.ReadOnly = b;
            txtLogradouro.ReadOnly = b;
            txtNumero.ReadOnly = b;
            txtBairro.ReadOnly = b;
            txtComplemento.ReadOnly = b;
            txtCidade.ReadOnly = b;
            txtUf.ReadOnly = b;
            txtTelefone.ReadOnly = b;
            txtEmail.ReadOnly = b;
            btnSalvar.Enabled = !b;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            nt = new Thread(startNovoUsuario);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void startNovoUsuario()
        {
            Application.Run(new NovoUsuario());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nt = new Thread(startAlteraSenha);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void startAlteraSenha()
        {
            Application.Run(new AlterarSenha());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            somente_leitura(false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UsuarioModel Usuario = UsuarioController.BuscaDadosUsuario();
            mostra_dados_formulario(Usuario);
            somente_leitura(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nt = new Thread(startConfirmaExclusao);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void startConfirmaExclusao()
        {
            Application.Run(new ConfirmaExclusao());
        }
    }
}
