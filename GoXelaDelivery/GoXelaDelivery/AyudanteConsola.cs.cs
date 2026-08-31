using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GoXelaDelivery
{
    public static class AyudanteConsola
    {
        public static string ValidarTexto(string mensajeSolicitudDeDatos, int limiteCaracteres)
        {
            int anchoConsola = Console.WindowWidth;
            int espacios = (anchoConsola - mensajeSolicitudDeDatos.Length) / 2;
            if (espacios < 0) espacios = 0
            Console.WriteLine($"{mensajeSolicitudDeDatos.}");
        } 
    }
}
