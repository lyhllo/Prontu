﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRONTU.Controller;
using PRONTU.Model;

namespace PRONTU
{
    public partial class Atendimento : Form
    {
        public int IdAtendimento { get; set; }
        public int IdProntuario { get; set; }
        public Agenda agendaReferencia { get; set; }

        public Atendimento()
        {
            InitializeComponent();
        }

        public void CarregaTela(AgendaModel atendimento)
        {
            IdAtendimento = atendimento.Id_atendimento;

            if (atendimento.Id_prontuario == null)
            {
                IdProntuario = 0;
            }
            else IdProntuario = atendimento.Id_prontuario.Value;

            txtNome.Text = atendimento.Nome;
            mTextCpf.Text = atendimento.Cpf;
            txtData.Text = atendimento.Horario.ToString("d");
            txtHora.Text = atendimento.Horario.ToString("HH:mm");

            if (atendimento.Dt_nasc != null)
                txtNascimento.Text = atendimento.Dt_nasc.Value.ToString("d");
            else
                txtNascimento.Text = "";

            popularComboBoxConvenio(atendimento.Convenio_atendimento, atendimento.Convenio_pcte);

            txtValorPago.Text = atendimento.Valor_pago.ToString("F2");
            txtAvaliacao.Text = atendimento.Avaliacao;
            txtCondutas.Text = atendimento.Condutas;

            if (atendimento.Pagto is null)
            {
                atendimento.Pagto = false;
            }

            popularComboBoxStatusPagto(atendimento.Pagto.Value);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            AgendaController atendimento = new AgendaController();

            bool _erro = false;

            if (String.IsNullOrEmpty(txtAvaliacao.Text))
            {
                MessageBox.Show("Nenhuma avaliação informada", "Atendimento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _erro = true;
            }

            if (String.IsNullOrEmpty(txtCondutas.Text) & !_erro)
            {
                MessageBox.Show("Nenhuma conduta informada", "Condutas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _erro = true;
            }

            if (!_erro)
            {
                string _convenio = cbConvenio.Text;
                string _valorPago = txtValorPago.Text.Replace(",", ".");
                bool _statusPago = cbStatusPagto.Text == "Sim";
                string _avaliacao = txtAvaliacao.Text;
                string _condutas = txtCondutas.Text;

                if (atendimento.RegistrarAtendimento(IdAtendimento, IdProntuario, _convenio, _valorPago, _statusPago, _avaliacao, _condutas))
                {
                    MessageBox.Show("Atendimento registrado com sucesso!", "Atendimento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao atualizar os dados do atendimento", "Atendimento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (agendaReferencia != null)
                    agendaReferencia.AtualizaHorarios();
                
                Close();
            }
        }

        private void popularComboBoxConvenio(string _convenioAtendimento, string _convenioPaciente)
        {
            cbConvenio.Items.Add("Particular");

            if (_convenioAtendimento != null & !String.Equals(_convenioAtendimento, "Particular"))
            {
                cbConvenio.Items.Add(_convenioAtendimento);
            }

            if (_convenioPaciente != null & !String.Equals(_convenioPaciente, _convenioAtendimento))
            {
                cbConvenio.Items.Add(_convenioPaciente);
            }

            cbConvenio.SelectedIndex = cbConvenio.FindStringExact(_convenioAtendimento);
        }

        private void popularComboBoxStatusPagto(bool _status)
        {
            cbStatusPagto.Items.Add("Sim");
            cbStatusPagto.Items.Add("Não");
 
            if(_status)
            {
                cbStatusPagto.SelectedIndex = cbStatusPagto.FindStringExact("Sim");
            } 
            else cbStatusPagto.SelectedIndex = cbStatusPagto.FindStringExact("Não");
        }
    }
}
