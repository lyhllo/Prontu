namespace PRONTU
{
    partial class PacientesPesquisar
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
            this.dgPacientes = new System.Windows.Forms.DataGridView();
            this.clNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDtNasc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clConvenio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTelefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clObservacoes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgPacientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPacientes
            // 
            this.dgPacientes.AllowUserToAddRows = false;
            this.dgPacientes.AllowUserToDeleteRows = false;
            this.dgPacientes.AllowUserToResizeColumns = false;
            this.dgPacientes.AllowUserToResizeRows = false;
            this.dgPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clNome,
            this.clDtNasc,
            this.clConvenio,
            this.clTelefone,
            this.clEmail,
            this.clObservacoes});
            this.dgPacientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgPacientes.Location = new System.Drawing.Point(12, 187);
            this.dgPacientes.MultiSelect = false;
            this.dgPacientes.Name = "dgPacientes";
            this.dgPacientes.ReadOnly = true;
            this.dgPacientes.RowHeadersVisible = false;
            this.dgPacientes.RowHeadersWidth = 51;
            this.dgPacientes.RowTemplate.Height = 24;
            this.dgPacientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPacientes.Size = new System.Drawing.Size(1178, 569);
            this.dgPacientes.TabIndex = 0;
            // 
            // clNome
            // 
            this.clNome.HeaderText = "Nome";
            this.clNome.MinimumWidth = 6;
            this.clNome.Name = "clNome";
            this.clNome.ReadOnly = true;
            this.clNome.Width = 275;
            // 
            // clDtNasc
            // 
            this.clDtNasc.HeaderText = "Data de Nascimento";
            this.clDtNasc.MinimumWidth = 6;
            this.clDtNasc.Name = "clDtNasc";
            this.clDtNasc.ReadOnly = true;
            this.clDtNasc.Width = 125;
            // 
            // clConvenio
            // 
            this.clConvenio.HeaderText = "Convênio";
            this.clConvenio.MinimumWidth = 6;
            this.clConvenio.Name = "clConvenio";
            this.clConvenio.ReadOnly = true;
            this.clConvenio.Width = 125;
            // 
            // clTelefone
            // 
            this.clTelefone.HeaderText = "Telefone";
            this.clTelefone.MinimumWidth = 6;
            this.clTelefone.Name = "clTelefone";
            this.clTelefone.ReadOnly = true;
            this.clTelefone.Width = 150;
            // 
            // clEmail
            // 
            this.clEmail.HeaderText = "E-mail";
            this.clEmail.MinimumWidth = 6;
            this.clEmail.Name = "clEmail";
            this.clEmail.ReadOnly = true;
            this.clEmail.Width = 150;
            // 
            // clObservacoes
            // 
            this.clObservacoes.HeaderText = "Observações";
            this.clObservacoes.MinimumWidth = 6;
            this.clObservacoes.Name = "clObservacoes";
            this.clObservacoes.ReadOnly = true;
            this.clObservacoes.Width = 350;
            // 
            // PacientesPesquisar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1202, 768);
            this.Controls.Add(this.dgPacientes);
            this.Name = "PacientesPesquisar";
            this.Text = "PacientesPesquisar";
            this.Load += new System.EventHandler(this.PacientesPesquisar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPacientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPacientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDtNasc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clConvenio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTelefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn clEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn clObservacoes;
    }
}