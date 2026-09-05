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
    internal static class ModuloClientes
    {
        public static void IniciarSubmenu(Delivery goXelaDelivery)
        {
            OpcionMenuPrincipal = 0;
            do
            {
                OpcionMenuPrincipal = ValidarNumerico(1, OpcionesMenuClientes, 4);
                Console.Clear();
                switch (OpcionMenuPrincipal)
                {
                    case 1:
                        RegistrarCliente(goXelaDelivery);
                        break;
                    case 2:
                        MostarInformacionCliente(goXelaDelivery);
                        break;
                    case 3:
                        AbrirSubmenuModificarInformacionCliente(goXelaDelivery);
                        break;
                    case 4:

                        break;
                    default:
                        ErroOpcionNoValida();
                        break;
                }
            } while (OpcionMenuPrincipal != 4);
        }

        public static void RegistrarCliente(Delivery goXelaDelivery)
        {
            string nombreCompletoCliente = ValidarTexto("Ingrese el Nombre Completo: ", 35);
            int numeroTelefonoCliente = ValidarTelefono();
            string correoElectronicoCliente = ValidarCorreo();
            int numeroMunicipioElegido = MenuMunicipios();
            Municipio municipioCliente = (Municipio)numeroMunicipioElegido;
            string direccionCliente = ValidarDireccion(municipioCliente);
            Cliente cliente = new Cliente(nombreCompletoCliente, numeroTelefonoCliente, correoElectronicoCliente, direccionCliente, municipioCliente);
            goXelaDelivery.IngresarCliente(cliente);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Se Registro Correctamente al Cliente.");
            Console.ResetColor();
            LimpiarConsola();
        }

        public static void MostarInformacionCliente(Delivery goXelaDelivery)
        {
            if (goXelaDelivery.ListaClientes.Count == 0 || goXelaDelivery.ListaClientes == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("No hay ningún Cliente Registrado");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            else
            {
                int posicionCliente = ValidarNumerico(1, ListaDeClientes, goXelaDelivery, goXelaDelivery.ListaClientes.Count);
                Console.WriteLine();
                goXelaDelivery.ListaClientes[posicionCliente-1].MostrarInformacion();
                LimpiarConsola();
                return;
            }
        }

        public static void ListaDeClientes(Delivery goXelaDelivery)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("          LISTA DE CLIENTES        ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();
            foreach (Cliente cliente in goXelaDelivery.ListaClientes)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{goXelaDelivery.ListaClientes.IndexOf(cliente) + 1}. Nombre: ");
                Console.ResetColor();
                Console.Write($"{cliente.NombreCompleto} || ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Municipio de Entrega: ");
                Console.ResetColor();
                Console.Write($"{cliente.MunicipioDestino} || ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"ID: ");
                Console.ResetColor();
                Console.Write($"{cliente.CodigoUnico}");
                Console.WriteLine();
            }
        }

        public static void AbrirSubmenuModificarInformacionCliente(Delivery goXelaDelivery)
        {
            if (goXelaDelivery.ListaClientes.Count == 0 || goXelaDelivery.ListaClientes == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("No hay ningún Cliente Registrado");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            else
            {
                int posicionCliente = ValidarNumerico(1, ListaDeClientes, goXelaDelivery, goXelaDelivery.ListaClientes.Count);
                Console.WriteLine();
                SubmenuModificacionCliente(goXelaDelivery.ListaClientes[posicionCliente-1]);
                LimpiarConsola();
                return;
            }
        }

        public static void SubmenuModificacionCliente(Cliente cliente)
        {
            OpcionMenuPrincipal = 0;
            do
            {
                OpcionMenuPrincipal = ValidarNumerico(1, OpcionesSubMenuModificarCliente, cliente, 5);
                Console.Clear();
                switch (OpcionMenuPrincipal)
                {
                    case 1:
                        ModificarNumeroTelefonoCliente(cliente);
                        break;
                    case 2:
                        ModificarCorreoCliente(cliente);
                        break;
                    case 3:
                        ModificarDireccionCliente(cliente);
                        break;
                    case 4:
                        ModificarNombreCliente(cliente);
                        break;
                    case 5:

                        break;
                    default:
                        ErroOpcionNoValida();
                        break;
                }
            } while (OpcionMenuPrincipal != 5);
        }

        public static void ModificarNumeroTelefonoCliente(Cliente cliente)
        {
            int nuevoNumeroTelefono = ValidarTelefono();
            cliente.NumeroTelefono = nuevoNumeroTelefono;
            LimpiarConsola();
        }

        public static void ModificarCorreoCliente(Cliente cliente)
        {
            string nuevoCorreo = ValidarCorreo();
            cliente.CorreoElectronico = nuevoCorreo;
            LimpiarConsola();
        }

        public static void ModificarDireccionCliente(Cliente cliente)
        {
            ValidarDireccion(cliente);
            LimpiarConsola();
        }

        public static void ModificarNombreCliente(Cliente cliente)
        {
            string nuevoNombre = ValidarTexto("Ingrese el nuevo Nombre Completo: ", 35);
            cliente.NombreCompleto = nuevoNombre;
            LimpiarConsola();
        }

        public static void OpcionesMenuClientes()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===================================");
            Console.WriteLine("           MÓDULO CLIENTE          ");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Registrar un Cliente");
            Console.WriteLine("2. Consultar Información de Cliente");
            Console.WriteLine("3. Modificar Información de Cliente");
            Console.WriteLine("4. Volver al Menú Principal");
            Console.ResetColor();
        }

        public static void OpcionesSubMenuModificarCliente(Cliente cliente)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("=====================================");
            Console.WriteLine($"MENÚ CLIENTE  ({cliente.CodigoUnico})");
            Console.WriteLine("=====================================");
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Modificar el Número de Teléfono");
            Console.WriteLine("2. Modificar el Correo Electrónico");
            Console.WriteLine("3. Nueva Dirección");
            Console.WriteLine("4. Modificar el Nombre ");
            Console.WriteLine("5. Regresar a Gestión de Clientes");
            Console.ResetColor();
        }
    }
}
