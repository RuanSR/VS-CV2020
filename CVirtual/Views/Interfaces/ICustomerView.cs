using CVirtual.Shared.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVirtual.Views.Interfaces
{
    public interface ICustomerView
    {
        int CustomerId { get; }
        string TitleForm { get; set; }
        ToolStripButton BtnAddAmount{ get; }
        ToolStripButton BtnRemoveAmount{ get; }
        ToolStripButton BtnUpdateDataCustomer{ get; }
        ToolStripButton BtnLogout{ get; }
        DataGridView DtgLog{ get; }
        Label LblFullName{ get; }
        Label LblDateAmount{ get; }
        Label LblAmountDateOpened{ get; }
        Label LblRemainingLimit{ get; }
        Label LblMaxAmount{ get; }
        Label LblTotalAmount{ get; }
        Label LblTotalNotes{ get; }
        Label LblCpf{ get; }
        Label LblPhoneNumber{ get; }
        Label LblAddress{ get; }
        Label LblFirstName{ get; }
        Label LblId{ get; }
        ToolStripButton BtnOpenFileStorage{ get; }
    }
}
