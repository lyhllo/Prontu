﻿using System;
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
        private string situacaoCadastro;
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
            situacaoCadastro = "buscar";
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
                    formularioPesquisar.horario = horario.Value;
                    formularioPesquisar.agendaReferencia = _agenda;
                    formularioPesquisar.lblHorario.Visible = true;
                    formularioPesquisar.txtHorario.Visible = true;
                    formularioPesquisar.txtHorario.Text = horario.Value.ToString("t");
                }
                else
                {
                    formularioPesquisar.lblHorario.Visible = false;
                    formularioPesquisar.txtHorario.Visible = false;
                    horario = null;
                }
                MostrarBotoes(true);
                homeReferencia.HabilitaBotoes(true);
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
                    formularioPesquisar.horario = horario.Value;
                    formularioPesquisar.agendaReferencia = _agenda;
                    formularioPesquisar.lblHorario.Visible = true;
                    formularioPesquisar.txtHorario.Visible = true;
                    formularioPesquisar.txtHorario.Text = horario.Value.ToString("t");
                }
                else
                {
                    formularioPesquisar.lblHorario.Visible = false;
                    formularioPesquisar.txtHorario.Visible = false;
                    horario = null;
                }
                MostrarBotoes(true);
                homeReferencia.HabilitaBotoes(true);
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
            AbrirPacientesPesquisar(false, null);
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
            if (btnSelecionar.Text == "Selecionar")
            {
                if (formularioPesquisar.AgendarPaciente())
                {
                    homeReferencia.HabilitaBotoes(true);
                    btnSelecionar.Visible = false;
                    AbrirPacientesPesquisar(false, null);
                }
            }
            
            if (situacaoCadastro == "incluir")
            {
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
            situacaoCadastro = "incluir";
            btnCancelar.Text = "Cancelar";
            FormataBotoes("incluir");
            AbrirPacientesCadastro(null);
        }

        private void AbrirPacientesCadastro(CadastroModel _cadastroPaciente)
        {
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
        }
    }
}
