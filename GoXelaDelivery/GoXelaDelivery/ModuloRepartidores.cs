using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoXelaDelivery.AyudanteConsola;
using static GoXelaDelivery.Globales;
using static GoXelaDelivery.Enums;

namespace GoXelaDelivery
{
    internal static class ModuloRepartidores
    {
        public static void IniciarSubmenu(Delivery goXelaDelivery)
        {
            OpcionMenuPrincipal = 0;
            do
            {
                OpcionMenuPrincipal = ValidarNumerico(1, OpcionesMenuRepartidores, 4);
                Console.Clear();
                switch (OpcionMenuPrincipal)
                {
                    case 1:
                        RegistrarRepartidor(goXelaDelivery);
                        break;
                    case 2:
                        MostarInformacionRepartidor(goXelaDelivery);
                        break;
                    case 3:
                        AbrirSubmenuModificarInformacionRepartidor(goXelaDelivery);
                        break;
                    case 4:

                        break;
                    default:
                        ErroOpcionNoValida();
                        break;
                }
            } while (OpcionMenuPrincipal != 4);
        }

        public static void AbrirSubmenuModificarInformacionRepartidor(Delivery goXelaDelivery)
        {
            if (goXelaDelivery.ListaRepartidores.Count == 0 || goXelaDelivery.ListaRepartidores == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("No hay ningún Repartidor Registrado");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            else
            {
                int posicionRepartidor = ValidarNumerico(1, ListaDeRepartidores, goXelaDelivery, goXelaDelivery.ListaRepartidores.Count);
                Console.WriteLine();
                SubmenuModificacionRepartidor(goXelaDelivery.ListaRepartidores[posicionRepartidor - 1]);
                OpcionMenuPrincipal = 0;
                LimpiarConsola();
                return;
            }
        }

        public static void SubmenuModificacionRepartidor(Repartidor repartidor)
        {
            OpcionMenuPrincipal = 0;
            do
            {
                OpcionMenuPrincipal = ValidarNumerico(1, OpcionesSubMenuModificarRepartidor, repartidor, 4);
                Console.Clear();
                switch (OpcionMenuPrincipal)
                {
                    case 1:
                        ModificarNumeroTelefonoRepartidor(repartidor);
                        break;
                    case 2:
                        ModificarNombreRepartidor(repartidor);
                        break;
                    case 3:
                        ModificarEstadoFueraDeServicio(repartidor);
                        break;
                    case 4:

                        break;
                    default:
                        ErroOpcionNoValida();
                        break;
                }
            } while (OpcionMenuPrincipal != 4);
        }
        public static void ModificarNumeroTelefonoRepartidor(Repartidor repartidor)
        {
            int nuevoNumeroTelefono = ValidarTelefono();
            repartidor.NumeroTelefono = nuevoNumeroTelefono;
            LimpiarConsola();
        }

        public static void ModificarNombreRepartidor(Repartidor repartidor)
        {
            string nuevoNombre = ValidarTexto("Ingrese el nuevo Nombre Completo: ", 35);
            repartidor.NombreCompleto = nuevoNombre;
            LimpiarConsola();
        }
        public static void ModificarEstadoFueraDeServicio(Repartidor repartidor)
        {
            if(repartidor.EstadoDisponibilidad != EstadoRepartidor.FueraDeServicio)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"El estado del repartidor es: {repartidor.EstadoDisponibilidad}.\n\nNo es necesario modificarlo.");
                Console.ResetColor();
            }
            else
            {
                repartidor.EstadoDisponibilidad = EstadoRepartidor.Disponible;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"¡Estado del repartidor modificado exitosamente!");
                Console.ResetColor();
            }
            LimpiarConsola();
        }
        public static void OpcionesSubMenuModificarRepartidor(Repartidor repartidor)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("=====================================");
            Console.WriteLine($"MENÚ REPARTIDOR  ({repartidor.CodigoUnico})");
            Console.WriteLine("=====================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Modificar el Número de teléfono");
            Console.WriteLine("2. Modificar el Nombre");
            Console.WriteLine("3. Cambiar estado Fuera de servicio");
            Console.WriteLine("4. Regresar a Gestión de Repartidores");
            Console.ResetColor();
        }

        public static void MostarInformacionRepartidor(Delivery goXelaDelivery)
        {
            if (goXelaDelivery.ListaRepartidores.Count == 0 || goXelaDelivery.ListaRepartidores == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("No hay ningún Repartidor Registrado");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            else
            {
                int posicionRepartidor = ValidarNumerico(1, ListaDeRepartidores, goXelaDelivery, goXelaDelivery.ListaRepartidores.Count);
                Console.WriteLine();
                goXelaDelivery.ListaRepartidores[posicionRepartidor - 1].MostrarInformacion();
                LimpiarConsola();
                return;
            }
        }

        public static void ListaDeRepartidores(Delivery goXelaDelivery)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("          LISTA DE REPARTIDORES        ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();
            foreach (Repartidor repartidor in goXelaDelivery.ListaRepartidores)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{goXelaDelivery.ListaRepartidores.IndexOf(repartidor) + 1}. Nombre: ");
                Console.ResetColor();
                Console.Write($"{repartidor.NombreCompleto} || ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Tipo de licencia: ");
                Console.ResetColor();
                Console.Write($"{repartidor.TipoLicencia.ObtenerDescripcion()} || ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"ID: ");
                Console.ResetColor();
                Console.Write($"{repartidor.CodigoUnico}");
                Console.WriteLine();
            }
        }

        public static void OpcionesMenuRepartidores()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("           MÓDULO REPARTIDORES          ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Registrar un Repartidor");
            Console.WriteLine("2. Consultar Información de Repartidor");
            Console.WriteLine("3. Modificar Información de Repartidor");
            Console.WriteLine("4. Volver al Menú Principal");
            Console.ResetColor();
        }

        public static void RegistrarRepartidor(Delivery goXelaDelivery)
        {
            string nombreCompletoRepartidor = ValidarTexto("Ingrese el Nombre Completo: ", 35);
            int numeroTelefonoRepartidor = ValidarTelefono();
            int numeroLicenciaRepartidor = ValidarNumerico("Ingrese el número de licencia (hasta 5 dígitos)", 5, true);
            int numeroTipoLicenciaElegida = ValidarNumerico(1, MenuTipoLicencias, Enum.GetNames(typeof(TipoLicencia)).Length);
            TipoLicencia tipoLicenciaRepartidor = (TipoLicencia)numeroTipoLicenciaElegida;
            int numeroEstadoRepartidorElegida = ValidarNumerico(1, MenuEstadoDisponibilidad, Enum.GetNames(typeof(EstadoRepartidor)).Length);
            EstadoRepartidor estadoRepartidor = (EstadoRepartidor)numeroEstadoRepartidorElegida;
            Repartidor repartidor = new Repartidor(nombreCompletoRepartidor,numeroTelefonoRepartidor, numeroLicenciaRepartidor,tipoLicenciaRepartidor, estadoRepartidor);
            goXelaDelivery.IngresarRepartidor(repartidor);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Se Registro Correctamente al Repartidor.");
            Console.ResetColor();
            LimpiarConsola();
        }

        public static void MenuTipoLicencias()
        {
            List<string> listaLicencias = Enum.GetValues(typeof(TipoLicencia))
                                   .Cast<TipoLicencia>()
                                   .Select(m => m.ObtenerDescripcion())
                                   .ToList();
            foreach (string licencia in listaLicencias)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{listaLicencias.IndexOf(licencia) + 1}. ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{licencia}");
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        public static void MenuEstadoDisponibilidad()
        {
            List<string> listaDeEstados = Enum.GetValues(typeof(EstadoRepartidor))
                                   .Cast<EstadoRepartidor>()
                                   .Select(m => m.ObtenerDescripcion())
                                   .ToList();
            foreach (string estado in listaDeEstados)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{listaDeEstados.IndexOf(estado) + 1}. ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{estado}");
                Console.ResetColor();
                Console.WriteLine();
            }
        }
    }
}
