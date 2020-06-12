using Models.Enum;
using System;

namespace WinDesktop.Utils
{
    public static class AppController
    {
        private static string _ultimoRegistro = null;

        public static void SetUltimaNota(string nomeCliente, double valorNota, DateTime horaNota, Operacoes operacao)
        {
            if (operacao == Operacoes.ADICIONAR)
            {
                _ultimoRegistro = string.Format("{0}, adicionado o valor de R${1}, ás {2}", nomeCliente, valorNota.ToString("F2"), horaNota.ToString("HH:mm:ss"));
            }
            else
                _ultimoRegistro = string.Format("{0}, debitado o valor de R${1}, ás {2}", nomeCliente, valorNota.ToString("F2"), horaNota.ToString("HH:mm:ss"));
        }
    }
}
