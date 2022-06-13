namespace PRONTU.View
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
            this.listaHorarios = new System.Windows.Forms.TableLayoutPanel();
            this.btnCadastro = new System.Windows.Forms.Button();
            this.btnRemoverAgendamento = new System.Windows.Forms.Button();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnAtender = new System.Windows.Forms.Button();
            this.btnFalta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // calendario
            // 
            this.calendario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calendario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calendario.Location = new System.Drawing.Point(18, 18);
            this.calendario.Name = "calendario";
            this.calendario.ShowTodayCircle = false;
            this.calendario.TabIndex = 0;
            this.calendario.TitleBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.calendario.TrailingForeColor = System.Drawing.SystemColors.InactiveCaption;
            // 
            // listaHorarios
            // 
            this.listaHorarios.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.listaHorarios.ColumnCount = 2;
            this.listaHorarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.80873F));
            this.listaHorarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.19127F));
            this.listaHorarios.Dock = System.Windows.Forms.DockStyle.Right;
            this.listaHorarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaHorarios.Location = new System.Drawing.Point(506, 0);
            this.listaHorarios.Name = "listaHorarios";
            this.listaHorarios.RowCount = 26;
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.listaHorarios.Size = new System.Drawing.Size(668, 1012);
            this.listaHorarios.TabIndex = 1;
            this.listaHorarios.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
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
            this.btnCadastro.Location = new System.Drawing.Point(27, 253);
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
            this.btnRemoverAgendamento.Location = new System.Drawing.Point(212, 253);
            this.btnRemoverAgendamento.Name = "btnRemoverAgendamento";
            this.btnRemoverAgendamento.Size = new System.Drawing.Size(179, 103);
            this.btnRemoverAgendamento.TabIndex = 3;
            this.btnRemoverAgendamento.Text = "Remover agendamento";
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
            this.btnPagar.Location = new System.Drawing.Point(27, 372);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(134, 76);
            this.btnPagar.TabIndex = 4;
            this.btnPagar.Text = "Pagar";
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
            this.btnAtender.Location = new System.Drawing.Point(27, 504);
            this.btnAtender.Name = "btnAtender";
            this.btnAtender.Size = new System.Drawing.Size(179, 103);
            this.btnAtender.TabIndex = 5;
            this.btnAtender.Text = "Atender";
            this.btnAtender.UseVisualStyleBackColor = false;
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
            this.btnFalta.Location = new System.Drawing.Point(27, 642);
            this.btnFalta.Name = "btnFalta";
            this.btnFalta.Size = new System.Drawing.Size(179, 103);
            this.btnFalta.TabIndex = 6;
            this.btnFalta.Text = "Registrar Falta";
            this.btnFalta.UseVisualStyleBackColor = false;
            // 
            // Agenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 1012);
            this.Controls.Add(this.btnFalta);
            this.Controls.Add(this.btnAtender);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.btnRemoverAgendamento);
            this.Controls.Add(this.btnCadastro);
            this.Controls.Add(this.listaHorarios);
            this.Controls.Add(this.calendario);
            this.Name = "Agenda";
            this.Text = "Agenda";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calendario;
        private System.Windows.Forms.TableLayoutPanel listaHorarios;
        private System.Windows.Forms.Button btnCadastro;
        private System.Windows.Forms.Button btnRemoverAgendamento;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnAtender;
        private System.Windows.Forms.Button btnFalta;
    }
}