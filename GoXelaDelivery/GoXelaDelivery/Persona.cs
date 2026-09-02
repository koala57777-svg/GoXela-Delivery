using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoXelaDelivery.Enums;

namespace GoXelaDelivery
{
    internal class Persona
    {
		private string  codigoUnico;

		private  string prefijo ="PER";

		private string nombreCompleto;

		private int numeroTelefono;

		public Persona(string nuevoNombreCompleto, int nuevoNumeroTelefono)
		{
			NombreCompleto = nuevoNombreCompleto;
			NumeroTelefono = nuevoNumeroTelefono;
		}

		internal virtual void MostrarInformacion()
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

		private Municipio municipioDestino;

		private int solicitudesRealizadas;

		public Cliente(string nuevoNombreCompleto, int nuevoNumeroTelefono, string nuevoCorreoElectronico, string nuevaDireccionDestino, Municipio nuevoMunicipioDestino, int nuevasSolicitudesRealizadas) : base(nuevoNombreCompleto, nuevoNumeroTelefono)
		{
			Prefijo = "CLI";
			CorreoElectronico = nuevoCorreoElectronico;
			DireccionDestino = nuevaDireccionDestino;
			MunicipioDestino = nuevoMunicipioDestino;
			SolicitudesRealizadas = nuevasSolicitudesRealizadas;
		}

		internal override void MostrarInformacion()
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

		public Municipio MunicipioDestino
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

	internal class Repartidor : Persona
	{
		private int numeroLicencia;

		private TipoLicencia tipoLicencia;

		private EstadoRepartidor estadoDisponibilidad;

		private int cantidadEntregasRealizadas;

		private double calificacionTotal;

		private double calificacionPromedio;

		public Repartidor(string nuevoNombreCompleto, int nuevoNumeroTelefono, int nuevoNumeroLicencia, TipoLicencia nuevoTipoLicencia, EstadoRepartidor nuevoEstadoDisponibilidad, int nuevaCantidadEntregas, double nuevaCalificacionTotal, double nuevaCalificacionPromedio) : base(nuevoNombreCompleto, nuevoNumeroTelefono)
		{
            Prefijo = "REP";
            NumeroLicencia = nuevoNumeroLicencia;
			TipoLicencia = nuevoTipoLicencia;
			EstadoDisponibilidad = nuevoEstadoDisponibilidad;
			CantidadEntregasRealizadas = nuevaCantidadEntregas;
			CalificacionTotal = nuevaCalificacionTotal;
			CalificacionPromedio = nuevaCalificacionPromedio;
		}

        internal override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine();
            Console.WriteLine("Número de Licencia: " + NumeroLicencia);
            Console.WriteLine();
            Console.WriteLine("Tipo de Licencia: " + TipoLicencia);
            Console.WriteLine();
            Console.WriteLine("Estado de Disponibilidad: " + EstadoDisponibilidad);
            Console.WriteLine();
            Console.WriteLine("Cantidad de Entregas Realizadas: " + CantidadEntregasRealizadas);
            Console.WriteLine();
            Console.WriteLine("Calificación Total: " + CalificacionTotal);
            Console.WriteLine();
            Console.WriteLine("Calificación Promedio: " + CalificacionPromedio);
        }

        public double CalificacionPromedio
		{
			get { return calificacionPromedio; }
			set { calificacionPromedio = value; }
		}

		public double CalificacionTotal
		{
			get { return calificacionTotal; }
			set { calificacionTotal = value; }
		}

		public int CantidadEntregasRealizadas
		{
			get { return cantidadEntregasRealizadas; }
			set { cantidadEntregasRealizadas = value; }
		}

		public EstadoRepartidor EstadoDisponibilidad
		{
			get { return estadoDisponibilidad; }
			set { estadoDisponibilidad = value; }
		}

		public TipoLicencia TipoLicencia
		{
			get { return tipoLicencia; }
			set { tipoLicencia = value; }
		}

		public int NumeroLicencia
		{
			get { return numeroLicencia; }
			set { numeroLicencia = value; }
		}

	}
}
