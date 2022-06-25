namespace CVirtual.Forms
{
    partial class frmGerenciadorSistema
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgAtendente = new System.Windows.Forms.DataGridView();
            this.IdAtendente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NivelAcesso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Senha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnDeletar = new System.Windows.Forms.DataGridViewImageColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnNovoAtendete = new System.Windows.Forms.ToolStripButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtLocal = new System.Windows.Forms.TextBox();
            this.btnDefinirLocal = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.btnBackup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAbrirLocal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBackupRestore = new System.Windows.Forms.ToolStripButton();
            this.label6 = new System.Windows.Forms.Label();
            this.cbBackupIntervalo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSalvarDados = new System.Windows.Forms.ToolStripButton();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAtendente)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(484, 461);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(476, 431);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Administrador";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 425F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(470, 425);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgAtendente);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 419);
            this.panel1.TabIndex = 0;
            // 
            // dtgAtendente
            // 
            this.dtgAtendente.AllowUserToAddRows = false;
            this.dtgAtendente.AllowUserToDeleteRows = false;
            this.dtgAtendente.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgAtendente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAtendente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdAtendente,
            this.Nome,
            this.Usuario,
            this.NivelAcesso,
            this.Senha,
            this.btnEditar,
            this.btnDeletar});
            this.dtgAtendente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgAtendente.Location = new System.Drawing.Point(0, 52);
            this.dtgAtendente.Name = "dtgAtendente";
            this.dtgAtendente.ReadOnly = true;
            this.dtgAtendente.RowHeadersVisible = false;
            this.dtgAtendente.RowTemplate.Height = 30;
            this.dtgAtendente.Size = new System.Drawing.Size(464, 367);
            this.dtgAtendente.TabIndex = 1;
            this.dtgAtendente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgAtendente_CellContentClick);
            // 
            // IdAtendente
            // 
            this.IdAtendente.DataPropertyName = "AtendenteId";
            this.IdAtendente.HeaderText = "Código";
            this.IdAtendente.Name = "IdAtendente";
            this.IdAtendente.ReadOnly = true;
            this.IdAtendente.Width = 60;
            // 
            // Nome
            // 
            this.Nome.DataPropertyName = "Nome";
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Width = 200;
            // 
            // Usuario
            // 
            this.Usuario.DataPropertyName = "Usuario";
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            // 
            // NivelAcesso
            // 
            this.NivelAcesso.DataPropertyName = "NivelAcesso";
            this.NivelAcesso.HeaderText = "Nivel Acesso";
            this.NivelAcesso.Name = "NivelAcesso";
            this.NivelAcesso.ReadOnly = true;
            this.NivelAcesso.Visible = false;
            // 
            // Senha
            // 
            this.Senha.DataPropertyName = "Senha";
            this.Senha.HeaderText = "senha_atendente";
            this.Senha.Name = "Senha";
            this.Senha.ReadOnly = true;
            this.Senha.Visible = false;
            // 
            // btnEditar
            // 
            this.btnEditar.HeaderText = "";
            this.btnEditar.Image = global::CVirtual.Properties.Resources.ediatar;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.ReadOnly = true;
            this.btnEditar.Width = 50;
            // 
            // btnDeletar
            // 
            this.btnDeletar.HeaderText = "";
            this.btnDeletar.Image = global::CVirtual.Properties.Resources.decline;
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.ReadOnly = true;
            this.btnDeletar.Width = 50;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNovoAtendete});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(464, 52);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnNovoAtendete
            // 
            this.btnNovoAtendete.Image = global::CVirtual.Properties.Resources.add_user;
            this.btnNovoAtendete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNovoAtendete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNovoAtendete.Name = "btnNovoAtendete";
            this.btnNovoAtendete.Size = new System.Drawing.Size(98, 49);
            this.btnNovoAtendete.Text = "Novo Atendente";
            this.btnNovoAtendete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNovoAtendete.Click += new System.EventHandler(this.btnNovoAtendente_ButtonClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.flowLayoutPanel1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.toolStrip3);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.cbBackupIntervalo);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.toolStrip1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(476, 431);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Backup / Restore";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.txtLocal);
            this.flowLayoutPanel1.Controls.Add(this.btnDefinirLocal);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 183);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(470, 39);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // txtLocal
            // 
            this.txtLocal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLocal.Enabled = false;
            this.txtLocal.Location = new System.Drawing.Point(3, 3);
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.Size = new System.Drawing.Size(382, 25);
            this.txtLocal.TabIndex = 0;
            // 
            // btnDefinirLocal
            // 
            this.btnDefinirLocal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDefinirLocal.Location = new System.Drawing.Point(391, 3);
            this.btnDefinirLocal.Name = "btnDefinirLocal";
            this.btnDefinirLocal.Size = new System.Drawing.Size(75, 23);
            this.btnDefinirLocal.TabIndex = 1;
            this.btnDefinirLocal.Text = "...";
            this.btnDefinirLocal.UseVisualStyleBackColor = false;
            this.btnDefinirLocal.Click += new System.EventHandler(this.btnDefinirLocal_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(3, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "LOCAL DE ARMAZENAMENTO BACKUP";
            // 
            // toolStrip3
            // 
            this.toolStrip3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBackup,
            this.toolStripSeparator1,
            this.btnAbrirLocal,
            this.toolStripSeparator2,
            this.btnBackupRestore});
            this.toolStrip3.Location = new System.Drawing.Point(3, 114);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(470, 52);
            this.toolStrip3.TabIndex = 6;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // btnBackup
            // 
            this.btnBackup.Image = global::CVirtual.Properties.Resources.backup;
            this.btnBackup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBackup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(80, 49);
            this.btnBackup.Text = "Fazer Backup";
            this.btnBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 52);
            // 
            // btnAbrirLocal
            // 
            this.btnAbrirLocal.Image = global::CVirtual.Properties.Resources.folder;
            this.btnAbrirLocal.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAbrirLocal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbrirLocal.Name = "btnAbrirLocal";
            this.btnAbrirLocal.Size = new System.Drawing.Size(68, 49);
            this.btnAbrirLocal.Text = "Abrir Local";
            this.btnAbrirLocal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAbrirLocal.Click += new System.EventHandler(this.btnAbrirLocal_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 52);
            // 
            // btnBackupRestore
            // 
            this.btnBackupRestore.Image = global::CVirtual.Properties.Resources.restore;
            this.btnBackupRestore.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBackupRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBackupRestore.Name = "btnBackupRestore";
            this.btnBackupRestore.Size = new System.Drawing.Size(102, 49);
            this.btnBackupRestore.Text = "Restaurar Backup";
            this.btnBackupRestore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBackupRestore.Click += new System.EventHandler(this.btnBackupRestore_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(3, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "BACKUP MANUAL";
            // 
            // cbBackupIntervalo
            // 
            this.cbBackupIntervalo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbBackupIntervalo.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbBackupIntervalo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBackupIntervalo.FormattingEnabled = true;
            this.cbBackupIntervalo.Location = new System.Drawing.Point(3, 72);
            this.cbBackupIntervalo.Name = "cbBackupIntervalo";
            this.cbBackupIntervalo.Size = new System.Drawing.Size(470, 25);
            this.cbBackupIntervalo.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(3, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "INTERVALO DE BACKUP AUTOMÁTICO";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSalvarDados});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(470, 52);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSalvarDados
            // 
            this.btnSalvarDados.Image = global::CVirtual.Properties.Resources.save;
            this.btnSalvarDados.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSalvarDados.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalvarDados.Name = "btnSalvarDados";
            this.btnSalvarDados.Size = new System.Drawing.Size(42, 49);
            this.btnSalvarDados.Text = "Salvar";
            this.btnSalvarDados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalvarDados.Click += new System.EventHandler(this.btnSalvarDados_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // frmGerenciadorSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "frmGerenciadorSistema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " :: Sistema / Atendentes / Administrador / Backup & restore";
            this.Load += new System.EventHandler(this.frmGerenciadorSistema_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAtendente)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbBackupIntervalo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSalvarDados;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton btnBackup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAbrirLocal;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtLocal;
        private System.Windows.Forms.Button btnDefinirLocal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtgAtendente;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnBackupRestore;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnNovoAtendete;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdAtendente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn NivelAcesso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Senha;
        private System.Windows.Forms.DataGridViewImageColumn btnEditar;
        private System.Windows.Forms.DataGridViewImageColumn btnDeletar;
    }
}