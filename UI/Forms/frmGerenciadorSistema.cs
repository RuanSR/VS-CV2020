using Business.Class;
using System;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class frmGerenciadorSistema : Form
    {
        private Atendente Atendente { get; set; }
        DBManager dbManager;
        public frmGerenciadorSistema()
        {
            InitializeComponent();
            dbManager = new DBManager();
        }

        private void frmGerenciadorSistema_Load(object sender, EventArgs e)
        {
            CarregaAtendentes();
        }
        //CONTROLES\\
        private void dtgAtendente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgAtendente.Columns[e.ColumnIndex].Name == "btnEdit")
                {
                    int id = (int)dtgAtendente.Rows[e.RowIndex].Cells["id_atendente"].Value;
                    string nome = dtgAtendente.Rows[e.RowIndex].Cells["usuario_atendente"].Value.ToString();
                    string senha = dtgAtendente.Rows[e.RowIndex].Cells["senha_atendente"].Value.ToString();

                    Atendente = new Atendente(id, nome, senha);
                    frmAtendenteDialog frm = new frmAtendenteDialog(Atendente);
                    frm.ShowDialog();

                    if (frm.IsDisposed)
                    {
                        CarregaAtendentes();
                    }
                }
                else if (dtgAtendente.Columns[e.ColumnIndex].Name == "btnAdd")
                {
                    frmAtendenteDialog frm = new frmAtendenteDialog();
                    frm.ShowDialog();

                    if (frm.IsDisposed)
                    {
                        CarregaAtendentes();
                    }
                }
                else if (dtgAtendente.Columns[e.ColumnIndex].Name == "btnDelete")
                {
                    if (MessageBox.Show("Deseja realamente remover este atendente?", "ATENÇÂO!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dbManager.RemoveAtendente((int)dtgAtendente.Rows[e.RowIndex].Cells["id_atendente"].Value);
                        MessageBox.Show("Atendete removido!", "ATENÇÂO!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        CarregaAtendentes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //METODOS\\
        private void CarregaAtendentes()
        {
            try
            {
                dtgAtendente.DataSource = dbManager.GetAtendentes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
