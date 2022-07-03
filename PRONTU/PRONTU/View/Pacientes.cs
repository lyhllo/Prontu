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

namespace PRONTU.View
{
    public partial class Pacientes : Form
    {
        public Home homeReferencia { get; set; }
        public DateTime? horario { get; set; }
        public int? idPaciente { get; set; }
        public string situacaoCadastro { get; set; }
        private PacientesPesquisar formularioPesquisar;
        private PacientesHistorico formularioHistorico;
        private PacientesAgendamentos formularioAgendamentos;
        private PacienteCadastro formularioCadastro;
        public Pacientes()
        {
            InitializeComponent();
        }

        public void AbrirPacientesPesquisar(bool _selecionar, Agenda _agenda)
        {
            formularioPesquisar = panelPaciente.Controls.OfType<PacientesPesquisar>().FirstOrDefault();

            if (formularioPesquisar == null)
            {
                formularioPesquisar = new PacientesPesquisar
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                panelPaciente.Controls.Add(formularioPesquisar);
                panelPaciente.Tag = formularioPesquisar;
                formularioPesquisar.pacientesReferencia = this;
                formularioPesquisar.selecionar = _selecionar;
                formularioPesquisar.CarregarPacientes();
                if (_selecionar)
                {
                    situacaoCadastro = "selecionar";
                    btnSelecionar.Text = "Selecionar";
                    btnSelecionar.Visible = true;
                    formularioPesquisar.horario = horario.Value;
                    formularioPesquisar.agendaReferencia = _agenda;
                    formularioPesquisar.lblHorario.Visible = true;
                    formularioPesquisar.txtHorario.Visible = true;
                    formularioPesquisar.txtHorario.Text = horario.Value.ToString("t");
                    MostrarBotoes(false);
                    homeReferencia.HabilitaBotoes(false);
                }
                else
                {
                    situacaoCadastro = "buscar";
                    btnBuscar.Visible = true;
                    btnSelecionar.Visible = false;
                    formularioPesquisar.lblHorario.Visible = false;
                    formularioPesquisar.txtHorario.Visible = false;
                    horario = null;
                    MostrarBotoes(true);
                    homeReferencia.HabilitaBotoes(true);
                }
                
                formularioPesquisar.Show();
                formularioPesquisar.BringToFront();
            }
            else
            {
                if (formularioPesquisar.WindowState == FormWindowState.Minimized)
                    formularioPesquisar.WindowState = FormWindowState.Normal;

                formularioPesquisar.pacientesReferencia = this;
                formularioPesquisar.selecionar = _selecionar;
                formularioPesquisar.CarregarPacientes();
                if (_selecionar)
                {
                    situacaoCadastro = "selecionar";
                    btnSelecionar.Text = "Selecionar";
                    btnSelecionar.Visible = true;
                    formularioPesquisar.horario = horario.Value;
                    formularioPesquisar.agendaReferencia = _agenda;
                    formularioPesquisar.lblHorario.Visible = true;
                    formularioPesquisar.txtHorario.Visible = true;
                    formularioPesquisar.txtHorario.Text = horario.Value.ToString("t");
                    MostrarBotoes(false);
                    homeReferencia.HabilitaBotoes(false);
                }
                else
                {
                    situacaoCadastro = "buscar";
                    btnBuscar.Visible = true;
                    btnSelecionar.Visible = false;
                    formularioPesquisar.lblHorario.Visible = false;
                    formularioPesquisar.txtHorario.Visible = false;
                    horario = null;
                    MostrarBotoes(true);
                    homeReferencia.HabilitaBotoes(true);
                }
                btnSelecionar.Enabled = true;
                formularioPesquisar.BringToFront();


            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            btnSelecionar.Visible = false;
            btnCancelar.Text = "Voltar";
            AbrirPacientesPesquisar(false, null);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            homeReferencia.HabilitaBotoes(true);
            btnSelecionar.Visible = false;
            if (situacaoCadastro == "selecionar" || situacaoCadastro == "buscar")
            {
                this.Close();
            }
            else
            {
                AbrirPacientesPesquisar(false, null);
            }
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
            if (situacaoCadastro == "selecionar")
            {
                if (formularioPesquisar.AgendarPaciente())
                {
                    homeReferencia.HabilitaBotoes(true);
                    btnSelecionar.Visible = false;
                    this.Close();
                }
            }
            
            if (situacaoCadastro == "incluir")
            {
                formularioCadastro.cadastro = new CadastroModel();
                if (formularioCadastro.SalvarPaciente())
                {
                    homeReferencia.HabilitaBotoes(true);
                    btnSelecionar.Visible = false;
                    AbrirPacientesPesquisar(false, null);
                }
            }

            if (situacaoCadastro == "editar")
            {
                if (formularioCadastro.EditarPaciente())
                {
                    homeReferencia.HabilitaBotoes(true);
                    btnSelecionar.Visible = false;
                    AbrirPacientesPesquisar(false, null);
                }
            }

            if (situacaoCadastro == "editarAgenda")
            {
                if (formularioCadastro.EditarPaciente())
                {
                    homeReferencia.HabilitaBotoes(true);
                    btnSelecionar.Visible = false;
                    this.Close();
                }
            }
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            btnCancelar.Text = "Voltar";
            int _idPcte = formularioPesquisar.SelecionaIdPcteSelecionado();
            if (_idPcte > 0)
            {
                AbrirPacientesHistorico(_idPcte);
            }
            else
            {
                MessageBox.Show("Selecione um paciente para pesquisar o histórico", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void AbrirPacientesHistorico(int _idPaciente)
        {
            btnCancelar.Text = "Voltar";
            formularioHistorico = panelPaciente.Controls.OfType<PacientesHistorico>().FirstOrDefault();

            if (formularioHistorico == null)
            {
                formularioHistorico = new PacientesHistorico
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                panelPaciente.Controls.Add(formularioHistorico);
                panelPaciente.Tag = formularioHistorico;
                formularioHistorico.pacientesReferencia = this;
                formularioHistorico.CarregarPacientes(_idPaciente);
                formularioHistorico.Show();
                formularioHistorico.BringToFront();
            }
            else
            {
                if (formularioHistorico.WindowState == FormWindowState.Minimized)
                    formularioHistorico.WindowState = FormWindowState.Normal;

                formularioHistorico.pacientesReferencia = this;
                formularioHistorico.CarregarPacientes(_idPaciente);
                formularioHistorico.BringToFront();
            }
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            int _idPcte = formularioPesquisar.SelecionaIdPcteSelecionado();
            if (_idPcte > 0)
            {
                AbrirPacientesAgendamentos(_idPcte);
            }
            else
            {
                MessageBox.Show("Selecione um paciente para pesquisar os agendamentos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AbrirPacientesAgendamentos(int _idPaciente)
        {
            formularioAgendamentos = panelPaciente.Controls.OfType<PacientesAgendamentos>().FirstOrDefault();

            if (formularioAgendamentos == null)
            {
                formularioAgendamentos = new PacientesAgendamentos
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                panelPaciente.Controls.Add(formularioAgendamentos);
                panelPaciente.Tag = formularioAgendamentos;
                formularioAgendamentos.pacientesReferencia = this;
                formularioAgendamentos.CarregarAtendimentos(_idPaciente);
                formularioAgendamentos.Show();
                formularioAgendamentos.BringToFront();
            }
            else
            {
                if (formularioAgendamentos.WindowState == FormWindowState.Minimized)
                    formularioAgendamentos.WindowState = FormWindowState.Normal;

                formularioAgendamentos.pacientesReferencia = this;
                formularioAgendamentos.CarregarAtendimentos(_idPaciente);
                formularioAgendamentos.BringToFront();
            }
        }

        public void FormataBotoes(string _janela)
        {
            if (_janela == "pesquisar")
            {
                btnBuscar.BackColor = Color.Goldenrod;
            }
            else
            {
                btnBuscar.BackColor = Color.DarkSlateGray;
            }

            if (_janela == "editar")
            {
                btnEditar.BackColor = Color.Goldenrod;
            }
            else
            {
                btnEditar.BackColor = Color.DarkSlateGray;
            }

            if (_janela == "excluir")
            {
                btnExcluir.BackColor = Color.Goldenrod;
            }
            else
            {
                btnExcluir.BackColor = Color.DarkSlateGray;
            }

            if (_janela == "incluir")
            {
                btnIncluir.BackColor = Color.Goldenrod;
            }
            else
            {
                btnIncluir.BackColor = Color.DarkSlateGray;
            }

            if (_janela == "historico")
            {
                btnHistorico.BackColor = Color.Goldenrod;
            }
            else
            {
                btnHistorico.BackColor = Color.DarkSlateGray;
            }

            if (_janela == "agendamentos")
            {
                btnAgenda.BackColor = Color.Goldenrod;
            }
            else
            {
                btnAgenda.BackColor = Color.DarkSlateGray;
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            CadastroModel model = new CadastroModel();
            situacaoCadastro = "incluir";
            btnCancelar.Text = "Cancelar";
            btnSelecionar.Text = "Salvar";
            btnSelecionar.Visible = true;
            AbrirPacientesCadastro(model);
        }

        private void AbrirPacientesCadastro(CadastroModel _cadastroPaciente)
        {
            FormataBotoes(situacaoCadastro);
            formularioCadastro = panelPaciente.Controls.OfType<PacienteCadastro>().FirstOrDefault();

            if (formularioCadastro == null)
            {
                formularioCadastro = new PacienteCadastro
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                panelPaciente.Controls.Add(formularioCadastro);
                panelPaciente.Tag = formularioCadastro;
                formularioCadastro.pacientesReferencia = this;
                formularioCadastro.CarregarCadastro(_cadastroPaciente);
                homeReferencia.HabilitaBotoes(false);
                formularioCadastro.Show();
                formularioCadastro.BringToFront();
            }
            else
            {
                if (formularioCadastro.WindowState == FormWindowState.Minimized)
                    formularioCadastro.WindowState = FormWindowState.Normal;

                formularioCadastro.pacientesReferencia = this;
                formularioCadastro.CarregarCadastro(_cadastroPaciente);
                homeReferencia.HabilitaBotoes(false);
                formularioCadastro.BringToFront();
            }
            if (situacaoCadastro == "editar")
            {
                btnBuscar.Visible = false;
                btnExcluir.Visible = false;
                btnIncluir.Visible = false;
                btnHistorico.Visible = false;
                btnAgenda.Visible = false;
            }

            if (situacaoCadastro == "excluir")
            {
                btnBuscar.Visible = false;
                btnEditar.Visible = false;
                btnIncluir.Visible = false;
                btnHistorico.Visible = false;
                btnAgenda.Visible = false;
            }

            if (situacaoCadastro == "incluir")
            {
                btnBuscar.Visible = false;
                btnEditar.Visible = false;
                btnExcluir.Visible = false;
                btnHistorico.Visible = false;
                btnAgenda.Visible = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            situacaoCadastro = "editar";
            btnSelecionar.Text = "Salvar";
            btnSelecionar.Visible = true;
            CadastroModel _cadastroPaciente = formularioPesquisar.SelecionaCadastroSelecionado();

            if (_cadastroPaciente.Id_Paciente > 0)
            {
                AbrirPacientesCadastro(_cadastroPaciente);
            }
            else
            {
                MessageBox.Show("Selecione um paciente para editar o cadastro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            situacaoCadastro = "excluir";
            CadastroModel _cadastroPaciente = formularioPesquisar.SelecionaCadastroSelecionado();

            if (_cadastroPaciente.Id_Paciente > 0)
            {
                AbrirPacientesCadastro(_cadastroPaciente);
                formularioCadastro.ExcluirPaciente(_cadastroPaciente.Id_Paciente);
                AbrirPacientesPesquisar(false, null);
            }
            else
            {
                MessageBox.Show("Selecione um paciente para excluir o cadastro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AbrirPacientesPesquisar(false, null);
            }
        }
    }
}
