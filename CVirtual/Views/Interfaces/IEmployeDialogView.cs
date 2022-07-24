using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVirtual.Views.Interfaces
{
    public interface IEmployeDialogView
    {
        int EmployeId { get; }
        TextBox TxtEmployeId { get; }
        TextBox TxtFullName { get; }
        TextBox TxtUser { get; }
        TextBox TxtPassword { get; }
        ToolStripButton BtnSave { get; }
    }
}
