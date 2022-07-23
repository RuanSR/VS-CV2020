using CVirtual.Shared.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVirtual.Utils
{
    public static class Util
    {
        public static int GetClienteTotalDays(Cliente cliente)
        {
            if (cliente == null || cliente?.NotaConta == null) throw new ArgumentNullException("Cliente não pode ser nulo.");
            
            if (cliente.NotaConta.DataConta == "ZERADO")
            {
                return 0;
            }
            TimeSpan date = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yy")) - Convert.ToDateTime(cliente.NotaConta.DataConta);
            return date.Days;
        }
    }
}
