using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoXelaDelivery.Globales;
namespace GoXelaDelivery
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            Delivery GoXelaDelivery = new Delivery();
            OpcionMenuPrincipal = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("===================================");
                Console.WriteLine("           GOXELA DELIVERY         ");
                Console.WriteLine("===================================");
                Console.ResetColor();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Gestión de Clientes");
                Console.WriteLine("2. Gestión de Repartidores");
                Console.WriteLine("3. Gestión de Vehículos");
                Console.WriteLine("4. Gestión de Paquetes");
                Console.WriteLine("5. Gestión de Entregas");
                Console.WriteLine("6. Gestión de Incidencias");
                Console.WriteLine("7. Reportes");
                Console.WriteLine("8. Salir");
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
                        ModuloClientes.IniciarSubmenu(GoXelaDelivery);
                        break;
                    case 2:
                        ModuloRepartidores.IniciarSubmenu(GoXelaDelivery);
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:

                        break;
                    case 8:
                        SalirMenu();
                        break;
                    default:
                        ErroOpcionNoValida();
                        break;
                }
            } while (OpcionMenuPrincipal != 8);
        }
    }
}
