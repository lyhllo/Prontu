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
        private AgendaModel atendimento;


        public Agenda()
        {
            InitializeComponent();
            formatoAgenda = 15;
            linhas = (60 / formatoAgenda * 24);
            AdicionaLinhas();
            CarregaHorarios();
            EditaFoco();
        }

        private void AdicionaLinhas()
        {
            dgHorarios.Rows.Add(linhas);
            CarregaHorarios();

        }

        private void CarregaHorarios()
        {
            DateTime _d = new DateTime();
            _d = calendario.SelectionRange.Start;
            
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
            DateTime d = DateTime.Now;
            for (int i = 0;i < dgHorarios.Rows.Count; i++)
            {
                var _horario = dgHorarios.Rows[i].Cells[1].Value.ToString().Split(':');
                DateTime _datahora = calendario.SelectionRange.Start;
                _datahora = _datahora.AddHours(Double.Parse(_horario[0]));
                _datahora = _datahora.AddMinutes(Double.Parse(_horario[1]));
                if (DateTime.Now >= _datahora && DateTime.Now < _datahora.AddMinutes(formatoAgenda))
                {
                    dgHorarios.CurrentCell = dgHorarios.Rows[i].Cells[1];
                    dgHorarios.FirstDisplayedScrollingRowIndex = i;
                }
            }
        }

        private void SelectionChanged(object sender, EventArgs e)
        {
            int _val = int.Parse(dgHorarios.SelectedCells[0].Value.ToString());

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


        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRemoverAgendamento_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja remover da agenda e deletar todas " +
                "as informações desse atendimento?", "Remover agendamento", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                MessageBox.Show("Agendamento removido com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            Home novo = (Home)ReferenciaHome;
            novo.AbrirAtendimento(atendimento);            
        }

        private void teste()
        {
            
        }

        private void calendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            CarregaHorarios();
            EditaFoco();
        }

        private void dgHorarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFalta_Click(object sender, EventArgs e)
        {

        }
    }
}
