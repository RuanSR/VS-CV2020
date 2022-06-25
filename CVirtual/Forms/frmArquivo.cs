using CVirtual.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVirtual.Forms
{
    public partial class frmArquivo : Form
    {
        private readonly int _id;
        public frmArquivo(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private void frmArquivo_Load(object sender, EventArgs e)
        {
            dtgLog.Columns["registro"].Width = this.Width;
            dtgLog.DataSource = new ArquivoRegistrosRepository().GetArquivados(_id).Result.OrderByDescending(n => n.ArquivoRegistrosId).ToList();
            Estilo();
        }

        private void Estilo()
        {
            for (int i = 0; i < dtgLog.Rows.Count; i += 2)
            {
                dtgLog.Rows[i].DefaultCellStyle.BackColor = Color.Lavender;
            }
        }
    }
}
