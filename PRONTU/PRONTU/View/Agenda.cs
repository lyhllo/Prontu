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
using PRONTU.Controller.AgendaController;


namespace PRONTU
{
    public partial class Agenda : Form
    {
        AgendaController agendaController = new AgendaController();
        public Form ReferenciaHome { get; set; }
        public int formatoAgenda { get; set; }
        string dataSelecionada;
        string horaSelecionada = DateTime.Now.Hour.ToString() + " : " + DateTime.Now.Minute.ToString();
        private int linhas;
        private List<AgendaModel> agenda;
        private AgendaModel atendimento = new AgendaModel();


        public Agenda()
        {
            InitializeComponent();
            formatoAgenda = 30;
            linhas = (60 / formatoAgenda * 24);
            AtualizaHorarios();
        }

        private void AtualizaHorarios()
        {
            dgHorarios.Rows.Clear();
            dgHorarios.Rows.Add(linhas);
            CarregaHorarios();
            EditaFoco();

        }

        private void CarregaHorarios()
        {
            DateTime _d = calendario.SelectionRange.Start;
            
            agenda = agendaController.BuscaAgendamentosDoDia(1, _d);
            for (int i = 0; i < linhas; i++)
            {
                dgHorarios.Rows[i].Cells[0].Value = "0";
                dgHorarios.Rows[i].Cells[1].Value = _d.ToString("HH:mm");

                foreach (AgendaModel agendaModel in agenda)
                {
                    if (agendaModel.Horario == _d)
                    {
                        dgHorarios.Rows[i].Cells[0].Value = agendaModel.Id_pcte;
                        dgHorarios.Rows[i].Cells[2].Value = agendaModel.Nome;
                        dgHorarios.Rows[i].Cells[3].Value = agendaModel.Cpf;
                        dgHorarios.Rows[i].Cells[4].Value = agendaModel.Convenio_atendimento;
                        dgHorarios.Rows[i].Cells[5].Value = agendaModel.Observacoes;
                    }
                }
                _d = _d.AddMinutes(formatoAgenda);
            }
        }

        private void EditaFoco()
        {
            DateTime d = calendario.SelectionRange.Start;
            d = d.AddHours(DateTime.Now.Hour);
            d = d.AddMinutes(DateTime.Now.Minute);
            for (int i = 0;i < dgHorarios.Rows.Count; i++)
            {
                var _horario = dgHorarios.Rows[i].Cells[1].Value.ToString().Split(':');
                DateTime _datahora = calendario.SelectionRange.Start;
                _datahora = _datahora.AddHours(Double.Parse(_horario[0]));
                _datahora = _datahora.AddMinutes(Double.Parse(_horario[1]));
                if (d >= _datahora && d < _datahora.AddMinutes(formatoAgenda))
                {
                    dgHorarios.CurrentCell = dgHorarios.Rows[i].Cells[1];
                    dgHorarios.FirstDisplayedScrollingRowIndex = i;
                }
            }
        }

        private void SelectionChanged(object sender, EventArgs e)
        {
            int _val;
            if (dgHorarios.SelectedRows.Count > 0)
            {
                _val = int.Parse(dgHorarios.SelectedCells[0].Value.ToString());
            }
            else
            {
                _val = 0;
            }


            if (_val == 0)
            {
                mostrar_botoes(false);
            }

            for (int i = 0; i < agenda.Count; i++)
            {
                if (agenda[i].Id_pcte == _val)
                {
                    atendimento = agenda[i];
                    mostrar_botoes(true);
                    txtValor.Text = atendimento.Valor_pago.ToString("N2");
                    if (atendimento.Pagto == true)
                    {
                        btnPagar.Text = "Desmarcar Pagamento";
                    }
                    else
                    {
                        btnPagar.Text = "Marcar Pagamento";
                    }
                    if (atendimento.Avaliacao != null || atendimento.Observacoes != null)
                    {
                        btnRemoverAgendamento.Text = "Remover atendimento";
                    }
                    else
                    {
                        btnRemoverAgendamento.Text = "Remover agendamento";
                    }
                    break;
                }
                else
                {
                    mostrar_botoes(false);
                }
            }
        }

        private void mostrar_botoes(Boolean _bol)
        {
            if (_bol)
            {
                btnAtender.Text = "Atender";
            }
            else
            {
                btnAtender.Text = "Agendar";
            }
            btnFalta.Visible = _bol;
            btnCadastro.Visible = _bol;
            btnRemoverAgendamento.Visible = _bol;
            lblValor.Visible = _bol;
            txtValor.Visible = _bol;
            btnPagar.Visible = _bol;

            if (atendimento.Id_prontuario != null)
            {
                btnRemoverAgendamento.Enabled = false;
            }
            else
            {
                btnRemoverAgendamento.Enabled = true;
            }
        }

        private void btnRemoverAgendamento_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja remover esse agendamento?",
                "Remover agendamento", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                bool _res = agendaController.RemoverAgendamento(atendimento.Id_atendimento);
                if (_res)
                {
                    MessageBox.Show("Agendamento removido com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizaHorarios();
                }
                else
                {
                    MessageBox.Show("Não foi possível remover o agendamento", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            Home _novo = (Home)ReferenciaHome;
            if (dgHorarios.SelectedCells[0].Value.ToString() == "0")
            {
                var _hora = dgHorarios.SelectedCells[1].Value.ToString().Split(':');
                DateTime _datahora = calendario.SelectionRange.Start;
                _datahora = _datahora.AddHours(Double.Parse(_hora[0]));
                _datahora = _datahora.AddMinutes(Double.Parse(_hora[1]));
                _novo.SelecionarPaciente(_datahora);
            }
            else
            {
                _novo.AbrirAtendimento(atendimento);
            }
        }

        private void calendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            AtualizaHorarios();
        }

        private void btnFalta_Click(object sender, EventArgs e)
        {
            bool _res = agendaController.RegistrarFalta(atendimento.Id_atendimento);
            if (_res)
            {
                MessageBox.Show("Falta registrada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizaHorarios();
            }
            else
            {
                MessageBox.Show("Não foi possível registrar a falta", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
