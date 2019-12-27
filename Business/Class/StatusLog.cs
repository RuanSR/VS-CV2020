using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Class
{
    public static class StatusLog
    {
        //private static string _ultimoBackup = null;
        private static string _ultimoRegistro = null;

        //public static string UltimoBackup
        //{
        //    get
        //    {
        //        if (_ultimoBackup != null)
        //        {
        //            return _ultimoBackup;
        //        }
        //        return "Nenhum registro até o momento.";
        //    }
        //    private set
        //    {

        //    }
        //}
        public static string UltimaNota 
        {
            get
            {
                if (_ultimoRegistro != null)
                {
                    return _ultimoRegistro;
                }
                return "Nenhum registro até o momento.";
            }
            private set
            {

            }
        }

        //public static void SetUltimoBackup(string hora)
        //{
        //    _ultimoBackup = string.Format("ás {0}", hora);
        //}
        public static void SetUltimaNota(string nomeCliente, string valorNota, string horaNota, Operacao operacao)
        {
            if (operacao == Operacao.ADICIONAR)
            {
                _ultimoRegistro = string.Format("{0}, adicionado o valor de R${1}, ás {2}",nomeCliente,valorNota, horaNota);
            }else
                _ultimoRegistro = string.Format("{0}, debitado o valor de R${1}, ás {2}", nomeCliente, valorNota, horaNota);
        }
    }
}
