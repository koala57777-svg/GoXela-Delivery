using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoXelaDelivery.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace GoXelaDelivery
{
    public static class AyudanteConsola
    {

        public static string ValidarTexto(string mensajeSolicitudDeDatos, int limiteCaracteres)
        {
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitudDeDatos.Length) / 2;
            if (espacios < 0) espacios = 0;
            Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
            Console.Write("Presione Enter para enviar\n\n Ingresar: ");
            StringBuilder sb = new StringBuilder(limiteCaracteres - 1, limiteCaracteres);
            do
            {
                ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                if (teclaInfo.Key == ConsoleKey.Enter && sb.Length > 0 && sb.Length <= limiteCaracteres)
                {
                    break;
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
            return sb.ToString();
        }

        public static int ValidarNumerico(string mensajeSolicitudDeDatos, int tamanoRequerido)
        {
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitudDeDatos.Length) / 2;
            if (espacios < 0) espacios = 0;
            Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());
            Console.Write($"Presione Enter para enviar. \nEl número debe ser de {tamanoRequerido} dígitos.\n\n Ingresar: ");
            StringBuilder sb = new StringBuilder(tamanoRequerido, tamanoRequerido);
            int numeroConvertido;
            do
            {
                ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                if (teclaInfo.Key == ConsoleKey.Enter && sb.Length == tamanoRequerido)
                {
                    if (int.TryParse(sb.ToString(), out numeroConvertido))
                    {
                        break;
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
            return numeroConvertido;
        }
    }

}
