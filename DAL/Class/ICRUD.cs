using System.Data;

namespace DAL.Class
{
    public interface ICRUD
    {
        DataTable Read();
        void Insert();
        void Update();
        void Delete();
    }
}
