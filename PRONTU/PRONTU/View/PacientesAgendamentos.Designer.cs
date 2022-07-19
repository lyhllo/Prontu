namespace PRONTU.View
{
    partial class PacientesAgendamentos
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
            this.lblDataFim = new System.Windows.Forms.Label();
            this.txtDataFim = new System.Windows.Forms.MaskedTextBox();
            this.txtDataInicio = new System.Windows.Forms.MaskedTextBox();
            this.dgAgendamentos = new System.Windows.Forms.DataGridView();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lblDataInicio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgAgendamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDataFim
            // 
            this.lblDataFim.AutoSize = true;
            this.lblDataFim.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataFim.Location = new System.Drawing.Point(276, 29);
            this.lblDataFim.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDataFim.Name = "lblDataFim";
            this.lblDataFim.Size = new System.Drawing.Size(89, 18);
            this.lblDataFim.TabIndex = 17;
            this.lblDataFim.Text = "Data Fim:";
            // 
            // txtDataFim
            // 
            this.txtDataFim.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataFim.Location = new System.Drawing.Point(369, 26);
            this.txtDataFim.Margin = new System.Windows.Forms.Padding(2);
            this.txtDataFim.Mask = "00/00/0000";
            this.txtDataFim.Name = "txtDataFim";
            this.txtDataFim.Size = new System.Drawing.Size(110, 27);
            this.txtDataFim.TabIndex = 16;
            this.txtDataFim.ValidatingType = typeof(System.DateTime);
            this.txtDataFim.Leave += new System.EventHandler(this.ValidaDataFim);
            // 
            // txtDataInicio
            // 
            this.txtDataInicio.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataInicio.Location = new System.Drawing.Point(132, 26);
            this.txtDataInicio.Margin = new System.Windows.Forms.Padding(2);
            this.txtDataInicio.Mask = "00/00/0000";
            this.txtDataInicio.Name = "txtDataInicio";
            this.txtDataInicio.Size = new System.Drawing.Size(110, 27);
            this.txtDataInicio.TabIndex = 15;
            this.txtDataInicio.ValidatingType = typeof(System.DateTime);
            this.txtDataInicio.Leave += new System.EventHandler(this.ValidaDataInicio);
            // 
            // dgAgendamentos
            // 
            this.dgAgendamentos.AllowUserToAddRows = false;
            this.dgAgendamentos.AllowUserToDeleteRows = false;
            this.dgAgendamentos.AllowUserToResizeColumns = false;
            this.dgAgendamentos.AllowUserToResizeRows = false;
            this.dgAgendamentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAgendamentos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAgendamentos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgAgendamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgAgendamentos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgAgendamentos.Location = new System.Drawing.Point(16, 72);
            this.dgAgendamentos.Margin = new System.Windows.Forms.Padding(2);
            this.dgAgendamentos.MultiSelect = false;
            this.dgAgendamentos.Name = "dgAgendamentos";
            this.dgAgendamentos.ReadOnly = true;
            this.dgAgendamentos.RowHeadersVisible = false;
            this.dgAgendamentos.RowHeadersWidth = 51;
            this.dgAgendamentos.RowTemplate.Height = 24;
            this.dgAgendamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAgendamentos.Size = new System.Drawing.Size(872, 488);
            this.dgAgendamentos.TabIndex = 14;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPesquisar.Location = new System.Drawing.Point(739, 12);
            this.btnPesquisar.Margin = new System.Windows.Forms.Padding(2);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(149, 48);
            this.btnPesquisar.TabIndex = 12;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // lblDataInicio
            // 
            this.lblDataInicio.AutoSize = true;
            this.lblDataInicio.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataInicio.Location = new System.Drawing.Point(13, 29);
            this.lblDataInicio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDataInicio.Name = "lblDataInicio";
            this.lblDataInicio.Size = new System.Drawing.Size(105, 18);
            this.lblDataInicio.TabIndex = 13;
            this.lblDataInicio.Text = "Data Início:";
            // 
            // PacientesAgendamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 571);
            this.Controls.Add(this.lblDataFim);
            this.Controls.Add(this.txtDataFim);
            this.Controls.Add(this.txtDataInicio);
            this.Controls.Add(this.dgAgendamentos);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.lblDataInicio);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PacientesAgendamentos";
            this.Text = "PacientesAgendamentos";
            ((System.ComponentModel.ISupportInitialize)(this.dgAgendamentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDataFim;
        private System.Windows.Forms.MaskedTextBox txtDataFim;
        private System.Windows.Forms.MaskedTextBox txtDataInicio;
        private System.Windows.Forms.DataGridView dgAgendamentos;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label lblDataInicio;
    }
}