using System;
using static GoXelaDelivery.AyudanteConsola;
using static GoXelaDelivery.Globales;

namespace GoXelaDelivery
{
    internal static class ModuloReportes
    {
        public static void IniciarSubmenu(Delivery goXelaDelivery)
        {
            OpcionMenuPrincipal = 0;
            do
            {
                OpcionMenuPrincipal = ValidarNumerico(2, OpcionesMenuReportes, 11, true);
                Console.Clear();
                switch (OpcionMenuPrincipal)
                {
                    case 1:
                        goXelaDelivery.MostrarEntregasActivas();
                        LimpiarConsola();
                        break;
                    case 2:
                        goXelaDelivery.MostrarEntregasFinalizadas();
                        LimpiarConsola();
                        break;
                    case 3:
                        goXelaDelivery.MostrarEntregasCanceladas();
                        LimpiarConsola();
                        break;
                    case 4:
                        goXelaDelivery.MostrarEntregasConIncidencias();
                        LimpiarConsola();
                        break;
                    case 5:
                        goXelaDelivery.MostrarRepartidoresDisponibles();
                        LimpiarConsola();
                        break;
                    case 6:
                        goXelaDelivery.MostrarRepartidorConMasEntregas();
                        LimpiarConsola();
                        break;
                    case 7:
                        goXelaDelivery.MostrarVehiculoMasUsado();
                        LimpiarConsola();
                        break;
                    case 8:
                        goXelaDelivery.CantidadPaquetesPorTipo();
                        LimpiarConsola();
                        break;
                    case 9:
                        goXelaDelivery.MostrarTotalIngresos();
                        LimpiarConsola();
                        break;
                    case 10:
                        goXelaDelivery.MostrarEntregaConMayorCosto();
                        LimpiarConsola();
                        break;
                    case 11:

                        break;
                    default:
                        ErroOpcionNoValida();
                        break;
                }
            } while (OpcionMenuPrincipal != 11);
        }

        public static void OpcionesMenuReportes()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("          MÓDULO REPORTES          ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Entregas activas");
            Console.WriteLine("2. Entregas finalizadas");
            Console.WriteLine("3. Entregas canceladas");
            Console.WriteLine("4. Entregas con incidencias");
            Console.WriteLine("5. Repartidores disponibles");
            Console.WriteLine("6. Repartidor con más entregas");
            Console.WriteLine("7. Vehículo más utilizado");
            Console.WriteLine("8. Cantidad de paquetes por tipo");
            Console.WriteLine("9. Total de ingresos");
            Console.WriteLine("10. Entrega con mayor costo");
            Console.WriteLine("11. Volver al Menú Principal");
            Console.ResetColor();
        }
    }
}