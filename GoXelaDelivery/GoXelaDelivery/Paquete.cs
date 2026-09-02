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

		public Paquete(TipoPaquete nuevoTipoPaquete, string nuevaDescripcion, double nuevoPeso, double nuevoValorDeclarado, Cliente nuevoClientePaquete, string nuevaDireccionOrigen, EstadoPaquete nuevoEstadoPaquete, Municipio nuevoMunicipioOrigen)
		{
			TipoPaquete = nuevoTipoPaquete;
			Descripcion = nuevaDescripcion;
			Peso = nuevoPeso;
			ValorDeclarado = nuevoValorDeclarado;
			ClientePaquete = nuevoClientePaquete;
			DireccionOrigen = nuevaDireccionOrigen;
			EstadoPaquete = nuevoEstadoPaquete;
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

		protected virtual void CalcularCostoTipo()
		{
            Console.WriteLine("Se calcula el costo del tipo de paquete...");
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
		public Documento(TipoPaquete nuevoTipoPaquete, string nuevaDescripcion, double nuevoPeso, double nuevoValorDeclarado, Cliente nuevoClientePaquete, string nuevaDireccionOrigen, EstadoPaquete nuevoEstadoPaquete, Municipio nuevoMunicipioOrigen) : base(nuevoTipoPaquete, nuevaDescripcion, nuevoPeso, nuevoValorDeclarado, nuevoClientePaquete, nuevaDireccionOrigen, nuevoEstadoPaquete, nuevoMunicipioOrigen)
		{
            Prefijo = "DPQ";
        }

        protected override void CalcularCostoTipo()
        {
            Console.WriteLine("Calcula el costo del tipo paquete Documento...");
        }
	}

	internal class PaqueteEstandar : Paquete
	{
        public PaqueteEstandar(TipoPaquete nuevoTipoPaquete, string nuevaDescripcion, double nuevoPeso, double nuevoValorDeclarado, Cliente nuevoClientePaquete, string nuevaDireccionOrigen, EstadoPaquete nuevoEstadoPaquete, Municipio nuevoMunicipioOrigen) : base(nuevoTipoPaquete, nuevaDescripcion, nuevoPeso, nuevoValorDeclarado, nuevoClientePaquete, nuevaDireccionOrigen, nuevoEstadoPaquete, nuevoMunicipioOrigen)
        {
            Prefijo = "EPQ";
        }

        protected override void CalcularCostoTipo()
        {
            Console.WriteLine("Calcula el costo del tipo paquete PaqueteEstandar...");
        }
    }

    internal class PaqueteFragil : Paquete
    {
        public PaqueteFragil(TipoPaquete nuevoTipoPaquete, string nuevaDescripcion, double nuevoPeso, double nuevoValorDeclarado, Cliente nuevoClientePaquete, string nuevaDireccionOrigen, EstadoPaquete nuevoEstadoPaquete, Municipio nuevoMunicipioOrigen) : base(nuevoTipoPaquete, nuevaDescripcion, nuevoPeso, nuevoValorDeclarado, nuevoClientePaquete, nuevaDireccionOrigen, nuevoEstadoPaquete, nuevoMunicipioOrigen)
        {
            Prefijo = "FPQ";
        }

        protected override void CalcularCostoTipo()
        {
            Console.WriteLine("Calcula el costo del tipo paquete PaqueteFragil...");
        }
    }

	internal class ProductoRefrigerado : Paquete
	{
        public ProductoRefrigerado(TipoPaquete nuevoTipoPaquete, string nuevaDescripcion, double nuevoPeso, double nuevoValorDeclarado, Cliente nuevoClientePaquete, string nuevaDireccionOrigen, EstadoPaquete nuevoEstadoPaquete, Municipio nuevoMunicipioOrigen) : base(nuevoTipoPaquete, nuevaDescripcion, nuevoPeso, nuevoValorDeclarado, nuevoClientePaquete, nuevaDireccionOrigen, nuevoEstadoPaquete, nuevoMunicipioOrigen)
        {
            Prefijo = "RPQ";
        }

        protected override void CalcularCostoTipo()
        {
            Console.WriteLine("Calcula el costo del tipo paquete ProductoRefrigerado...");
        }
    }
}
