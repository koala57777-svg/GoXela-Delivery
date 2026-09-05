using System;
using System.Collections.Generic;
using System.Linq;
using static GoXelaDelivery.AyudanteConsola;
using static GoXelaDelivery.Globales;
using static GoXelaDelivery.Enums;

namespace GoXelaDelivery
{
    internal static class ModuloVehiculos
    {
        public static void IniciarSubmenu(Delivery goXelaDelivery)
        {
            OpcionMenuPrincipal = 0;
            do
            {
                OpcionMenuPrincipal = ValidarNumerico(1, OpcionesMenuVehiculos, 4);
                Console.Clear();
                switch (OpcionMenuPrincipal)
                {
                    case 1:
                        RegistrarVehiculo(goXelaDelivery);
                        break;
                    case 2:
                        MostarInformacionVehiculo(goXelaDelivery);
                        break;
                    case 3:
                        AbrirSubmenuModificarInformacionVehiculo(goXelaDelivery);
                        break;
                    case 4:

                        break;
                    default:
                        ErroOpcionNoValida();
                        break;
                }
            } while (OpcionMenuPrincipal != 4);
        }

        public static void RegistrarVehiculo(Delivery goXelaDelivery)
        {
            int numeroTipoVehiculo = ValidarNumerico(1, MenuTipoVehiculos, Enum.GetNames(typeof(TipoVehiculo)).Length);
            TipoVehiculo tipoVehiculo = (TipoVehiculo)numeroTipoVehiculo;

            string placa = ValidarAlfanumerico("Ingrese la Placa (N/A si no aplica)", 10);
            string marca = ValidarTexto("Ingrese la Marca", 25);
            int modelo = ValidarNumerico("Ingrese el Modelo (Año)", 4);

            int numeroEspecializacion = ValidarNumerico(1, MenuEspecializacion, Enum.GetNames(typeof(TipoEspecializacion)).Length);
            TipoEspecializacion especializacion = (TipoEspecializacion)numeroEspecializacion;

            int numeroEstado = ValidarNumerico(1, MenuEstadoVehiculo, Enum.GetNames(typeof(EstadoVehiculo)).Length);
            EstadoVehiculo estadoVehiculo = (EstadoVehiculo)numeroEstado;

            Vehiculo vehiculo;
            if (tipoVehiculo == TipoVehiculo.Motocicleta)
            {
                vehiculo = new Motocicleta(placa, marca, modelo, estadoVehiculo, tipoVehiculo, especializacion);
            }
            else if (tipoVehiculo == TipoVehiculo.Automovil)
            {
                vehiculo = new Carro(placa, marca, modelo, estadoVehiculo, tipoVehiculo, especializacion);
            }
            else
            {
                vehiculo = new Bicicleta(placa, marca, modelo, estadoVehiculo, tipoVehiculo, especializacion);
            }

            goXelaDelivery.IngresarVehiculo(vehiculo);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Se Registró Correctamente el Vehículo.");
            Console.ResetColor();
            LimpiarConsola();
        }

        public static void MostarInformacionVehiculo(Delivery goXelaDelivery)
        {
            List<Vehiculo> todosVehiculos = goXelaDelivery.ListaVehiculos.SelectMany(v => v).ToList();
            if (todosVehiculos.Count == 0 || todosVehiculos == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("No hay ningún Vehículo Registrado");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            else
            {
                int posicionVehiculo = ValidarNumerico(1, ListaDeVehiculos, goXelaDelivery, todosVehiculos.Count);
                Console.WriteLine();
                todosVehiculos[posicionVehiculo - 1].MostarInformacion();
                LimpiarConsola();
                return;
            }
        }

        public static void AbrirSubmenuModificarInformacionVehiculo(Delivery goXelaDelivery)
        {
            List<Vehiculo> todosVehiculos = goXelaDelivery.ListaVehiculos.SelectMany(v => v).ToList();
            if (todosVehiculos.Count == 0 || todosVehiculos == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("No hay ningún Vehículo Registrado");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            else
            {
                int posicionVehiculo = ValidarNumerico(1, ListaDeVehiculos, goXelaDelivery, todosVehiculos.Count);
                Console.WriteLine();
                SubmenuModificacionVehiculo(todosVehiculos[posicionVehiculo - 1]);
                OpcionMenuPrincipal = 0;
                LimpiarConsola();
                return;
            }
        }

        public static void SubmenuModificacionVehiculo(Vehiculo vehiculo)
        {
            OpcionMenuPrincipal = 0;
            do
            {
                OpcionMenuPrincipal = ValidarNumerico(1, OpcionesSubMenuModificarVehiculo, vehiculo, 2);
                Console.Clear();
                switch (OpcionMenuPrincipal)
                {
                    case 1:
                        ModificarEstadoEnMantenimiento(vehiculo);
                        break;
                    case 2:

                        break;
                    default:
                        ErroOpcionNoValida();
                        break;
                }
            } while (OpcionMenuPrincipal != 2);
        }

        public static void ModificarEstadoEnMantenimiento(Vehiculo vehiculo)
        {
            if (vehiculo.EstadoVehiculo != EstadoVehiculo.EnMantenimiento)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"El estado del vehículo es: {vehiculo.EstadoVehiculo.ObtenerDescripcion()}.\n\nNo es necesario modificarlo.");
                Console.ResetColor();
            }
            else
            {
                vehiculo.ModificarEstado(EstadoVehiculo.Disponible);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"¡Estado del vehículo modificado exitosamente a Disponible!");
                Console.ResetColor();
            }
            LimpiarConsola();
        }

        public static void ListaDeVehiculos(Delivery goXelaDelivery)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("          LISTA DE VEHÍCULOS       ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();

            List<Vehiculo> todosVehiculos = goXelaDelivery.ListaVehiculos.SelectMany(v => v).ToList();

            foreach (Vehiculo vehiculo in todosVehiculos)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{todosVehiculos.IndexOf(vehiculo) + 1}. Tipo: ");
                Console.ResetColor();
                Console.Write($"{vehiculo.TipoVehiculo.ObtenerDescripcion()} || ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Placa: ");
                Console.ResetColor();
                Console.Write($"{vehiculo.Placa} || ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"ID: ");
                Console.ResetColor();
                Console.Write($"{vehiculo.CodigoUnico}");
                Console.WriteLine();
            }
        }

        public static void OpcionesMenuVehiculos()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("           MÓDULO VEHÍCULOS        ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Registrar un Vehículo");
            Console.WriteLine("2. Consultar Información de Vehículo");
            Console.WriteLine("3. Modificar Información de Vehículo");
            Console.WriteLine("4. Volver al Menú Principal");
            Console.ResetColor();
        }

        public static void OpcionesSubMenuModificarVehiculo(Vehiculo vehiculo)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("=====================================");
            Console.WriteLine($"MENÚ VEHÍCULO  ({vehiculo.CodigoUnico})");
            Console.WriteLine("=====================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Cambiar estado En mantenimiento");
            Console.WriteLine("2. Regresar a Gestión de Vehículos");
            Console.ResetColor();
        }

        public static void MenuTipoVehiculos()
        {
            List<string> listaTipos = Enum.GetValues(typeof(TipoVehiculo))
                                   .Cast<TipoVehiculo>()
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

        public static void MenuEspecializacion()
        {
            List<string> listaEsp = Enum.GetValues(typeof(TipoEspecializacion))
                                   .Cast<TipoEspecializacion>()
                                   .Select(m => m.ObtenerDescripcion())
                                   .ToList();
            foreach (string esp in listaEsp)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{listaEsp.IndexOf(esp) + 1}. ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{esp}");
                Console.ResetColor();
            }
        }

        public static void MenuEstadoVehiculo()
        {
            List<string> listaEstados = Enum.GetValues(typeof(EstadoVehiculo))
                                   .Cast<EstadoVehiculo>()
                                   .Select(m => m.ObtenerDescripcion())
                                   .ToList();
            foreach (string estado in listaEstados)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{listaEstados.IndexOf(estado) + 1}. ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{estado}");
                Console.ResetColor();
            }
        }
    }
}