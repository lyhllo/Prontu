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
using System.Globalization;

namespace PRONTU
{
    public partial class PacienteCadastro : Form
    {
        public Pacientes pacientesReferencia { get; set; }
        private CadastroModel cadastro;
        private PacienteCadastroController controller = new PacienteCadastroController();
        public PacienteCadastro()
        {
            InitializeComponent();            
        }

        private void PacienteCadastro_Load(object sender, EventArgs e)
        {
            pacientesReferencia.btnSelecionar.Text = "Salvar";
            pacientesReferencia.btnSelecionar.Visible = true;
            pacientesReferencia.FormataBotoes("incluir");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void ObsTextField_TextChanged(object sender, EventArgs e)
        {

        }


        private void ValidarDataNascimento(object sender, EventArgs e)
        {
            if (txtDataNascimento.Text != "  /  /")
            {
                DateTime _data;
                bool dataValida = DateTime.TryParseExact(txtDataNascimento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                                                         DateTimeStyles.None, out _data);

                if (!dataValida)
                {
                    txtDataNascimento.Focus();
                    MessageBox.Show("Data inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ValidaCpfPaciente(object sender, EventArgs e)
        {
            if (!Validacao.ValidaCpf(txtCPF.Text) && txtCPF.Text != "")
            {
                txtCPF.Focus();
                MessageBox.Show("CPF inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidaCpfResponsavel(object sender, EventArgs e)
        {
            if (!Validacao.ValidaCpf(txtCpfResponsavel.Text) && txtCpfResponsavel.Text != "")
            {
                txtCpfResponsavel.Focus();
                MessageBox.Show("CPF inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidaEmail(object sender, EventArgs e)
        {
            if (!Validacao.ValidaEmail(txtEmail.Text) && txtEmail.Text != "")
            {
                txtEmail.Focus();
                MessageBox.Show("E-mail inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool SalvarPaciente()
        {
            if (ValidaCadastro())
            {
                if (controller.CadastraPaciente(cadastro))
                {
                    MessageBox.Show("Cadastro efetuado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar paciente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void CarregarCadastro(CadastroModel _cadastroPaciente)
        {
            if (_cadastroPaciente != null)
            {
                cadastro = _cadastroPaciente;
                txtNome.Text = _cadastroPaciente.Nome;
                txtDataNascimento.Text = _cadastroPaciente.Dt_nasc.Value.ToString("d");
                txtCPF.Text = _cadastroPaciente.Cpf;
                txtResponsavelNome.Text = _cadastroPaciente.Responsavel_Nome;
                txtCpfResponsavel.Text = _cadastroPaciente.Responsavel_CPF;
                txtConvenio.Text = _cadastroPaciente.Convenio;
                txtConvenioCodigo.Text = _cadastroPaciente.Convenio_Codigo;
                txtObservacoes.Text = _cadastroPaciente.Observacoes;
                txtCEP.Text = _cadastroPaciente.CEP;
                txtTelefone.Text = _cadastroPaciente.Telefone;
                txtEmail.Text = _cadastroPaciente.Email;
                txtLogradouro.Text = _cadastroPaciente.Logradouro;
                txtNumero.Text = _cadastroPaciente.Numero;
                txtComplemento.Text = _cadastroPaciente.Complemento;
                txtBairro.Text = _cadastroPaciente.Bairro;
                txtCidade.Text = _cadastroPaciente.Cidade;
                cbUF.Text = _cadastroPaciente.UF;
            }
        }

        private Boolean ValidaCadastro()
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Obrigatório preencher no mínimo Nome e CPF", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if ((txtCPF.Text == "") && (txtCpfResponsavel.Text == ""))
            {
                MessageBox.Show("Obrigatório preencher o CPF do(a) paciente ou da pessoa responsável", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cadastro.Id_Paciente == 0)
            {
                cadastro = new CadastroModel();
                cadastro.Id_Paciente = controller.NovoIdPaciente();
            }

            cadastro.Nome = txtNome.Text;

            cadastro.Cpf = txtCPF.Text;

            if (txtDataNascimento.Text != "  /  /")
                cadastro.Dt_nasc = DateTime.Parse(txtDataNascimento.Text);
            else
                cadastro.Dt_nasc = null;

            cadastro.Responsavel_CPF = txtCpfResponsavel.Text;

            cadastro.Responsavel_Nome = txtResponsavelNome.Text;

            cadastro.Convenio = txtConvenio.Text;

            cadastro.Convenio_Codigo = txtConvenioCodigo.Text;

            cadastro.Observacoes = txtObservacoes.Text;

            cadastro.Logradouro = txtLogradouro.Text;

            cadastro.Numero = txtNumero.Text;

            cadastro.Bairro = txtBairro.Text;

            cadastro.Complemento = txtComplemento.Text;

            cadastro.Cidade = txtCidade.Text;

            cadastro.UF = cbUF.Text;

            cadastro.Telefone = txtTelefone.Text;

            cadastro.Email = txtEmail.Text;

            cadastro.CEP = txtCEP.Text;

            return true;
        }

        public bool EditarPaciente()
        {
            if (ValidaCadastro())
            {
                if (controller.EditaPaciente(cadastro))
                {
                    MessageBox.Show("Cadastro alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Erro ao alterar o cadastro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
