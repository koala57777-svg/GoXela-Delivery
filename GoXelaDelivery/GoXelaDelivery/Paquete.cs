using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoXelaDelivery.Enums;

namespace GoXelaDelivery
{
    internal class Paquete
    {
		private string codigoUnico;

		private string prefijo = "PAQ";

		private TipoPaquete tipoPaquete;

		private string descripcion;

		private double peso;

		private double valorDeclarado;

		private Cliente clientePaquete;

		private string direccionOrigen;

		private string direccionDestino;

		private EstadoPaquete estadoPaquete;

		private Municipio municipioOrigen;

		private Municipio municipioDestino;

		public Paquete(TipoPaquete nuevoTipoPaquete, string nuevaDescripcion, double nuevoPeso, double nuevoValorDeclarado, Cliente nuevoClientePaquete, string nuevaDireccionOrigen, Municipio nuevoMunicipioOrigen)
		{
			TipoPaquete = nuevoTipoPaquete;
			Descripcion = nuevaDescripcion;
			Peso = nuevoPeso;
			ValorDeclarado = nuevoValorDeclarado;
			ClientePaquete = nuevoClientePaquete;
			DireccionOrigen = nuevaDireccionOrigen;
			EstadoPaquete = EstadoPaquete.NoAsignado;
			MunicipioOrigen = nuevoMunicipioOrigen;
		}

        protected void MostrarInformacion()
        {
            Console.WriteLine("ID: " + CodigoUnico);
            Console.WriteLine();
            Console.WriteLine("Prefijo: " + Prefijo);
            Console.WriteLine();
            Console.WriteLine("Tipo de Paquete: " + TipoPaquete);
            Console.WriteLine();
            Console.WriteLine("Descripción del Paquete: " + Descripcion);
            Console.WriteLine();
            Console.WriteLine("Peso (kg): " + Peso);
            Console.WriteLine();
            Console.WriteLine("Valor Declarado: " + ValorDeclarado);
            Console.WriteLine();
            Console.WriteLine("Cliente del Paquete: " + ClientePaquete);
            Console.WriteLine();
            Console.WriteLine("Dirección de Origen: " + DireccionOrigen);
            Console.WriteLine();
            Console.WriteLine("Dirección de Destino: " + DireccionDestino);
            Console.WriteLine();
            Console.WriteLine("Estado del Paquete: " + EstadoPaquete);
            Console.WriteLine();
            Console.WriteLine("Municipio de Origen: " + MunicipioOrigen);
            Console.WriteLine();
            Console.WriteLine("Municipio de Destino: " + MunicipioDestino);
        }

        protected void CambiarEstado(EstadoPaquete nuevoEstadoPaquete)
		{
			EstadoPaquete = nuevoEstadoPaquete;
		}

		protected void CambiarDescripcion(string nuevaDescripcion)
		{
			Descripcion = nuevaDescripcion;
		}

		internal virtual double CalcularCostoTipo(double valorDeclarado, double Peso)
		{
            Console.WriteLine("Se calcula el costo por el tipo de paquete...");
		}

		public Municipio MunicipioDestino
		{
			get { return municipioDestino; }
			set { municipioDestino = ClientePaquete.MunicipioDestino; }
		}

		public Municipio MunicipioOrigen
		{
			get { return municipioOrigen; }
			set { municipioOrigen = value; }
		}

		public EstadoPaquete EstadoPaquete
		{
			get { return estadoPaquete; }
			set { estadoPaquete = value; }
		}

		public string DireccionDestino
		{
			get { return direccionDestino; }
			set { direccionDestino = ClientePaquete.DireccionDestino; }
		}

		public string DireccionOrigen
		{
			get { return direccionOrigen; }
			set { direccionOrigen = value; }
		}

		public Cliente ClientePaquete
		{
			get { return clientePaquete; }
			set { clientePaquete = value; }
		}

		public double ValorDeclarado
		{
			get { return valorDeclarado; }
			set { valorDeclarado = value; }
		}

		public double Peso
		{
			get { return peso; }
			set { peso = value; }
		}

		public string Descripcion
		{
			get { return descripcion; }
			set { descripcion = value; }
		}

		public TipoPaquete TipoPaquete
		{
			get { return tipoPaquete; }
			set { tipoPaquete = value; }
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

	internal class Documento : Paquete
	{
		public Documento(TipoPaquete nuevoTipoPaquete, string nuevaDescripcion, double nuevoPeso, double nuevoValorDeclarado, Cliente nuevoClientePaquete, string nuevaDireccionOrigen, Municipio nuevoMunicipioOrigen) : base(nuevoTipoPaquete, nuevaDescripcion, nuevoPeso, nuevoValorDeclarado, nuevoClientePaquete, nuevaDireccionOrigen, nuevoMunicipioOrigen)
		{
            EstadoPaquete = EstadoPaquete.NoAsignado;
            Prefijo = "DPQ";
        }

        internal override double CalcularCostoTipo(double valorDeclarado, double Peso)
        {
            return (valorDeclarado * 0.10) + (Peso * 20);
        }
	}

	internal class PaqueteEstandar : Paquete
	{
        public PaqueteEstandar(TipoPaquete nuevoTipoPaquete, string nuevaDescripcion, double nuevoPeso, double nuevoValorDeclarado, Cliente nuevoClientePaquete, string nuevaDireccionOrigen, Municipio nuevoMunicipioOrigen) : base(nuevoTipoPaquete, nuevaDescripcion, nuevoPeso, nuevoValorDeclarado, nuevoClientePaquete, nuevaDireccionOrigen, nuevoMunicipioOrigen)
        {
            EstadoPaquete = EstadoPaquete.NoAsignado;
            Prefijo = "EPQ";
        }

        internal override double CalcularCostoTipo(double valorDeclarado, double Peso)
        {
			return (valorDeclarado * 0.00) + (Peso * 20);
        }
    }

    internal class PaqueteFragil : Paquete
    {
        public PaqueteFragil(TipoPaquete nuevoTipoPaquete, string nuevaDescripcion, double nuevoPeso, double nuevoValorDeclarado, Cliente nuevoClientePaquete, string nuevaDireccionOrigen, Municipio nuevoMunicipioOrigen) : base(nuevoTipoPaquete, nuevaDescripcion, nuevoPeso, nuevoValorDeclarado, nuevoClientePaquete, nuevaDireccionOrigen, nuevoMunicipioOrigen)
        {
            EstadoPaquete = EstadoPaquete.NoAsignado;
            Prefijo = "FPQ";
        }

        internal override double CalcularCostoTipo(double valorDeclarado, double Peso)
        {
            return (valorDeclarado * 0.20) + (Peso * 20);
        }
    }

	internal class ProductoRefrigerado : Paquete
	{
        public ProductoRefrigerado(TipoPaquete nuevoTipoPaquete, string nuevaDescripcion, double nuevoPeso, double nuevoValorDeclarado, Cliente nuevoClientePaquete, string nuevaDireccionOrigen, Municipio nuevoMunicipioOrigen) : base(nuevoTipoPaquete, nuevaDescripcion, nuevoPeso, nuevoValorDeclarado, nuevoClientePaquete, nuevaDireccionOrigen, nuevoMunicipioOrigen)
        {
            EstadoPaquete = EstadoPaquete.NoAsignado;
            Prefijo = "RPQ";
        }

        internal override double CalcularCostoTipo(double valorDeclarado, double Peso)
        {
            return (valorDeclarado * 0.25) + (Peso * 20);
        }
    }
}
