using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoXelaDelivery.Enums;

namespace GoXelaDelivery
{
    public static class GestorDistancias
    {

        private static readonly double[,] MatrizDistancias = new double[5, 5]
        {
                               
            { 2.0,   9.0,     4.5,   10.0,    6.5 },
            { 9.0,   2.0,    12.0,    7.0,   11.0 },
            { 4.5,  12.0,     2.0,    8.0,   10.5 },
            { 10.0,  7.0,     8.0,    2.0,   13.0 },
            { 6.5,  11.0,    10.5,   13.0,    2.0 }
        };

        public static double ObtenerDistancia(Municipio origen, Municipio destino)
        {
            
            int fila = (int)origen - 1;
            int columna = (int)destino - 1;

            return MatrizDistancias[fila, columna];
        }
    }
}

