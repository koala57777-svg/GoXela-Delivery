using System;
using System.Collections.Generic;
using System.Linq;
using static GoXelaDelivery.AyudanteConsola;
using static GoXelaDelivery.Globales;
using static GoXelaDelivery.Enums;

namespace GoXelaDelivery
{
    internal static class ModuloEntregas
    {
        public static void IniciarSubmenu(Delivery goXelaDelivery)
        {
            OpcionMenuPrincipal = 0;
            do
            {
                OpcionMenuPrincipal = ValidarNumerico(1, OpcionesMenuEntregas, 4);
                Console.Clear();
                switch (OpcionMenuPrincipal)
                {
                    case 1:
                        RegistrarEntrega(goXelaDelivery);
                        break;
                    case 2:
                        MostarInformacionEntrega(goXelaDelivery);
                        break;
                    case 3:
                        AbrirSubmenuModificarInformacionEntrega(goXelaDelivery);
                        break;
                    case 4:

                        break;
                    default:
                        ErroOpcionNoValida();
                        break;
                }
            } while (OpcionMenuPrincipal != 4);
        }

        public static void RegistrarEntrega(Delivery goXelaDelivery)
        {
            if (goXelaDelivery.ListaClientes.Count == 0 || goXelaDelivery.ListaClientes == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No hay ningún Cliente registrado.");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }

            List<Paquete> todosNoAsignados = goXelaDelivery.ListasPaquetes.SelectMany(p => p).Where(p => p.EstadoPaquete == EstadoPaquete.NoAsignado).ToList();
            if (todosNoAsignados.Count == 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No hay Paquetes disponibles (No Asignados) en el sistema.");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }

            int numeroTipoServicio = ValidarNumerico(1, MenuTipoServicios, Enum.GetNames(typeof(TipoServicio)).Length);
            TipoServicio tipoServicio = (TipoServicio)numeroTipoServicio;
            ServicioSeleccionado = tipoServicio;

            int posicionCliente = ValidarNumerico(1, ModuloClientes.ListaDeClientes, goXelaDelivery, goXelaDelivery.ListaClientes.Count);
            Cliente clienteSeleccionado = goXelaDelivery.ListaClientes[posicionCliente - 1];

            List<Paquete> paquetesDelCliente = todosNoAsignados.Where(p => p.ClientePaquete == clienteSeleccionado).ToList();

            if (paquetesDelCliente.Count == 0)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("El cliente seleccionado no tiene paquetes sin asignar.");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }

            int posicionPaquete = ValidarNumerico(1, ListaDePaquetesDisponibles, paquetesDelCliente, paquetesDelCliente.Count);
            Paquete paqueteSeleccionado = paquetesDelCliente[posicionPaquete - 1];

            double distancia = GestorDistancias.ObtenerDistancia(paqueteSeleccionado.MunicipioOrigen, paqueteSeleccionado.MunicipioDestino);

            Entrega entrega = new Entrega(paqueteSeleccionado, TipoVehiculoGeneral.Motocicleta, distancia, tipoServicio, 0);

            entrega.ClienteEntrega = clienteSeleccionado;

            double tarifaBase = entrega.CalcularTarifaEntrega(paqueteSeleccionado, distancia);
            entrega.TarifaBase = tarifaBase;
            entrega.VehiculoGeneral = VehiculoSeleccionado;

            paqueteSeleccionado.EstadoPaquete = EstadoPaquete.Asignado;
            paqueteSeleccionado.ClientePaquete.SolicitudesRealizadas++;

            goXelaDelivery.IngresarEntrega(entrega);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Se Registró Correctamente la Entrega.");
            Console.ResetColor();
            LimpiarConsola();
        }

        public static void MostarInformacionEntrega(Delivery goXelaDelivery)
        {
            if (goXelaDelivery.ListaEntregas.Count == 0 || goXelaDelivery.ListaEntregas == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("No hay ninguna Entrega Registrada");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            else
            {
                int posicion = ValidarNumerico(1, ListaDeEntregas, goXelaDelivery, goXelaDelivery.ListaEntregas.Count);
                Console.WriteLine();
                goXelaDelivery.ListaEntregas[posicion - 1].MostrarInformacion();
                LimpiarConsola();
                return;
            }
        }

        public static void AbrirSubmenuModificarInformacionEntrega(Delivery goXelaDelivery)
        {
            if (goXelaDelivery.ListaEntregas.Count == 0 || goXelaDelivery.ListaEntregas == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("No hay ninguna Entrega Registrada");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            else
            {
                int posicion = ValidarNumerico(1, ListaDeEntregas, goXelaDelivery, goXelaDelivery.ListaEntregas.Count);
                Console.WriteLine();
                SubmenuModificacionEntrega(goXelaDelivery.ListaEntregas[posicion - 1], goXelaDelivery);
                OpcionMenuPrincipal = 0;
                LimpiarConsola();
                return;
            }
        }

        public static void SubmenuModificacionEntrega(Entrega entrega, Delivery goXelaDelivery)
        {
            OpcionMenuPrincipal = 0;
            do
            {
                OpcionMenuPrincipal = ValidarNumerico(1, OpcionesSubMenuModificarEntrega, entrega, 5);
                Console.Clear();
                switch (OpcionMenuPrincipal)
                {
                    case 1:
                        ConfirmarEntrega(entrega, goXelaDelivery);
                        if (entrega.EstadoEntrega == EstadoEntrega.Cofirmado)
                        {
                            entrega.CalcularTotalEntregaConfirmada(entrega);
                        }
                        break;
                    case 2:
                        entrega.CambiarEstadoEntregaConfirmada();
                        if (entrega.EstadoEntrega == EstadoEntrega.Entregada)
                        {
                            entrega.RepartidorAsignado.CantidadEntregasRealizadas++;
                            entrega.VehiculoAsigando.EntregasRealizadas++;
                            goXelaDelivery.TotalIngresos += entrega.Total;

                            double calificacion = ValidarCalificacion();
                            entrega.RepartidorAsignado.CalificacionTotal += calificacion;
                            entrega.RepartidorAsignado.CalificacionPromedio = entrega.RepartidorAsignado.CalificacionTotal / entrega.RepartidorAsignado.CantidadEntregasRealizadas;

                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Calificación registrada exitosamente.");
                            Console.ResetColor();
                            LimpiarConsola();
                        }
                        break;
                    case 3:
                        entrega.CancelarEntrega();
                        break;
                    case 4:
                        entrega.ReprogramarEntrega();
                        break;
                    case 5:

                        break;
                    default:
                        ErroOpcionNoValida();
                        break;
                }
            } while (OpcionMenuPrincipal != 5);
        }

        public static void ListaDeEntregas(Delivery goXelaDelivery)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("          LISTA DE ENTREGAS        ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();

            foreach (Entrega entrega in goXelaDelivery.ListaEntregas)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{goXelaDelivery.ListaEntregas.IndexOf(entrega) + 1}. Estado: ");
                Console.ResetColor();
                Console.Write($"{entrega.EstadoEntrega.ObtenerDescripcion()} || ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Cliente: ");
                Console.ResetColor();
                Console.Write($"{entrega.ClienteEntrega.NombreCompleto} || ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"ID: ");
                Console.ResetColor();
                Console.Write($"{entrega.CodigoUnico}");
                Console.WriteLine();
            }
        }

        public static void ListaDePaquetesDisponibles(List<Paquete> paquetes)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("    PAQUETES NO ASIGNADOS          ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();

            foreach (Paquete paquete in paquetes)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{paquetes.IndexOf(paquete) + 1}. Tipo: ");
                Console.ResetColor();
                Console.Write($"{paquete.TipoPaquete.ObtenerDescripcion()} || ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Cliente: ");
                Console.ResetColor();
                Console.Write($"{paquete.ClientePaquete.NombreCompleto} || ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"ID: ");
                Console.ResetColor();
                Console.Write($"{paquete.CodigoUnico}");
                Console.WriteLine();
            }
        }

        public static void OpcionesMenuEntregas()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("           MÓDULO ENTREGAS         ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Registrar una Entrega");
            Console.WriteLine("2. Consultar Información de Entrega");
            Console.WriteLine("3. Modificar Información de Entrega");
            Console.WriteLine("4. Volver al Menú Principal");
            Console.ResetColor();
        }

        public static void OpcionesSubMenuModificarEntrega(Entrega entrega)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("=====================================");
            Console.WriteLine($"MENÚ ENTREGA  ({entrega.CodigoUnico})");
            Console.WriteLine("=====================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Confirmar Entrega");
            Console.WriteLine("2. Cambiar a Siguiente Estado");
            Console.WriteLine("3. Cancelar Entrega");
            Console.WriteLine("4. Reprogramar Entrega");
            Console.WriteLine("5. Regresar a Gestión de Entregas");
            Console.ResetColor();
        }

        public static void MenuTipoServicios()
        {
            List<string> listaServicios = Enum.GetValues(typeof(TipoServicio))
                                   .Cast<TipoServicio>()
                                   .Select(m => m.ObtenerDescripcion())
                                   .ToList();
            foreach (string servicio in listaServicios)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{listaServicios.IndexOf(servicio) + 1}. ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{servicio}");
                Console.ResetColor();
            }
        }
    }
}