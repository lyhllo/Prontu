using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using PRONTU.Controller;
using PRONTU.View;
using PRONTU.Model;

namespace PRONTU
{
    public partial class Login : Form
    {
        Thread nt;
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cpf = textBox1.Text;
            string senha = textBox2.Text;
            bool result = UsuarioController.Login(cpf, senha);
            //bool result = true; // usado para testes

            if (result)
            {
                //MessageBox.Show("Login OK.");
                Close();
                nt = new Thread(startHome);
                nt.SetApartmentState(ApartmentState.STA);
                nt.Start();
            }
            else
            {
                MessageBox.Show("Login inválido.");
            }

        }

        private void startHome()
        {
            Application.Run(new Home());
        }

        private void startEsqueciMinhaSenha()
        {
            Application.Run(new EsqueciMinhaSenha());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            nt = new Thread(startEsqueciMinhaSenha);
            nt.SetApartmentState(ApartmentState.STA);
            nt.Start();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
