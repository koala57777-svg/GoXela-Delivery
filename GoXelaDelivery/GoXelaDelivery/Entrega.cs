using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoXelaDelivery.Enums;

namespace GoXelaDelivery
{
    internal class Entrega
    {
		private string codigoUnico;

		private string prefijo;

		private Paquete paqueteEntrega;

		private Cliente clienteEntrega;

		private Repartidor repartidorAsignado;

		private Vehiculo vehiculoAsignado;

		private TipoVehiculoGeneral vehiculoGeneral;

		private DateTime fechaSolicitud;

		private string direccionOrigen;

		private Municipio municipioOrigen;

		private string direccionDestino;

		private Municipio municipioDestino;

		private double distanciaEstimada;

		private TipoServicio tipoServicio;

		private double tarifaBase;

		private double recargo;

		private double descuento;

		private List<Incidente> listaIncidentes = new List<Incidente>();

		private EstadoEntrega estadoEntrega;

		private double total;

		public Entrega(string nuevoCodigoUnico, string nuevoPrefijo, Paquete nuevoPaqueteEntrega, Repartidor nuevoRepartidorAsignado, Vehiculo nuevoVehiculoAsignado, TipoVehiculoGeneral nuevoVehiculoGeneral, double nuevaDistanciaEstimada, TipoServicio nuevoTipoServicio, double nuevaTarifaBase, double nuevoTotal)
		{
			CodigoUnico = nuevoCodigoUnico;
			Prefijo = nuevoPrefijo;
			PaqueteEntrega = nuevoPaqueteEntrega;
			RepartidorAsignado = nuevoRepartidorAsignado;
			VehiculoAsigando = nuevoVehiculoAsignado;
			VehiculoGeneral = nuevoVehiculoGeneral;
			DistanciaEstimada = nuevaDistanciaEstimada;
			TipoServicio = nuevoTipoServicio;
			TarifaBase = nuevaTarifaBase;
			listaIncidentes = new List<Incidente>();
			Total = nuevoTotal;
		}

		protected void MostrarInformacion()
		{
            Console.WriteLine("ID: " + CodigoUnico);
            Console.WriteLine();
            Console.WriteLine("Prefijo: " + Prefijo);
            Console.WriteLine();
            Console.WriteLine("Paquete de la Entrega: " + PaqueteEntrega);
            Console.WriteLine();
            Console.WriteLine("Repartidor Asignado: " + RepartidorAsignado);
            Console.WriteLine();
            Console.WriteLine("Vehículo Asignado: " + VehiculoAsigando);
            Console.WriteLine();
            Console.WriteLine("Vehículo General: " + VehiculoGeneral);
            Console.WriteLine();
            Console.WriteLine("Distancia Estimada (Km): " + DistanciaEstimada);
            Console.WriteLine();
            Console.WriteLine("Tipo de Servicio: " + TipoServicio);
            Console.WriteLine();
            Console.WriteLine("Tarifa Base de la Entrega : Q" + TarifaBase);
            Console.WriteLine();
            Console.WriteLine("Total de la Entrega (Pueden aplicar Recargos y Descuentos): Q" + Total);
		}

        public double Total
        {
            get { return total; }
            set { total = value; }
        }

        public EstadoEntrega EstadoEntrega
		{
			get { return estadoEntrega; }
			set { estadoEntrega = EstadoEntrega.Solicitado; }
		}

		public List<Incidente> ListaIncidentes
		{
			get { return listaIncidentes; }
			set { listaIncidentes = value; }
		}

		public double Descuento
		{
			get { return descuento; }
			set { descuento = value; }
		}

		public double Recargo
		{
			get { return recargo; }
			set { recargo = value; }
		}

		public double TarifaBase
		{
			get { return tarifaBase; }
			set { tarifaBase = value; }
		}

		public TipoServicio TipoServicio
		{
			get { return tipoServicio; }
			set { tipoServicio = value; }
		}

		public double DistanciaEstimada
		{
			get { return distanciaEstimada; }
			set { distanciaEstimada = value; }
		}

		public Municipio MunicipioDestino
		{
			get { return municipioDestino; }
			set { municipioDestino = PaqueteEntrega.MunicipioDestino; }
		}

		public string DireccionDestino
		{
			get { return direccionDestino; }
			set { direccionDestino = PaqueteEntrega.DireccionDestino; }
		}

		public Municipio MunicipioOrigen
		{
			get { return municipioOrigen; }
			set { municipioOrigen = PaqueteEntrega.MunicipioOrigen; }
		}

		public string DireccionOrigen
		{
			get { return direccionOrigen; }
			set { direccionOrigen = PaqueteEntrega.DireccionOrigen; }
		}

		public DateTime FechaSolicitud
		{
			get { return fechaSolicitud; }
			set { fechaSolicitud = DateTime.Now; }
		}

		public TipoVehiculoGeneral VehiculoGeneral
		{
			get { return myVavehiculoGeneral; }
			set { vehiculoGeneral = value; }
		}
		 
		public Vehiculo VehiculoAsigando
		{
			get { return vehiculoAsignado; }
			set { vehiculoAsignado = value; }
		}

		public Repartidor RepartidorAsignado
		{
			get { return repartidorAsignado; }
			set { repartidorAsignado = value; }
		}

		public Paquete ClienteEntrega
		{
			get { return clienteEntrega; }
			set { clienteEntrega = PaqueteEntrega.ClientePaquete; }
		}

		public Paquete PaqueteEntrega
		{
			get { return paqueteEntrega; }
			set { paqueteEntrega = value; }
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
}
