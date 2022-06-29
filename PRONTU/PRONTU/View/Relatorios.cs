using PRONTU.Controller;
using PRONTU.Model;
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
    public partial class Relatorios : Form
    {
        public Relatorios()
        {
            InitializeComponent();
            gbAtendimento.Visible = false;
            PopularComboBoxPaciente();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            string rb = "";
            rb = gbTipos.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text;

            switch (rb)
            {
                case "Relatório de atendimentos":
                    RelatorioAtendimentos();
                    break;

                case "Laudo":
                    Laudo();
                    break;
            }
        }

        private void CheckedChangedTipo(object sender, EventArgs e)
        {
            
            string rb = "";
            rb = gbTipos.Controls.OfType<RadioButton>().SingleOrDefault(RadioButton => RadioButton.Checked).Text;
            
            if(rb.Equals("Relatório de atendimentos"))
            {
                gbAtendimento.Visible = true;
            }
            else
            {
                gbAtendimento.Visible = false;
            }
        }

        private void PopularComboBoxPaciente()
        {
            var _pacientes = new List<String>();
            RelatorioAtendimentoController relatorio = new RelatorioAtendimentoController();

            _pacientes = relatorio.RetornarPacientesAtendimento(1);

            cbPaciente.Items.Add("Todos os pacientes");

            foreach(var v in _pacientes)
            {
                cbPaciente.Items.Add(v);
            }

            cbPaciente.SelectedIndex = cbPaciente.FindStringExact("Todos os pacientes"); // iniciar com TODOS
        }

        public void RelatorioAtendimentos()
        {
            RelatorioAtendimentoController atendimento = new RelatorioAtendimentoController();
            var _atendimento = new List<RelatorioAtendimentoModel>();

             _atendimento = atendimento.RetornarAtendimentos(1, dpDataInicial.Value, dpDataFinal.Value, cbPaciente.Text);

            if (dpDataInicial.Value.Date > dpDataFinal.Value.Date)
            {
                MessageBox.Show("Data inicial maior que a data final", "Relatório de atendimentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Mostrar na tela para testes
                string str = "";
                for (int i = 0; i < _atendimento.Count(); i++)
                {
                    str = str + _atendimento[i].Nome.ToString() + " ; ";
                    str = str + _atendimento[i].Horario.ToString() + " ; ";
                    str = str + _atendimento[i].Convenio.ToString() + " ; ";
                    str = str + _atendimento[i].Valor_pago.ToString() + " ; ";
                    str = str + _atendimento[i].Avaliacao.ToString() + " ; ";
                    str = str + _atendimento[i].Condutas.ToString();
                    str = str + "\r\n" + "\r\n";
                }
                MessageBox.Show(str);
            }

             
        }

        public void Laudo()
        {
            LaudoController laudo = new LaudoController();
            var _laudo = new List<LaudoModel>();

            _laudo = laudo.RetornarDadosDoProfissional(1);

            // Mostrar na tela para testes
            string str = "";
            for (int i = 0; i < _laudo.Count(); i++)
            {
                str = str + _laudo[i].Nome.ToString() + " ; ";
                str = str + _laudo[i].Profissao.ToString() + " ; ";
                str = str + _laudo[i].Especialidade.ToString() + " ; ";
                str = str + _laudo[i].Registro_profissional.ToString() + " ; ";
                str = str + _laudo[i].Telefone.ToString() + " ; ";
                str = str + _laudo[i].Email.ToString();
                str = str + "\r\n" + "\r\n";
            }
            MessageBox.Show(str);
        }
    }
}
