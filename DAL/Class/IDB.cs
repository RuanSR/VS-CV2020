using System;
using System.Data;

namespace DAL.Class
{
    public interface IDB
    {
        DataTable GetAdmin(string usuario, string senha);
        DataTable GetData();
    }
}
