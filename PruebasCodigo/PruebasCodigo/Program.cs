using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasCodigo
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
                    if (teclaInfo.Key == ConsoleKey.Spacebar && sb.Length > 0 && sb.Length+1!=limiteCaracteres)
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
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string nombre = AyudanteConsola.ValidarTexto("Ingrese su nombre completo", 16);
            Console.WriteLine($"\n\n{nombre}");
        }
    }
}
