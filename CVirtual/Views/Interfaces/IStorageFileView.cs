using System.Windows.Forms;

namespace CVirtual.Views.Interfaces
{
    public interface IStorageFileView
    {
        int ClienteId { get; }
        DataGridView GridViewLog { get; }
    }
}