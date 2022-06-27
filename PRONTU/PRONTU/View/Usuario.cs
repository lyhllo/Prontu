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
                    if (UsuarioController.AtualizaUsuario(usuario))
                    {
                        MessageBox.Show("Usuário atualizado com sucesso.");
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
            txtLogradouro.Text = usuario.Contato.Logradouro;
            txtNumero.Text = usuario.Contato.Numero;
            txtBairro.Text = usuario.Contato.Bairro;
            txtComplemento.Text = usuario.Contato.Logradouro;
            txtCidade.Text = usuario.Contato.Cidade;
            txtUf.Text = usuario.Contato.Uf;
            txtTelefone.Text = usuario.Contato.Telefone;
            txtEmail.Text = usuario.Contato.Email;
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

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtCpf_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
