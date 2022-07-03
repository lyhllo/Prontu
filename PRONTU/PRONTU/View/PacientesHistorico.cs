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
using System.Globalization;

namespace PRONTU.View
{
    public partial class PacientesHistorico : Form
    {
        private DataTable dt = new DataTable();
        private List<AgendaModel> historico;
        private AgendaController controller = new AgendaController();
        public Pacientes pacientesReferencia;
        public PacientesHistorico()
        {
            InitializeComponent();
        }

        public void CarregarPacientes(int _idPaciente)
        {
            pacientesReferencia.FormataBotoes("historico");
            pacientesReferencia.btnSelecionar.Visible = false;
            dt.Clear();

            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("Id_atendimento", typeof(int));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("Data", typeof(DateTime));
                dt.Columns.Add("Horário", typeof(string));
                dt.Columns.Add("Convênio", typeof(string));
                dt.Columns.Add("Avaliação", typeof(string));
                dt.Columns.Add("Condutas", typeof(string));
            }

            historico = controller.BuscaHistoricoAtendimentos(_idPaciente);

            if (historico != null)
            {
                for (int i = 0; i < historico.Count; i++)
                {
                    dt.Rows.Add(new object[] {historico[i].Id_atendimento, historico[i].Nome, historico[i].Horario.Date,
                        historico[i].Horario.ToString("t"), historico[i].Convenio_atendimento, historico[i].Avaliacao,
                        historico[i].Condutas});

                }
            }

            dgHistorico.DataSource = dt;

            FormataCelulas();
        }

        private void FormataCelulas()
        {
            dgHistorico.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            foreach (DataGridViewColumn column in dgHistorico.Columns)
            {
                if (column.DataPropertyName == "Id_atendimento")
                    column.Visible = false;

                if (column.DataPropertyName == "Nome")
                    column.Width = 230;

                if (column.DataPropertyName == "Data")
                    column.Width = 120;

                if (column.DataPropertyName == "Horário")
                    column.Width = 120;

                if (column.DataPropertyName == "Convênio")
                    column.Width = 150;

                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
                dgHistorico.DataSource = dt;
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

        private void DetalharAtendimento(object sender, EventArgs e)
        {
            
            foreach (AgendaModel am in historico)
            {
                if (am.Id_atendimento == int.Parse(dgHistorico.SelectedCells[0].Value.ToString()))
                {
                    pacientesReferencia.homeReferencia.AbrirAtendimento(am, null);
                    pacientesReferencia.AbrirPacientesPesquisar(false, null);
                    break;
                }
            }
        }
    }
}
