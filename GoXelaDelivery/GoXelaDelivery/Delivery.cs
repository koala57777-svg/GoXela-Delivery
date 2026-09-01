using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoXelaDelivery.Enums;

namespace GoXelaDelivery
{
	internal class Delivery
	{
		private List<Cliente> listaClientes = new List<Cliente>();

		private List<Repartidor> listaRepartidores = new List<Repartidor>();

		private List<List<Vehiculo>> listasVehiculos = new List<List<Vehiculo>>();

		private List<Bicicleta> listaBicicletas = new List<Bicicleta>();

		private List<Motocicleta> listaMotocicletas = new List<Motocicleta>();

		private List<Carro> listaCarros = new List<Carro>();

		private List<List<Paquete>> listasPaquetes = new List<List<Paquete>>();

		private List<Documento> listaDocumentos = new List<Documento>();

		private List<PaqueteEstandar> listaPaquetesEstandar = new List<PaqueteEstandar>();

		private List<PaqueteFragil> listaPaquetesFragiles = new List<PaqueteFragil>();

		private List<ProductoRefrigerado> listaProductosRefrigerados = new List<ProductoRefrigerado>();

		private List<Entrega> listaEntregas = new List<Entrega>();

		private double totalIngresos;

		public Delivery()
		{
			listaClientes = new List<Cliente>();

			listaRepartidores = new List<Repartidor>();

			listasVehiculos = new List<List<Vehiculo>>();
			listasVehiculos.Add(new List<Vehiculo>());
            listasVehiculos.Add(new List<Vehiculo>());
            listasVehiculos.Add(new List<Vehiculo>());

            listasPaquetes = new List<List<Paquete>>();
			listasPaquetes.Add(new List<Paquete>());
            listasPaquetes.Add(new List<Paquete>());
            listasPaquetes.Add(new List<Paquete>());
            listasPaquetes.Add(new List<Paquete>());

            listaEntregas = new List<Entrega>();
		}

		protected void IngresarCliente(Cliente cliente)
		{
			if (cliente != null)
			{
				listaClientes.Add(cliente);
			}
		}

		protected void IngresarRepartidor(Repartidor repartidor)
		{
			if (repartidor != null)
			{
				listaRepartidores.Add(repartidor);
			}
		}

		protected void IngresarVehiculo(Vehiculo vehiculo)
		{
			if (vehiculo != null)
			{
                if (vehiculo.TipoVehiculo == TipoVehiculo.Motocicleta)
                {
					listasVehiculos[0].Add(vehiculo);
                }
                else if (vehiculo.TipoVehiculo == TipoVehiculo.Automovil)
                {
                    listasVehiculos[1].Add(vehiculo);
                }
                else
                {
                    listasVehiculos[2].Add(vehiculo);
                }
            }
		}

		protected void IngresarPaquete(Paquete paquete)
		{
			if (paquete != null)
			{
				if (paquete.TipoPaquete == TipoPaquete.Documento)
				{
					listasPaquetes[0].Add(paquete);
				}
				else if (paquete.TipoPaquete == TipoPaquete.Estandar)
				{
                    listasPaquetes[1].Add(paquete);
                }
				else if (paquete.TipoPaquete == TipoPaquete.Fragil)
				{
                    listasPaquetes[2].Add(paquete);
                }
				else
				{
                    listasPaquetes[3].Add(paquete);
                }
			}
		}

		protected void IngresarEntrega(Entrega entrega)
		{
			if (entrega != null)
			{
				listaEntregas.Add(entrega);
			}
		}

		protected void MostrarEntregasActivas()
		{
			Console.WriteLine("Se muestra la cantidad de Entregas Activas...");
		}

        protected void MostrarEntregasFinalizadas()
        {
            Console.WriteLine("Se muestra la cantidad de Entregas Finalizadas...");
        }

        protected void MostrarEntregasCanceladas()
        {
            Console.WriteLine("Se muestra la cantidad de Entregas Canceladas...");
        }

        protected void MostrarEntregasConIncidencias()
        {
            Console.WriteLine("Se muestra la cantidad de Entregas con Incidencias...");
        }

        protected void MostrarRepartidoresDisponibles()
        {
            Console.WriteLine("Se muestra la cantidad de Repartidores Disponibles...");
        }

        protected void MostrarRepartidorConMasEntregas()
        {
            Console.WriteLine("Se muestra al Repartidor con más Entregas Realizadas...");
        }

        protected void MostrarVehiculoMasUsado()
        {
            Console.WriteLine("Se muestra al Vehiculo más Usado...");
        }

        protected void CantidadPaquetesPorTipo()
        {
            Console.WriteLine("Se muestra la cantidad de Paquetes por Tipos...");
        }

        protected void MostrarTotalIngresos()
        {
            Console.WriteLine("Se muestra el Total de Ingresos Generados...");
        }

        protected void MostrarEntregaConMayorCosto()
        {
            Console.WriteLine("Se muestra la Entrega con Mayor Costo...");
        }

        public double TotalIngresos
		{
			get { return totalIngresos; }
			set { totalIngresos = value; }
		}

		public List<Entrega> ListaEntregas
		{
			get { return listaEntregas = new List<Entrega>(); }
			set { listaEntregas = new List<Entrega>() = value; }
		}

		public List<List<Paquete>> ListaPaquetes
		{
			get { return listaPaquetes = new List<List<Paquete>>; }
			set { listaPaquetes = new List<List<Paquete>> = value; }
		}

		public List<List<Vehiculo>> ListaVehiculos
		{
			get { return listaVehiculos = new List<List<Vehiculo>>(); }
			set { listaVehiculos = new List<List<Vehiculo>>() = value; }
		}

		public List<Repartidor> ListaRepartidores
		{
			get { return listaRepartidores = new List<Repartidor>(); }
			set { listaRepartidores = new List<Repartidor>() = value; }
		}

		public List<Cliente> ListaClientes
		{
			get { return listaClientes = new List<Cliente>(); }
			set { listaClientes = new List<Cliente>() = value; }
		}
	}
}
