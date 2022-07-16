using CVirtual.Views.Interfaces;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace CVirtual.Views
{
    partial class AboutBoxForm : Form, IAboutBoxView
    {
        public Label LblProductName => this.labelProductName;

        public Label LblVersion => this.labelVersion;

        public Label LblCopyright => this.labelCopyright;

        public Label LblCompanyName => this.labelCompanyName;

        public TextBox TxtDescription => this.textBoxDescription;

        public Button BtnOk => this.okButton;

        public AboutBoxForm()
        {
            InitializeComponent();
            this.Text = String.Format("Sobre {0}", AssemblyTitle);
            LblProductName.Text = AssemblyProduct;
            LblVersion.Text = String.Format("Versão {0}", AssemblyVersion);
            LblCopyright.Text = AssemblyCopyright;
            LblCompanyName.Text = AssemblyCompany;
            TxtDescription.Text = AssemblyDescription;
        }

        #region Acessório de Atributos do Assembly

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}
