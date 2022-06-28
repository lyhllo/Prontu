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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void NascimentoTextField_TextChanged(object sender, EventArgs e)
        {

        }

        private void CpfRespTextField_TextChanged(object sender, EventArgs e)
        {

        }

        private void ObsTextField_TextChanged(object sender, EventArgs e)
        {

        }

        private void BotaoCancelar_Click(object sender, EventArgs e)
        {

        }

        private void BotaoSalvar_Click(object sender, EventArgs e)
        {
            CadastroModel paciente = new CadastroModel();
            paciente.Nome = txtNome.Text;
            //paciente.Cpf = CpfTextField.Text;
            paciente.Responsavel_Nome = txtResponsavelNome.Text;
            //paciente.Dt_nasc = NascimentoTextField.Text;
            //paciente.Responsavel_CPF = CpfRespTextField.Text;
            paciente.Convenio = txtConvenio.Text;
            paciente.Convenio_Codigo = txtConvenioCodigo.Text;
            paciente.Telefone = txtTelefone.Text;
            paciente.Logradouro = txtLogradouro.Text;
            paciente.Complemento = txtComplemento.Text;
            paciente.Cidade = txtCidade.Text;
            paciente.Email = txtEmail.Text;
            paciente.Numero = txtConvenioCodigo.Text;
            paciente.Bairro = txtBairro.Text;
            //paciente.UF = txtEstado.Text;
            paciente.Observacoes = ObsTextField.Text;

            /*int ex = PacienteCadastroController.NovoIdPaciente();

            if (PacienteCadastroController.CadastraPaciente(paciente))
            {
                MessageBox.Show("Paciente cadastrado com sucesso.");
                Close();
            }
            else
            {
                MessageBox.Show("Falha no cadastro do Paciente.");
            }*/




        }

        private void BotaoEditar_Click(object sender, EventArgs e)
        {
            CadastroModel _cadastroModel = new CadastroModel();
            _cadastroModel.Nome = txtNome.Text;
            //_cadastroModel.Cpf = CpfTextField.Text;
            //_cadastroModel.Dt_nasc = DateTime.Parse(NascimentoTextField.Text);
            //_cadastroModel.Responsavel_CPF = CpfRespTextField.Text;
            _cadastroModel.Responsavel_Nome = txtResponsavelNome.Text;
            _cadastroModel.Convenio = txtConvenio.Text;
            _cadastroModel.Convenio_Codigo = txtConvenioCodigo.Text;
            _cadastroModel.Observacoes = ObsTextField.Text;
            _cadastroModel.Logradouro = txtLogradouro.Text;
            _cadastroModel.Numero = txtNumero.Text;
            _cadastroModel.Bairro = txtBairro.Text;
            _cadastroModel.Complemento = txtComplemento.Text;
            _cadastroModel.Cidade = txtCidade.Text;
            //_cadastroModel.UF = txtEstado.Text;
            _cadastroModel.Telefone = txtTelefone.Text;
            _cadastroModel.Email = txtEmail.Text;

            PacienteCadastroController _pacienteController = new PacienteCadastroController();
            /*if (_pacienteController.AtualizaPaciente(_cadastroModel))
            {
                MessageBox.Show("Cadastrado com sucesso");
            }
            else
            {
                MessageBox.Show("Não foi possível cadastrar o paciente");
            }*/
        }
    



    

        private void BotaoExcluir_Click(object sender, EventArgs e)
        {
            //PacienteCadastroController.ExcluirPaciente(id);



        }

        private void BotaoIncluir_Click(object sender, EventArgs e)
        {
            CadastroModel _cadastroModel = new CadastroModel();
            _cadastroModel.Nome = txtNome.Text;
            //_cadastroModel.Cpf = CpfTextField.Text;
            //_cadastroModel.Dt_nasc = DateTime.Parse(NascimentoTextField.Text);
            //_cadastroModel.Responsavel_CPF = CpfRespTextField.Text;
            _cadastroModel.Responsavel_Nome = txtResponsavelNome.Text;
            _cadastroModel.Convenio = txtConvenio.Text;
            _cadastroModel.Convenio_Codigo = txtConvenioCodigo.Text;
            _cadastroModel.Observacoes = ObsTextField.Text;
            _cadastroModel.Logradouro = txtLogradouro.Text;
            _cadastroModel.Numero = txtNumero.Text;
            _cadastroModel.Bairro = txtBairro.Text;
            _cadastroModel.Complemento = txtComplemento.Text;
            _cadastroModel.Cidade = txtCidade.Text;
            //_cadastroModel.UF = txtEstado.Text;
            _cadastroModel.Telefone = txtTelefone.Text;
            _cadastroModel.Email = txtEmail.Text;

            PacienteCadastroController _pacienteController = new PacienteCadastroController();
            if (_pacienteController.CadastraContato(_cadastroModel))
            {
                MessageBox.Show("Cadastrado com sucesso");
            }
            else
            {
                MessageBox.Show("Não foi possível cadastrar o paciente");
            }
        }

        private void BotaoHistorico_Click(object sender, EventArgs e)
        {

        }

        private void BotaoAgenda_Click(object sender, EventArgs e)
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

            cadastro = new CadastroModel();

            cadastro.Id_Paciente = controller.NovoIdPaciente();

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
    }
}
