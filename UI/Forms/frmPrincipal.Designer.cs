﻿namespace UI.Forms
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripBar = new System.Windows.Forms.ToolStrip();
            this.btnNovoCliente = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLogin = new System.Windows.Forms.ToolStripButton();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.btnSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nome_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.login_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_conta_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.limite_conta_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ultima_compra_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_conta_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNotaRapida = new System.Windows.Forms.DataGridViewImageColumn();
            this.id_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endereco_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefone_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpf_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.credito_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_pago_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_notas_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conta_ativa_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxPesquisa = new System.Windows.Forms.GroupBox();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.toolStripBar.SuspendLayout();
            this.menuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxPesquisa.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripBar
            // 
            this.toolStripBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripBar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNovoCliente,
            this.toolStripSeparator1,
            this.btnLogin});
            this.toolStripBar.Location = new System.Drawing.Point(0, 25);
            this.toolStripBar.Name = "toolStripBar";
            this.toolStripBar.Size = new System.Drawing.Size(484, 58);
            this.toolStripBar.TabIndex = 0;
            this.toolStripBar.Text = "toolStripBar";
            // 
            // btnNovoCliente
            // 
            this.btnNovoCliente.Image = global::UI.Properties.Resources.add_user;
            this.btnNovoCliente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNovoCliente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNovoCliente.Name = "btnNovoCliente";
            this.btnNovoCliente.Size = new System.Drawing.Size(109, 55);
            this.btnNovoCliente.Text = "Novo Cliente";
            this.btnNovoCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNovoCliente.Click += new System.EventHandler(this.btnNovoCliente_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 58);
            // 
            // btnLogin
            // 
            this.btnLogin.Image = global::UI.Properties.Resources.login;
            this.btnLogin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLogin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(55, 55);
            this.btnLogin.Text = "Login";
            this.btnLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // menuBar
            // 
            this.menuBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuBar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSistema,
            this.btnAbout});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(484, 25);
            this.menuBar.TabIndex = 1;
            this.menuBar.Text = "menuBar";
            // 
            // btnSistema
            // 
            this.btnSistema.Name = "btnSistema";
            this.btnSistema.Size = new System.Drawing.Size(67, 21);
            this.btnSistema.Text = "Sistema";
            this.btnSistema.Click += new System.EventHandler(this.btnSistema_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(55, 21);
            this.btnAbout.Text = "Sobre";
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nome_cliente,
            this.login_cliente,
            this.data_conta_cliente,
            this.limite_conta_cliente,
            this.ultima_compra_cliente,
            this.total_conta_cliente,
            this.btnNotaRapida,
            this.id_cliente,
            this.endereco_cliente,
            this.telefone_cliente,
            this.cpf_cliente,
            this.credito_cliente,
            this.total_pago_cliente,
            this.num_notas_cliente,
            this.conta_ativa_cliente});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 136);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(484, 325);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // nome_cliente
            // 
            this.nome_cliente.HeaderText = "Nome";
            this.nome_cliente.Name = "nome_cliente";
            this.nome_cliente.ReadOnly = true;
            this.nome_cliente.Width = 200;
            // 
            // login_cliente
            // 
            this.login_cliente.HeaderText = "Apelido";
            this.login_cliente.Name = "login_cliente";
            this.login_cliente.ReadOnly = true;
            // 
            // data_conta_cliente
            // 
            this.data_conta_cliente.HeaderText = "Data Conta";
            this.data_conta_cliente.Name = "data_conta_cliente";
            this.data_conta_cliente.ReadOnly = true;
            // 
            // limite_conta_cliente
            // 
            this.limite_conta_cliente.HeaderText = "Limite";
            this.limite_conta_cliente.Name = "limite_conta_cliente";
            this.limite_conta_cliente.ReadOnly = true;
            // 
            // ultima_compra_cliente
            // 
            this.ultima_compra_cliente.HeaderText = "Ultima Compra";
            this.ultima_compra_cliente.Name = "ultima_compra_cliente";
            this.ultima_compra_cliente.ReadOnly = true;
            this.ultima_compra_cliente.Width = 150;
            // 
            // total_conta_cliente
            // 
            this.total_conta_cliente.HeaderText = "Total";
            this.total_conta_cliente.Name = "total_conta_cliente";
            this.total_conta_cliente.ReadOnly = true;
            // 
            // btnNotaRapida
            // 
            this.btnNotaRapida.HeaderText = "";
            this.btnNotaRapida.Image = global::UI.Properties.Resources.speed;
            this.btnNotaRapida.Name = "btnNotaRapida";
            this.btnNotaRapida.ReadOnly = true;
            // 
            // id_cliente
            // 
            this.id_cliente.HeaderText = "Código";
            this.id_cliente.Name = "id_cliente";
            this.id_cliente.ReadOnly = true;
            this.id_cliente.Visible = false;
            // 
            // endereco_cliente
            // 
            this.endereco_cliente.HeaderText = "Endereço";
            this.endereco_cliente.Name = "endereco_cliente";
            this.endereco_cliente.ReadOnly = true;
            this.endereco_cliente.Visible = false;
            // 
            // telefone_cliente
            // 
            this.telefone_cliente.HeaderText = "Telefone";
            this.telefone_cliente.Name = "telefone_cliente";
            this.telefone_cliente.ReadOnly = true;
            this.telefone_cliente.Visible = false;
            // 
            // cpf_cliente
            // 
            this.cpf_cliente.HeaderText = "CPF";
            this.cpf_cliente.Name = "cpf_cliente";
            this.cpf_cliente.ReadOnly = true;
            this.cpf_cliente.Visible = false;
            // 
            // credito_cliente
            // 
            this.credito_cliente.HeaderText = "Crédito";
            this.credito_cliente.Name = "credito_cliente";
            this.credito_cliente.ReadOnly = true;
            this.credito_cliente.Visible = false;
            // 
            // total_pago_cliente
            // 
            this.total_pago_cliente.HeaderText = "Total Pago";
            this.total_pago_cliente.Name = "total_pago_cliente";
            this.total_pago_cliente.ReadOnly = true;
            this.total_pago_cliente.Visible = false;
            // 
            // num_notas_cliente
            // 
            this.num_notas_cliente.HeaderText = "Num. Notas";
            this.num_notas_cliente.Name = "num_notas_cliente";
            this.num_notas_cliente.ReadOnly = true;
            this.num_notas_cliente.Visible = false;
            // 
            // conta_ativa_cliente
            // 
            this.conta_ativa_cliente.HeaderText = "Status";
            this.conta_ativa_cliente.Name = "conta_ativa_cliente";
            this.conta_ativa_cliente.ReadOnly = true;
            this.conta_ativa_cliente.Visible = false;
            // 
            // groupBoxPesquisa
            // 
            this.groupBoxPesquisa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBoxPesquisa.Controls.Add(this.txtPesquisa);
            this.groupBoxPesquisa.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxPesquisa.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPesquisa.Location = new System.Drawing.Point(0, 83);
            this.groupBoxPesquisa.Name = "groupBoxPesquisa";
            this.groupBoxPesquisa.Size = new System.Drawing.Size(484, 53);
            this.groupBoxPesquisa.TabIndex = 3;
            this.groupBoxPesquisa.TabStop = false;
            this.groupBoxPesquisa.Text = "Pesquisa";
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.BackColor = System.Drawing.Color.White;
            this.txtPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisa.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPesquisa.Location = new System.Drawing.Point(3, 21);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(478, 25);
            this.txtPesquisa.TabIndex = 0;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBoxPesquisa);
            this.Controls.Add(this.toolStripBar);
            this.Controls.Add(this.menuBar);
            this.MainMenuStrip = this.menuBar;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " :: 2020 Edition";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStripBar.ResumeLayout(false);
            this.toolStripBar.PerformLayout();
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxPesquisa.ResumeLayout(false);
            this.groupBoxPesquisa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripBar;
        private System.Windows.Forms.ToolStripButton btnNovoCliente;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnLogin;
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem btnAbout;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBoxPesquisa;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.ToolStripMenuItem btnSistema;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn login_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_conta_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn limite_conta_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ultima_compra_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_conta_cliente;
        private System.Windows.Forms.DataGridViewImageColumn btnNotaRapida;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn endereco_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefone_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpf_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn credito_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_pago_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_notas_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn conta_ativa_cliente;
    }
}

