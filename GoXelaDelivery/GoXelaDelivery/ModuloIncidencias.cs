using System;
using System.Collections.Generic;
using System.Linq;
using static GoXelaDelivery.AyudanteConsola;
using static GoXelaDelivery.Globales;
using static GoXelaDelivery.Enums;

namespace GoXelaDelivery
{
    internal static class ModuloIncidencias
    {
        public static void IniciarSubmenu(Delivery goXelaDelivery)
        {
            OpcionMenuPrincipal = 0;
            do
            {
                OpcionMenuPrincipal = ValidarNumerico(1, OpcionesMenuIncidencias, 4);
                Console.Clear();
                switch (OpcionMenuPrincipal)
                {
                    case 1:
                        RegistrarIncidencia(goXelaDelivery);
                        break;
                    case 2:
                        MostarInformacionIncidencia(goXelaDelivery);
                        break;
                    case 3:
                        AbrirSubmenuModificarInformacionIncidencia(goXelaDelivery);
                        break;
                    case 4:

                        break;
                    default:
                        ErroOpcionNoValida();
                        break;
                }
            } while (OpcionMenuPrincipal != 4);
        }

        public static void RegistrarIncidencia(Delivery goXelaDelivery)
        {
            if (goXelaDelivery.ListaEntregas.Count == 0 || goXelaDelivery.ListaEntregas == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No hay ninguna Entrega registrada en el sistema.");
                Console.WriteLine("Debe existir al menos una entrega para registrar una incidencia.");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }

            int posicionEntrega = ValidarNumerico(1, ModuloEntregas.ListaDeEntregas, goXelaDelivery, goXelaDelivery.ListaEntregas.Count);
            Entrega entregaSeleccionada = goXelaDelivery.ListaEntregas[posicionEntrega - 1];

            int numeroTipoIncidencia = ValidarNumerico(1, MenuTipoIncidencias, Enum.GetNames(typeof(TipoIncidencia)).Length);
            TipoIncidencia tipoIncidencia = (TipoIncidencia)numeroTipoIncidencia;

            string descripcion = ValidarTexto("Ingrese la descripción del incidente", 80);
            string accionTomada = ValidarTexto("Ingrese la acción tomada inicial (Ej. Ninguna)", 80);

            Incidente incidente = new Incidente(tipoIncidencia, descripcion, entregaSeleccionada);
            incidente.AccionTomada = accionTomada;

            entregaSeleccionada.AgregarIncidenteAEntrega(entregaSeleccionada, incidente);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Se Registró Correctamente la Incidencia.");
            Console.ResetColor();
            LimpiarConsola();
        }

        public static void MostarInformacionIncidencia(Delivery goXelaDelivery)
        {
            List<Incidente> todosIncidentes = goXelaDelivery.ListaEntregas.SelectMany(e => e.ListaIncidentes).ToList();
            if (todosIncidentes.Count == 0 || todosIncidentes == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("No hay ninguna Incidencia Registrada");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            else
            {
                int posicionIncidente = ValidarNumerico(1, ListaDeIncidencias, todosIncidentes, todosIncidentes.Count);
                Console.WriteLine();
                todosIncidentes[posicionIncidente - 1].MostrarInformacion();
                LimpiarConsola();
                return;
            }
        }

        public static void AbrirSubmenuModificarInformacionIncidencia(Delivery goXelaDelivery)
        {
            List<Incidente> todosIncidentes = goXelaDelivery.ListaEntregas.SelectMany(e => e.ListaIncidentes).ToList();
            if (todosIncidentes.Count == 0 || todosIncidentes == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("No hay ninguna Incidencia Registrada");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            else
            {
                int posicionIncidente = ValidarNumerico(1, ListaDeIncidencias, todosIncidentes, todosIncidentes.Count);
                Console.WriteLine();
                SubmenuModificacionIncidencia(todosIncidentes[posicionIncidente - 1]);
                OpcionMenuPrincipal = 0;
                LimpiarConsola();
                return;
            }
        }

        public static void SubmenuModificacionIncidencia(Incidente incidente)
        {
            OpcionMenuPrincipal = 0;
            do
            {
                OpcionMenuPrincipal = ValidarNumerico(1, OpcionesSubMenuModificarIncidencia, incidente, 3);
                Console.Clear();
                switch (OpcionMenuPrincipal)
                {
                    case 1:
                        ModificarAccionTomada(incidente);
                        break;
                    case 2:
                        incidente.EntregaRelacionada.CambiarEstadoIncidente(incidente);
                        break;
                    case 3:

                        break;
                    default:
                        ErroOpcionNoValida();
                        break;
                }
            } while (OpcionMenuPrincipal != 3);
        }

        public static void ModificarAccionTomada(Incidente incidente)
        {
            string nuevaAccion = ValidarTexto("Ingrese la nueva Acción Tomada: ", 80);
            incidente.EntregaRelacionada.CambiarAccionTomadaIncidente(incidente, nuevaAccion);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n¡Acción tomada modificada exitosamente!");
            Console.ResetColor();
            LimpiarConsola();
        }

        public static void ListaDeIncidencias(List<Incidente> incidentes)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("        LISTA DE INCIDENCIAS       ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();

            foreach (Incidente incidente in incidentes)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{incidentes.IndexOf(incidente) + 1}. Tipo: ");
                Console.ResetColor();
                Console.Write($"{incidente.TipoIncidente.ObtenerDescripcion()} || ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Estado: ");
                Console.ResetColor();
                Console.Write($"{incidente.EstadoIncidente.ObtenerDescripcion()} || ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"ID: ");
                Console.ResetColor();
                Console.Write($"{incidente.CodigoUnico}");
                Console.WriteLine();
            }
        }

        public static void OpcionesMenuIncidencias()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("         MÓDULO INCIDENCIAS        ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Registrar una Incidencia");
            Console.WriteLine("2. Consultar Información de Incidencia");
            Console.WriteLine("3. Modificar Información de Incidencia");
            Console.WriteLine("4. Volver al Menú Principal");
            Console.ResetColor();
        }

        public static void OpcionesSubMenuModificarIncidencia(Incidente incidente)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("=====================================");
            Console.WriteLine($"MENÚ INCIDENCIA  ({incidente.CodigoUnico})");
            Console.WriteLine("=====================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Modificar Acción Tomada");
            Console.WriteLine("2. Cambiar Estado a Resuelto");
            Console.WriteLine("3. Regresar a Gestión de Incidencias");
            Console.ResetColor();
        }

        public static void MenuTipoIncidencias()
        {
            List<string> listaTipos = Enum.GetValues(typeof(TipoIncidencia))
                                   .Cast<TipoIncidencia>()
                                   .Select(m => m.ObtenerDescripcion())
                                   .ToList();
            foreach (string tipo in listaTipos)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{listaTipos.IndexOf(tipo) + 1}. ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{tipo}");
                Console.ResetColor();
            }
        }
    }
}