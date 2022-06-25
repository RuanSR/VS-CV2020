namespace CVirtual.Shared.Struct
{
    public struct ClienteDataVisualizer
    {
        public ClienteDataVisualizer(int idCliente, string nomeCliente, string apelidoCliente, string enderecoCliente,
            double limiteContaCliente, double totalContaCliente, string dataContaCliente, bool statusCliente)
        {
            IdCliente = idCliente;
            NomeCliente = nomeCliente;
            ApelidoCliente = apelidoCliente;
            EnderecoCliente = enderecoCliente;
            LimiteContaCliente = limiteContaCliente;
            TotalContaCliente = totalContaCliente;
            DataContaCliente = dataContaCliente;
            StatusCliente = statusCliente;
        }

        public int IdCliente { get; }
        public string NomeCliente { get; }
        public string ApelidoCliente { get; }
        public string EnderecoCliente { get; }
        public double LimiteContaCliente { get; }
        public double TotalContaCliente { get; }
        public string DataContaCliente { get; }
        public bool StatusCliente { get; }
    }
}
