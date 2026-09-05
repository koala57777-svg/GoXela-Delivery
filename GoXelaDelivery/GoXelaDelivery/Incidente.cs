using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoXelaDelivery.Enums;

namespace GoXelaDelivery
{
    internal class Incidente
    {
		private string codigoUnico;

		private string prefijo = "INC";

		private TipoIncidencia tipoIncidente;

		private string descripcion;

		private EstadoIncidencia estadoIncidente;

		private string accionTomada;

		private Entrega entreRelacionada;

		private DateTime fechaIncidente;

		public Incidente(TipoIncidencia nuevoTipoIncidente, string nuevaDescripcion, Entrega nuevaEntregaRelacionada)
		{
			TipoIncidente = nuevoTipoIncidente;
            Descripcion = nuevaDescripcion;
			EstadoIncidente = EstadoIncidencia.SinResolver;
			EntregaRelacionada = nuevaEntregaRelacionada;
		}

		protected void MostrarInformacion()
		{
            Console.WriteLine("ID: " + CodigoUnico);
            Console.WriteLine();
            Console.WriteLine("Prefijo: " + Prefijo);
            Console.WriteLine();
            Console.WriteLine("Tipo de Incidente: " + TipoIncidente);
            Console.WriteLine();
            Console.WriteLine("Descripción del Incidente: " + Descripcion);
            Console.WriteLine();
            Console.WriteLine("Estado de la Incidencia: " + EstadoIncidente);
            Console.WriteLine();
            Console.WriteLine("Acción Tomada: " + AccionTomada);
            Console.WriteLine();
            Console.WriteLine("Entrega Relacionada: " + EntregaRelacionada);
            Console.WriteLine();
            Console.WriteLine("Fecha del Incidente: "+ FechaIncidente);
		}

		protected void CambiarEstado(Incidente incidente)
		{
			if (incidente.AccionTomada == null || incidente.AccionTomada.Length == 0)
			{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se puede el estado de la incidencia. Coloque una acción tomada");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
			else
			{
                EstadoIncidente = EstadoIncidencia.Resuelta;
            }
		}

		protected void CambiarAccionTomada(string nuevaAccionTomada)
		{
			AccionTomada = nuevaAccionTomada;
		}

		public DateTime FechaIncidente
		{
			get { return fechaIncidente; }
			set { fechaIncidente = EntregaRelacionada.FechaSolicitud; }
		}

		public Entrega EntregaRelacionada
		{
			get { return entreRelacionada; }
			set { entreRelacionada = value; }
		}

		public string AccionTomada
		{
			get { return accionTomada; }
			set { accionTomada = value; }
		}

		public EstadoIncidencia EstadoIncidente
		{
			get { return estadoIncidente; }
			set { estadoIncidente = value; }
		}

		public string Descripcion
		{
			get { return descripcion; }
			set { descripcion = value; }
		}

		public TipoIncidencia TipoIncidente
		{
			get { return tipoIncidente; }
			set { tipoIncidente = value; }
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
