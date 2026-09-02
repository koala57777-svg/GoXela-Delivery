using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoXelaDelivery
{
    internal class CodigoUnico
    {
        
        private HashSet<string> baseDeCodigosUnicos = new HashSet<string>();

        
        private Dictionary<string, int> ultimosNumeros = new Dictionary<string, int>();

        
        private static readonly object bloqueo = new object();

        public string GenerarCodigoUnico(string prefijo)
        {
            lock (bloqueo)
            {
                if (!ultimosNumeros.TryGetValue(prefijo, out int numeroActual))
                {
                    numeroActual = 0;
                }

                string codigoCandidato;

                do
                {
                    numeroActual++;
                    codigoCandidato = $"{prefijo}-{numeroActual:D3}";
                }
                while (ExisteEnBaseDeDatos(codigoCandidato));

                ultimosNumeros[prefijo] = numeroActual;
                baseDeCodigosUnicos.Add(codigoCandidato);

                return codigoCandidato;
            }
        }

        private bool ExisteEnBaseDeDatos(string codigo)
        {
            return baseDeCodigosUnicos.Contains(codigo);
        }
    }
}
