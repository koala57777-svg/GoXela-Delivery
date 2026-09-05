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
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("ID: ");
			Console.ResetColor();
            Console.Write(CodigoUnico);
			Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Prefijo: ");
            Console.ResetColor();
            Console.Write(Prefijo);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Nombre Completo: ");
            Console.ResetColor();
            Console.Write(NombreCompleto);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Número de Teléfono: ");
            Console.ResetColor();
            Console.Write(NumeroTelefono);
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

		public Cliente(string nuevoNombreCompleto, int nuevoNumeroTelefono, string nuevoCorreoElectronico, string nuevaDireccionDestino, Municipio nuevoMunicipioDestino) : base(nuevoNombreCompleto, nuevoNumeroTelefono)
		{
			Prefijo = "CLI";
			CorreoElectronico = nuevoCorreoElectronico;
			DireccionDestino = nuevaDireccionDestino;
			MunicipioDestino = nuevoMunicipioDestino;
			SolicitudesRealizadas = 0;
		}

		internal override void MostrarInformacion()
		{
			base.MostrarInformacion();
			Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Correo Electrónico: ");
            Console.ResetColor();
            Console.Write(CorreoElectronico);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Dirección de Destino: ");
            Console.ResetColor();
            Console.Write(DireccionDestino);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Municipio de Destino: " );
            Console.ResetColor();
            Console.Write(MunicipioDestino);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Cantidad de Solicitudes Realizadas: ");
            Console.ResetColor();
            Console.Write(SolicitudesRealizadas);
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

		public Repartidor(string nuevoNombreCompleto, int nuevoNumeroTelefono, int nuevoNumeroLicencia, TipoLicencia nuevoTipoLicencia, EstadoRepartidor nuevoEstadoDisponibilidad) : base(nuevoNombreCompleto, nuevoNumeroTelefono)
		{
            Prefijo = "REP";
            NumeroLicencia = nuevoNumeroLicencia;
			TipoLicencia = nuevoTipoLicencia;
			EstadoDisponibilidad = nuevoEstadoDisponibilidad;
			CantidadEntregasRealizadas = 0;
			CalificacionTotal = 0;
			CalificacionPromedio = 0;
		}

        internal override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Número de Licencia: ");
            Console.ResetColor();
            Console.Write(NumeroLicencia);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Tipo de Licencia: ");
            Console.ResetColor();
            Console.Write(TipoLicencia);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Estado de Disponibilidad: ");
            Console.ResetColor();
            Console.Write(EstadoDisponibilidad);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Cantidad de Entregas Realizadas: ");
            Console.ResetColor();
            Console.Write(CantidadEntregasRealizadas);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Calificación Total: ");
            Console.ResetColor();
            Console.Write(CalificacionTotal);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Calificación Promedio: ");
            Console.ResetColor();
            Console.Write(CalificacionPromedio);
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
