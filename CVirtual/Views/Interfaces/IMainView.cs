using CVirtual.Shared.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVirtual.Views.Interfaces
{
    public interface IMainView
    {
        ToolStripButton BtnAddCustomer { get; }
        ToolStripButton BtnAuth { get; }
        ToolStripMenuItem BtnAbout { get; }
        TextBox TxtSearch { get; }
        ToolStripMenuItem BtnSystem { get; }
        DataGridView DataGridViewCustomers { get; }
        ToolStripStatusLabel LblStatusRegistro { get; }
        ToolStripStatusLabel LblLastBackup { get; }
        RadioButton RbStatusOff { get; }
        RadioButton RbStatusOn { get; }
        GroupBox GroupBoxSearth { get; }
        StatusStrip StatusBar { get; }
    }
}
