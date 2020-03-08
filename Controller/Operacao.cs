using Model.Classes.ClienteModel;
using Model.Enum;
using Model.Exceptions;
using System;

namespace Controller
{
    public class Operacao
    {
        static ClienteController cController = new ClienteController();
        public static Cliente AdicionarValor(Cliente c, double valor, string atendente, string obs)
        {
            ValidaDados(c, valor, atendente);
            if (valor <= c.NotaConta.LimiteConta)
            {
                var limiteConta = c.NotaConta.LimiteConta;
                var totalConta = c.NotaConta.TotalConta + valor;
                var dataConta = VerificaData(Operacoes.ADICIONAR, c.NotaConta.DataConta, valor);
                cController.AtualizarCliente(c);
                c.NotaConta.AtualizarNota(limiteConta, totalConta, dataConta);
                c.NotaConta.RegistroNotas.Add(new RegistroNota(FormatoDateTime(), atendente, valor, FormatObs(Operacoes.ADICIONAR,obs)));
                return c;
            }
            throw new OperacaoException("O valor não pode ser maior que o limite da conta!");
        }
        public static Cliente DebitarValor(Cliente c, double valor, string atendente, string obs)
        {
            ValidaDados(c, valor, atendente);
            if (valor <= c.NotaConta.TotalConta)
            {
                var limiteConta = c.NotaConta.LimiteConta;
                var totalConta = c.NotaConta.TotalConta - valor;
                var dataConta = VerificaData(Operacoes.DEBITAR, c.NotaConta.DataConta, totalConta);
                cController.AtualizarCliente(c);
                c.NotaConta.AtualizarNota(limiteConta, totalConta, dataConta);
                c.NotaConta.RegistroNotas.Add(new RegistroNota(FormatoDateTime(), atendente, valor, FormatObs(Operacoes.DEBITAR, obs)));
                return c;
            }
            throw new OperacaoException("O valor do debito não pode ser maior que valor total da conta!");
        }

        static string VerificaData(Operacoes op, string propriedadeData, double totalConta)
        {
            if (op == Operacoes.ADICIONAR)
            {
                if (propriedadeData != "ZERADO")
                {
                    return propriedadeData;
                }
                return DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
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
            if (valor < 0)
            {
                throw new ArgumentException("O valor não pode ser negativo.");
            }
            if (valor == 0.0)
            {
                throw new OperacaoException("O valor não pode ser zero.");
            }
            if (string.IsNullOrEmpty(atendente))
            {
                throw new ArgumentException("É preciso prenecher o campo Atendente.");
            }
        }
        private static string FormatObs(Operacoes opType,string obs)
        {
            if (opType == Operacoes.ADICIONAR)
            {
                if (string.IsNullOrEmpty(obs))
                {
                    return "SEM OBSERVAÇÔES";
                }
                return obs;
            }
            else
            {
                if (string.IsNullOrEmpty(obs))
                {
                    return "DEBITO EFETUADO, SEM OBSERVAÇÔES";
                }
                return $"DEBITO EFETUADO. {obs}";
            }
        }
        private static DateTime FormatoDateTime()
        {
            return DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        }
    }
}
