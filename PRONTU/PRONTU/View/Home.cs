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

        private bool telaMax = false;

        public Home()
        {
            InitializeComponent();
            AbrirFormNoPanel<LogoHome>();
        }

        private void AbrirFormNoPanel<Forms>() where Forms : Form, new()
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
            AbrirFormNoPanel<PacientesPesquisar>();
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Agenda>();
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
            AbrirFormNoPanel<Ajustes>();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
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
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelCabecalho_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                RelapseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
