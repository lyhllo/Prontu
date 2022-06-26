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

namespace PRONTU.View
{
    public partial class PacientesHistorico : Form
    {
        private DataTable dt = new DataTable();
        private List<AgendaModel> historico;
        private AgendaController controller = new AgendaController();
        public PacientesHistorico()
        {
            InitializeComponent();
        }

        public void CarregarPacientes()
        {
            if (dt.Columns.Count == 0)
            {
                historico = controller.BuscaHistoricoAtendimentos();

                dt.Columns.Add("Id_atendimento", typeof(int));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("Data", typeof(string));
                dt.Columns.Add("Horário", typeof(string));
                dt.Columns.Add("Convênio", typeof(string));
                dt.Columns.Add("Avaliação", typeof(string));
                dt.Columns.Add("Condutas", typeof(string));

                if (historico != null)
                {
                    for (int i = 0; i < historico.Count; i++)
                    {
                        dt.Rows.Add(new object[] {historico[i].Id_atendimento, historico[i].Nome, historico[i].Horario.ToString("d"),
                            historico[i].Horario.ToString("t"), historico[i].Convenio_atendimento, historico[i].Avaliacao,
                            historico[i].Condutas});

                    }
                }

                dgHistorico.DataSource = dt;
            }

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
    }
}
