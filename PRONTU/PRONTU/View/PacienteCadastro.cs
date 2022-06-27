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

namespace PRONTU
{
    public partial class PacienteCadastro : Form
    {
        public Pacientes pacientesReferencia { get; set; }
        public PacienteCadastro()
        {
            InitializeComponent();
            
        }

        private void PacienteCadastro_Load(object sender, EventArgs e)
        {
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

        private void respTextField_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConvenioTextField_TextChanged(object sender, EventArgs e)
        {

        }

        private void NascimentoTextField_TextChanged(object sender, EventArgs e)
        {

        }

        private void CpfRespTextField_TextChanged(object sender, EventArgs e)
        {

        }

        private void NumeroTextField_TextChanged(object sender, EventArgs e)
        {

        }

        private void TelefoneTextField_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmailTextField_TextChanged(object sender, EventArgs e)
        {

        }

        private void RuaTextField_TextChanged(object sender, EventArgs e)
        {

        }

        private void CompelmentoTextField_TextChanged(object sender, EventArgs e)
        {

        }

        private void BairroTextField_TextChanged(object sender, EventArgs e)
        {

        }

        private void CidadeTextField_TextChanged(object sender, EventArgs e)
        {

        }

        private void EstadoTextField_TextChanged(object sender, EventArgs e)
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
            paciente.Nome = NomeTextField.Text;
            paciente.Cpf = CpfTextField.Text;
            paciente.Responsavel_Nome = txtResponsavelNome.Text;
            //paciente.Dt_nasc = NascimentoTextField.Text;
            paciente.Responsavel_CPF = CpfRespTextField.Text;
            paciente.Convenio = txtConvenio.Text;
            paciente.Convenio_Codigo = txtConvenioCodigo.Text;
            paciente.Telefone = txtTelefone.Text;
            paciente.Logradouro = txtLogradouro.Text;
            paciente.Complemento = txtComplemento.Text;
            paciente.Cidade = txtCidade.Text;
            paciente.Email = txtEmail.Text;
            paciente.Numero = txtConvenioCodigo.Text;
            paciente.Bairro = txtBairro.Text;
            paciente.UF = txtEstado.Text;
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
            _cadastroModel.Nome = NomeTextField.Text;
            _cadastroModel.Cpf = CpfTextField.Text;
            _cadastroModel.Dt_nasc = DateTime.Parse(NascimentoTextField.Text);
            _cadastroModel.Responsavel_CPF = CpfRespTextField.Text;
            _cadastroModel.Responsavel_Nome = txtResponsavelNome.Text;
            _cadastroModel.Convenio = txtConvenio.Text;
            _cadastroModel.Convenio_Codigo = txtConvenioCodigo.Text;
            _cadastroModel.Observacoes = ObsTextField.Text;
            _cadastroModel.Logradouro = txtLogradouro.Text;
            _cadastroModel.Numero = txtNumero.Text;
            _cadastroModel.Bairro = txtBairro.Text;
            _cadastroModel.Complemento = txtComplemento.Text;
            _cadastroModel.Cidade = txtCidade.Text;
            _cadastroModel.UF = txtEstado.Text;
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
            _cadastroModel.Nome = NomeTextField.Text;
            _cadastroModel.Cpf = CpfTextField.Text;
            _cadastroModel.Dt_nasc = DateTime.Parse(NascimentoTextField.Text);
            _cadastroModel.Responsavel_CPF = CpfRespTextField.Text;
            _cadastroModel.Responsavel_Nome = txtResponsavelNome.Text;
            _cadastroModel.Convenio = txtConvenio.Text;
            _cadastroModel.Convenio_Codigo = txtConvenioCodigo.Text;
            _cadastroModel.Observacoes = ObsTextField.Text;
            _cadastroModel.Logradouro = txtLogradouro.Text;
            _cadastroModel.Numero = txtNumero.Text;
            _cadastroModel.Bairro = txtBairro.Text;
            _cadastroModel.Complemento = txtComplemento.Text;
            _cadastroModel.Cidade = txtCidade.Text;
            _cadastroModel.UF = txtEstado.Text;
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

        private void NomeTextField_TextChanged(object sender, EventArgs e)
        {

        }

        private void CpfTextField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
