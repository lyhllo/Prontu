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
    public partial class Agenda : Form
    {
        public Form ReferenciaHome { get; set; }
        public int formatoAgenda { get; set; }
        string dataSelecionada;
        string horaSelecionada = DateTime.Now.Hour.ToString() + " : " + DateTime.Now.Minute.ToString();
        private int linhas;


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
            //_d = DateTime.Today.Date;
            for (int i = 0; i < linhas; i++)
            {
                dgHorarios.Rows[i].Cells[0].Value = _d.ToString("HH:mm");
                _d = _d.AddMinutes(formatoAgenda);
            }
        }

        private void EditaFoco()
        {
            DateTime d = DateTime.Now;
            for (int i = 0;i < dgHorarios.Rows.Count; i++)
            {
                var _horario = dgHorarios.Rows[i].Cells[0].Value.ToString().Split(':');
                DateTime _datahora = calendario.SelectionRange.Start;
                _datahora = _datahora.AddHours(Double.Parse(_horario[0]));
                _datahora = _datahora.AddMinutes(Double.Parse(_horario[1]));
                if (DateTime.Now >= _datahora && DateTime.Now < _datahora.AddMinutes(formatoAgenda))
                {
                    dgHorarios.CurrentCell = dgHorarios.Rows[i].Cells[0];
                    dgHorarios.FirstDisplayedScrollingRowIndex = i;
                }
            }
        }

        private void GetDatas()
        {
            dataSelecionada = calendario.SelectionRange.Start.ToShortDateString();
            horaSelecionada = "14:30";
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRemoverAgendamento_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            Home novo = (Home)ReferenciaHome;
            novo.AbrirAtendimento(DateTime.Now, 1);            
        }

        private void teste()
        {
            
        }

        private void calendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            CarregaHorarios();
            EditaFoco();
        }
    }
}
