using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRONTU.Controller;
using PRONTU.Model;
using PRONTU.Controller.AgendaController;
using PRONTU.View;

namespace PRONTU

{
    public partial class PacientesPesquisar : Form
    {
        private PacienteCadastroController controller = new PacienteCadastroController();
        private AgendaController agendaController = new AgendaController();
        private List<CadastroModel> cadastro;
        private DataTable dt = new DataTable();
        public Pacientes pacientesReferencia { get; set; }
        public DateTime horario { get; set; }
        public bool selecionar { get; set; }
        public Agenda agendaReferencia { get; set; }
        
        public PacientesPesquisar()
        {
            InitializeComponent();
        }

        private void PacientesPesquisar_Load(object sender, EventArgs e)
        {
            CarregarPacientes();
        }

        public void CarregarPacientes()
        {
            pacientesReferencia.btnSelecionar.Text = "Selecionar";
            pacientesReferencia.btnSelecionar.Visible = selecionar;
            pacientesReferencia.FormataBotoes("pesquisar");
            
            if (dt.Columns.Count == 0)
            {
                cadastro = controller.BuscaCadastrosPacientes();

                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("Nascimento", typeof(string));
                dt.Columns.Add("Convênio", typeof(string));
                dt.Columns.Add("Telefone", typeof(string));
                dt.Columns.Add("E-mail", typeof(string));
                dt.Columns.Add("Observações", typeof(string));


                if (cadastro != null)
                {
                    for (int i = 0; i < cadastro.Count; i++)
                    {
                        dt.Rows.Add(new object[] {cadastro[i].Id_Paciente, cadastro[i].Nome, cadastro[i].Dt_nasc.Value.ToString("d"),
                                        cadastro[i].Convenio, cadastro[i].Telefone, cadastro[i].Email, cadastro[i].Observacoes});

                    }
                }

                dgPacientes.DataSource = dt;
            }
            
            FormataCelulas();


        }

        private void FormataCelulas()
        {
            dgPacientes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            foreach (DataGridViewColumn column in dgPacientes.Columns)
            {
                if (column.DataPropertyName == "Id")
                    column.Visible = false;

                if (column.DataPropertyName == "Nome")
                    column.Width = 245;

                if (column.DataPropertyName == "Telefone")
                    column.Width = 120;

                if (column.DataPropertyName == "E-mail")
                    column.Width = 250;

                if (column.DataPropertyName == "Observações")
                    column.Width = 365;

                //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            FiltrarGrade();
        }

        private void FiltrarGrade()
        {
            dt.DefaultView.RowFilter = String.Format("[{0}] LIKE '%{1}%'", "Nome", txtNome.Text);
            dgPacientes.DataSource = dt;
        }

        public bool AgendarPaciente()
        {
            if (dgPacientes.SelectedRows.Count > 0)
            {
                int _idPcte = int.Parse(dgPacientes.SelectedCells[0].Value.ToString());
                string _convenio = dgPacientes.SelectedCells[3].Value.ToString();

                if (agendaController.AgendaPaciente(_idPcte, horario, _convenio))
                {
                    MessageBox.Show("Agendamento realizado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selecionar = false;
                    agendaReferencia.AtualizaHorarios();
                    selecionar = false;
                    return true;
                }
                else
                {
                    MessageBox.Show("Não foi possível realizar o agendamento", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Selecione um paciente para agendar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public int SelecionaIdPcteSelecionado()
        {
            if (dgPacientes.SelectedRows.Count > 0)
            {
                return int.Parse(dgPacientes.SelectedCells[0].Value.ToString());
            }
            else
            {
                return 0;
            }
        }
    }
}
