using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoXelaDelivery.Enums;

namespace GoXelaDelivery
{
    internal class Vehiculo
    {
        private string codigoUnico;

        private string prefijo;

        private string placa;

        private string marca;

        private int modelo;

        private double capacidadMaxima;

        private EstadoVehiculo estadoVehiculo;

        private int entregasRealizadas;

        private TipoVehiculo tipoVehiculo;

        private Repartidor repartidorAsignado;

        private TipoEspecializacion especializacion;

        public Vehiculo(string nuevoCodigoUnico, string nuevoPrefijo, string nuevaPlaca, string nuevaMarca, int nuevoModelo, double nuevaCapacidadMaxima, EstadoVehiculo nuevoEstadoVehiculo, int nuevasEntregasRealizadas, TipoVehiculo nuevoTipoVehiculo, Repartidor nuevoRepartidor, TipoEspecializacion nuevoTipoEspecializacion)
        {
            CodigoUnico = nuevoCodigoUnico;
            Prefijo = nuevoPrefijo;
            Placa = nuevaPlaca;
            Marca = nuevaMarca;
            Modelo = nuevoModelo;
            CapacidadMaxima = nuevaCapacidadMaxima;
            EstadoVehiculo = nuevoEstadoVehiculo;
            EntregasRealizadas = nuevasEntregasRealizadas;
            TipoVehiculo = nuevoTipoVehiculo;
            RepartidorAsignado = nuevoRepartidor;
            Especializacion = nuevoTipoEspecializacion;
        }

        protected void MostarInformacion()
        {
            Console.WriteLine("ID: " + CodigoUnico);
            Console.WriteLine();
            Console.WriteLine("Prefijo: " + Prefijo);
            Console.WriteLine();
            Console.WriteLine("Placa: " + Placa);
            Console.WriteLine();
            Console.WriteLine("Marca: " + Marca);
            Console.WriteLine();
            Console.WriteLine("Modelo: " + Modelo);
            Console.WriteLine();
            Console.WriteLine("Capacidad Máxima de Carga: " + CapacidadMaxima);
            Console.WriteLine();
            Console.WriteLine("Estado del Vehículo: " + EstadoVehiculo);
            Console.WriteLine();
            Console.WriteLine("Entregas Realizadas: " + EntregasRealizadas);
            Console.WriteLine();
            Console.WriteLine("Tipo de Vehículo: " + TipoVehiculo);
            Console.WriteLine();
            Console.WriteLine("Repartidor Asignado: " + RepartidorAsignado);
            Console.WriteLine();
            Console.WriteLine("Especialización del Vehículo: " + Especializacion);
        }

        protected void ModificarEstado(EstadoVehiculo nuevoEstadoVehiculo)
        {
            EstadoVehiculo = nuevoEstadoVehiculo;
        }

        protected void AgregarEntregasRealizadas(int nuevaEntrega)
        {
            EntregasRealizadas += nuevaEntrega;
        }

        protected virtual void CalcularCostoOperativo()
        {
            Console.WriteLine("Se calcula el costo operativo del vehículo...");
        }

        public TipoEspecializacion Especializacion
        {
            get { return especializacion; }
            set { especializacion = value; }
        }

        public Repartidor RepartidorAsignado
        {
            get { return repartidorAsignado; }
            set { repartidorAsignado = value; }
        }

        public TipoVehiculo TipoVehiculo
        {
            get { return tipoVehiculo; }
            set { tipoVehiculo = value; }
        }

        public int EntregasRealizadas
        {
            get { return entregasRealizadas; }
            set { entregasRealizadas = value; }
        }

        public EstadoVehiculo EstadoVehiculo
        {
            get { return estadoVehiculo; }
            set { estadoVehiculo = value; }
        }

        public double CapacidadMaxima
        {
            get { return capacidadMaxima; }
            set { capacidadMaxima = value; }
        }

        public int Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public string Placa
        {
            get { return placa; }
            set { placa = value; }
        }

        public string Prefijo
        {
            get { return prefijo; }
            set { prefijo = value; }
        }

        public string CodigoUnico
        {
            get { return codigoUnico; }
            set { codigoUnico = value; }
        }
    }

    internal class Bicicleta : Vehiculo
    {
        public Bicicleta(string nuevoCodigoUnico, string nuevoPrefijo, string nuevaPlaca, string nuevaMarca, int nuevoModelo, double nuevaCapacidadMaxima, EstadoVehiculo nuevoEstadoVehiculo, int nuevasEntregasRealizadas, TipoVehiculo nuevoTipoVehiculo, Repartidor nuevoRepartidor, TipoEspecializacion nuevoTipoEspecializacion) : base(nuevoCodigoUnico, nuevoPrefijo, nuevaPlaca, nuevaMarca, nuevoModelo, nuevaCapacidadMaxima, nuevoEstadoVehiculo, nuevasEntregasRealizadas, nuevoTipoVehiculo, nuevoRepartidor, nuevoTipoEspecializacion)
        {

        }

        protected override void CalcularCostoOperativo()
        {
            Console.WriteLine("Se calcula el costo operativo de la Bicicleta...");
        }
    }

    internal class Motocicleta : Vehiculo
    {
        public Motocicleta(string nuevoCodigoUnico, string nuevoPrefijo, string nuevaPlaca, string nuevaMarca, int nuevoModelo, double nuevaCapacidadMaxima, EstadoVehiculo nuevoEstadoVehiculo, int nuevasEntregasRealizadas, TipoVehiculo nuevoTipoVehiculo, Repartidor nuevoRepartidor, TipoEspecializacion nuevoTipoEspecializacion) : base(nuevoCodigoUnico, nuevoPrefijo, nuevaPlaca, nuevaMarca, nuevoModelo, nuevaCapacidadMaxima, nuevoEstadoVehiculo, nuevasEntregasRealizadas, nuevoTipoVehiculo, nuevoRepartidor, nuevoTipoEspecializacion)
        {

        }

        protected override void CalcularCostoOperativo()
        {
            Console.WriteLine("Se calcula el costo operativo de la Motocicleta...");
        }
    }

    internal class Carro : Vehiculo
    {
        public Carro(string nuevoCodigoUnico, string nuevoPrefijo, string nuevaPlaca, string nuevaMarca, int nuevoModelo, double nuevaCapacidadMaxima, EstadoVehiculo nuevoEstadoVehiculo, int nuevasEntregasRealizadas, TipoVehiculo nuevoTipoVehiculo, Repartidor nuevoRepartidor, TipoEspecializacion nuevoTipoEspecializacion) : base(nuevoCodigoUnico, nuevoPrefijo, nuevaPlaca, nuevaMarca, nuevoModelo, nuevaCapacidadMaxima, nuevoEstadoVehiculo, nuevasEntregasRealizadas, nuevoTipoVehiculo, nuevoRepartidor, nuevoTipoEspecializacion)
        {

        }

        protected override void CalcularCostoOperativo()
        {
            Console.WriteLine("Se calcula el costo operativo del Carro...");
        }
    }
}
