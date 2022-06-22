using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Controller.Paciente paciente = new Controller.Paciente();
            Controller.Contato contato = new Controller.Contato();
            paciente.nome = NomeTextField.Text;
            paciente.cpf = CpfTextField.Text;
            paciente.dt_nasc = NascimentoTextField.Text;
            paciente.responsavel_cpf = CpfRespTextField.Text;
            paciente.responsavel_nome = respTextField.Text;
            paciente.convenio = ConvenioTextField.Text;
            paciente.convenio_codigo = NumeroTextField.Text;
            paciente.observacoes = ObsTextField.Text;
            contato.logradouro = RuaTextField.Text;
            contato.numero = NumRuaTextField.Text;
            contato.bairro = BairroTextField.Text;
            contato.complemento = CompelmentoTextField.Text;
            contato.cidade = CidadeTextField.Text;
            contato.uf = EstadoTextField.Text;
            contato.telefone = TelefoneTextField.Text;
            contato.email = EmailTextField.Text;
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
