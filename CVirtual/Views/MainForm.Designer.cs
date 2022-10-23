namespace CVirtual.Views
{
    partial class FrmPrincipal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripBar = new System.Windows.Forms.ToolStrip();
            this.btnAddCustomer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAuth = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.btnSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxSearth = new System.Windows.Forms.GroupBox();
            this.rbStatusOff = new System.Windows.Forms.RadioButton();
            this.rbStatusOn = new System.Windows.Forms.RadioButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridViewCustomers = new System.Windows.Forms.DataGridView();
            this.btnDebitar = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnAdd = new System.Windows.Forms.DataGridViewImageColumn();
            this.IdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apelido_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endereco_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimiteConta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalConta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_conta_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lblStatusRegistro = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLastBackup = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripBar.SuspendLayout();
            this.menuBar.SuspendLayout();
            this.groupBoxSearth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).BeginInit();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripBar
            // 
            this.toolStripBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripBar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddCustomer,
            this.toolStripSeparator1,
            this.btnAuth,
            this.toolStripSeparator2});
            this.toolStripBar.Location = new System.Drawing.Point(0, 25);
            this.toolStripBar.Name = "toolStripBar";
            this.toolStripBar.Size = new System.Drawing.Size(484, 58);
            this.toolStripBar.TabIndex = 0;
            this.toolStripBar.Text = "toolStripBar";
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Enabled = false;
            this.btnAddCustomer.Image = global::CVirtual.Properties.Resources.add_user;
            this.btnAddCustomer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAddCustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(109, 55);
            this.btnAddCustomer.Text = "Novo Cliente";
            this.btnAddCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddCustomer.Click += new System.EventHandler(this.BtnAddCustomer_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 58);
            // 
            // btnAuth
            // 
            this.btnAuth.Image = global::CVirtual.Properties.Resources.login;
            this.btnAuth.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAuth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAuth.Name = "btnAuth";
            this.btnAuth.Size = new System.Drawing.Size(55, 55);
            this.btnAuth.Text = "Login";
            this.btnAuth.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAuth.Click += new System.EventHandler(this.BtnAuth_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 58);
            // 
            // menuBar
            // 
            this.menuBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuBar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSystem,
            this.btnAbout});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(484, 25);
            this.menuBar.TabIndex = 1;
            this.menuBar.Text = "menuBar";
            // 
            // btnSystem
            // 
            this.btnSystem.Enabled = false;
            this.btnSystem.Name = "btnSystem";
            this.btnSystem.Size = new System.Drawing.Size(67, 21);
            this.btnSystem.Text = "Sistema";
            this.btnSystem.Click += new System.EventHandler(this.BtnSystem_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(55, 21);
            this.btnAbout.Text = "Sobre";
            this.btnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // groupBoxSearth
            // 
            this.groupBoxSearth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBoxSearth.Controls.Add(this.rbStatusOff);
            this.groupBoxSearth.Controls.Add(this.rbStatusOn);
            this.groupBoxSearth.Controls.Add(this.txtSearch);
            this.groupBoxSearth.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSearth.Enabled = false;
            this.groupBoxSearth.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSearth.Location = new System.Drawing.Point(0, 83);
            this.groupBoxSearth.Name = "groupBoxSearth";
            this.groupBoxSearth.Size = new System.Drawing.Size(484, 81);
            this.groupBoxSearth.TabIndex = 3;
            this.groupBoxSearth.TabStop = false;
            this.groupBoxSearth.Text = "Pesquisa";
            // 
            // rbStatusOff
            // 
            this.rbStatusOff.AutoSize = true;
            this.rbStatusOff.Location = new System.Drawing.Point(83, 53);
            this.rbStatusOff.Name = "rbStatusOff";
            this.rbStatusOff.Size = new System.Drawing.Size(74, 21);
            this.rbStatusOff.TabIndex = 1;
            this.rbStatusOff.Text = "Inativos";
            this.rbStatusOff.UseVisualStyleBackColor = true;
            this.rbStatusOff.CheckedChanged += new System.EventHandler(this.RbStatus_CheckedChanged);
            // 
            // rbStatusOn
            // 
            this.rbStatusOn.AutoSize = true;
            this.rbStatusOn.Checked = true;
            this.rbStatusOn.Location = new System.Drawing.Point(13, 53);
            this.rbStatusOn.Name = "rbStatusOn";
            this.rbStatusOn.Size = new System.Drawing.Size(64, 21);
            this.rbStatusOn.TabIndex = 1;
            this.rbStatusOn.TabStop = true;
            this.rbStatusOn.Text = "Ativos";
            this.rbStatusOn.UseVisualStyleBackColor = true;
            this.rbStatusOn.CheckedChanged += new System.EventHandler(this.RbStatus_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.Location = new System.Drawing.Point(3, 21);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(478, 25);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // dataGridViewCustomers
            // 
            this.dataGridViewCustomers.AllowUserToAddRows = false;
            this.dataGridViewCustomers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewCustomers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCustomers.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCustomers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnDebitar,
            this.btnAdd,
            this.IdCliente,
            this.nome_cliente,
            this.apelido_cliente,
            this.endereco_cliente,
            this.LimiteConta,
            this.TotalConta,
            this.data_conta_cliente,
            this.StatusCliente});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCustomers.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCustomers.EnableHeadersVisualStyles = false;
            this.dataGridViewCustomers.GridColor = System.Drawing.Color.SlateGray;
            this.dataGridViewCustomers.Location = new System.Drawing.Point(0, 164);
            this.dataGridViewCustomers.Name = "dataGridViewCustomers";
            this.dataGridViewCustomers.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCustomers.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewCustomers.RowHeadersVisible = false;
            this.dataGridViewCustomers.RowHeadersWidth = 49;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewCustomers.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewCustomers.RowTemplate.Height = 35;
            this.dataGridViewCustomers.Size = new System.Drawing.Size(484, 297);
            this.dataGridViewCustomers.TabIndex = 4;
            this.dataGridViewCustomers.Visible = false;
            this.dataGridViewCustomers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgCustomers_CellContentClick);
            this.dataGridViewCustomers.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgCustomers_CellContentDoubleClick);
            // 
            // btnDebitar
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle3.NullValue")));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.btnDebitar.DefaultCellStyle = dataGridViewCellStyle3;
            this.btnDebitar.HeaderText = "--";
            this.btnDebitar.Image = global::CVirtual.Properties.Resources.debitar;
            this.btnDebitar.Name = "btnDebitar";
            this.btnDebitar.ReadOnly = true;
            this.btnDebitar.Width = 50;
            // 
            // btnAdd
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle4.NullValue")));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.btnAdd.DefaultCellStyle = dataGridViewCellStyle4;
            this.btnAdd.HeaderText = "$";
            this.btnAdd.Image = global::CVirtual.Properties.Resources.add;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ReadOnly = true;
            this.btnAdd.ToolTipText = "Ação Rápida";
            this.btnAdd.Width = 50;
            // 
            // IdCliente
            // 
            this.IdCliente.DataPropertyName = "IdCliente";
            this.IdCliente.HeaderText = "Código";
            this.IdCliente.Name = "IdCliente";
            this.IdCliente.ReadOnly = true;
            this.IdCliente.Visible = false;
            // 
            // nome_cliente
            // 
            this.nome_cliente.DataPropertyName = "NomeCliente";
            this.nome_cliente.HeaderText = "Nome";
            this.nome_cliente.Name = "nome_cliente";
            this.nome_cliente.ReadOnly = true;
            this.nome_cliente.Width = 250;
            // 
            // apelido_cliente
            // 
            this.apelido_cliente.DataPropertyName = "ApelidoCliente";
            this.apelido_cliente.HeaderText = "Apelido";
            this.apelido_cliente.Name = "apelido_cliente";
            this.apelido_cliente.ReadOnly = true;
            this.apelido_cliente.Width = 150;
            // 
            // endereco_cliente
            // 
            this.endereco_cliente.DataPropertyName = "EnderecoCliente";
            this.endereco_cliente.HeaderText = "Endereço";
            this.endereco_cliente.Name = "endereco_cliente";
            this.endereco_cliente.ReadOnly = true;
            this.endereco_cliente.Width = 250;
            // 
            // LimiteConta
            // 
            this.LimiteConta.DataPropertyName = "LimiteContaCliente";
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.LimiteConta.DefaultCellStyle = dataGridViewCellStyle5;
            this.LimiteConta.HeaderText = "Limite Conta";
            this.LimiteConta.Name = "LimiteConta";
            this.LimiteConta.ReadOnly = true;
            this.LimiteConta.Width = 150;
            // 
            // TotalConta
            // 
            this.TotalConta.DataPropertyName = "TotalContaCliente";
            this.TotalConta.HeaderText = "Total Conta";
            this.TotalConta.Name = "TotalConta";
            this.TotalConta.ReadOnly = true;
            this.TotalConta.Width = 150;
            // 
            // data_conta_cliente
            // 
            this.data_conta_cliente.DataPropertyName = "DataContaCliente";
            this.data_conta_cliente.HeaderText = "Data Conta";
            this.data_conta_cliente.Name = "data_conta_cliente";
            this.data_conta_cliente.ReadOnly = true;
            this.data_conta_cliente.Width = 150;
            // 
            // StatusCliente
            // 
            this.StatusCliente.DataPropertyName = "StatusCliente";
            this.StatusCliente.HeaderText = "StatusCliente";
            this.StatusCliente.Name = "StatusCliente";
            this.StatusCliente.ReadOnly = true;
            this.StatusCliente.Visible = false;
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.statusBar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusRegistro,
            this.lblLastBackup});
            this.statusBar.Location = new System.Drawing.Point(0, 439);
            this.statusBar.Name = "statusBar";
            this.statusBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusBar.Size = new System.Drawing.Size(484, 22);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 5;
            this.statusBar.Visible = false;
            // 
            // lblStatusRegistro
            // 
            this.lblStatusRegistro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.lblStatusRegistro.Name = "lblStatusRegistro";
            this.lblStatusRegistro.Size = new System.Drawing.Size(109, 17);
            this.lblStatusRegistro.Text = "Ultimo Registro: ";
            // 
            // lblLastBackup
            // 
            this.lblLastBackup.Name = "lblLastBackup";
            this.lblLastBackup.Size = new System.Drawing.Size(103, 17);
            this.lblLastBackup.Text = "Último backup: ";
            this.lblLastBackup.Visible = false;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.dataGridViewCustomers);
            this.Controls.Add(this.groupBoxSearth);
            this.Controls.Add(this.toolStripBar);
            this.Controls.Add(this.menuBar);
            this.MainMenuStrip = this.menuBar;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caderno Virtual :: 2020 Edition";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnLoad);
            this.toolStripBar.ResumeLayout(false);
            this.toolStripBar.PerformLayout();
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.groupBoxSearth.ResumeLayout(false);
            this.groupBoxSearth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).EndInit();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripBar;
        private System.Windows.Forms.ToolStripButton btnAddCustomer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAuth;
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem btnAbout;
        private System.Windows.Forms.GroupBox groupBoxSearth;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ToolStripMenuItem btnSystem;
        private System.Windows.Forms.DataGridView dataGridViewCustomers;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusRegistro;
        private System.Windows.Forms.ToolStripStatusLabel lblLastBackup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.RadioButton rbStatusOff;
        private System.Windows.Forms.RadioButton rbStatusOn;
        private System.Windows.Forms.DataGridViewImageColumn btnDebitar;
        private System.Windows.Forms.DataGridViewImageColumn btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn apelido_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn endereco_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn LimiteConta;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalConta;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_conta_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusCliente;
    }
}

