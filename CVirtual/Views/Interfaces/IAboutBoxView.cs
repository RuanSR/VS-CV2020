using System.Windows.Forms;

namespace CVirtual.Views.Interfaces
{
    public interface IAboutBoxView
    {
        Label LblProductName { get; }
        Label LblVersion { get; }
        Label LblCopyright { get; }
        Label LblCompanyName { get; }
        TextBox TxtDescription { get; }
        Button BtnOk { get; }
    }
}
