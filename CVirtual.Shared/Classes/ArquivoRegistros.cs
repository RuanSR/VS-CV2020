using System.Collections.Generic;

namespace CVirtual.Shared.Classes
{
    public class ArquivoRegistros
    {
        public ArquivoRegistros(string registro)
        {
            Registro = registro;
        }
        public int ArquivoRegistrosId { get; set; }
        public string Registro { get; private set; }
        public int NotaContaId { get; set; }

        public override string ToString()
        {
            return Registro;
        }
    }
}
