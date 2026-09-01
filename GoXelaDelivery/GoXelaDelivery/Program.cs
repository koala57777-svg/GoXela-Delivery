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
            Cliente cliente = new Cliente("hola", 23, "d", "di", Enums.Municipio.Olintepeque, 3);
            AyudanteConsola.ValidarDireccion(cliente);
            Console.WriteLine($"{cliente.MunicipioDestino}\n\n{cliente.DireccionDestino}");
            Console.ReadKey();
        }
    }
}
