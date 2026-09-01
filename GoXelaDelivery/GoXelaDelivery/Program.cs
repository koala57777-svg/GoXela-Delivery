using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoXelaDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numeroElegido = AyudanteConsola.MenuMunicipios();
            Console.WriteLine($"\n\n{numeroElegido}");

            Console.ReadKey();
        }
    }
}
