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
            
            if(cbPaciente.Text.Equals("Todos os pacientes"))
            {
                _atendimento = atendimento.RetornarAtendimentosTodosPacientes(1, dpDataInicial.Value, dpDataFinal.Value);
            }
            else
            {
                _atendimento = atendimento.RetornarAtendimentosPorPaciente(1, dpDataInicial.Value, dpDataFinal.Value, cbPaciente.Text);
            }
            

            // Mostrar na tela para testes
            string str = "";
            for(int i = 0; i < _atendimento.Count(); i++)
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

        public void Laudo()
        {
            MessageBox.Show("Laudo");
        }
    }
}
