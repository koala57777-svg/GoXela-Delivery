using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoXelaDelivery.Enums;

namespace GoXelaDelivery
{
    internal static class Globales
    {
		private static int contadorEntregasActivas;

		private static int contadorEntregasFinalizadas;

		private static int contadorEntregasCanceladas;

		private static int contadorEntregasConIncidentes;

		private static int contadorRepartidoresDisponibles;

		private static List<Repartidor> repartidorConMasEntregas;

		private static int entregasMaximas;

		private static Repartidor elRepatidor;

		private static int cantidadMaximaUsosVehiculo;

		private static List<Vehiculo> vehiculoMasUsado;

		private static Vehiculo elVehiculo;

		private static List<List<Vehiculo>> tiposDeVehiculosNoVacios;

		private static List<Entrega> entregasFinalizadas;

		private static double mayorCostoDeEntrega;

		private static List<Entrega> entregaConMayorCosto;

		private static Entrega laEntrega;

		private static TipoVehiculoGeneral vehiculoSeleccionado;

		private static TipoServicio servicioSeleccionado;

		private static List<Vehiculo> vehiculoCorrecto;

		private static List<Vehiculo> listaVehiculosCorrectos;

		private static List<Repartidor> listaRepartidoresCorrectos;

		private static int opcionMenuPrincipal;

		public static int OpcionMenuPrincipal
		{
			get { return opcionMenuPrincipal; }
			set { opcionMenuPrincipal = value; }
		}

		public static List<Repartidor>  ListaRepartidoresCorrectos
		{
			get { return listaRepartidoresCorrectos; }
			set { listaRepartidoresCorrectos = value; }
		}

		private static List<Repartidor> repartidorCorrecto;

		public static List<Repartidor>  RepartidorCorrecto
		{
			get { return repartidorCorrecto; }
			set { repartidorCorrecto = value; }
		}

		public static List<Vehiculo> ListaVehiculosCorrectos
		{
			get { return listaVehiculosCorrectos; }
			set { listaVehiculosCorrectos = value; }
		}

		public static List<Vehiculo> VehiculoCorrecto
		{
			get { return vehiculoCorrecto; }
			set { vehiculoCorrecto = value; }
		}

		public static TipoServicio ServicioSeleccionado
		{
			get { return servicioSeleccionado; }
			set { servicioSeleccionado = value; }
		}

		public static TipoVehiculoGeneral VehiculoSeleccionado
		{
			get { return vehiculoSeleccionado; }
			set { vehiculoSeleccionado = value; }
		}

		public static Entrega LaEntrega
		{
			get { return laEntrega; }
			set { laEntrega = value; }
		}

		public static List<Entrega> EntregaConMayorCosto
		{
			get { return entregaConMayorCosto; }
			set { entregaConMayorCosto = value; }
		}

		public static double MayorCostoDeEntrega
		{
			get { return mayorCostoDeEntrega; }
			set { mayorCostoDeEntrega = value; }
		}

		public static List<Entrega> EntregasFinalizadas
		{
			get { return entregasFinalizadas; }
			set { entregasFinalizadas = value; }
		}

		public static List<List<Vehiculo>> TiposDeVehiculosNoVacios
        {
			get { return tiposDeVehiculosNoVacios; }
			set { tiposDeVehiculosNoVacios = value; }
		}

		public static Vehiculo ElVehiculo
		{
			get { return elVehiculo; }
			set { elVehiculo = value; }
		}

		public static List<Vehiculo> VehiculoMasUsado 
		{
			get { return vehiculoMasUsado; }
			set { vehiculoMasUsado = value; }
		}

		public static int CantidadMaximaUsosVehiculo
		{
			get { return cantidadMaximaUsosVehiculo; }
			set { cantidadMaximaUsosVehiculo = value; }
		}

		public static Repartidor ElRepartidor
		{
			get { return elRepatidor; }
			set { elRepatidor = value; }
		}

		public static int EntregasMaximas
		{
			get { return entregasMaximas; }
			set { entregasMaximas = value; }
		}

		public static List<Repartidor> RepartidorConMasEntregas
		{
			get { return repartidorConMasEntregas; }
			set { repartidorConMasEntregas = value; }
		}

		public static int ContadorRepartidoresDisponibles
		{
			get { return contadorRepartidoresDisponibles; }
			set { contadorRepartidoresDisponibles = value; }
		}

		public static int ContadorEntregasConIncidentes
		{
			get { return contadorEntregasConIncidentes; }
			set { contadorEntregasConIncidentes = value; }
		}

		public static int ContadorEntregasCanceladas
		{
			get { return contadorEntregasCanceladas; }
			set { contadorEntregasCanceladas = value; }
		}

		public static int ContadorEntregasFinalizadas
		{
			get { return contadorEntregasFinalizadas; }
			set { contadorEntregasFinalizadas = value; }
		}

		public static int ContadorEntregasActivas
		{
			get { return contadorEntregasActivas; }
			set { contadorEntregasActivas = value; }
		}

        public static void LimpiarConsola()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Presione CUALQUIER tecla para continuar");
            Console.ResetColor();
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
        }

		public static void SalirMenu()
		{
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Gracias por usar el programa :)");
            Console.WriteLine();
            Console.ResetColor();
        }

		public static void ErroOpcionNoValida()
		{
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error opción no válida");
            Console.WriteLine();
            Console.ResetColor();
			LimpiarConsola();
        }
    }
}
