namespace PRONTU
{
    partial class Relatorios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGerar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPaciente = new System.Windows.Forms.ComboBox();
            this.dpDataInicial = new System.Windows.Forms.DateTimePicker();
            this.dpDataFinal = new System.Windows.Forms.DateTimePicker();
            this.gbAtendimento = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbLaudo = new System.Windows.Forms.RadioButton();
            this.rbAtendimentos = new System.Windows.Forms.RadioButton();
            this.gbTipos = new System.Windows.Forms.GroupBox();
            this.gbLaudo = new System.Windows.Forms.GroupBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbAtendimento.SuspendLayout();
            this.gbTipos.SuspendLayout();
            this.gbLaudo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGerar
            // 
            this.btnGerar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnGerar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerar.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerar.ForeColor = System.Drawing.Color.White;
            this.btnGerar.Location = new System.Drawing.Point(1009, 36);
            this.btnGerar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(149, 48);
            this.btnGerar.TabIndex = 20;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = false;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 21;
            this.label1.Text = "Paciente:";
            // 
            // cbPaciente
            // 
            this.cbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaciente.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPaciente.FormattingEnabled = true;
            this.cbPaciente.Location = new System.Drawing.Point(118, 39);
            this.cbPaciente.Name = "cbPaciente";
            this.cbPaciente.Size = new System.Drawing.Size(427, 26);
            this.cbPaciente.TabIndex = 25;
            // 
            // dpDataInicial
            // 
            this.dpDataInicial.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDataInicial.Location = new System.Drawing.Point(118, 87);
            this.dpDataInicial.Name = "dpDataInicial";
            this.dpDataInicial.Size = new System.Drawing.Size(119, 27);
            this.dpDataInicial.TabIndex = 26;
            // 
            // dpDataFinal
            // 
            this.dpDataFinal.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDataFinal.Location = new System.Drawing.Point(424, 85);
            this.dpDataFinal.Name = "dpDataFinal";
            this.dpDataFinal.Size = new System.Drawing.Size(121, 27);
            this.dpDataFinal.TabIndex = 27;
            // 
            // gbAtendimento
            // 
            this.gbAtendimento.Controls.Add(this.label3);
            this.gbAtendimento.Controls.Add(this.dpDataFinal);
            this.gbAtendimento.Controls.Add(this.label2);
            this.gbAtendimento.Controls.Add(this.label1);
            this.gbAtendimento.Controls.Add(this.cbPaciente);
            this.gbAtendimento.Controls.Add(this.dpDataInicial);
            this.gbAtendimento.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAtendimento.Location = new System.Drawing.Point(12, 272);
            this.gbAtendimento.Name = "gbAtendimento";
            this.gbAtendimento.Size = new System.Drawing.Size(1176, 137);
            this.gbAtendimento.TabIndex = 28;
            this.gbAtendimento.TabStop = false;
            this.gbAtendimento.Text = "Informe os dados do atendimento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 18);
            this.label3.TabIndex = 28;
            this.label3.Text = "Data final:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 18);
            this.label2.TabIndex = 27;
            this.label2.Text = "Data inicial:";
            // 
            // rbLaudo
            // 
            this.rbLaudo.AutoSize = true;
            this.rbLaudo.Checked = true;
            this.rbLaudo.Location = new System.Drawing.Point(11, 45);
            this.rbLaudo.Name = "rbLaudo";
            this.rbLaudo.Size = new System.Drawing.Size(75, 22);
            this.rbLaudo.TabIndex = 0;
            this.rbLaudo.TabStop = true;
            this.rbLaudo.Text = "Laudo";
            this.rbLaudo.UseVisualStyleBackColor = true;
            this.rbLaudo.CheckedChanged += new System.EventHandler(this.CheckedChangedTipo);
            // 
            // rbAtendimentos
            // 
            this.rbAtendimentos.AutoSize = true;
            this.rbAtendimentos.Location = new System.Drawing.Point(11, 88);
            this.rbAtendimentos.Name = "rbAtendimentos";
            this.rbAtendimentos.Size = new System.Drawing.Size(245, 22);
            this.rbAtendimentos.TabIndex = 1;
            this.rbAtendimentos.Text = "Relatório de atendimentos";
            this.rbAtendimentos.UseVisualStyleBackColor = true;
            this.rbAtendimentos.CheckedChanged += new System.EventHandler(this.CheckedChangedTipo);
            // 
            // gbTipos
            // 
            this.gbTipos.Controls.Add(this.rbAtendimentos);
            this.gbTipos.Controls.Add(this.rbLaudo);
            this.gbTipos.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTipos.Location = new System.Drawing.Point(12, 99);
            this.gbTipos.Name = "gbTipos";
            this.gbTipos.Size = new System.Drawing.Size(1177, 137);
            this.gbTipos.TabIndex = 1;
            this.gbTipos.TabStop = false;
            this.gbTipos.Text = "Selecione o tipo de relatório";
            // 
            // gbLaudo
            // 
            this.gbLaudo.Controls.Add(this.txtTitulo);
            this.gbLaudo.Controls.Add(this.txtDiagnostico);
            this.gbLaudo.Controls.Add(this.label5);
            this.gbLaudo.Controls.Add(this.label4);
            this.gbLaudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLaudo.Location = new System.Drawing.Point(12, 239);
            this.gbLaudo.Name = "gbLaudo";
            this.gbLaudo.Size = new System.Drawing.Size(1176, 382);
            this.gbLaudo.TabIndex = 29;
            this.gbLaudo.TabStop = false;
            this.gbLaudo.Text = "Informe os dados do Laudo";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(12, 55);
            this.txtTitulo.MaxLength = 50;
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(1149, 26);
            this.txtTitulo.TabIndex = 2;
            // 
            // txtDiagnostico
            // 
            this.txtDiagnostico.Location = new System.Drawing.Point(12, 123);
            this.txtDiagnostico.MaxLength = 1000;
            this.txtDiagnostico.Multiline = true;
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiagnostico.Size = new System.Drawing.Size(1149, 244);
            this.txtDiagnostico.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Título:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Diagnóstico:";
            // 
            // Relatorios
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1204, 776);
            this.Controls.Add(this.gbLaudo);
            this.Controls.Add(this.gbAtendimento);
            this.Controls.Add(this.btnGerar);
            this.Controls.Add(this.gbTipos);
            this.Name = "Relatorios";
            this.Text = "Relatorios";
            this.gbAtendimento.ResumeLayout(false);
            this.gbAtendimento.PerformLayout();
            this.gbTipos.ResumeLayout(false);
            this.gbTipos.PerformLayout();
            this.gbLaudo.ResumeLayout(false);
            this.gbLaudo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpDataInicial;
        private System.Windows.Forms.DateTimePicker dpDataFinal;
        private System.Windows.Forms.GroupBox gbAtendimento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbLaudo;
        private System.Windows.Forms.RadioButton rbAtendimentos;
        private System.Windows.Forms.GroupBox gbTipos;
        protected System.Windows.Forms.Button btnGerar;
        public System.Windows.Forms.ComboBox cbPaciente;
        private System.Windows.Forms.GroupBox gbLaudo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}