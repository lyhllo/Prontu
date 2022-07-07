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
using PRONTU.Controller;
using PRONTU.View;
using System.Text.RegularExpressions;

namespace PRONTU
{
    public partial class Agenda : Form
    {
        AgendaController agendaController = new AgendaController();
        
        public Home ReferenciaHome { get; set; }
        public Pacientes ReferenciaPacientes { get; set; }
        private int linhas;
        private List<AgendaModel> agenda;
        private AgendaModel atendimento = new AgendaModel();


        public Agenda()
        {
            InitializeComponent();
            linhas = (1440 / Home.ajustesUsuario.formato_minutos);
            AtualizaHorarios();
        }

        public void AtualizaHorarios()
        {
            dgHorarios.Rows.Clear();
            dgHorarios.Rows.Add(linhas);
            CarregaHorarios();
            EditaFoco();
            MudancaSelecao();

        }

        public void CarregaHorarios()
        {
            DateTime _d = calendario.SelectionRange.Start;
            agenda = agendaController.BuscaAgendamentosDoDia(_d);
            for (int i = 0; i < linhas; i++)
            {
                dgHorarios.Rows[i].Cells[0].Value = "0";
                dgHorarios.Rows[i].Cells[1].Value = _d.ToString("HH:mm");

                foreach (AgendaModel agendaModel in agenda)
                {
                    if (agendaModel.Horario == _d)
                    {
                        dgHorarios.Rows[i].Cells[0].Value = agendaModel.Id_pcte;
                        dgHorarios.Rows[i].Cells[2].Value = agendaModel.Nome;
                        dgHorarios.Rows[i].Cells[3].Value = agendaModel.Cpf;
                        dgHorarios.Rows[i].Cells[4].Value = agendaModel.Convenio_atendimento;
                        dgHorarios.Rows[i].Cells[5].Value = agendaModel.Observacoes;
                        MudaCoresPresenca(i, agendaModel.Reg_presenca);
                    }
                }

                _d = _d.AddMinutes(Home.ajustesUsuario.formato_minutos);
            }
        }

        private void MudaCoresPresenca(int _i, bool? _falta)
        {
            if (Home.ajustesUsuario.marcador_comparecimento)
            {
                if (_falta == true)
                {
                    dgHorarios.Rows[_i].Cells[1].Style.BackColor = Color.LightSkyBlue;
                    dgHorarios.Rows[_i].Cells[2].Style.BackColor = Color.LightSkyBlue;
                    dgHorarios.Rows[_i].Cells[3].Style.BackColor = Color.LightSkyBlue;
                    dgHorarios.Rows[_i].Cells[4].Style.BackColor = Color.LightSkyBlue;
                    dgHorarios.Rows[_i].Cells[5].Style.BackColor = Color.LightSkyBlue;
                }

                if (_falta == false)
                {
                    dgHorarios.Rows[_i].Cells[1].Style.BackColor = Color.Red;
                    dgHorarios.Rows[_i].Cells[2].Style.BackColor = Color.Red;
                    dgHorarios.Rows[_i].Cells[3].Style.BackColor = Color.Red;
                    dgHorarios.Rows[_i].Cells[4].Style.BackColor = Color.Red;
                    dgHorarios.Rows[_i].Cells[5].Style.BackColor = Color.Red;
                }

                if (_falta is null)
                {
                    dgHorarios.Rows[_i].Cells[1].Style.BackColor = DefaultBackColor;
                    dgHorarios.Rows[_i].Cells[2].Style.BackColor = DefaultBackColor;
                    dgHorarios.Rows[_i].Cells[3].Style.BackColor = DefaultBackColor;
                    dgHorarios.Rows[_i].Cells[4].Style.BackColor = DefaultBackColor;
                    dgHorarios.Rows[_i].Cells[5].Style.BackColor = DefaultBackColor;
                }
            }
        }

        private void MudaCorPagto(bool? _pagto)
        {
            if (Home.ajustesUsuario.marcador_pagamento)
            {
                if (_pagto == true)
                {
                    btnPagar.BackColor = Color.LightGreen;
                }
                else
                {
                    btnPagar.BackColor = Color.Gainsboro;
                }
            }
        }

        public void EditaFoco()
        {
            DateTime d = calendario.SelectionRange.Start;
            d = d.AddHours(DateTime.Now.Hour);
            d = d.AddMinutes(DateTime.Now.Minute);
            for (int i = 0;i < dgHorarios.Rows.Count; i++)
            {
                var _horario = dgHorarios.Rows[i].Cells[1].Value.ToString().Split(':');
                DateTime _datahora = calendario.SelectionRange.Start;
                _datahora = _datahora.AddHours(Double.Parse(_horario[0]));
                _datahora = _datahora.AddMinutes(Double.Parse(_horario[1]));
                if (d >= _datahora && d < _datahora.AddMinutes(Home.ajustesUsuario.formato_minutos))
                {
                    dgHorarios.CurrentCell = dgHorarios.Rows[i].Cells[1];
                    dgHorarios.FirstDisplayedScrollingRowIndex = i;
                }
            }
            MudancaSelecao();
        }

        public void MudancaSelecao()
        {
            DateTime? _horario;
            if (dgHorarios.SelectedRows.Count > 0)
            {
                _horario = DateTime.Parse(dgHorarios.SelectedCells[1].Value.ToString());
            }
            else
            {
                _horario = null;
            }

            if (_horario is null || agenda.Count == 0)
            {
                mostrar_botoes(false);
            }

            for (int i = 0; i < agenda.Count; i++)
            {
                if (agenda[i].Horario == _horario)
                {
                    atendimento = agenda[i];
                    mostrar_botoes(true);
                    txtValor.Text = atendimento.Valor_pago.ToString("N2");
                    if (atendimento.Pagto == true)
                    {
                        btnPagar.Text = "Desmarcar Pagamento";
                    }
                    else
                    {
                        btnPagar.Text = "Marcar Pagamento";
                    }
                    if (atendimento.Reg_presenca == false)
                    {
                        btnFalta.Text = "Retirar Falta";
                    }
                    else
                    {
                        btnFalta.Text = "Registrar Falta";
                    }
                    if (atendimento.Id_prontuario > 0)
                    {
                        btnRemoverAgendamento.Text = "Remover atendimento";
                        btnFalta.Visible = false;
                    }
                    else
                    {
                        btnRemoverAgendamento.Text = "Remover agendamento";
                        if (Home.ajustesUsuario.marcador_comparecimento)
                            btnFalta.Visible = true;
                    }
                    
                    break;
                }
                else
                {
                    mostrar_botoes(false);
                }
            }
            MudaCorPagto(atendimento.Pagto);
        }

        private void SelectionChanged(object sender, EventArgs e)
        {
            MudancaSelecao();
        }

        private void mostrar_botoes(Boolean _bol)
        {
            if (_bol)
            {
                btnAtender.Text = "Atender";
            }
            else
            {
                btnAtender.Text = "Agendar";
            }
            if (Home.ajustesUsuario.marcador_comparecimento)
                btnFalta.Visible = _bol;
            else
                btnFalta.Visible = false;

            if (Home.ajustesUsuario.mostrar_valor)
            {
                lblValor.Visible = _bol;
                txtValor.Visible = _bol;
            }
            else
            {
                lblValor.Visible = false;
                txtValor.Visible = false;
            }

            if (Home.ajustesUsuario.marcador_pagamento && Home.ajustesUsuario.mostrar_valor)
                btnPagar.Visible = _bol;
            else
                btnPagar.Visible = false;

            btnRemoverAgendamento.Visible = _bol;
        }

        private void btnRemoverAgendamento_Click(object sender, EventArgs e)
        {
            if (atendimento.Id_prontuario > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja remover este atendimento?",
                "Remover atendimento", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    bool _res = agendaController.RemoveAtendimento(atendimento.Id_atendimento, atendimento.Id_prontuario);
                    if (_res)
                    {
                        MessageBox.Show("Atendimento removido com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AtualizaHorarios();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível remover o atendimento", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja remover este agendamento?",
                "Remover agendamento", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    bool _res = agendaController.RemoverAgendamento(atendimento.Id_atendimento);
                    if (_res)
                    {
                        MessageBox.Show("Agendamento removido com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AtualizaHorarios();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível remover o agendamento", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            Home _novo = (Home)ReferenciaHome;
            if (dgHorarios.SelectedCells[0].Value.ToString() == "0")
            {
                var _hora = dgHorarios.SelectedCells[1].Value.ToString().Split(':');
                DateTime _datahora = calendario.SelectionRange.Start;
                _datahora = _datahora.AddHours(Double.Parse(_hora[0]));
                _datahora = _datahora.AddMinutes(Double.Parse(_hora[1]));
                _novo.AbrirPacientes(true, _datahora, this);
            }
            else
            {
                _novo.AbrirAtendimento(atendimento, this);
            }
        }

        private void calendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            AtualizaHorarios();
        }

        private void btnFalta_Click(object sender, EventArgs e)
        {
            if (atendimento.Reg_presenca == null)
            {
                bool _res = agendaController.MudarPresenca(atendimento.Id_atendimento, false);
                if (_res)
                {
                    MessageBox.Show("Falta registrada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizaHorarios();
                }
                else
                {
                    MessageBox.Show("Não foi possível registrar a falta", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                    bool _res = agendaController.MudarPresenca(atendimento.Id_atendimento, null);
                if (_res)
                {
                    MessageBox.Show("Falta retirada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizaHorarios();
                    MudaCoresPresenca(atendimento.Id_atendimento, null);
                }
                else
                {
                    MessageBox.Show("Não foi possível retirar a falta", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            bool _pago;
            if (atendimento.Pagto == false)
            {
                _pago = true;
            }
            else
            {
                _pago = false;
            }

            double _valor = double.Parse(txtValor.Text);

            bool _res = agendaController.RegistrarPagto(atendimento.Id_atendimento, _valor, _pago);

            if (_res)
            {
                MessageBox.Show("Pagamento registrado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AtualizaHorarios();
            }
            else
            {
                MessageBox.Show("Não foi possível registrar o pagamento", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void fechar()
        {
            this.Close();
        }

        // Formata o campo do valor de pagamento conforme digita
        private void FormatarValor(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar.Equals((char)Keys.Back))
            {
                TextBox t = (TextBox)sender;
                string w = Regex.Replace(t.Text, "[^0-9]", string.Empty);
                if (w == string.Empty) w = "00";

                if (e.KeyChar.Equals((char)Keys.Back))
                {
                    w = w.Substring(0, w.Length - 1);
                }
                else
                {
                    w += e.KeyChar;
                }

                t.Text = String.Format("{0:#,##0.00}", Double.Parse(w) / 100);
                t.Select(t.Text.Length, 0);
            }
            e.Handled = true;
        }

        private void SalvaDeletaValor(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                TextBox t = (TextBox)sender;
                t.Text = string.Format("{0:#,##0.00}", 0d);
                t.Select(t.Text.Length, 0);
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                double _valor = double.Parse(txtValor.Text);

                bool _res = agendaController.AlterarValor(atendimento.Id_atendimento, _valor);

                if (_res)
                {
                    MessageBox.Show("Valor alterado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizaHorarios();
                }
                else
                {
                    MessageBox.Show("Não foi possível alterar o valor", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
