using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoXelaDelivery.AyudanteConsola;
using static GoXelaDelivery.Globales;

namespace GoXelaDelivery
{
    internal static class ModuloClientes
    {
        public static void IniciarSubmenu(Delivery GoXelaDelivery)
        {
            OpcionMenuPrincipal = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("===================================");
                Console.WriteLine("           MÓDULO CLIENTE          ");
                Console.WriteLine("===================================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Registrar un Cliente");
                Console.WriteLine("2. Consultar Información de Cliente");
                Console.WriteLine("3. Modificar Información de Cliente");
                Console.WriteLine("4. Volver al Menú Principal");
                Console.ResetColor();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Opción: ");
                Console.ResetColor();
                int opcionElegida;
                while (!int.TryParse(Console.ReadLine(), out opcionElegida))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("Error: Dato no válido");
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Intente de nuevo: ");
                    Console.ResetColor();
                }
                OpcionMenuPrincipal = opcionElegida;
                Console.Clear();
                switch (OpcionMenuPrincipal)
                {
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    default:

                        break;
                }
            } while (OpcionMenuPrincipal != 4);
        }
    }
}
