using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PRONTU.Model;
using PRONTU.View;

namespace PRONTU
{
    public partial class Home : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool RelapseCapture();
        public DateTime diaHora { get; set; }
        public int id_pcte { get; set; }

        public Home()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            AbrirFormNoPanel<LogoHome>();
        }

        protected void AbrirFormNoPanel<Forms>() where Forms : Form, new()
        {
            Form formulario;
            formulario = panelConteudo.Controls.OfType<Forms>().FirstOrDefault();
            
            if (formulario == null)
            {
                formulario = new Forms();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelConteudo.Controls.Add(formulario);
                panelConteudo.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                if (formulario.WindowState == FormWindowState.Minimized)
                    formulario.WindowState = FormWindowState.Normal;
                formulario.BringToFront();
            }
        }


        private void Home_Load(object sender, EventArgs e)
        {
            
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<LogoHome>();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            AbrirPacientes(false, null, null);
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            AbrirAgenda(this);
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Relatorios>();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Usuario>();
        }

        private void btnAjustes_Click(object sender, EventArgs e)
        {
            AbrirAjustes();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (!telaMax)
            {
                this.WindowState = FormWindowState.Maximized;
                telaMax = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                telaMax = false;
            }
        }*/

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void AbrirAtendimento(AgendaModel _atendimento, Agenda _agenda)
        {
            Atendimento formulario = panelConteudo.Controls.OfType<Atendimento>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new Atendimento();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelConteudo.Controls.Add(formulario);
                panelConteudo.Tag = formulario;
                formulario.agendaReferencia = _agenda;
                formulario.CarregaTela(_atendimento);
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                if (formulario.WindowState == FormWindowState.Minimized)
                    formulario.WindowState = FormWindowState.Normal;
                formulario.agendaReferencia = _agenda;
                formulario.CarregaTela(_atendimento);
                formulario.BringToFront();
                

            }
        }

        public void AbrirPacientes(bool _selecionar, DateTime? _hora, Agenda _agenda)
        {
            Pacientes formulario = panelConteudo.Controls.OfType<Pacientes>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new Pacientes
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                panelConteudo.Controls.Add(formulario);
                panelConteudo.Tag = formulario;
                formulario.homeReferencia = this;
                formulario.horario = _hora;
                
                formulario.AbrirPacientesPesquisar(_selecionar, _agenda);
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                if (formulario.WindowState == FormWindowState.Minimized)
                    formulario.WindowState = FormWindowState.Normal;
                formulario.homeReferencia = this;
                formulario.horario = _hora;
                formulario.AbrirPacientesPesquisar(_selecionar, _agenda);
                formulario.BringToFront();


            }
        }

        public void AbrirAgenda(Home _home)
        {
            Agenda formulario = panelConteudo.Controls.OfType<Agenda>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new Agenda();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelConteudo.Controls.Add(formulario);
                panelConteudo.Tag = formulario;
                formulario.ReferenciaHome = _home;
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                if (formulario.WindowState == FormWindowState.Minimized)
                    formulario.WindowState = FormWindowState.Normal;
                formulario.BringToFront();
                formulario.ReferenciaHome = _home;
            }
        }

        public void AbrirAjustes()
        {
            Ajustes formulario = panelConteudo.Controls.OfType<Ajustes>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new Ajustes();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelConteudo.Controls.Add(formulario);
                panelConteudo.Tag = formulario;
                
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                if (formulario.WindowState == FormWindowState.Minimized)
                    formulario.WindowState = FormWindowState.Normal;
                formulario.BringToFront();
                
            }
        }

        public void HabilitaBotoes(bool _info)
        {
            btnHome.Enabled = _info;
            btnPacientes.Enabled = _info;
            btnAgenda.Enabled = _info;
            btnRelatorios.Enabled = _info;
            btnUsuario.Enabled = _info;
            btnAjustes.Enabled = _info;
        }
    }
}
