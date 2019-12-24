namespace UI.Forms
{
    partial class frmOperacao
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnConfirmar = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTotalConta = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTempoAberto = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblLimiteRestante = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLimiteConta = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDataConta = new System.Windows.Forms.Label();
            this.lblNomeCliente = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtValorOperacao = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbAtendente = new System.Windows.Forms.ComboBox();
            this.groupOperacao = new System.Windows.Forms.GroupBox();
            this.groupLog = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupOperacao.SuspendLayout();
            this.groupLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConfirmar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(323, 54);
            this.toolStrip1.TabIndex = 0;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Image = global::UI.Properties.Resources.accept;
            this.btnConfirmar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnConfirmar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(88, 51);
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Lavender;
            this.groupBox2.Controls.Add(this.flowLayoutPanel5);
            this.groupBox2.Controls.Add(this.flowLayoutPanel4);
            this.groupBox2.Controls.Add(this.flowLayoutPanel3);
            this.groupBox2.Controls.Add(this.flowLayoutPanel2);
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(0, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 168);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DADOS NOTA";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.label10);
            this.flowLayoutPanel5.Controls.Add(this.label12);
            this.flowLayoutPanel5.Controls.Add(this.lblTotalConta);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel5.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 129);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(317, 35);
            this.flowLayoutPanel5.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Crimson;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 32);
            this.label10.TabIndex = 0;
            this.label10.Text = "Total Conta:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Crimson;
            this.label12.Location = new System.Drawing.Point(155, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 32);
            this.label12.TabIndex = 1;
            this.label12.Text = "R$:";
            // 
            // lblTotalConta
            // 
            this.lblTotalConta.AutoSize = true;
            this.lblTotalConta.ForeColor = System.Drawing.Color.Crimson;
            this.lblTotalConta.Location = new System.Drawing.Point(210, 0);
            this.lblTotalConta.Name = "lblTotalConta";
            this.lblTotalConta.Size = new System.Drawing.Size(28, 32);
            this.lblTotalConta.TabIndex = 2;
            this.lblTotalConta.Text = "0";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.label9);
            this.flowLayoutPanel4.Controls.Add(this.lblTempoAberto);
            this.flowLayoutPanel4.Controls.Add(this.label11);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 104);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(317, 25);
            this.flowLayoutPanel4.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(171, 25);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tempo em Aberto:";
            // 
            // lblTempoAberto
            // 
            this.lblTempoAberto.AutoSize = true;
            this.lblTempoAberto.Location = new System.Drawing.Point(180, 0);
            this.lblTempoAberto.Name = "lblTempoAberto";
            this.lblTempoAberto.Size = new System.Drawing.Size(23, 25);
            this.lblTempoAberto.TabIndex = 1;
            this.lblTempoAberto.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(209, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 25);
            this.label11.TabIndex = 2;
            this.label11.Text = "Dias";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label6);
            this.flowLayoutPanel3.Controls.Add(this.label7);
            this.flowLayoutPanel3.Controls.Add(this.lblLimiteRestante);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 79);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(317, 25);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "Limite Restante:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(158, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 25);
            this.label7.TabIndex = 1;
            this.label7.Text = "RS:";
            // 
            // lblLimiteRestante
            // 
            this.lblLimiteRestante.AutoSize = true;
            this.lblLimiteRestante.ForeColor = System.Drawing.Color.Black;
            this.lblLimiteRestante.Location = new System.Drawing.Point(203, 0);
            this.lblLimiteRestante.Name = "lblLimiteRestante";
            this.lblLimiteRestante.Size = new System.Drawing.Size(23, 25);
            this.lblLimiteRestante.TabIndex = 2;
            this.lblLimiteRestante.Text = "0";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Lavender;
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.lblLimiteConta);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 54);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(317, 25);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Limite Conta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "R$:";
            // 
            // lblLimiteConta
            // 
            this.lblLimiteConta.AutoSize = true;
            this.lblLimiteConta.Location = new System.Drawing.Point(181, 0);
            this.lblLimiteConta.Name = "lblLimiteConta";
            this.lblLimiteConta.Size = new System.Drawing.Size(23, 25);
            this.lblLimiteConta.TabIndex = 2;
            this.lblLimiteConta.Text = "0";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.lblDataConta);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 29);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(317, 25);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Data Conta:";
            // 
            // lblDataConta
            // 
            this.lblDataConta.AutoSize = true;
            this.lblDataConta.ForeColor = System.Drawing.Color.Black;
            this.lblDataConta.Location = new System.Drawing.Point(123, 0);
            this.lblDataConta.Name = "lblDataConta";
            this.lblDataConta.Size = new System.Drawing.Size(94, 25);
            this.lblDataConta.TabIndex = 1;
            this.lblDataConta.Text = "00/00/00";
            // 
            // lblNomeCliente
            // 
            this.lblNomeCliente.AutoSize = true;
            this.lblNomeCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNomeCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNomeCliente.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeCliente.ForeColor = System.Drawing.Color.Crimson;
            this.lblNomeCliente.Location = new System.Drawing.Point(0, 54);
            this.lblNomeCliente.Name = "lblNomeCliente";
            this.lblNomeCliente.Size = new System.Drawing.Size(171, 25);
            this.lblNomeCliente.TabIndex = 2;
            this.lblNomeCliente.Text = "NOME COMPLETO";
            this.lblNomeCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(7, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 21);
            this.label14.TabIndex = 0;
            this.label14.Text = "VALOR R$:";
            // 
            // txtValorOperacao
            // 
            this.txtValorOperacao.BackColor = System.Drawing.Color.Lavender;
            this.txtValorOperacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorOperacao.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtValorOperacao.Location = new System.Drawing.Point(131, 26);
            this.txtValorOperacao.MaxLength = 8;
            this.txtValorOperacao.Name = "txtValorOperacao";
            this.txtValorOperacao.Size = new System.Drawing.Size(100, 33);
            this.txtValorOperacao.TabIndex = 1;
            this.txtValorOperacao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValorOperacao_KeyDown);
            this.txtValorOperacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorOperacao_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(7, 69);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 21);
            this.label15.TabIndex = 0;
            this.label15.Text = "ATENDENTE:";
            // 
            // cbAtendente
            // 
            this.cbAtendente.BackColor = System.Drawing.Color.Lavender;
            this.cbAtendente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAtendente.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.cbAtendente.FormattingEnabled = true;
            this.cbAtendente.Items.AddRange(new object[] {
            ""});
            this.cbAtendente.Location = new System.Drawing.Point(131, 66);
            this.cbAtendente.Name = "cbAtendente";
            this.cbAtendente.Size = new System.Drawing.Size(180, 33);
            this.cbAtendente.TabIndex = 1;
            // 
            // groupOperacao
            // 
            this.groupOperacao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupOperacao.Controls.Add(this.label15);
            this.groupOperacao.Controls.Add(this.txtValorOperacao);
            this.groupOperacao.Controls.Add(this.label14);
            this.groupOperacao.Controls.Add(this.cbAtendente);
            this.groupOperacao.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupOperacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupOperacao.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.groupOperacao.Location = new System.Drawing.Point(0, 247);
            this.groupOperacao.Name = "groupOperacao";
            this.groupOperacao.Size = new System.Drawing.Size(323, 105);
            this.groupOperacao.TabIndex = 4;
            this.groupOperacao.TabStop = false;
            this.groupOperacao.Text = "OPERAÇÃO :: ";
            // 
            // groupLog
            // 
            this.groupLog.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupLog.Controls.Add(this.txtLog);
            this.groupLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupLog.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupLog.Location = new System.Drawing.Point(0, 352);
            this.groupLog.Name = "groupLog";
            this.groupLog.Size = new System.Drawing.Size(323, 127);
            this.groupLog.TabIndex = 5;
            this.groupLog.TabStop = false;
            this.groupLog.Text = "DETALHES";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.Lavender;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(3, 29);
            this.txtLog.MaxLength = 500;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(317, 95);
            this.txtLog.TabIndex = 0;
            this.txtLog.Text = "";
            // 
            // frmOperacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(323, 479);
            this.Controls.Add(this.groupLog);
            this.Controls.Add(this.groupOperacao);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblNomeCliente);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOperacao";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::";
            this.Load += new System.EventHandler(this.frmOperacao_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupOperacao.ResumeLayout(false);
            this.groupOperacao.PerformLayout();
            this.groupLog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripButton btnConfirmar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTotalConta;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTempoAberto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblLimiteRestante;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLimiteConta;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDataConta;
        private System.Windows.Forms.Label lblNomeCliente;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtValorOperacao;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbAtendente;
        private System.Windows.Forms.GroupBox groupOperacao;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox groupLog;
        private System.Windows.Forms.RichTextBox txtLog;
    }
}