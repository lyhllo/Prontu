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

namespace PRONTU
{
    public partial class PacienteCadastro : Form
    {
        public PacienteCadastro()
        {
            InitializeComponent();
        }

        private void PacienteCadastro_Load(object sender, EventArgs e)
        {

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

        private void NumRuaTextField_TextChanged(object sender, EventArgs e)
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

        }

        private void BotaoBuscar_Click(object sender, EventArgs e)
        {

        }

        private void BotaoEditar_Click(object sender, EventArgs e)
        {

        }

        private void BotaoExcluir_Click(object sender, EventArgs e)
        {

        }

        private void BotaoIncluir_Click(object sender, EventArgs e)
        {
            CadastroModel _cadastroModel = new CadastroModel();
            _cadastroModel.Nome = NomeTextField.Text;
            _cadastroModel.Cpf = CpfTextField.Text;
            _cadastroModel.Dt_nasc = DateTime.Parse(NascimentoTextField.Text);
            _cadastroModel.Responsavel_CPF = CpfRespTextField.Text;
            _cadastroModel.Responsavel_Nome = respTextField.Text;
            _cadastroModel.Convenio = ConvenioTextField.Text;
            _cadastroModel.Convenio_Codigo = NumeroTextField.Text;
            _cadastroModel.Observacoes = ObsTextField.Text;
            _cadastroModel.Logradouro = RuaTextField.Text;
            _cadastroModel.Numero = NumRuaTextField.Text;
            _cadastroModel.Bairro = BairroTextField.Text;
            _cadastroModel.Complemento = CompelmentoTextField.Text;
            _cadastroModel.Cidade = CidadeTextField.Text;
            _cadastroModel.UF = EstadoTextField.Text;
            _cadastroModel.Telefone = TelefoneTextField.Text;
            _cadastroModel.Email = EmailTextField.Text;

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
