namespace PRONTU.View
{
    partial class PacientesHistorico
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
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lblDataInicio = new System.Windows.Forms.Label();
            this.dgHistorico = new System.Windows.Forms.DataGridView();
            this.txtDataInicio = new System.Windows.Forms.MaskedTextBox();
            this.txtDataFim = new System.Windows.Forms.MaskedTextBox();
            this.lblDataFim = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgHistorico)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(678, 6);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(115, 37);
            this.btnPesquisar.TabIndex = 4;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // lblDataInicio
            // 
            this.lblDataInicio.AutoSize = true;
            this.lblDataInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataInicio.Location = new System.Drawing.Point(22, 12);
            this.lblDataInicio.Name = "lblDataInicio";
            this.lblDataInicio.Size = new System.Drawing.Size(109, 25);
            this.lblDataInicio.TabIndex = 5;
            this.lblDataInicio.Text = "Data Início:";
            // 
            // dgHistorico
            // 
            this.dgHistorico.AllowUserToAddRows = false;
            this.dgHistorico.AllowUserToDeleteRows = false;
            this.dgHistorico.AllowUserToResizeColumns = false;
            this.dgHistorico.AllowUserToResizeRows = false;
            this.dgHistorico.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgHistorico.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHistorico.ColumnHeadersVisible = false;
            this.dgHistorico.Location = new System.Drawing.Point(27, 57);
            this.dgHistorico.MultiSelect = false;
            this.dgHistorico.Name = "dgHistorico";
            this.dgHistorico.ReadOnly = true;
            this.dgHistorico.RowHeadersWidth = 51;
            this.dgHistorico.RowTemplate.Height = 24;
            this.dgHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgHistorico.Size = new System.Drawing.Size(1163, 634);
            this.dgHistorico.TabIndex = 7;
            this.dgHistorico.DoubleClick += new System.EventHandler(this.DetalharAtendimento);
            // 
            // txtDataInicio
            // 
            this.txtDataInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataInicio.Location = new System.Drawing.Point(137, 9);
            this.txtDataInicio.Mask = "00/00/0000";
            this.txtDataInicio.Name = "txtDataInicio";
            this.txtDataInicio.Size = new System.Drawing.Size(112, 30);
            this.txtDataInicio.TabIndex = 9;
            this.txtDataInicio.ValidatingType = typeof(System.DateTime);
            this.txtDataInicio.Leave += new System.EventHandler(this.ValidaDataInicio);
            // 
            // txtDataFim
            // 
            this.txtDataFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataFim.Location = new System.Drawing.Point(483, 9);
            this.txtDataFim.Mask = "00/00/0000";
            this.txtDataFim.Name = "txtDataFim";
            this.txtDataFim.Size = new System.Drawing.Size(112, 30);
            this.txtDataFim.TabIndex = 10;
            this.txtDataFim.ValidatingType = typeof(System.DateTime);
            this.txtDataFim.Leave += new System.EventHandler(this.ValidaDataFim);
            // 
            // lblDataFim
            // 
            this.lblDataFim.AutoSize = true;
            this.lblDataFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataFim.Location = new System.Drawing.Point(379, 12);
            this.lblDataFim.Name = "lblDataFim";
            this.lblDataFim.Size = new System.Drawing.Size(96, 25);
            this.lblDataFim.TabIndex = 11;
            this.lblDataFim.Text = "Data Fim:";
            // 
            // PacientesHistorico
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1202, 703);
            this.Controls.Add(this.lblDataFim);
            this.Controls.Add(this.txtDataFim);
            this.Controls.Add(this.txtDataInicio);
            this.Controls.Add(this.dgHistorico);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.lblDataInicio);
            this.Name = "PacientesHistorico";
            this.Text = "PacientesHistorico";
            ((System.ComponentModel.ISupportInitialize)(this.dgHistorico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label lblDataInicio;
        private System.Windows.Forms.DataGridView dgHistorico;
        private System.Windows.Forms.MaskedTextBox txtDataInicio;
        private System.Windows.Forms.MaskedTextBox txtDataFim;
        private System.Windows.Forms.Label lblDataFim;
    }
}