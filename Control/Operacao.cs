using Model.Classes.ClienteModel;
using Model.Enum;
using Model.Exceptions;
using System;

namespace Model.Classes
{
    public static class Operacao
    {
        public static Cliente AdicionarValor(Cliente c, double valor, string atendente, string obs)
        {
            ValidaDados(c, valor, atendente);
            if(valor <= c.NotaConta.LimiteConta)
            {
                var limiteConta = c.NotaConta.LimiteConta;
                var totalConta = c.NotaConta.TotalConta + valor;
                var dataConta = VerificaData(Operacoes.ADICIONAR, c.NotaConta.DataConta, valor);
                c.NotaConta.AtualizarNota(limiteConta, totalConta, dataConta);
                c.NotaConta.RegistroNotas.Add(new RegistroNota(DateTime.Now, atendente, valor, obs));
                return c;
            }
            throw new OperacaoException("O valor não pode ser maior que o limite da conta!");
        }

        public static Cliente DebitarValor(Cliente c, double valor, string atendente, string obs)
        {
            ValidaDados(c, valor, atendente);
            if(valor <= c.NotaConta.TotalConta)
            {
                var limiteConta = c.NotaConta.LimiteConta;
                var totalConta = c.NotaConta.TotalConta - valor;
                var dataConta = VerificaData(Operacoes.DEBITAR, c.NotaConta.DataConta, totalConta);
                c.NotaConta.AtualizarNota(limiteConta, totalConta, dataConta);
                c.NotaConta.RegistroNotas.Add(new RegistroNota(DateTime.Now, atendente, valor, obs));
                return c;
            }
            throw new OperacaoException("O valor do debito não pode ser maior que valor total da conta!");
        }

        static string VerificaData(Operacoes op, string propriedadeData, double totalConta)
        {
            if (op == Operacoes.ADICIONAR)
            {
                if(propriedadeData != "ZERADO")
                {
                    return propriedadeData;
                }
                return DateTime.Now.ToString("dd/MM/yyyy");
            }else
            {
                if (totalConta <= 0)
                {
                    return "ZERADO";
                }
                return propriedadeData;
            }
        }
        private static void ValidaDados(Cliente c, double valor, string atendente)
        {
            if(valor < 0)
            {
                throw new ArgumentException("O valor não pode ser negativo.");
            }
            if(valor == 0.0)
            {
                throw new OperacaoException("O valor não pode ser zero.");
            }
            if(string.IsNullOrEmpty(atendente))
            {
                throw new ArgumentException("É preciso prenecher o campo Atendente.");
            }
        }
    }
}