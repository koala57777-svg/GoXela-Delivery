using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoXelaDelivery
{
    internal class Persona
    {
		private string  codigoUnico;

		private string prefijo;

		private string nombreCompleto;

		private int numeroTelefono;

		public Persona(string nuevoCodigoUnico, string nuevoPrefijo, string nuevoNombreCompleto, string nuevoNumeroTelefono)
		{
			CodigoUnico = nuevoCodigoUnico;
			Prefijo = nuevoPrefijo;
			NombreCompleto = nuevoNombreCompleto;
			NumeroTelefono = nuevoNumeroTelefono;
		}

		protected virtual void MostrarInformacion()
		{
            Console.WriteLine("ID: " + CodigoUnico);
            Console.WriteLine();
            Console.WriteLine("Prefijo: " + Prefijo);
            Console.WriteLine();
            Console.WriteLine("Nombre Completo: " + NombreCompleto);
            Console.WriteLine();
            Console.WriteLine("Número de Teléfono: " + NumeroTelefono);
		}

		public int NumeroTelefono
		{
			get { return numeroTelefono; }
			set { numeroTelefono = value; }
		}

		public string NombreCompleto
		{
			get { return nombreCompleto; }
			set { nombreCompleto = value; }
		}

		public string Prefijo
		{
			get { return prefijo; }
			set { prefijo = value; }
		}

		public string  CodigoUnico
		{
			get { return codigoUnico; }
			set { codigoUnico = value; }
		}
	}
}
