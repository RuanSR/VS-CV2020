using System.Windows.Forms;

namespace CVirtual.Views.Interfaces
{
    public interface ISystemManagerView
    {
        TabControl TabControl { get; }
        TabPage TabPageAdmin { get; }
        DataGridView DataGridViewEmployee { get; }
        ToolStripButton BtnNewEmployee { get; }
        ComboBox CbBackupInterval { get; }
        TabPage TabPageBackupRestore { get; }
        OpenFileDialog OpenFileDialog { get; }
        FolderBrowserDialog FolderBrowserDialog { get; }
        TextBox LocalPathBackup { get; }
    }
}
