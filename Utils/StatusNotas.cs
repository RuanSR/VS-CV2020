using System;
using Utils.Enum;

namespace Utils
{
    public static class StatusNotas
    {
        private static string _ultimoRegistro = null;

        public static string GetUltimaNota {
            get {
                if (_ultimoRegistro != null)
                {
                    return _ultimoRegistro;
                }
                return "Nenhum registro até o momento.";
            }
            private set {

            }
        }

        public static void SetUltimaNota(string nomeCliente, double valorNota, DateTime horaNota, Operacao operacao)
        {
            if (operacao == Operacao.ADICIONAR)
            {
                _ultimoRegistro = string.Format("{0}, adicionado o valor de R${1}, ás {2}", nomeCliente, valorNota.ToString("F2"), horaNota.ToString("HH:mm:ss"));
            }
            else
                _ultimoRegistro = string.Format("{0}, debitado o valor de R${1}, ás {2}", nomeCliente, valorNota.ToString("F2"), horaNota.ToString("HH:mm:ss"));
        }
    }
}
