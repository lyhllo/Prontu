namespace PRONTU
{
    partial class Agenda
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
            this.calendario = new System.Windows.Forms.MonthCalendar();
            this.btnCadastro = new System.Windows.Forms.Button();
            this.btnRemoverAgendamento = new System.Windows.Forms.Button();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnAtender = new System.Windows.Forms.Button();
            this.btnFalta = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clConvenio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clObs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // calendario
            // 
            this.calendario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calendario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calendario.Location = new System.Drawing.Point(29, 27);
            this.calendario.Name = "calendario";
            this.calendario.ShowTodayCircle = false;
            this.calendario.TabIndex = 0;
            this.calendario.TitleBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.calendario.TrailingForeColor = System.Drawing.SystemColors.InactiveCaption;
            // 
            // btnCadastro
            // 
            this.btnCadastro.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCadastro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadastro.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCadastro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCadastro.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCadastro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastro.Font = new System.Drawing.Font("Noto Sans Arabic UI", 10.8F);
            this.btnCadastro.Location = new System.Drawing.Point(22, 438);
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.Size = new System.Drawing.Size(134, 103);
            this.btnCadastro.TabIndex = 2;
            this.btnCadastro.Text = "Editar cadastro";
            this.btnCadastro.UseVisualStyleBackColor = false;
            // 
            // btnRemoverAgendamento
            // 
            this.btnRemoverAgendamento.BackColor = System.Drawing.Color.Gainsboro;
            this.btnRemoverAgendamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoverAgendamento.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnRemoverAgendamento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRemoverAgendamento.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnRemoverAgendamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoverAgendamento.Font = new System.Drawing.Font("Noto Sans Arabic UI", 10.8F);
            this.btnRemoverAgendamento.Location = new System.Drawing.Point(207, 438);
            this.btnRemoverAgendamento.Name = "btnRemoverAgendamento";
            this.btnRemoverAgendamento.Size = new System.Drawing.Size(131, 103);
            this.btnRemoverAgendamento.TabIndex = 3;
            this.btnRemoverAgendamento.Text = "Remover da Agenda";
            this.btnRemoverAgendamento.UseVisualStyleBackColor = false;
            this.btnRemoverAgendamento.Click += new System.EventHandler(this.btnRemoverAgendamento_Click);
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPagar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnPagar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPagar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.Font = new System.Drawing.Font("Noto Sans Arabic UI", 10.8F);
            this.btnPagar.Location = new System.Drawing.Point(103, 327);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(134, 71);
            this.btnPagar.TabIndex = 4;
            this.btnPagar.Text = "Pago";
            this.btnPagar.UseVisualStyleBackColor = false;
            // 
            // btnAtender
            // 
            this.btnAtender.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAtender.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtender.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnAtender.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAtender.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAtender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtender.Font = new System.Drawing.Font("Noto Sans Arabic UI", 10.8F);
            this.btnAtender.Location = new System.Drawing.Point(207, 590);
            this.btnAtender.Name = "btnAtender";
            this.btnAtender.Size = new System.Drawing.Size(134, 103);
            this.btnAtender.TabIndex = 5;
            this.btnAtender.Text = "Atender";
            this.btnAtender.UseVisualStyleBackColor = false;
            this.btnAtender.Click += new System.EventHandler(this.btnAtender_Click);
            // 
            // btnFalta
            // 
            this.btnFalta.BackColor = System.Drawing.Color.Gainsboro;
            this.btnFalta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFalta.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnFalta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFalta.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnFalta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFalta.Font = new System.Drawing.Font("Noto Sans Arabic UI", 10.8F);
            this.btnFalta.Location = new System.Drawing.Point(22, 590);
            this.btnFalta.Name = "btnFalta";
            this.btnFalta.Size = new System.Drawing.Size(134, 103);
            this.btnFalta.TabIndex = 6;
            this.btnFalta.Text = "Registrar Falta";
            this.btnFalta.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clHora,
            this.clPaciente,
            this.clDocumento,
            this.clConvenio,
            this.clObs});
            this.dataGridView1.Location = new System.Drawing.Point(397, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(750, 954);
            this.dataGridView1.TabIndex = 7;
            // 
            // clHora
            // 
            this.clHora.HeaderText = "Hora";
            this.clHora.MinimumWidth = 6;
            this.clHora.Name = "clHora";
            this.clHora.Width = 90;
            // 
            // clPaciente
            // 
            this.clPaciente.HeaderText = "Paciente";
            this.clPaciente.MinimumWidth = 6;
            this.clPaciente.Name = "clPaciente";
            this.clPaciente.Width = 300;
            // 
            // clDocumento
            // 
            this.clDocumento.HeaderText = "Documento";
            this.clDocumento.MinimumWidth = 6;
            this.clDocumento.Name = "clDocumento";
            this.clDocumento.Width = 90;
            // 
            // clConvenio
            // 
            this.clConvenio.HeaderText = "Convênio";
            this.clConvenio.MinimumWidth = 6;
            this.clConvenio.Name = "clConvenio";
            this.clConvenio.Width = 90;
            // 
            // clObs
            // 
            this.clObs.HeaderText = "Observações";
            this.clObs.MinimumWidth = 6;
            this.clObs.Name = "clObs";
            this.clObs.Width = 300;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Sans Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(20, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 42);
            this.label1.TabIndex = 8;
            this.label1.Text = "Valor: R$ ";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Noto Naskh Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(169, 268);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 42);
            this.textBox1.TabIndex = 9;
            // 
            // Agenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 1012);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnFalta);
            this.Controls.Add(this.btnAtender);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.btnRemoverAgendamento);
            this.Controls.Add(this.btnCadastro);
            this.Controls.Add(this.calendario);
            this.Name = "Agenda";
            this.Text = "Agenda";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calendario;
        private System.Windows.Forms.Button btnCadastro;
        private System.Windows.Forms.Button btnRemoverAgendamento;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnAtender;
        private System.Windows.Forms.Button btnFalta;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn clConvenio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clObs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}