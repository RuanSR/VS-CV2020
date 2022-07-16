namespace CVirtual.Forms
{
    partial class AuthForm
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
            this.panelForm = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.tablePanelHeader = new System.Windows.Forms.TableLayoutPanel();
            this.panelCrachaHeader = new System.Windows.Forms.Panel();
            this.picBoxCracha = new System.Windows.Forms.PictureBox();
            this.panelInfoHeader = new System.Windows.Forms.Panel();
            this.lblInfoHeader = new System.Windows.Forms.Label();
            this.panelForm.SuspendLayout();
            this.tablePanelHeader.SuspendLayout();
            this.panelCrachaHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCracha)).BeginInit();
            this.panelInfoHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.btnLogin);
            this.panelForm.Controls.Add(this.txtPassword);
            this.panelForm.Controls.Add(this.lblPassword);
            this.panelForm.Controls.Add(this.txtUser);
            this.panelForm.Controls.Add(this.lblUser);
            this.panelForm.Controls.Add(this.tablePanelHeader);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(279, 246);
            this.panelForm.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.Location = new System.Drawing.Point(0, 207);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(279, 37);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "ENTRAR";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.LoginForm_Click);
            this.btnLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(0, 172);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(279, 35);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(0, 142);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(87, 30);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "SENHA";
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.White;
            this.txtUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtUser.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(0, 107);
            this.txtUser.MaxLength = 30;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(279, 35);
            this.txtUser.TabIndex = 0;
            this.txtUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(0, 77);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(110, 30);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "USUARIO";
            // 
            // tablePanelHeader
            // 
            this.tablePanelHeader.BackColor = System.Drawing.Color.PowderBlue;
            this.tablePanelHeader.ColumnCount = 2;
            this.tablePanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tablePanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tablePanelHeader.Controls.Add(this.panelCrachaHeader, 0, 0);
            this.tablePanelHeader.Controls.Add(this.panelInfoHeader, 1, 0);
            this.tablePanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.tablePanelHeader.Location = new System.Drawing.Point(0, 0);
            this.tablePanelHeader.Name = "tablePanelHeader";
            this.tablePanelHeader.RowCount = 1;
            this.tablePanelHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tablePanelHeader.Size = new System.Drawing.Size(279, 77);
            this.tablePanelHeader.TabIndex = 3;
            // 
            // panelCrachaHeader
            // 
            this.panelCrachaHeader.Controls.Add(this.picBoxCracha);
            this.panelCrachaHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCrachaHeader.Location = new System.Drawing.Point(3, 3);
            this.panelCrachaHeader.Name = "panelCrachaHeader";
            this.panelCrachaHeader.Size = new System.Drawing.Size(87, 71);
            this.panelCrachaHeader.TabIndex = 0;
            // 
            // picBoxCracha
            // 
            this.picBoxCracha.BackColor = System.Drawing.Color.PowderBlue;
            this.picBoxCracha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxCracha.Image = global::CVirtual.Properties.Resources.id;
            this.picBoxCracha.Location = new System.Drawing.Point(0, 0);
            this.picBoxCracha.Name = "picBoxCracha";
            this.picBoxCracha.Size = new System.Drawing.Size(87, 71);
            this.picBoxCracha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBoxCracha.TabIndex = 0;
            this.picBoxCracha.TabStop = false;
            // 
            // panelInfoHeader
            // 
            this.panelInfoHeader.BackColor = System.Drawing.Color.PowderBlue;
            this.panelInfoHeader.Controls.Add(this.lblInfoHeader);
            this.panelInfoHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInfoHeader.Location = new System.Drawing.Point(96, 3);
            this.panelInfoHeader.Name = "panelInfoHeader";
            this.panelInfoHeader.Size = new System.Drawing.Size(180, 71);
            this.panelInfoHeader.TabIndex = 1;
            // 
            // lblInfoHeader
            // 
            this.lblInfoHeader.AutoSize = true;
            this.lblInfoHeader.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoHeader.ForeColor = System.Drawing.Color.Black;
            this.lblInfoHeader.Location = new System.Drawing.Point(0, 10);
            this.lblInfoHeader.Name = "lblInfoHeader";
            this.lblInfoHeader.Size = new System.Drawing.Size(180, 50);
            this.lblInfoHeader.TabIndex = 4;
            this.lblInfoHeader.Text = "SENHA DE \r\nADMINISTRADOR";
            this.lblInfoHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(279, 246);
            this.Controls.Add(this.panelForm);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ":: Autenticar-se";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            this.tablePanelHeader.ResumeLayout(false);
            this.panelCrachaHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCracha)).EndInit();
            this.panelInfoHeader.ResumeLayout(false);
            this.panelInfoHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.TableLayoutPanel tablePanelHeader;
        private System.Windows.Forms.Panel panelCrachaHeader;
        private System.Windows.Forms.Panel panelInfoHeader;
        private System.Windows.Forms.PictureBox picBoxCracha;
        private System.Windows.Forms.Label lblInfoHeader;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnLogin;
    }
}