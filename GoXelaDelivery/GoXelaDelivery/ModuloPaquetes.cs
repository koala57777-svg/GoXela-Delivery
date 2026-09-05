using System;
using System.Collections.Generic;
using System.Linq;
using static GoXelaDelivery.AyudanteConsola;
using static GoXelaDelivery.Globales;
using static GoXelaDelivery.Enums;

namespace GoXelaDelivery
{
    internal static class ModuloPaquetes
    {
        public static void IniciarSubmenu(Delivery goXelaDelivery)
        {
            OpcionMenuPrincipal = 0;
            do
            {
                OpcionMenuPrincipal = ValidarNumerico(1, OpcionesMenuPaquetes, 4);
                Console.Clear();
                switch (OpcionMenuPrincipal)
                {
                    case 1:
                        RegistrarPaquete(goXelaDelivery);
                        break;
                    case 2:
                        MostarInformacionPaquete(goXelaDelivery);
                        break;
                    case 3:
                        AbrirSubmenuModificarInformacionPaquete(goXelaDelivery);
                        break;
                    case 4:

                        break;
                    default:
                        ErroOpcionNoValida();
                        break;
                }
            } while (OpcionMenuPrincipal != 4);
        }

        public static void RegistrarPaquete(Delivery goXelaDelivery)
        {
            if (goXelaDelivery.ListaClientes.Count == 0 || goXelaDelivery.ListaClientes == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No hay ningún Cliente registrado en el sistema.");
                Console.WriteLine("Debe registrar al menos un Cliente antes de crear un Paquete.");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }

            int numeroTipoPaquete = ValidarNumerico(1, MenuTipoPaquetes, Enum.GetNames(typeof(TipoPaquete)).Length);
            TipoPaquete tipoPaquete = (TipoPaquete)numeroTipoPaquete;

            string descripcion = ValidarTexto("Ingrese la descripción del paquete", 50);

            int peso = ValidarNumerico("Ingrese el peso en kg (hasta 3 dígitos)", 3, true);

            int valorDeclarado = ValidarNumerico("Ingrese el valor declarado en Q (hasta 5 dígitos)", 5, true);

            int posicionCliente = ValidarNumerico(1, ModuloClientes.ListaDeClientes, goXelaDelivery, goXelaDelivery.ListaClientes.Count);
            Cliente clienteSeleccionado = goXelaDelivery.ListaClientes[posicionCliente - 1];

            int numeroMunicipioOrigen = MenuMunicipios();
            Municipio municipioOrigen = (Municipio)numeroMunicipioOrigen;

            string direccionOrigen = ValidarDireccion(municipioOrigen, true);

            Paquete paquete;

            if (tipoPaquete == TipoPaquete.Documento)
            {
                paquete = new Documento(tipoPaquete, descripcion, peso, valorDeclarado, clienteSeleccionado, direccionOrigen, municipioOrigen);
            }
            else if (tipoPaquete == TipoPaquete.Estandar)
            {
                paquete = new PaqueteEstandar(tipoPaquete, descripcion, peso, valorDeclarado, clienteSeleccionado, direccionOrigen, municipioOrigen);
            }
            else if (tipoPaquete == TipoPaquete.Fragil)
            {
                paquete = new PaqueteFragil(tipoPaquete, descripcion, peso, valorDeclarado, clienteSeleccionado, direccionOrigen, municipioOrigen);
            }
            else
            {
                paquete = new ProductoRefrigerado(tipoPaquete, descripcion, peso, valorDeclarado, clienteSeleccionado, direccionOrigen, municipioOrigen);
            }

            goXelaDelivery.IngresarPaquete(paquete);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Se Registró Correctamente el Paquete.");
            Console.ResetColor();
            LimpiarConsola();
        }

        public static void MostarInformacionPaquete(Delivery goXelaDelivery)
        {
            List<Paquete> todosPaquetes = goXelaDelivery.ListasPaquetes.SelectMany(p => p).ToList();
            if (todosPaquetes.Count == 0 || todosPaquetes == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("No hay ningún Paquete Registrado");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            else
            {
                int posicionPaquete = ValidarNumerico(1, ListaDePaquetes, goXelaDelivery, todosPaquetes.Count);
                Console.WriteLine();

                todosPaquetes[posicionPaquete - 1].MostrarInformacion();

                LimpiarConsola();
                return;
            }
        }

        public static void AbrirSubmenuModificarInformacionPaquete(Delivery goXelaDelivery)
        {
            List<Paquete> todosPaquetes = goXelaDelivery.ListasPaquetes.SelectMany(p => p).ToList();
            if (todosPaquetes.Count == 0 || todosPaquetes == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("No hay ningún Paquete Registrado");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            else
            {
                int posicionPaquete = ValidarNumerico(1, ListaDePaquetes, goXelaDelivery, todosPaquetes.Count);
                Console.WriteLine();
                SubmenuModificacionPaquete(todosPaquetes[posicionPaquete - 1]);
                OpcionMenuPrincipal = 0;
                LimpiarConsola();
                return;
            }
        }

        public static void SubmenuModificacionPaquete(Paquete paquete)
        {
            OpcionMenuPrincipal = 0;
            do
            {
                OpcionMenuPrincipal = ValidarNumerico(1, OpcionesSubMenuModificarPaquete, paquete, 2);
                Console.Clear();
                switch (OpcionMenuPrincipal)
                {
                    case 1:
                        ModificarDescripcionPaquete(paquete);
                        break;
                    case 2:

                        break;
                    default:
                        ErroOpcionNoValida();
                        break;
                }
            } while (OpcionMenuPrincipal != 2);
        }

        public static void ModificarDescripcionPaquete(Paquete paquete)
        {
            string nuevaDescripcion = ValidarTexto("Ingrese la nueva Descripción: ", 50);
            paquete.Descripcion = nuevaDescripcion;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n¡Descripción del paquete modificada exitosamente!");
            Console.ResetColor();
            LimpiarConsola();
        }

        public static void ListaDePaquetes(Delivery goXelaDelivery)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("          LISTA DE PAQUETES        ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();

            List<Paquete> todosPaquetes = goXelaDelivery.ListasPaquetes.SelectMany(p => p).ToList();

            foreach (Paquete paquete in todosPaquetes)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{todosPaquetes.IndexOf(paquete) + 1}. Tipo: ");
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

        public static void OpcionesMenuPaquetes()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("           MÓDULO PAQUETES         ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Registrar un Paquete");
            Console.WriteLine("2. Consultar Información de Paquete");
            Console.WriteLine("3. Modificar Información de Paquete");
            Console.WriteLine("4. Volver al Menú Principal");
            Console.ResetColor();
        }

        public static void OpcionesSubMenuModificarPaquete(Paquete paquete)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("=====================================");
            Console.WriteLine($"MENÚ PAQUETE  ({paquete.CodigoUnico})");
            Console.WriteLine("=====================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Modificar la Descripción");
            Console.WriteLine("2. Regresar a Gestión de Paquetes");
            Console.ResetColor();
        }

        public static void MenuTipoPaquetes()
        {
            List<string> listaTipos = Enum.GetValues(typeof(TipoPaquete))
                                   .Cast<TipoPaquete>()
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