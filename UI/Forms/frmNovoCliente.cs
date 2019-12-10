using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class frmNovoCliente : Form
    {
        
        public frmNovoCliente(Size sizeParent)
        {
            InitializeComponent();
            sizeParent.Width = sizeParent.Width / 2;
            sizeParent.Height = sizeParent.Height / 2;
            this.Size = sizeParent;
        }
    }
}
