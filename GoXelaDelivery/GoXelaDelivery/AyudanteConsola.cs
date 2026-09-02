using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static GoXelaDelivery.Enums;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;
using System.ComponentModel;

namespace GoXelaDelivery
{
    internal static class AyudanteConsola
    {
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
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
                Console.Write("Presione Enter para enviar\n\n Ingresar: ");
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
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
                Console.Write($"Presione Enter para enviar. \nEl número debe ser de {tamanoRequerido} dígitos.\n\n Ingresar: ");
                StringBuilder sb = new StringBuilder(tamanoRequerido, tamanoRequerido);
                do
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                    if (teclaInfo.Key == ConsoleKey.Enter && sb.Length == tamanoRequerido)
                    {
                        if (int.TryParse(sb.ToString(), out int numeroConvertido))
                        {
                            Console.Write($"\n\nConfirmar el número {numeroConvertido} (Yes/No): ");
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
                                Console.WriteLine("\nElección inválida");
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
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
                Console.Write($"Presione Enter para enviar. \nEl número debe ser de 8 dígitos.\n\n Ingresar: ");
                StringBuilder sb = new StringBuilder(tamanoRequerido, tamanoRequerido);

                do
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                    if (teclaInfo.Key == ConsoleKey.Enter && sb.Length == tamanoRequerido)
                    {
                        if (int.TryParse(sb.ToString(), out int numeroConvertido))
                        {
                            Console.Write($"\n\nConfirmar el número de teléfono {numeroConvertido} (Yes/No): ");
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
                                Console.WriteLine("\nElección inválida");
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
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
                Console.Write("Presione Enter para enviar\n\n Ingresar: ");
                StringBuilder sb = new StringBuilder(limiteCaracteres - 1, limiteCaracteres);
                do
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                    if (teclaInfo.Key == ConsoleKey.Enter && sb.Length > 0 && sb.Length <= limiteCaracteres && sb.ToString().Contains('@') && sb.ToString().Contains('.') && sb[sb.Length - 1] != '.' && sb[sb.Length - 1] != ' ')
                    {
                        Console.Write($"\n\nConfirmar correo {sb.ToString()} (Yes/No): ");
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
                            Console.WriteLine("\nElección inválida");
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

                int cantidadPuntos = i % 4;
                string puntos = new string('.', cantidadPuntos);


                string espaciosBlancos = new string(' ', 3 - cantidadPuntos);


                Console.Write($"\r{textoMostrar}{puntos}{espaciosBlancos}");


                Thread.Sleep(250);
            }


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
            Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeMunicipio.ToUpper());
            Console.Write("\n\n");
            StringBuilder sbMunicipio = new StringBuilder(1, 1);
            Console.WriteLine("Ingrese el número de su municipio\n");
            foreach (string municipio in listaMunicipios)
            {
                Console.WriteLine($"{listaMunicipios.IndexOf(municipio) + 1}. {municipio}");
            }
            Console.Write("\nElección: ");
            do
            {
                ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                if (teclaInfo.Key == ConsoleKey.Enter && sbMunicipio.Length == 1)
                {
                    numeroMunicipioElegido = int.Parse(sbMunicipio.ToString());

                    Console.Write($"\n\nConfirmar elección de {listaMunicipios[numeroMunicipioElegido - 1]} (Yes/No): ");
                    string respuesta = Console.ReadLine().ToLower();

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
                        Console.WriteLine("\nElección inválida");
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
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
                Console.Write("Presione Enter para enviar\n\n Ingresar: ");

                StringBuilder sbDireccionCompleta = new StringBuilder(limiteCaracteres - 1, limiteCaracteres);
                sbDireccionCompleta.Append($"{municipioElegido}, ");
                int longitudMinima = sbDireccionCompleta.Length;
                Console.Write(sbDireccionCompleta);


                while (true)
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);

                    if (teclaInfo.Key == ConsoleKey.Enter && sbDireccionCompleta.Length > longitudMinima && sbDireccionCompleta.Length <= limiteCaracteres)
                    {
                        Console.Write($"\n\nConfirmar dirección de destino en {municipioElegido} (Yes/No): ");
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
                            Console.WriteLine("\nElección inválida");
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

        internal static void ValidarDireccion(Paquete paquete)
        {
            int numeroMunicipioElegido = MenuMunicipios();
            string municipioElegido = ((Municipio)numeroMunicipioElegido).ObtenerDescripcion();
            paquete.MunicipioOrigen = (Municipio)numeroMunicipioElegido;

            int limiteCaracteres = 80;
            string mensajeSolicitudDeDatos = "Ingrese su dirección completa";
            int anchoConsola = Console.WindowWidth;
            int espacios = Math.Max(0, (anchoConsola - mensajeSolicitudDeDatos.Length) / 2);

            bool direccionConfirmada = false;
            string direccionOrigen = string.Empty;

            while (!direccionConfirmada)
            {
                Console.Clear();
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
                Console.Write("Presione Enter para enviar\n\n Ingresar: ");

                StringBuilder sbDireccionCompleta = new StringBuilder(limiteCaracteres - 1, limiteCaracteres);
                sbDireccionCompleta.Append($"{municipioElegido}, ");
                int longitudMinima = sbDireccionCompleta.Length;
                Console.Write(sbDireccionCompleta);


                while (true)
                {
                    ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);

                    if (teclaInfo.Key == ConsoleKey.Enter && sbDireccionCompleta.Length > longitudMinima && sbDireccionCompleta.Length <= limiteCaracteres)
                    {
                        Console.Write($"\n\nConfirmar dirección de destino en {municipioElegido} (Yes/No): ");
                        string respuesta = Console.ReadLine().ToLower().Trim();

                        if (respuesta == "yes")
                        {
                            direccionOrigen = sbDireccionCompleta.ToString();
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
                            Console.WriteLine("\nElección inválida");
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

            paquete.DireccionOrigen = direccionOrigen;
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
    }

}
