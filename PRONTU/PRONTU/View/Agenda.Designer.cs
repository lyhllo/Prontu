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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.calendario = new System.Windows.Forms.MonthCalendar();
            this.btnCadastro = new System.Windows.Forms.Button();
            this.btnRemoverAgendamento = new System.Windows.Forms.Button();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnAtender = new System.Windows.Forms.Button();
            this.btnFalta = new System.Windows.Forms.Button();
            this.dgHorarios = new System.Windows.Forms.DataGridView();
            this.clIdPcte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clConvenio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clObs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgHorarios)).BeginInit();
            this.SuspendLayout();
            // 
            // calendario
            // 
            this.calendario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calendario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calendario.Location = new System.Drawing.Point(48, 43);
            this.calendario.Name = "calendario";
            this.calendario.ShowTodayCircle = false;
            this.calendario.TabIndex = 0;
            this.calendario.TitleBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.calendario.TrailingForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.calendario.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendario_DateChanged);
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
            this.btnCadastro.Location = new System.Drawing.Point(22, 445);
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.Size = new System.Drawing.Size(134, 103);
            this.btnCadastro.TabIndex = 2;
            this.btnCadastro.Text = "Editar cadastro";
            this.btnCadastro.UseVisualStyleBackColor = false;
            this.btnCadastro.Visible = false;
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
            this.btnRemoverAgendamento.Location = new System.Drawing.Point(186, 302);
            this.btnRemoverAgendamento.Name = "btnRemoverAgendamento";
            this.btnRemoverAgendamento.Size = new System.Drawing.Size(131, 103);
            this.btnRemoverAgendamento.TabIndex = 3;
            this.btnRemoverAgendamento.Text = "Remover Agendamento";
            this.btnRemoverAgendamento.UseVisualStyleBackColor = false;
            this.btnRemoverAgendamento.Visible = false;
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
            this.btnPagar.Location = new System.Drawing.Point(114, 669);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(134, 71);
            this.btnPagar.TabIndex = 4;
            this.btnPagar.Text = "Marcar Pagamento";
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Visible = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
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
            this.btnAtender.Location = new System.Drawing.Point(22, 302);
            this.btnAtender.Name = "btnAtender";
            this.btnAtender.Size = new System.Drawing.Size(134, 103);
            this.btnAtender.TabIndex = 5;
            this.btnAtender.Text = "Agendar";
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
            this.btnFalta.Location = new System.Drawing.Point(183, 445);
            this.btnFalta.Name = "btnFalta";
            this.btnFalta.Size = new System.Drawing.Size(134, 103);
            this.btnFalta.TabIndex = 6;
            this.btnFalta.Text = "Registrar Falta";
            this.btnFalta.UseVisualStyleBackColor = false;
            this.btnFalta.Visible = false;
            this.btnFalta.Click += new System.EventHandler(this.btnFalta_Click);
            // 
            // dgHorarios
            // 
            this.dgHorarios.AllowUserToAddRows = false;
            this.dgHorarios.AllowUserToDeleteRows = false;
            this.dgHorarios.AllowUserToResizeColumns = false;
            this.dgHorarios.AllowUserToResizeRows = false;
            this.dgHorarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgHorarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHorarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clIdPcte,
            this.clHora,
            this.clPaciente,
            this.clDocumento,
            this.clConvenio,
            this.clObs});
            this.dgHorarios.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgHorarios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgHorarios.Location = new System.Drawing.Point(345, 18);
            this.dgHorarios.MultiSelect = false;
            this.dgHorarios.Name = "dgHorarios";
            this.dgHorarios.ReadOnly = true;
            this.dgHorarios.RowHeadersVisible = false;
            this.dgHorarios.RowHeadersWidth = 51;
            this.dgHorarios.RowTemplate.Height = 24;
            this.dgHorarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgHorarios.Size = new System.Drawing.Size(830, 691);
            this.dgHorarios.TabIndex = 7;
            this.dgHorarios.Click += new System.EventHandler(this.SelectionChanged);
            // 
            // clIdPcte
            // 
            this.clIdPcte.HeaderText = "idPaciente";
            this.clIdPcte.MinimumWidth = 6;
            this.clIdPcte.Name = "clIdPcte";
            this.clIdPcte.ReadOnly = true;
            this.clIdPcte.Visible = false;
            this.clIdPcte.Width = 125;
            // 
            // clHora
            // 
            this.clHora.HeaderText = "Hora";
            this.clHora.MinimumWidth = 6;
            this.clHora.Name = "clHora";
            this.clHora.ReadOnly = true;
            this.clHora.Width = 60;
            // 
            // clPaciente
            // 
            this.clPaciente.HeaderText = "Paciente";
            this.clPaciente.MinimumWidth = 6;
            this.clPaciente.Name = "clPaciente";
            this.clPaciente.ReadOnly = true;
            this.clPaciente.Width = 200;
            // 
            // clDocumento
            // 
            this.clDocumento.HeaderText = "Documento";
            this.clDocumento.MinimumWidth = 6;
            this.clDocumento.Name = "clDocumento";
            this.clDocumento.ReadOnly = true;
            this.clDocumento.Width = 125;
            // 
            // clConvenio
            // 
            this.clConvenio.HeaderText = "Convênio";
            this.clConvenio.MinimumWidth = 6;
            this.clConvenio.Name = "clConvenio";
            this.clConvenio.ReadOnly = true;
            this.clConvenio.Width = 90;
            // 
            // clObs
            // 
            this.clObs.HeaderText = "Observações";
            this.clObs.MinimumWidth = 6;
            this.clObs.Name = "clObs";
            this.clObs.ReadOnly = true;
            this.clObs.Width = 385;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Noto Sans Arabic", 12F, System.Drawing.FontStyle.Bold);
            this.lblValor.Location = new System.Drawing.Point(31, 592);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(139, 42);
            this.lblValor.TabIndex = 8;
            this.lblValor.Text = "Valor: R$ ";
            this.lblValor.Visible = false;
            // 
            // txtValor
            // 
            this.txtValor.Font = new System.Drawing.Font("Noto Naskh Arabic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(180, 592);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(132, 42);
            this.txtValor.TabIndex = 9;
            this.txtValor.Visible = false;
            // 
            // Agenda
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1202, 768);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.dgHorarios);
            this.Controls.Add(this.btnFalta);
            this.Controls.Add(this.btnAtender);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.btnRemoverAgendamento);
            this.Controls.Add(this.btnCadastro);
            this.Controls.Add(this.calendario);
            this.Name = "Agenda";
            this.Text = "Agenda";
            ((System.ComponentModel.ISupportInitialize)(this.dgHorarios)).EndInit();
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
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.DataGridView dgHorarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn clIdPcte;
        private System.Windows.Forms.DataGridViewTextBoxColumn clHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn clPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn clConvenio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clObs;
    }
}