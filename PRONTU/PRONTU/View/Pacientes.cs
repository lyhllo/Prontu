using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRONTU.View
{
    public partial class Pacientes : Form
    {
        public Home homeReferencia { get; set; }
        public DateTime? horario { get; set; }
        public int? idPaciente { get; set; }
        private PacientesPesquisar formulario;
        public Pacientes()
        {
            InitializeComponent();
        }

        public void AbrirPacientesPesquisar(bool _selecionar, Agenda _agenda)
        {
            formulario = panelPaciente.Controls.OfType<PacientesPesquisar>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new PacientesPesquisar
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                panelPaciente.Controls.Add(formulario);
                panelPaciente.Tag = formulario;
                formulario.CarregarPacientes();
                if (_selecionar)
                {
                    formulario.horario = horario.Value;
                    formulario.agendaReferencia = _agenda;
                    formulario.lblHorario.Visible = true;
                    formulario.txtHorario.Visible = true;
                    formulario.txtHorario.Text = horario.Value.ToString("t");
                    MostrarBotoes(false);
                    homeReferencia.HabilitaBotoes(false);

                }
                else
                {
                    formulario.lblHorario.Visible = false;
                    formulario.txtHorario.Visible = false;
                    horario = null;
                    MostrarBotoes(true);
                    homeReferencia.HabilitaBotoes(true);
                }
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                if (formulario.WindowState == FormWindowState.Minimized)
                    formulario.WindowState = FormWindowState.Normal;
                formulario.CarregarPacientes();
                if (_selecionar)
                {
                    formulario.horario = horario.Value;
                    formulario.agendaReferencia = _agenda;
                    formulario.lblHorario.Visible = true;
                    formulario.txtHorario.Visible = true;
                    formulario.txtHorario.Text = horario.Value.ToString("t");
                    MostrarBotoes(false);
                    homeReferencia.HabilitaBotoes(false);
                }
                else
                {
                    formulario.lblHorario.Visible = false;
                    formulario.txtHorario.Visible = false;
                    horario = null;
                    MostrarBotoes(true);
                    homeReferencia.HabilitaBotoes(true);
                }
                formulario.BringToFront();


            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            AbrirPacientesPesquisar(false, null);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            homeReferencia.HabilitaBotoes(true);
            this.Close();
        }

        private void MostrarBotoes(bool _info)
        {
            btnBuscar.Enabled = _info;
            btnEditar.Visible = _info;
            btnExcluir.Visible = _info;
            btnIncluir.Visible = _info;
            btnHistorico.Visible = _info;
            btnAgenda.Visible = _info;
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (formulario.AgendarPaciente())
            {
                homeReferencia.HabilitaBotoes(true);
                this.Close();
            }
                
        }
    }
}
