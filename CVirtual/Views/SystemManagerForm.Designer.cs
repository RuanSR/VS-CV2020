namespace CVirtual.Views
{
    partial class SystemManagerForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageAdmin = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewEmployee = new System.Windows.Forms.DataGridView();
            this.IdAtendente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NivelAcesso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Senha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditar = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnDeletar = new System.Windows.Forms.DataGridViewImageColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnNewEmployee = new System.Windows.Forms.ToolStripButton();
            this.tabPageBackupRestore = new System.Windows.Forms.TabPage();
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
            this.cbBackupInterval = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSavePreferences = new System.Windows.Forms.ToolStripButton();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl.SuspendLayout();
            this.tabPageAdmin.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployee)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.tabPageBackupRestore.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageAdmin);
            this.tabControl.Controls.Add(this.tabPageBackupRestore);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(484, 461);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageAdmin
            // 
            this.tabPageAdmin.Controls.Add(this.tableLayoutPanel1);
            this.tabPageAdmin.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageAdmin.Location = new System.Drawing.Point(4, 26);
            this.tabPageAdmin.Name = "tabPageAdmin";
            this.tabPageAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdmin.Size = new System.Drawing.Size(476, 431);
            this.tabPageAdmin.TabIndex = 0;
            this.tabPageAdmin.Text = "Administrador";
            this.tabPageAdmin.UseVisualStyleBackColor = true;
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
            this.panel1.Controls.Add(this.dataGridViewEmployee);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 419);
            this.panel1.TabIndex = 0;
            // 
            // dataGridViewEmployee
            // 
            this.dataGridViewEmployee.AllowUserToAddRows = false;
            this.dataGridViewEmployee.AllowUserToDeleteRows = false;
            this.dataGridViewEmployee.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdAtendente,
            this.Nome,
            this.Usuario,
            this.NivelAcesso,
            this.Senha,
            this.btnEditar,
            this.btnDeletar});
            this.dataGridViewEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEmployee.Location = new System.Drawing.Point(0, 52);
            this.dataGridViewEmployee.Name = "dataGridViewEmployee";
            this.dataGridViewEmployee.ReadOnly = true;
            this.dataGridViewEmployee.RowHeadersVisible = false;
            this.dataGridViewEmployee.RowTemplate.Height = 30;
            this.dataGridViewEmployee.Size = new System.Drawing.Size(464, 367);
            this.dataGridViewEmployee.TabIndex = 1;
            this.dataGridViewEmployee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgEmployee_CellClickOptions);
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
            this.btnEditar.DataPropertyName = "btnEditar";
            this.btnEditar.HeaderText = "";
            this.btnEditar.Image = global::CVirtual.Properties.Resources.ediatar;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.ReadOnly = true;
            this.btnEditar.Width = 50;
            // 
            // btnDeletar
            // 
            this.btnDeletar.DataPropertyName = "btnDeletar";
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
            this.btnNewEmployee});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(464, 52);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnNewEmployee
            // 
            this.btnNewEmployee.Image = global::CVirtual.Properties.Resources.add_user;
            this.btnNewEmployee.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNewEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewEmployee.Name = "btnNewEmployee";
            this.btnNewEmployee.Size = new System.Drawing.Size(98, 49);
            this.btnNewEmployee.Text = "Novo Atendente";
            this.btnNewEmployee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNewEmployee.Click += new System.EventHandler(this.BtnNewEmployee_ButtonClick);
            // 
            // tabPageBackupRestore
            // 
            this.tabPageBackupRestore.Controls.Add(this.flowLayoutPanel1);
            this.tabPageBackupRestore.Controls.Add(this.label5);
            this.tabPageBackupRestore.Controls.Add(this.toolStrip3);
            this.tabPageBackupRestore.Controls.Add(this.label6);
            this.tabPageBackupRestore.Controls.Add(this.cbBackupInterval);
            this.tabPageBackupRestore.Controls.Add(this.label4);
            this.tabPageBackupRestore.Controls.Add(this.toolStrip1);
            this.tabPageBackupRestore.Location = new System.Drawing.Point(4, 26);
            this.tabPageBackupRestore.Name = "tabPageBackupRestore";
            this.tabPageBackupRestore.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBackupRestore.Size = new System.Drawing.Size(476, 431);
            this.tabPageBackupRestore.TabIndex = 1;
            this.tabPageBackupRestore.Text = "Backup / Restore";
            this.tabPageBackupRestore.UseVisualStyleBackColor = true;
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
            this.btnDefinirLocal.Click += new System.EventHandler(this.BtnSetLocalBackup_Click);
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
            this.btnBackup.Click += new System.EventHandler(this.BtnBackup_Click);
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
            this.btnAbrirLocal.Click += new System.EventHandler(this.BtnOpenLocalBackup_Click);
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
            this.btnBackupRestore.Click += new System.EventHandler(this.BtnBackupRestore_Click);
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
            // cbBackupInterval
            // 
            this.cbBackupInterval.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbBackupInterval.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbBackupInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBackupInterval.FormattingEnabled = true;
            this.cbBackupInterval.Location = new System.Drawing.Point(3, 72);
            this.cbBackupInterval.Name = "cbBackupInterval";
            this.cbBackupInterval.Size = new System.Drawing.Size(470, 25);
            this.cbBackupInterval.TabIndex = 2;
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
            this.btnSavePreferences});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(470, 52);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSavePreferences
            // 
            this.btnSavePreferences.Image = global::CVirtual.Properties.Resources.save;
            this.btnSavePreferences.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSavePreferences.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSavePreferences.Name = "btnSavePreferences";
            this.btnSavePreferences.Size = new System.Drawing.Size(42, 49);
            this.btnSavePreferences.Text = "Salvar";
            this.btnSavePreferences.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSavePreferences.Click += new System.EventHandler(this.BtnSaveDataPreferences_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // SystemManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "SystemManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " :: Sistema / Atendentes / Administrador / Backup & restore";
            this.Load += new System.EventHandler(this.OnLoad);
            this.tabControl.ResumeLayout(false);
            this.tabPageAdmin.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployee)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPageBackupRestore.ResumeLayout(false);
            this.tabPageBackupRestore.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageAdmin;
        private System.Windows.Forms.TabPage tabPageBackupRestore;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbBackupInterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSavePreferences;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton btnBackup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAbrirLocal;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtLocal;
        private System.Windows.Forms.Button btnDefinirLocal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewEmployee;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnBackupRestore;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnNewEmployee;
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