using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoXelaDelivery
{
    internal class Enums
    {
        public enum EstadoRepartidor
        {
            Disponible=1,
            Asignado=2, 
            FueraDeServicio=3
        }

        public enum TipoLicencia
        {
            M = 1,
            C = 2,
            B = 3
        }

        public enum EstadoVehiculo
        {
            Disponible = 1,
            Asignado = 2,
            EnMantenimiento = 3
        }

        public enum TipoVehiculoGeneral
        {
            Motocicleta = 1,
            Automovil = 2,
            Bicicleta = 3
        }

        public enum TipoVehiculo
        {
            Motocicleta = 1,
            Automovil = 2,
            Bicicleta = 3
        }

        public enum TipoEspecializacion
        {
            Estándar = 1,
            Refrigerado = 2,
            Asegurado = 3,
            Acolchado = 4

        }

        public enum TipoServicio
        {
            Normal = 1,
            Prioritario = 2,
            Urgente = 3
        }

        public enum EstadoEntrega
        {
            Solicitado = 1,
            Cofirmado,
            EnRuta,
            Entregada,
            Cancelada
        }
        public enum TipoIncidencia
        {
            ClienteAusente = 1,
            DireccionIncorrecta,
            PaqueteDanado,
            VehiculoAveriado,
            Retraso,
            ProblemasClimaticos,
            RechazoRecepcion
        }

        public enum EstadoIncidencia
        {
            SinResolver = 1,
            EnRevision,
            Resuelta
        }
    }
}
