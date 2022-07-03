using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRONTU.Controller.AjustesController;
using PRONTU.Model;



namespace PRONTU
{
    public partial class Ajustes : Form
    {

        AjustesController ajustesController = new AjustesController();

        public Ajustes()
        {
            InitializeComponent();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            AjustesModel _ajustes = new AjustesModel();
            //ajustes.formato_minutos();


            ajustesController.BuscarAjustesUsuario(1);
            Form lista = new Form();
            lista.Show();


            //ajustesController.AtualizarAjustesUsuario();






            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja salvar as alterações?",
                           "Salvar", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
               /* bool _res = ajustesController.AtualizarAjustesUsuario();
                if (_res)
                {
                    MessageBox.Show("Ajustes salvos com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizarAjustes();
                }
                else
                {
                    MessageBox.Show("Não foi possível salvar as alterações de ajustes", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/

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

    }
}
