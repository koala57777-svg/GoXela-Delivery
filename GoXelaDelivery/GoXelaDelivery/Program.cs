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
            //Cliente cliente = new Cliente("hola", 23, "d", "di", Enums.Municipio.Olintepeque, 3);
            Console.WriteLine(AyudanteConsola.ValidarAlfanumerico("Ingrese su placa", 10));
            //Console.WriteLine($"{cliente.MunicipioDestino}\n\n{cliente.DireccionDestino}");
            Console.ReadKey();
        }
    }
}
