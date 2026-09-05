using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoXelaDelivery.Enums;
using static GoXelaDelivery.Globales;

namespace GoXelaDelivery
{
    internal class Entrega
    {
		private string codigoUnico;

		private string prefijo = "ENT";

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

		public Entrega(Paquete nuevoPaqueteEntrega, TipoVehiculoGeneral nuevoVehiculoGeneral, double nuevaDistanciaEstimada, TipoServicio nuevoTipoServicio, double nuevaTarifaBase)
		{
			EstadoEntrega = EstadoEntrega.Solicitado;
			PaqueteEntrega = nuevoPaqueteEntrega;
			VehiculoGeneral = nuevoVehiculoGeneral;
			DistanciaEstimada = nuevaDistanciaEstimada;
			TipoServicio = nuevoTipoServicio;
			TarifaBase = nuevaTarifaBase;
			listaIncidentes = new List<Incidente>();
		}

		internal void AgregarIncidenteAEntrega(Entrega entregaAAgregarIncidente, Incidente incidenteAAgregar)
		{
            if (incidenteAAgregar != null)
            {
                string codigoUnico = GoXelaDelivery.CodigoUnico.GenerarCodigoUnico(incidenteAAgregar.Prefijo);
                incidenteAAgregar.CodigoUnico = codigoUnico;
                entregaAAgregarIncidente.ListaIncidentes.Add(incidenteAAgregar);
            }
        }

		internal void CambiarEstadoIncidente(Incidente incidenteACambiarEstado)
		{
            if (incidenteACambiarEstado.AccionTomada == null || incidenteACambiarEstado.AccionTomada.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se puede el estado de la incidencia. Coloque una acción tomada");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
            else
            {
                incidenteACambiarEstado.EstadoIncidente = EstadoIncidencia.Resuelta;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Se cambió correctamente el estado del incidente a Resuelto.");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
        }

		internal void CambiarAccionTomadaIncidente(Incidente incidenteACambiarDescripcion, string nuevaAccionTomada)
		{
			incidenteACambiarDescripcion.Descripcion = nuevaAccionTomada;
		}
		
		internal void MostrarInformacion()
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

		internal void CambiarEstadoEntregaConfirmada()
		{
			if (EstadoEntrega == EstadoEntrega.Solicitado)
			{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se puede el estado de la entrega. Confirme la Entrega primero");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
			else
			{
				if (EstadoEntrega == EstadoEntrega.Reprogramado)
				{
					EstadoEntrega = EstadoEntrega.Cofirmado;
				}

                if (ListaIncidentes != null && ListaIncidentes.Any())
                {
                    bool todosResueltos = ListaIncidentes.All(incidente => incidente.EstadoIncidente == EstadoIncidencia.Resuelta);
                    if (todosResueltos)
                    {
                        EstadoEntrega = (EstadoEntrega)((int)EstadoEntrega + 1);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Se ha cambiado Correctamente el Estado de la Entrega. Nuevo Estado: {EstadoEntrega}");
                        Console.ResetColor();
                        LimpiarConsola();
                        return;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No se puede cambiar el estado: existen incidentes marcados como Sin Resolver.");
                        Console.ResetColor();
                        LimpiarConsola();
                        return;
                    }
                }
                else
                {
                    EstadoEntrega = (EstadoEntrega)((int)EstadoEntrega + 1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Se ha cambiado Correctamente el Estado de la Entrega. Nuevo Estado: {EstadoEntrega}");
                    Console.ResetColor();
                    LimpiarConsola();
                    return;
                }
            }
		}

		internal void CancelarEntrega()
		{
			EstadoEntrega = EstadoEntrega.Cancelada;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Se ha Cancelado Correctamente la Entrega.");
            Console.ResetColor();
            LimpiarConsola();
            return;
        }

		internal void ReprogramarEntrega()
		{
			if (EstadoEntrega != EstadoEntrega.Cofirmado)
			{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No se puede Reprogramar la entrega. Debe solo estar en Confirmada para poder hacerlo");
                Console.ResetColor();
                LimpiarConsola();
                return;
            }
			else
			{
                EstadoEntrega = EstadoEntrega.Reprogramado;
            }
		}

		internal void CalcularTotalEntregaConfirmada(Entrega entregaConfirmada)
		{
			if (entregaConfirmada.ClienteEntrega.SolicitudesRealizadas > 10)
			{
				if (entregaConfirmada.EstadoEntrega == EstadoEntrega.Reprogramado)
				{
					entregaConfirmada.Total = (entregaConfirmada.tarifaBase + entregaConfirmada.VehiculoAsigando.CalcularTarifaEspecialización(entregaConfirmada.VehiculoAsigando) + 5) - (0.10*entregaConfirmada.tarifaBase);
				}
				else
				{
                    entregaConfirmada.Total = (entregaConfirmada.tarifaBase + entregaConfirmada.VehiculoAsigando.CalcularTarifaEspecialización(entregaConfirmada.VehiculoAsigando)) - (0.10 * entregaConfirmada.tarifaBase);
                }
			}
			else if (entregaConfirmada.estadoEntrega == EstadoEntrega.Reprogramado)
			{
				entregaConfirmada.Total = (entregaConfirmada.tarifaBase + entregaConfirmada.VehiculoAsigando.CalcularTarifaEspecialización(entregaConfirmada.VehiculoAsigando) + 5);

            }
			else
			{
				entregaConfirmada.Total = (entregaConfirmada.tarifaBase + entregaConfirmada.VehiculoAsigando.CalcularTarifaEspecialización(entregaConfirmada.VehiculoAsigando));

            }
		}

		internal double CalcularTarifaServicio()
		{
			if (ServicioSeleccionado == TipoServicio.Normal)
			{
				return 20;
			}
			else if (ServicioSeleccionado == TipoServicio.Prioritario)
			{
				return 60;
			}
			else
			{
				return 110;
			}
		}

		internal void SeleccionarVehiculoGeneral(Paquete paqueteEntrega)
		{
			if ((280 - paqueteEntrega.Peso) >= 0)
			{
				VehiculoSeleccionado = TipoVehiculoGeneral.Bicicleta;
			}
			else if ((400 - paqueteEntrega.Peso) >= 0)
			{
                VehiculoSeleccionado = TipoVehiculoGeneral.Motocicleta;
			}
			else if ((400 - paqueteEntrega.Peso) >= 0)
			{
                VehiculoSeleccionado = TipoVehiculoGeneral.Motocicleta;
            }
			else
			{
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El paquete supera el peso de cualquier tipo de vehículo.");
                Console.ResetColor();
            }
		}

		internal double CalcularTarifaVehiculoGeneral(double distanciaRecorrer)
		{
			if (VehiculoSeleccionado == TipoVehiculoGeneral.Bicicleta)
			{
                return (distanciaRecorrer * 0.75);
            }
			else if (VehiculoSeleccionado == TipoVehiculoGeneral.Motocicleta)
			{
                return (distanciaRecorrer * 1.50);
            }
			else
			{
                return (distanciaRecorrer * 2.50);
            }
		}

		internal double CalcularTarifaEntrega(Paquete paqueteEntrega, double distanciaRecorrer)
		{
			SeleccionarVehiculoGeneral(paqueteEntrega);
			return CalcularTarifaVehiculoGeneral(distanciaRecorrer) + paqueteEntrega.CalcularCostoTipo(paqueteEntrega.ValorDeclarado, paqueteEntrega.Peso) + CalcularTarifaServicio();
		}

		internal void IngresarIncidente(Incidente incidente)
		{
			string nuevoCodigo = GoXelaDelivery.CodigoUnico.GenerarCodigoUnico(incidente.Prefijo);
            incidente.CodigoUnico = nuevoCodigo;
            listaIncidentes.Add(incidente);
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
			get { return vehiculoGeneral; }
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

		public Cliente ClienteEntrega
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
