using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRONTU.Controller;
using PRONTU.Model;

namespace PRONTU.View
{
    public partial class PacientesAgendamentos : Form
    {
        private DataTable dt = new DataTable();
        private AgendaController controller = new AgendaController();
        private List<AgendaModel> agendamentos;
        public Pacientes pacientesReferencia { get; set; }
        public PacientesAgendamentos()
        {
            InitializeComponent();
        }

        public void CarregarAtendimentos(int _idPaciente)
        {
            pacientesReferencia.FormataBotoes("agendamentos");
            pacientesReferencia.btnSelecionar.Visible = false;
            dt.Clear();

            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("Id_atendimento", typeof(int));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("Data", typeof(DateTime));
                dt.Columns.Add("Horário", typeof(string));
                dt.Columns.Add("Convênio", typeof(string));
                dt.Columns.Add("Valor", typeof(string));
                dt.Columns.Add("Situação", typeof(string));
                dt.Columns.Add("Observações", typeof(string));
            }

            agendamentos = controller.BuscaAgendamentos(_idPaciente);

            if (agendamentos != null)
            {
                for (int i = 0; i < agendamentos.Count; i++)
                {
                    string _pago = "";
                    if (agendamentos[i].Pagto == true)
                    {
                        _pago = "PAGO";
                    }
                    else
                    {
                        _pago = "SEM PAGAMENTO";
                    }
                    dt.Rows.Add(new object[] {agendamentos[i].Id_atendimento, agendamentos[i].Nome, agendamentos[i].Horario.Date,
                        agendamentos[i].Horario.ToString("t"), agendamentos[i].Convenio_atendimento,
                        agendamentos[i].Valor_pago.ToString("N2"), _pago, agendamentos[i].Observacoes});

                }
            }

            dgAgendamentos.DataSource = dt;

            FormataCelulas();
        }

        private void FormataCelulas()
        {
            dgAgendamentos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            foreach (DataGridViewColumn column in dgAgendamentos.Columns)
            {
                if (column.DataPropertyName == "Id_atendimento")
                    column.Visible = false;

                if (column.DataPropertyName == "Nome")
                    column.Width = 250;

                if (column.DataPropertyName == "Situação")
                    column.Width = 150;

                if (column.DataPropertyName == "Observações")
                    column.Width = 400;

                //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void ValidaDataInicio(object sender, EventArgs e)
        {
            if (txtDataInicio.Text != "  /  /")
            {
                DateTime _data;
                bool dataValida = DateTime.TryParseExact(txtDataInicio.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                                                         DateTimeStyles.None, out _data);

                if (!dataValida)
                {
                    txtDataInicio.Focus();
                    MessageBox.Show("Data inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void ValidaDataFim(object sender, EventArgs e)
        {
            if (txtDataFim.Text != "  /  /")
            {
                DateTime _data;
                bool dataValida = DateTime.TryParseExact(txtDataFim.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                                                         DateTimeStyles.None, out _data);

                if (!dataValida)
                {
                    txtDataFim.Focus();
                    MessageBox.Show("Data inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            DateTime? _dataInicio = null;
            DateTime? _dataFim = null;
            if (txtDataInicio.Text != "  /  /")
            {
                _dataInicio = DateTime.Parse(txtDataInicio.Text);
            }

            if (txtDataFim.Text != "  /  /")
            {
                _dataFim = DateTime.Parse(txtDataFim.Text);
            }

            FiltrarGrade(_dataInicio, _dataFim);
        }

        private void FiltrarGrade(DateTime? _inicio, DateTime? _fim)
        {
            if (_inicio == null)
                _inicio = DateTime.MinValue;

            if (_fim == null)
                _fim = DateTime.MaxValue;

            if (_inicio != null || _fim != null)
            {
                string str = "";

                if (_inicio != null && _fim != null)
                    str = String.Format("[{0}] >= '{1}' AND [{0}] <= '{2}'", "Data", _inicio.Value.Date, _fim.Value.Date);

                if (_inicio != null && _fim == null)
                    str = String.Format("[{0}] >= '{1}'", "Data", _inicio.Value.Date);

                if (_inicio == null && _fim != null)
                    str = String.Format("[{0}] <= '{1}'", "Data", _fim.Value.Date);

                dt.DefaultView.RowFilter = str;
                dgAgendamentos.DataSource = dt;
            }
        }
    }
}
