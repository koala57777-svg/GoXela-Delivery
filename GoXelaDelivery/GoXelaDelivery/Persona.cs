using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoXelaDelivery.Enums

namespace GoXelaDelivery
{
    internal class Persona
    {
		private string  codigoUnico;

		private string prefijo;

		private string nombreCompleto;

		private string numeroTelefono;

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

	internal class Cliente : Persona
	{
		private string correoElectronico;

		private string direccionDestino;

		private Enums.Municipio municipioDestino;

		private int solicitudesRealizadas;

		public Cliente(string nuevoCodigoUnico, string nuevoPrefijo, string nuevoNombreCompleto, string nuevoNumeroTelefono, string nuevoCorreoElectronico, string nuevaDireccionDestino, Enums.Municipio nuevoMunicipioDestino, int nuevasSolicitudesRealizadas) : base(nuevoCodigoUnico, nuevoPrefijo, nuevoNombreCompleto, nuevoNumeroTelefono)
		{
			CorreoElectronico = nuevoCorreoElectronico;
			DireccionDestino = nuevaDireccionDestino;
			MunicipioDestino = nuevoMunicipioDestino;
			SolicitudesRealizadas = nuevasSolicitudesRealizadas;
		}

		protected override void MostrarInformacion()
		{
			base.MostrarInformacion();
			Console.WriteLine();
			Console.WriteLine("Correo Electrónico: " + CorreoElectronico);
			Console.WriteLine();
			Console.WriteLine("Dirección de Destino: " + DireccionDestino);
			Console.WriteLine();
			Console.WriteLine("Municipio de Destino: " + MunicipioDestino);
			Console.WriteLine();
			Console.WriteLine("Cantidad de Solicitudes Realizadas: " + SolicitudesRealizadas);
        }

		public int SolicitudesRealizadas
		{
			get { return solicitudesRealizadas; }
			set { solicitudesRealizadas = value; }
		}

		public Enums.Municipio MunicipioDestino
		{
			get { return municipioDestino; }
			set { municipioDestino = value; }
		}

		public string DireccionDestino
		{
			get { return direccionDestino; }
			set { direccionDestino = value; }
		}

		public string CorreoElectronico
		{
			get { return correoElectronico; }
			set { correoElectronico = value; }
		}

	}
}
