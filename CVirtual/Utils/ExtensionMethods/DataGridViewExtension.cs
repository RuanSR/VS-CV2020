using System.Drawing;
using System.Windows.Forms;

namespace CVirtual.Utils.ExtensionMethods
{
    public static class DataGridViewExtension
    {
        public static DataGridView ApplyGridViewCellStyle(this DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.Rows.Count; i += 2)
            {
                dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Lavender;
            }

            return dataGridView;
        }
    }
}
