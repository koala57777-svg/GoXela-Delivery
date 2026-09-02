using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace GoXelaDelivery
{
    internal class Enums
    {
        public enum EstadoRepartidor
        {
            Disponible = 1,
            Asignado = 2,
            [Description("Fuera de servicio")]
            FueraDeServicio = 3
        }

        public enum TipoLicencia
        {
            [Description("Tipo M")]
            M = 1,
            [Description("Tipo C")]
            C = 2,
            [Description("Tipo B")]
            B = 3
        }

        public enum EstadoVehiculo
        {
            Disponible = 1,
            Asignado = 2,
            [Description("En mantenimiento")]
            EnMantenimiento = 3
        }

        public enum TipoVehiculoGeneral
        {
            Motocicleta = 1,
            [Description("Automóvil")]
            Automovil = 2,
            Bicicleta = 3
        }

        public enum TipoVehiculo
        {
            Motocicleta = 1,
            [Description("Automóvil")]
            Automovil = 2,
            Bicicleta = 3
        }

        public enum TipoEspecializacion
        {
            [Description("Estándar")]
            Estandar = 1,
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
            [Description("En ruta")]
            EnRuta,
            Entregada,
            Cancelada
        }
        public enum TipoIncidencia
        {
            [Description("Cliente ausente")]
            ClienteAusente = 1,
            [Description("Dirección incorrecta")]
            DireccionIncorrecta,
            [Description("Paquete dañado")]
            PaqueteDanado,
            [Description("Vehículo averiado")]
            VehiculoAveriado,
            Retraso,
            [Description("Problemas climáticos")]
            ProblemasClimaticos,
            [Description("Rechazo recepción")]
            RechazoRecepcion
        }

        public enum EstadoIncidencia
        {
            [Description("Sin resolver")]
            SinResolver = 1,
            [Description("En revisión")]
            EnRevision,
            Resuelta
        }


        public enum EstadoPaquete
        {
            [Description("No asignado")]
            NoAsignado = 1,
            Asignado

        }

        public enum TipoPaquete
        {
            Documento = 1,
            [Description("Estándar")]
            Estandar,
            [Description("Frágil")]
            Fragil,
            [Description("Producto refrigerado")]
            ProductoRefrigerado

        }
    }
    public enum Municipio
    {
        Quetzaltenango = 1,

        [Description("Salcajá")]
        Salcaja,
        Almolonga,
        Cantel,
        Olintepeque
    }

}
