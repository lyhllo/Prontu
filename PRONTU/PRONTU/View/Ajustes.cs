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



namespace PRONTU
{
    public partial class Ajustes : Form
    {
        public Home homeRef { get; set; }
        AjustesController ajustesController = new AjustesController();

        public Ajustes()
        {
            InitializeComponent();
        }

        public void carregarAjustes()//carrega as informações que constam no banco
        {
            AjustesModel _ajustesModel = ajustesController.BuscarAjustesUsuario(1);
            cbDuracao.Text = _ajustesModel.formato_minutos.ToString();

            if (_ajustesModel.marcador_comparecimento == true)
                rbComparecimentoSIM.Checked = true;
            else
                rbComparecimento_NAO.Checked = true;

           if (_ajustesModel.marcador_pagamento == true)
                rbPagamento_SIM.Checked = true;
            else
                rbPagamento_NAO.Checked = true;

            if (_ajustesModel.mostrar_valor == true)
                rbValor_SIM.Checked = true;
            else
                rbValor_NAO.Checked = true;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            AjustesModel _ajustes = new AjustesModel();

            _ajustes.id_agenda = 1;
            _ajustes.id_usuario = 1;
            _ajustes.formato_minutos = int.Parse(cbDuracao.Text);

            if (rbComparecimentoSIM.Checked)
                _ajustes.marcador_comparecimento = true;
            else
                _ajustes.marcador_comparecimento = false;

            if (rbPagamento_SIM.Checked)
                _ajustes.marcador_pagamento = true;
            else
                _ajustes.marcador_pagamento = false;

            if (rbValor_SIM.Checked)
                _ajustes.mostrar_valor = true;
            else
                _ajustes.mostrar_valor = false;


            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja salvar as alterações?",
                           "Ajustes", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
               bool _res = ajustesController.AtualizarAjustesUsuario(_ajustes);
                if (_res)
                {
                    MessageBox.Show("Ajustes salvos com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    homeRef.AbrirLogo();
                }

                else
                {
                    MessageBox.Show("Não foi possível salvar as alterações de ajustes", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }



        private void marcador_comparecimento_SIM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void marcador_comparecimento_NAO_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void marcador_atendimento_SIM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void marcador_atendimento_NAO_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void marcador_pagamento_SIM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void marcador_pagamento_NAO_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mostrar_valor_SIM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mostrar_valor_NAO_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
