namespace WinDesktop.Forms
{
    partial class frmArquivo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgLog = new System.Windows.Forms.DataGridView();
            this.arquivo_registro_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nota_conta_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLog)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgLog
            // 
            this.dtgLog.AllowUserToAddRows = false;
            this.dtgLog.AllowUserToDeleteRows = false;
            this.dtgLog.BackgroundColor = System.Drawing.Color.White;
            this.dtgLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.arquivo_registro_id,
            this.nota_conta_id,
            this.registro});
            this.dtgLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgLog.EnableHeadersVisualStyles = false;
            this.dtgLog.Location = new System.Drawing.Point(0, 0);
            this.dtgLog.Name = "dtgLog";
            this.dtgLog.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgLog.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtgLog.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgLog.RowTemplate.Height = 40;
            this.dtgLog.Size = new System.Drawing.Size(614, 451);
            this.dtgLog.TabIndex = 1;
            // 
            // arquivo_registro_id
            // 
            this.arquivo_registro_id.DataPropertyName = "ArquivoRegistrosId";
            this.arquivo_registro_id.HeaderText = "ArquivoRegistroId";
            this.arquivo_registro_id.Name = "arquivo_registro_id";
            this.arquivo_registro_id.ReadOnly = true;
            this.arquivo_registro_id.Visible = false;
            this.arquivo_registro_id.Width = 185;
            // 
            // nota_conta_id
            // 
            this.nota_conta_id.DataPropertyName = "NotaContaId";
            this.nota_conta_id.HeaderText = "NotaContaId";
            this.nota_conta_id.Name = "nota_conta_id";
            this.nota_conta_id.ReadOnly = true;
            this.nota_conta_id.Visible = false;
            this.nota_conta_id.Width = 150;
            // 
            // registro
            // 
            this.registro.DataPropertyName = "Registro";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.registro.DefaultCellStyle = dataGridViewCellStyle2;
            this.registro.HeaderText = "Registros Arquivados";
            this.registro.Name = "registro";
            this.registro.ReadOnly = true;
            this.registro.ToolTipText = "R$";
            this.registro.Width = 1000;
            // 
            // frmArquivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 451);
            this.Controls.Add(this.dtgLog);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(630, 490);
            this.Name = "frmArquivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " :: ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmArquivo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn arquivo_registro_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nota_conta_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn registro;
    }
}