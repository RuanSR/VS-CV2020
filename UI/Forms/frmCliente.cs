using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class frmCliente : Form
    {
        private Size SizeParent { get; set; }
        public frmCliente(Size sizeParent)
        {
            InitializeComponent();
            sizeParent.Width = sizeParent.Width / 2;
            sizeParent.Height = sizeParent.Height / 2;
            SizeParent = sizeParent;
            this.Size = SizeParent;
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            
        }
    }
}
