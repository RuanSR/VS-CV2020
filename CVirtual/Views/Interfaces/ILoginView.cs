using CVirtual.Shared.Classes;
using System.Windows.Forms;

namespace CVirtual.Views.Interfaces
{
    public interface ILoginView
    {
        TextBox TxtUser { get; }
        TextBox TxtPassword { get; }
        Button BtnLogin { get; }
    }
}