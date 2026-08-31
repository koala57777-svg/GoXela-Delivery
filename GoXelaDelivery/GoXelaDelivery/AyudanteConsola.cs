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
            do
            {
                int anchoConsola = Console.WindowWidth;
                int espacios = (anchoConsola - mensajeSolicitudDeDatos.Length) / 2;
                if (espacios < 0) espacios = 0;
                Console.WriteLine(new string(' ', espacios) + mensajeSolicitudDeDatos.ToUpper());

                StringBuilder sb = new StringBuilder(limiteCaracteres-1,limiteCaracteres);
                ConsoleKeyInfo teclaInfo = Console.ReadKey(intercept: true);
                if(teclaInfo.Key == ConsoleKey.Spacebar && sb.Length>0 && sb.Length < limiteCaracteres)
                {
                    if (sb[sb.Length-1]!=' ')
                    {
                        sb.Append(' ');
                        Console.Write(' ');
                    }
                }
                if(teclaInfo.Key == ConsoleKey.Enter && sb.Length>0 && sb.Length <= limiteCaracteres)
                {
                    return sb.ToString();
                }

                
            } while (true);
        }
    }

}
