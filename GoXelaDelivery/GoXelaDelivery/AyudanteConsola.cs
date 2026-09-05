using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static GoXelaDelivery.Enums;
using static System.Net.Mime.MediaTypeNames;
using static GoXelaDelivery.Delivery;
using static GoXelaDelivery.Globales;
using System.Reflection;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;

namespace GoXelaDelivery
{
    internal static class AyudanteConsola
    {
        public static void ConfirmarEntrega(Entrega entregaAConfirmar)
        {
            if ((ListaVehiculos[0].Count == 0 && ListaVehiculos[1].Count == 0 && ListaVehiculos[2].Count == 0) || (ListaVehiculos[0] == null && ListaVehiculos[1] == null && ListaVehiculos[2] == null))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No hay ningún Vehículo Registrado");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            else
            {
                ListaVehiculosCorrectos = EncontrarVehiculoCorrecto(entregaAConfirmar);
                if (ListaVehiculosCorrectos.Count == 0 || ListaVehiculosCorrectos == null)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No hay ningún Vehículo que Pueda llevar el Paquete");
                    Console.ResetColor();
                    LimpiarConsola();
                    return;
                }
                else
                {
                    if (ListaRepartidores.Count == 0 || ListaRepartidores == null)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("No hay ningún Repartidor Registrado");
                        Console.ResetColor();
                        LimpiarConsola();
                        return;
                    }
                    else
                    {
                        ListaRepartidoresCorrectos = EncontrarRepartidorCorrecto(entregaAConfirmar);
                        if (ListaRepartidoresCorrectos.Count == 0 || ListaRepartidoresCorrectos == null)
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("No hay ningún Repartidor que Pueda llevar el Paquete");
                            Console.ResetColor();
                            LimpiarConsola();
                            return;
                        }
                        else
                        {
                            entregaAConfirmar.VehiculoAsigando = ListaVehiculosCorrectos.First();
                            entregaAConfirmar.RepartidorAsignado = ListaRepartidoresCorrectos.First();
                            entregaAConfirmar.VehiculoAsigando.EstadoVehiculo = EstadoVehiculo.Asignado;
                            entregaAConfirmar.RepartidorAsignado.EstadoDisponibilidad = EstadoRepartidor.Asignado;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Se ha Cofirmado Correctamente la Entrega ({entregaAConfirmar.CodigoUnico})");
                            Console.WriteLine();
                            Console.WriteLine($"Repartidor Asignado: {entregaAConfirmar.RepartidorAsignado.NombreCompleto} ({entregaAConfirmar.RepartidorAsignado.CodigoUnico})");
                            Console.WriteLine();
                            Console.WriteLine($"Vehículo Asigando: Placa {entregaAConfirmar.VehiculoAsigando.Placa} ({entregaAConfirmar.VehiculoAsigando.CodigoUnico})");
                            Console.WriteLine();
                            Console.ResetColor();
                            LimpiarConsola();
                        }
                    }
                }
            }
        }

        internal static List<Repartidor> EncontrarRepartidorCorrecto(Entrega entregaAConfirmar)
        {
            if (entregaAConfirmar.VehiculoGeneral == TipoVehiculoGeneral.Bicicleta)
            {
                RepartidorCorrecto = ListaRepartidores.Where(repartidor => (repartidor.TipoLicencia == TipoLicencia.B) && (repartidor.EstadoDisponibilidad == EstadoRepartidor.Disponible)).ToList();
                return RepartidorCorrecto;
            }
            else if (entregaAConfirmar.VehiculoGeneral == TipoVehiculoGeneral.Motocicleta)
            {
                RepartidorCorrecto = ListaRepartidores.Where(repartidor => (repartidor.TipoLicencia == TipoLicencia.M) && (repartidor.EstadoDisponibilidad == EstadoRepartidor.Disponible)).ToList();
                return RepartidorCorrecto;
            }
            else
            {
                RepartidorCorrecto = ListaRepartidores.Where(repartidor => (repartidor.TipoLicencia == TipoLicencia.C) && (repartidor.EstadoDisponibilidad == EstadoRepartidor.Disponible)).ToList();
                return RepartidorCorrecto;
            }
        }

        internal static List<Vehiculo> EncontrarVehiculoCorrecto(Entrega entraAConfirmar)
        {
            if (entraAConfirmar.VehiculoGeneral == TipoVehiculoGeneral.Bicicleta)
            {
                if (ListaVehiculos[2].Count == 0 || ListaVehiculos[2] == null)
                {
                    LimpiarConsola();
                    VehiculoCorrecto.Clear();
                    return VehiculoCorrecto;
                }
                else
                {
                    if (entraAConfirmar.PaqueteEntrega.TipoPaquete == TipoPaquete.Estandar)
                    {
                        VehiculoCorrecto = ListaVehiculos[2].Where(vehiculo => (vehiculo.Especializacion == TipoEspecializacion.Estandar) && (vehiculo.EstadoVehiculo == EstadoVehiculo.Disponible)).ToList();
                        return VehiculoCorrecto;
                    }
                    else if (entraAConfirmar.PaqueteEntrega.TipoPaquete == TipoPaquete.Documento)
                    {
                        VehiculoCorrecto = ListaVehiculos[2].Where(vehiculo => (vehiculo.Especializacion == TipoEspecializacion.Asegurado) && (vehiculo.EstadoVehiculo == EstadoVehiculo.Disponible)).ToList();
                        return VehiculoCorrecto;
                    }
                    else if (entraAConfirmar.PaqueteEntrega.TipoPaquete == TipoPaquete.Fragil)
                    {
                        VehiculoCorrecto = ListaVehiculos[2].Where(vehiculo => (vehiculo.Especializacion == TipoEspecializacion.Acolchado) && (vehiculo.EstadoVehiculo == EstadoVehiculo.Disponible)).ToList();
                        return VehiculoCorrecto;
                    }
                    else
                    {
                        VehiculoCorrecto = ListaVehiculos[2].Where(vehiculo => (vehiculo.Especializacion == TipoEspecializacion.Refrigerado) && (vehiculo.EstadoVehiculo == EstadoVehiculo.Disponible)).ToList();
                        return VehiculoCorrecto;
                    }
                }
            }
            else if (entraAConfirmar.VehiculoGeneral == TipoVehiculoGeneral.Motocicleta)
            {
                if (ListaVehiculos[0].Count == 0 || ListaVehiculos[0] == null)
                {
                    VehiculoCorrecto.Clear();
                    return VehiculoCorrecto;
                }
                else
                {
                    if (entraAConfirmar.PaqueteEntrega.TipoPaquete == TipoPaquete.Estandar)
                    {
                        VehiculoCorrecto = ListaVehiculos[0].Where(vehiculo => (vehiculo.Especializacion == TipoEspecializacion.Estandar) && (vehiculo.EstadoVehiculo == EstadoVehiculo.Disponible)).ToList();
                        return VehiculoCorrecto;
                    }
                    else if (entraAConfirmar.PaqueteEntrega.TipoPaquete == TipoPaquete.Documento)
                    {
                        VehiculoCorrecto = ListaVehiculos[0].Where(vehiculo => (vehiculo.Especializacion == TipoEspecializacion.Asegurado) && (vehiculo.EstadoVehiculo == EstadoVehiculo.Disponible)).ToList();
                        return VehiculoCorrecto;
                    }
                    else if (entraAConfirmar.PaqueteEntrega.TipoPaquete == TipoPaquete.Fragil)
                    {
                        VehiculoCorrecto = ListaVehiculos[0].Where(vehiculo => (vehiculo.Especializacion == TipoEspecializacion.Acolchado) && (vehiculo.EstadoVehiculo == EstadoVehiculo.Disponible)).ToList();
                        return VehiculoCorrecto;
                    }
                    else
                    {
                        VehiculoCorrecto = ListaVehiculos[0].Where(vehiculo => (vehiculo.Especializacion == TipoEspecializacion.Refrigerado) && (vehiculo.EstadoVehiculo == EstadoVehiculo.Disponible)).ToList();
                        return VehiculoCorrecto;
                    }
                }
            }
            else
            {
                if (ListaVehiculos[1].Count == 0 || ListaVehiculos[1] == null)
                {
                    VehiculoCorrecto.Clear();
                    return VehiculoCorrecto;
                }
                else
                {
                    if (entraAConfirmar.PaqueteEntrega.TipoPaquete == TipoPaquete.Estandar)
                    {
                        VehiculoCorrecto = ListaVehiculos[1].Where(vehiculo => (vehiculo.Especializacion == TipoEspecializacion.Estandar) && (vehiculo.EstadoVehiculo == EstadoVehiculo.Disponible)).ToList();
                        return VehiculoCorrecto;
                    }
                    else if (entraAConfirmar.PaqueteEntrega.TipoPaquete == TipoPaquete.Documento)
                    {
                        VehiculoCorrecto = ListaVehiculos[1].Where(vehiculo => (vehiculo.Especializacion == TipoEspecializacion.Asegurado) && (vehiculo.EstadoVehiculo == EstadoVehiculo.Disponible)).ToList();
                        return VehiculoCorrecto;
                    }
                    else if (entraAConfirmar.PaqueteEntrega.TipoPaquete == TipoPaquete.Fragil)
                    {
                        VehiculoCorrecto = ListaVehiculos[1].Where(vehiculo => (vehiculo.Especializacion == TipoEspecializacion.Acolchado) && (vehiculo.EstadoVehiculo == EstadoVehiculo.Disponible)).ToList();
                        return VehiculoCorrecto;
                    }
                    else
                    {
                        VehiculoCorrecto = ListaVehiculos[1].Where(vehiculo => (vehiculo.Especializacion == TipoEspecializacion.Refrigerado) && (vehiculo.EstadoVehiculo == EstadoVehiculo.Disponible)).ToList();
                        return VehiculoCorrecto;
                    }
                }
            }
        }

        public static string ObtenerDescripcion(this Enum valor)
        {
            FieldInfo field = valor.GetType().GetField(valor.ToString());
            DescriptionAttribute attribute = field?.GetCustomAttribute<DescriptionAttribute>();

            return attribute != null ? attribute.Description : valor.ToString();
        }

        internal static string ValidarTexto(string mensajeSolicitudDeDatos, int limiteCaracteres)
        {
            bool textoConfirmado = false;
            string textoFinal = string.Empty;
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitudDeDatos.Length) / 2;
            if (espacios < 0) espacios = 0;
            while (!textoConfirmado)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Presione Enter para enviar\n\n Ingresar: ");
                Console.ResetColor();
                StringBuilder sb = new StringBuilder(limiteCaracteres - 1, limiteCaracteres);
                do
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                    if (teclaInfo.Key == ConsoleKey.Enter && sb.Length > 0 && sb.Length <= limiteCaracteres)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"\n\nConfirmar el texto ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(sb.ToString());
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" (Yes/No): ");
                        Console.ResetColor();
                        string respuesta = Console.ReadLine().ToLower().Trim();

                        if (respuesta == "yes")
                        {
                            textoFinal = sb.ToString();
                            textoConfirmado = true;
                            Console.Clear();
                            break;
                        }
                        else if (respuesta == "no")
                        {
                            Mostrar("Reiniciando texto", 1);
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nElección inválida");
                            Console.ResetColor();
                            Mostrar("Reiniciando texto", 1);
                            break;
                        }
                    }
                    if (teclaInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                    if (sb.Length < limiteCaracteres)
                    {
                        if (char.IsLetter(teclaInfo.KeyChar))
                        {
                            sb.Append(teclaInfo.KeyChar);
                            Console.Write(teclaInfo.KeyChar);
                        }
                        if (teclaInfo.Key == ConsoleKey.Spacebar && sb.Length > 0 && sb.Length + 1 != limiteCaracteres)
                        {
                            if (sb[sb.Length - 1] != ' ')
                            {
                                sb.Append(' ');
                                Console.Write(' ');
                            }
                        }

                    }
                } while (true);
            }
            return textoFinal;
        }

        internal static int ValidarNumerico(string mensajeSolicitudDeDatos, int tamanoRequerido)
        {
            bool numeroConfirmado = false;
            int numeroFinal = 0;
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitudDeDatos.Length) / 2;
            if (espacios < 0) espacios = 0;
            while (!numeroConfirmado)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Presione Enter para enviar. \nEl número debe ser de ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(tamanoRequerido);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" dígitos. \n\n Ingrsar: ");
                Console.ResetColor();
                StringBuilder sb = new StringBuilder(tamanoRequerido, tamanoRequerido);
                do
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                    if (teclaInfo.Key == ConsoleKey.Enter && sb.Length == tamanoRequerido)
                    {
                        if (int.TryParse(sb.ToString(), out int numeroConvertido))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"\n\nConfirmar el número ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(numeroConvertido);
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" (Yes/No): ");
                            Console.ResetColor();
                            string respuesta = Console.ReadLine().ToLower().Trim();

                            if (respuesta == "yes")
                            {
                                numeroFinal = numeroConvertido;
                                numeroConfirmado = true;
                                Console.Clear();
                                break;
                            }
                            else if (respuesta == "no")
                            {
                                Mostrar("Reiniciando número", 1);
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nElección inválida");
                                Console.ResetColor();
                                Mostrar("Reiniciando número", 1);
                                break;
                            }
                        }
                    }
                    if (teclaInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                    if (sb.Length < tamanoRequerido)
                    {
                        if (char.IsDigit(teclaInfo.KeyChar))
                        {
                            if (teclaInfo.KeyChar == '0')
                            {
                                if (sb.Length > 0)
                                {
                                    sb.Append('0');
                                    Console.Write('0');
                                }
                            }
                            else
                            {
                                sb.Append(teclaInfo.KeyChar);
                                Console.Write(teclaInfo.KeyChar);
                            }
                        }
                    }
                } while (true);
            }
            return numeroFinal;
        }

        internal static int ValidarNumerico(int tamanoRequerido, Action menuMostrar, int rangoValido)
        {
            bool numeroConfirmado = false;
            int numeroFinal = 0;
            while (!numeroConfirmado)
            {
                Console.Clear();
                menuMostrar();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n Ingresar: ");
                Console.ResetColor();
                StringBuilder sb = new StringBuilder(tamanoRequerido, tamanoRequerido);
                do
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                    if (teclaInfo.Key == ConsoleKey.Enter && sb.Length == tamanoRequerido)
                    {
                        if (int.TryParse(sb.ToString(), out int numeroConvertido))
                        {
                            if (numeroConvertido >= 1 && numeroConvertido <= rangoValido)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write($"\n\nConfirmar el número ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write(numeroConvertido);
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(" (Yes/No): ");
                                Console.ResetColor();
                                string respuesta = Console.ReadLine().ToLower().Trim();

                                if (respuesta == "yes")
                                {
                                    numeroFinal = numeroConvertido;
                                    numeroConfirmado = true;
                                    Console.Clear();
                                    break;
                                }
                                else if (respuesta == "no")
                                {
                                    Mostrar("Reiniciando número", 1);
                                    break;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nElección inválida");
                                    Console.ResetColor();
                                    Mostrar("Reiniciando número", 1);
                                    break;
                                }
                            }
                        }
                    }
                    if (teclaInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                    if (sb.Length < tamanoRequerido)
                    {
                        if (char.IsDigit(teclaInfo.KeyChar))
                        {
                            if (teclaInfo.KeyChar == '0')
                            {
                                if (sb.Length > 0)
                                {
                                    sb.Append('0');
                                    Console.Write('0');
                                }
                            }
                            else
                            {
                                sb.Append(teclaInfo.KeyChar);
                                Console.Write(teclaInfo.KeyChar);
                            }
                        }
                    }
                } while (true);
            }
            return numeroFinal;
        }

        internal static int ValidarTelefono()
        {
            bool telefonoConfirmado = false;
            int telefonoFinal = 0;
            string mensajeSolicitudDeDatos = "Ingrese su número de teléfono";
            int tamanoRequerido = 8;
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitudDeDatos.Length) / 2;
            if (espacios < 0) espacios = 0;
            while (!telefonoConfirmado)
            { 
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Presione Enter para enviar. \nEl número debe ser de 8 dígitos.\n\n Ingresar: ");
                Console.ResetColor();
                StringBuilder sb = new StringBuilder(tamanoRequerido, tamanoRequerido);

                do
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                    if (teclaInfo.Key == ConsoleKey.Enter && sb.Length == tamanoRequerido)
                    {
                        if (int.TryParse(sb.ToString(), out int numeroConvertido))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"\n\nConfirmar el número de teléfono ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(numeroConvertido);
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" (Yes/No): ");
                            Console.ResetColor();
                            string respuesta = Console.ReadLine().ToLower().Trim();

                            if (respuesta == "yes")
                            {
                                telefonoFinal = numeroConvertido;
                                telefonoConfirmado = true;
                                Console.Clear();
                                break;
                            }
                            else if (respuesta == "no")
                            {
                                Mostrar("Reiniciando teléfono", 1);
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nElección inválida");
                                Console.ResetColor();
                                Mostrar("Reiniciando teléfono", 1);
                                break;
                            }
                        }
                    }
                    if (teclaInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                    {
                        if (sb.Length == 5)
                        {
                            Console.Write("\b \b");
                        }
                        sb.Remove(sb.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                    if (sb.Length < tamanoRequerido)
                    {
                        if (char.IsDigit(teclaInfo.KeyChar))
                        {
                            if (teclaInfo.KeyChar == '0')
                            {
                                if (sb.Length > 0)
                                {
                                    sb.Append('0');
                                    Console.Write('0');
                                }
                            }
                            else
                            {
                                sb.Append(teclaInfo.KeyChar);
                                Console.Write(teclaInfo.KeyChar);
                            }
                            if (sb.Length == 4)
                            {
                                Console.Write("-");
                            }
                        }
                    }
                } while (true);
            }
            return telefonoFinal;
        }

        internal static string ValidarCorreo()
        {
            bool correoConfirmado = false;
            string mensajeSolicitudDeDatos = "Ingrese su correo";
            int limiteCaracteres = 35;
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitudDeDatos.Length) / 2;
            if (espacios < 0) espacios = 0;
            string correoFinal = string.Empty;
            while (!correoConfirmado)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Presione Enter para enviar\n\n Ingresar: ");
                Console.ResetColor();
                StringBuilder sb = new StringBuilder(limiteCaracteres - 1, limiteCaracteres);
                do
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                    if (teclaInfo.Key == ConsoleKey.Enter && sb.Length > 0 && sb.Length <= limiteCaracteres && sb.ToString().Contains('@') && sb.ToString().Contains('.') && sb[sb.Length - 1] != '.' && sb[sb.Length - 1] != ' ')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"\n\nConfirmar correo ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(sb.ToString());
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" (Yes/No): ");
                        Console.ResetColor();
                        string respuesta = Console.ReadLine().ToLower().Trim();

                        if (respuesta == "yes")
                        {
                            correoFinal = sb.ToString();
                            correoConfirmado = true;
                            Console.Clear();
                            break;
                        }
                        else if (respuesta == "no")
                        {
                            Mostrar("Reiniciando correo", 1);
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nElección inválida");
                            Console.ResetColor();
                            Mostrar("Reiniciando correo", 1);
                            break;
                        }
                    }
                    if (teclaInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                    if (sb.Length < limiteCaracteres)
                    {
                        if (char.IsLetterOrDigit(teclaInfo.KeyChar))
                        {
                            sb.Append(teclaInfo.KeyChar);
                            Console.Write(teclaInfo.KeyChar);
                        }
                        if (teclaInfo.KeyChar == '.')
                        {
                            if (sb.ToString().Contains('@') && sb[sb.Length - 1] != '.' && sb[sb.Length - 1] != '@' && sb.Length + 1 != limiteCaracteres)
                            {
                                sb.Append('.');
                                Console.Write('.');
                            }
                        }
                        if (teclaInfo.KeyChar == '@')
                        {
                            if (!sb.ToString().Contains('@') && sb.Length > 0 && sb.Length < 15)
                            {
                                sb.Append('@');
                                Console.Write('@');
                            }
                        }
                        if (!sb.ToString().Contains('@') && sb.Length == 15 && teclaInfo.Key != ConsoleKey.Backspace)
                        {
                            sb.Append('@');
                            Console.Write('@');
                        }
                    }
                } while (true);
            }
            return correoFinal;
        }
        internal static void Mostrar(string textoMostrar, int duracionSegundos)
        {
            
            int ciclosTotales = duracionSegundos * 4;

            for (int i = 0; i < ciclosTotales; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                int cantidadPuntos = i % 4;
                string puntos = new string('.', cantidadPuntos);


                string espaciosBlancos = new string(' ', 3 - cantidadPuntos);


                Console.Write($"\r{textoMostrar}{puntos}{espaciosBlancos}");


                Thread.Sleep(250);
                
            }
            Console.ResetColor();

            Console.Write("\r" + new string(' ', 20) + "\r");
        }
        internal static int MenuMunicipios()
        {
            string mensajeSolicitudDeMunicipio = "Elija su municipio";
            int numeroMunicipioElegido;
            List<string> listaMunicipios = Enum.GetValues(typeof(Municipio))
                                   .Cast<Municipio>()
                                   .Select(m => m.ObtenerDescripcion())
                                   .ToList();
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitudDeMunicipio.Length) / 2;
            if (espacios < 0) espacios = 0;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeMunicipio.ToUpper());
            Console.ResetColor();
            Console.Write("\n\n");
            StringBuilder sbMunicipio = new StringBuilder(1, 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ingrese el número de su municipio\n");
            Console.ResetColor();
            foreach (string municipio in listaMunicipios)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{listaMunicipios.IndexOf(municipio) + 1}. ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{municipio}");
                Console.ResetColor();
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nElección: ");
            Console.ResetColor();
            do
            {
                ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                if (teclaInfo.Key == ConsoleKey.Enter && sbMunicipio.Length == 1)
                {
                    numeroMunicipioElegido = int.Parse(sbMunicipio.ToString());

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"\n\nConfirmar elección de ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(listaMunicipios[numeroMunicipioElegido - 1]);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" (Yes/No): ");
                    Console.ResetColor();
                    string respuesta = Console.ReadLine().ToLower().Trim();

                    if (respuesta == "no")
                    {
                        Mostrar("Reiniciando municipio", 1);
                        Console.Clear();
                        return MenuMunicipios();
                    }
                    else if (respuesta == "yes")
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nElección inválida");
                        Console.ResetColor();
                        Mostrar("Reiniciando municipio", 1);
                        Console.Clear();
                        return MenuMunicipios();
                    }
                }
                if (teclaInfo.Key == ConsoleKey.Backspace && sbMunicipio.Length > 0)
                {
                    sbMunicipio.Remove(sbMunicipio.Length - 1, 1);
                    Console.Write("\b \b");
                }
                if (sbMunicipio.Length < 1)
                {
                    if (char.IsDigit(teclaInfo.KeyChar))
                    {
                        int numeroConvertido = int.Parse(teclaInfo.KeyChar.ToString());
                        if (numeroConvertido >= 1 && numeroConvertido <= 5)
                        {
                            sbMunicipio.Append(teclaInfo.KeyChar);
                            Console.Write(teclaInfo.KeyChar);
                        }
                    }
                }
            } while (true);
            return numeroMunicipioElegido;
        }
        internal static void ValidarDireccion(Cliente cliente)
        {
            int numeroMunicipioElegido = MenuMunicipios();
            string municipioElegido = ((Municipio)numeroMunicipioElegido).ObtenerDescripcion();
            cliente.MunicipioDestino = (Municipio)numeroMunicipioElegido;

            int limiteCaracteres = 80;
            string mensajeSolicitudDeDatos = "Ingrese su dirección completa";
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitudDeDatos.Length) / 2;

            bool direccionConfirmada = false;
            string direccionFinal = string.Empty;

            while (!direccionConfirmada)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Presione Enter para enviar\n\n Ingresar: ");
                Console.ResetColor();

                StringBuilder sbDireccionCompleta = new StringBuilder(limiteCaracteres - 1, limiteCaracteres);
                sbDireccionCompleta.Append($"{municipioElegido}, ");
                int longitudMinima = sbDireccionCompleta.Length;
                Console.Write(sbDireccionCompleta);


                while (true)
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);

                    if (teclaInfo.Key == ConsoleKey.Enter && sbDireccionCompleta.Length > longitudMinima && sbDireccionCompleta.Length <= limiteCaracteres)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"\n\nConfirmar dirección de destino en ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(municipioElegido);
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" (Yes/No): ");
                        Console.ResetColor();
                        string respuesta = Console.ReadLine().ToLower().Trim();

                        if (respuesta == "yes")
                        {
                            direccionFinal = sbDireccionCompleta.ToString();
                            direccionConfirmada = true;
                            break;
                        }
                        else if (respuesta == "no")
                        {
                            Mostrar("Reiniciando dirección", 1);
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nElección inválida");
                            Console.ResetColor();
                            Mostrar("Reiniciando dirección", 1);
                            break;
                        }
                    }

                    if (teclaInfo.Key == ConsoleKey.Backspace && sbDireccionCompleta.Length > longitudMinima)
                    {
                        sbDireccionCompleta.Remove(sbDireccionCompleta.Length - 1, 1);
                        Console.Write("\b \b");
                    }

                    if (sbDireccionCompleta.Length < limiteCaracteres)
                    {
                        if (char.IsLetterOrDigit(teclaInfo.KeyChar))
                        {
                            sbDireccionCompleta.Append(teclaInfo.KeyChar);
                            Console.Write(teclaInfo.KeyChar);
                        }
                        else if (teclaInfo.Key == ConsoleKey.Spacebar && sbDireccionCompleta.Length > longitudMinima && sbDireccionCompleta.Length + 1 != limiteCaracteres)
                        {
                            if (sbDireccionCompleta[sbDireccionCompleta.Length - 1] != ' ')
                            {
                                sbDireccionCompleta.Append(' ');
                                Console.Write(' ');
                            }
                        }
                        else if (teclaInfo.KeyChar == ',' && sbDireccionCompleta.Length > longitudMinima && sbDireccionCompleta.Length + 1 != limiteCaracteres)
                        {
                            if (sbDireccionCompleta[sbDireccionCompleta.Length - 1] != ',')
                            {
                                sbDireccionCompleta.Append(',');
                                Console.Write(',');
                            }
                        }
                        else if (teclaInfo.KeyChar == '-' && sbDireccionCompleta.Length > longitudMinima && sbDireccionCompleta.Length + 1 != limiteCaracteres)
                        {
                            if (sbDireccionCompleta[sbDireccionCompleta.Length - 1] != '-')
                            {
                                sbDireccionCompleta.Append('-');
                                Console.Write('-');
                            }
                        }
                    }
                }
            }

            cliente.DireccionDestino = direccionFinal;
        }

        internal static string ValidarDireccion(Municipio municipioDestino)
        {
            string municipioElegido = municipioDestino.ObtenerDescripcion();


            int limiteCaracteres = 80;
            string mensajeSolicitudDeDatos = "Ingrese su dirección completa";
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitudDeDatos.Length) / 2;

            bool direccionConfirmada = false;
            string direccionFinal = string.Empty;

            while (!direccionConfirmada)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Presione Enter para enviar\n\n Ingresar: ");
                Console.ResetColor();

                StringBuilder sbDireccionCompleta = new StringBuilder(limiteCaracteres - 1, limiteCaracteres);
                sbDireccionCompleta.Append($"{municipioElegido}, ");
                int longitudMinima = sbDireccionCompleta.Length;
                Console.Write(sbDireccionCompleta);


                while (true)
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);

                    if (teclaInfo.Key == ConsoleKey.Enter && sbDireccionCompleta.Length > longitudMinima && sbDireccionCompleta.Length <= limiteCaracteres)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"\n\nConfirmar dirección de destino en ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(municipioElegido);
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" (Yes/No): ");
                        Console.ResetColor();
                        string respuesta = Console.ReadLine().ToLower().Trim();

                        if (respuesta == "yes")
                        {
                            direccionFinal = sbDireccionCompleta.ToString();
                            direccionConfirmada = true;
                            break;
                        }
                        else if (respuesta == "no")
                        {
                            Mostrar("Reiniciando dirección", 1);
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nElección inválida");
                            Console.ResetColor();
                            Mostrar("Reiniciando dirección", 1);
                            break;
                        }
                    }

                    if (teclaInfo.Key == ConsoleKey.Backspace && sbDireccionCompleta.Length > longitudMinima)
                    {
                        sbDireccionCompleta.Remove(sbDireccionCompleta.Length - 1, 1);
                        Console.Write("\b \b");
                    }

                    if (sbDireccionCompleta.Length < limiteCaracteres)
                    {
                        if (char.IsLetterOrDigit(teclaInfo.KeyChar))
                        {
                            sbDireccionCompleta.Append(teclaInfo.KeyChar);
                            Console.Write(teclaInfo.KeyChar);
                        }
                        else if (teclaInfo.Key == ConsoleKey.Spacebar && sbDireccionCompleta.Length > longitudMinima && sbDireccionCompleta.Length + 1 != limiteCaracteres)
                        {
                            if (sbDireccionCompleta[sbDireccionCompleta.Length - 1] != ' ')
                            {
                                sbDireccionCompleta.Append(' ');
                                Console.Write(' ');
                            }
                        }
                        else if (teclaInfo.KeyChar == ',' && sbDireccionCompleta.Length > longitudMinima && sbDireccionCompleta.Length + 1 != limiteCaracteres)
                        {
                            if (sbDireccionCompleta[sbDireccionCompleta.Length - 1] != ',')
                            {
                                sbDireccionCompleta.Append(',');
                                Console.Write(',');
                            }
                        }
                        else if (teclaInfo.KeyChar == '-' && sbDireccionCompleta.Length > longitudMinima && sbDireccionCompleta.Length + 1 != limiteCaracteres)
                        {
                            if (sbDireccionCompleta[sbDireccionCompleta.Length - 1] != '-')
                            {
                                sbDireccionCompleta.Append('-');
                                Console.Write('-');
                            }
                        }
                    }
                }
            }
            return direccionFinal;

        }

        internal static void ValidarDireccion(Paquete paquete)
        {
            int numeroMunicipioElegido = MenuMunicipios();
            string municipioElegido = ((Municipio)numeroMunicipioElegido).ObtenerDescripcion();
            paquete.MunicipioOrigen = (Municipio)numeroMunicipioElegido;

            int limiteCaracteres = 80;
            string mensajeSolicitudDeDatos = "Ingrese su dirección completa";
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitudDeDatos.Length) / 2;

            bool direccionConfirmada = false;
            string direccionFinal = string.Empty;

            while (!direccionConfirmada)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Presione Enter para enviar\n\n Ingresar: ");
                Console.ResetColor();

                StringBuilder sbDireccionCompleta = new StringBuilder(limiteCaracteres - 1, limiteCaracteres);
                sbDireccionCompleta.Append($"{municipioElegido}, ");
                int longitudMinima = sbDireccionCompleta.Length;
                Console.Write(sbDireccionCompleta);


                while (true)
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);

                    if (teclaInfo.Key == ConsoleKey.Enter && sbDireccionCompleta.Length > longitudMinima && sbDireccionCompleta.Length <= limiteCaracteres)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"\n\nConfirmar dirección de origen del paquete en ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(municipioElegido);
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" (Yes/No): ");
                        Console.ResetColor();
                        string respuesta = Console.ReadLine().ToLower().Trim();

                        if (respuesta == "yes")
                        {
                            direccionFinal = sbDireccionCompleta.ToString();
                            direccionConfirmada = true;
                            break;
                        }
                        else if (respuesta == "no")
                        {
                            Mostrar("Reiniciando dirección", 1);
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nElección inválida");
                            Console.ResetColor();
                            Mostrar("Reiniciando dirección", 1);
                            break;
                        }
                    }

                    if (teclaInfo.Key == ConsoleKey.Backspace && sbDireccionCompleta.Length > longitudMinima)
                    {
                        sbDireccionCompleta.Remove(sbDireccionCompleta.Length - 1, 1);
                        Console.Write("\b \b");
                    }

                    if (sbDireccionCompleta.Length < limiteCaracteres)
                    {
                        if (char.IsLetterOrDigit(teclaInfo.KeyChar))
                        {
                            sbDireccionCompleta.Append(teclaInfo.KeyChar);
                            Console.Write(teclaInfo.KeyChar);
                        }
                        else if (teclaInfo.Key == ConsoleKey.Spacebar && sbDireccionCompleta.Length > longitudMinima && sbDireccionCompleta.Length + 1 != limiteCaracteres)
                        {
                            if (sbDireccionCompleta[sbDireccionCompleta.Length - 1] != ' ')
                            {
                                sbDireccionCompleta.Append(' ');
                                Console.Write(' ');
                            }
                        }
                        else if (teclaInfo.KeyChar == ',' && sbDireccionCompleta.Length > longitudMinima && sbDireccionCompleta.Length + 1 != limiteCaracteres)
                        {
                            if (sbDireccionCompleta[sbDireccionCompleta.Length - 1] != ',')
                            {
                                sbDireccionCompleta.Append(',');
                                Console.Write(',');
                            }
                        }
                        else if (teclaInfo.KeyChar == '-' && sbDireccionCompleta.Length > longitudMinima && sbDireccionCompleta.Length + 1 != limiteCaracteres)
                        {
                            if (sbDireccionCompleta[sbDireccionCompleta.Length - 1] != '-')
                            {
                                sbDireccionCompleta.Append('-');
                                Console.Write('-');
                            }
                        }
                    }
                }
            }

            paquete.DireccionOrigen = direccionFinal;
        }

        internal static string ValidarDireccion(Municipio municipioOrigen, bool direccionOrigen)
        {
            string municipioElegido = municipioOrigen.ObtenerDescripcion();


            int limiteCaracteres = 80;
            string mensajeSolicitudDeDatos = "Ingrese su dirección completa";
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitudDeDatos.Length) / 2;

            bool direccionConfirmada = false;
            string direccionFinal = string.Empty;

            while (!direccionConfirmada)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Presione Enter para enviar\n\n Ingresar: ");
                Console.ResetColor();

                StringBuilder sbDireccionCompleta = new StringBuilder(limiteCaracteres - 1, limiteCaracteres);
                sbDireccionCompleta.Append($"{municipioElegido}, ");
                int longitudMinima = sbDireccionCompleta.Length;
                Console.Write(sbDireccionCompleta);


                while (true)
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);

                    if (teclaInfo.Key == ConsoleKey.Enter && sbDireccionCompleta.Length > longitudMinima && sbDireccionCompleta.Length <= limiteCaracteres)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"\n\nConfirmar dirección de origen del paquete en ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(municipioElegido);
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" (Yes/No): ");
                        Console.ResetColor();
                        string respuesta = Console.ReadLine().ToLower().Trim();

                        if (respuesta == "yes")
                        {
                            direccionFinal = sbDireccionCompleta.ToString();
                            direccionConfirmada = true;
                            break;
                        }
                        else if (respuesta == "no")
                        {
                            Mostrar("Reiniciando dirección", 1);
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nElección inválida");
                            Console.ResetColor();
                            Mostrar("Reiniciando dirección", 1);
                            break;
                        }
                    }

                    if (teclaInfo.Key == ConsoleKey.Backspace && sbDireccionCompleta.Length > longitudMinima)
                    {
                        sbDireccionCompleta.Remove(sbDireccionCompleta.Length - 1, 1);
                        Console.Write("\b \b");
                    }

                    if (sbDireccionCompleta.Length < limiteCaracteres)
                    {
                        if (char.IsLetterOrDigit(teclaInfo.KeyChar))
                        {
                            sbDireccionCompleta.Append(teclaInfo.KeyChar);
                            Console.Write(teclaInfo.KeyChar);
                        }
                        else if (teclaInfo.Key == ConsoleKey.Spacebar && sbDireccionCompleta.Length > longitudMinima && sbDireccionCompleta.Length + 1 != limiteCaracteres)
                        {
                            if (sbDireccionCompleta[sbDireccionCompleta.Length - 1] != ' ')
                            {
                                sbDireccionCompleta.Append(' ');
                                Console.Write(' ');
                            }
                        }
                        else if (teclaInfo.KeyChar == ',' && sbDireccionCompleta.Length > longitudMinima && sbDireccionCompleta.Length + 1 != limiteCaracteres)
                        {
                            if (sbDireccionCompleta[sbDireccionCompleta.Length - 1] != ',')
                            {
                                sbDireccionCompleta.Append(',');
                                Console.Write(',');
                            }
                        }
                        else if (teclaInfo.KeyChar == '-' && sbDireccionCompleta.Length > longitudMinima && sbDireccionCompleta.Length + 1 != limiteCaracteres)
                        {
                            if (sbDireccionCompleta[sbDireccionCompleta.Length - 1] != '-')
                            {
                                sbDireccionCompleta.Append('-');
                                Console.Write('-');
                            }
                        }
                    }
                }
            }
            return direccionFinal;

        }

        internal static string ValidarAlfanumerico(string mensajePedirDatos, int limiteCaracteres)
        {
            bool alfanumericoConfirmado = false;
            string alfanumericoFinal = string.Empty;
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajePedirDatos.Length) / 2;
            if (espacios < 0) espacios = 0;
            while (!alfanumericoConfirmado)
            {
                Console.Clear();
                Console.WriteLine(new string(' ', espacios) + mensajePedirDatos.ToUpper());
                Console.Write($"\n\n Ingresar: ");
                StringBuilder sb = new StringBuilder(limiteCaracteres - 1, limiteCaracteres);
                do
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                    if (teclaInfo.Key == ConsoleKey.Enter && sb.Length > 0 && sb.Length <= limiteCaracteres)
                    {

                        Console.Write($"\n\nConfirmar el texto {sb.ToString()} (Yes/No): ");
                        string respuesta = Console.ReadLine().ToLower().Trim();

                        if (respuesta == "yes")
                        {
                            alfanumericoFinal = sb.ToString();
                            alfanumericoConfirmado = true;
                            Console.Clear();
                            break;
                        }
                        else if (respuesta == "no")
                        {
                            Mostrar("Reiniciando texto", 1);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nElección inválida");
                            Mostrar("Reiniciando texto", 1);
                            break;
                        }

                    }
                    if (teclaInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                    if (sb.Length < limiteCaracteres && teclaInfo.Key != ConsoleKey.Spacebar && teclaInfo.Key != ConsoleKey.Backspace)
                    {
                        sb.Append(teclaInfo.KeyChar);
                        Console.Write(teclaInfo.KeyChar);
                    }
                } while (true);
            }
            return alfanumericoFinal;
        }

        internal static double ValidarCalificacion()
        {
            string mensajeSolicitudDeDatos = "Ingrese su calificación";
            int tamanoRequerido = 2;
            bool calificacionConfirmada = false;
            double calificacionFinal = 0;

            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitudDeDatos.Length) / 2;
            if (espacios < 0) espacios = 0;

            while (!calificacionConfirmada)
            {
                Console.Clear();
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
                Console.Write($"\nCalificación de 1.0 a 5.0 \n\n Ingresar: ");

                
                StringBuilder sb = new StringBuilder(tamanoRequerido, tamanoRequerido);

                do
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);

                    
                    if (teclaInfo.Key == ConsoleKey.Enter && sb.Length == tamanoRequerido)
                    {
                        if (double.TryParse(sb.ToString(), out double numeroConvertido))
                        {
                            double numeroDividido = numeroConvertido / 10.0;

                            if (numeroDividido >= 1.0 && numeroDividido <= 5.0 && numeroConvertido % 5 == 0)
                            {
                                Console.Write($"\n\nConfirmar la calificación de {numeroDividido:F1} (Yes/No): ");
                                string respuesta = Console.ReadLine().ToLower().Trim();

                                if (respuesta == "yes")
                                {
                                    calificacionFinal = numeroDividido;
                                    calificacionConfirmada = true;
                                    Console.Clear();
                                    break;
                                }
                                else if (respuesta == "no")
                                {
                                    Mostrar("Reiniciando calificación", 1);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\n Calificación inválida. Ingrese una calificación válida (ej. 2.5, 4.0)");
                                    Mostrar("Reiniciando número", 1);
                                    break;
                                }
                            }
                        }
                    }

                    if (teclaInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                    {
                        if (sb.Length == 2)
                        { 
                            sb.Remove(sb.Length - 1, 1);
                            Console.Write("\b \b");
                        }
                        else if (sb.Length == 1)
                        {
                            sb.Remove(sb.Length - 1, 1);
                            Console.Write("\b \b\b \b");
                        }
                    }
                    else if (sb.Length < tamanoRequerido)
                    {
                        if (char.IsDigit(teclaInfo.KeyChar))
                        {
                            if (teclaInfo.KeyChar == '0' && sb.Length == 0)
                            {
                                continue;
                            }

                            sb.Append(teclaInfo.KeyChar);

                            if (sb.Length == 1)
                            {
                                Console.Write(teclaInfo.KeyChar + ".");
                            }
                            else if (sb.Length == 2)
                            {
                                Console.Write(teclaInfo.KeyChar);
                            }
                        }
                    }
                } while (true);
            }
            return calificacionFinal;
        }
    }

}
