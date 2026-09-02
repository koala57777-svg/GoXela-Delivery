using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoXelaDelivery.Enums;
using static GoXelaDelivery.Globales;

namespace GoXelaDelivery
{
    internal class Delivery
    {
        private List<Cliente> listaClientes = new List<Cliente>();

        private List<Repartidor> listaRepartidores = new List<Repartidor>();

        private List<List<Vehiculo>> listasVehiculos = new List<List<Vehiculo>>();

        private List<List<Paquete>> listasPaquetes = new List<List<Paquete>>();

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
            if (listaEntregas.Count == 0 || listaEntregas == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No hay ninguna Entrega Registrada");
                Console.ResetColor();
            }
            else
            {
                foreach (Entrega entrega in ListaEntregas)
                {
                    if (entrega.EstadoEntrega == EstadoEntrega.Cofirmado || entrega.EstadoEntrega == EstadoEntrega.EnRuta)
                    {
                        ContadorEntregasActivas += 1;
                    }
                }
                Console.WriteLine();
                if (ContadorEntregasActivas == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No hay ninguna Entrega Activa por el momento");
                    Console.ResetColor();
                }
                else if (ContadorEntregasActivas == 1)
                {
                    Console.Write("Hay ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{ContadorEntregasActivas} ");
                    Console.ResetColor();
                    Console.Write("Entrega Activa");
                }
                else
                {
                    Console.Write("Hay ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{ContadorEntregasActivas} ");
                    Console.ResetColor();
                    Console.Write("Entregas Activas");
                }
            }
            LimpiarConsola();
        }

        protected void MostrarEntregasFinalizadas()
        {
            if (listaEntregas.Count == 0 || listaEntregas == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No hay ninguna Entrega Registrada");
                Console.ResetColor();
            }
            else
            {
                foreach (Entrega entrega in ListaEntregas)
                {
                    if (entrega.EstadoEntrega == EstadoEntrega.Entregada)
                    {
                        ContadorEntregasFinalizadas += 1;
                    }
                }
                Console.WriteLine();
                if (ContadorEntregasFinalizadas == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No hay ninguna Entrega Finalizada por el momento");
                    Console.ResetColor();
                }
                else if (ContadorEntregasFinalizadas == 1)
                {
                    Console.Write("Hay ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{ContadorEntregasFinalizadas} ");
                    Console.ResetColor();
                    Console.Write("Entrega Finalizada");
                }
                else
                {
                    Console.Write("Hay ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{ContadorEntregasFinalizadas} ");
                    Console.ResetColor();
                    Console.Write("Entregas Finalizadas");
                }
            }
            LimpiarConsola();
        }

        protected void MostrarEntregasCanceladas()
        {
            if (listaEntregas.Count == 0 || listaEntregas == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No hay ninguna Entrega Registrada");
                Console.ResetColor();
            }
            else
            {
                foreach (Entrega entrega in ListaEntregas)
                {
                    if (entrega.EstadoEntrega == EstadoEntrega.Cancelada)
                    {
                        ContadorEntregasCanceladas += 1;
                    }
                }
                Console.WriteLine();
                if (ContadorEntregasCanceladas == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No hay ninguna Entrega Cancelada por el momento");
                    Console.ResetColor();
                }
                else if (ContadorEntregasCanceladas == 1)
                {
                    Console.Write("Hay ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{ContadorEntregasCanceladas} ");
                    Console.ResetColor();
                    Console.Write("Entrega Cancelada");
                }
                else
                {
                    Console.Write("Hay ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{ContadorEntregasCanceladas} ");
                    Console.ResetColor();
                    Console.Write("Entregas Canceladas");
                }
            }
            LimpiarConsola();
        }

        protected void MostrarEntregasConIncidencias()
        {
            if (listaEntregas.Count == 0 || listaEntregas == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No hay ninguna Entrega Registrada");
                Console.ResetColor();
            }
            else
            {
                foreach (Entrega entrega in ListaEntregas)
                {
                    if (entrega.ListaIncidentes.Count > 0)
                    {
                        ContadorEntregasConIncidentes += 1;
                    }
                }
                Console.WriteLine();
                if (ContadorEntregasConIncidentes == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No hay ninguna Entrega con Incidentes por el momento");
                    Console.ResetColor();
                }
                else if (ContadorEntregasConIncidentes == 1)
                {
                    Console.Write("Hay ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{ContadorEntregasConIncidentes} ");
                    Console.ResetColor();
                    Console.Write("Entrega con Incidente");
                }
                else
                {
                    Console.Write("Hay ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{ContadorEntregasConIncidentes} ");
                    Console.ResetColor();
                    Console.Write("Entregas con Incidentes");
                }
            }
            LimpiarConsola();
        }

        protected void MostrarRepartidoresDisponibles()
        {
            if (listaRepartidores.Count == 0 || listaRepartidores == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No hay ningún Repartidor Registrado");
                Console.ResetColor();
            }
            else
            {
                foreach (Repartidor repartidor in ListaRepartidores)
                {
                    if (repartidor.EstadoDisponibilidad == EstadoRepartidor.Disponible)
                    {
                        ContadorRepartidoresDisponibles += 1;
                    }
                }
                Console.WriteLine();
                if (ContadorRepartidoresDisponibles == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No hay ningun Repartidor Disponible por el momento");
                    Console.ResetColor();
                }
                else if (ContadorRepartidoresDisponibles == 1)
                {
                    Console.Write("Hay ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{ContadorRepartidoresDisponibles} ");
                    Console.ResetColor();
                    Console.Write("Repartidor Disponible");
                }
                else
                {
                    Console.Write("Hay ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{ContadorRepartidoresDisponibles} ");
                    Console.ResetColor();
                    Console.Write("Repartidores Disponibles");
                }
            }
            LimpiarConsola();
        }

        protected void MostrarRepartidorConMasEntregas()
        {
            if (listaRepartidores.Count == 0 || listaRepartidores == null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No hay ningún Repartidor Registrado");
                Console.ResetColor();
            }
            else
            {
                EntregasMaximas = listaRepartidores.Max(repartidor => repartidor.CantidadEntregasRealizadas);
                RepartidorConMasEntregas = listaRepartidores.Where(repartidor => repartidor.CantidadEntregasRealizadas == EntregasMaximas).ToList();
                if (EntregasMaximas == 0 || RepartidorConMasEntregas.Count == 0 || RepartidorConMasEntregas == null)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No hay ningún Repartidor con las Máximas Entregas");
                    Console.ResetColor();
                }
                else
                {
                    if (RepartidorConMasEntregas.Count == 1)
                    {
                        ElRepartidor = listaRepartidores.First();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("El Repartidor con Más Entregas es: ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        ElRepartidor.MostrarInformacion();
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("(Empate) Los Repartidores con Más Entregas son: ");
                        Console.ResetColor();
                        foreach (Repartidor repartidor in RepartidorConMasEntregas)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            repartidor.MostrarInformacion();
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                    }
                }
            }
            LimpiarConsola();
        }

        protected void MostrarVehiculoMasUsado()
        {
            if ((listasVehiculos[0].Count == 0 && listasVehiculos[1].Count == 0 && listasVehiculos[2].Count == 0) || (listasVehiculos[0] == null && listasVehiculos[1] == null && listasVehiculos[2] == null))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No hay ningún Vehículo Registrado");
                Console.ResetColor();
            }
            else
            {
                foreach (List<Vehiculo> listaVehiculo in listasVehiculos)
                {
                    if (listaVehiculo.Count > 0 || listaVehiculo != null)
                    {
                        TiposDeVehiculosNoVacios.Add(listaVehiculo);
                    }
                }
                CantidadMaximaUsosVehiculo = TiposDeVehiculosNoVacios.SelectMany(TodosLosVehiculos => TodosLosVehiculos).Max(vehiculo => vehiculo.EntregasRealizadas);
                VehiculoMasUsado = TiposDeVehiculosNoVacios.SelectMany(TodosLosVehiculos => TodosLosVehiculos).Where(vehiculo => vehiculo.EntregasRealizadas == CantidadMaximaUsosVehiculo).ToList();
                if (CantidadMaximaUsosVehiculo == 0 || VehiculoMasUsado.Count == 0 || VehiculoMasUsado == null)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No hay ningún Vehículo Más Usado");
                    Console.ResetColor();
                }
                else
                {
                    if (VehiculoMasUsado.Count == 1)
                    {
                        ElVehiculo = VehiculoMasUsado.First();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("El Vehículo Más Usado es: ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        ElVehiculo.MostarInformacion();
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("(Empate) Los Vehículos Más Usados son: ");
                        Console.ResetColor();
                        foreach (Vehiculo vehiculo in VehiculoMasUsado)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            vehiculo.MostarInformacion();
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                    }
                }
            }
            LimpiarConsola();
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
            get { return listaEntregas; }
            set { listaEntregas = value; }
        }

        public List<List<Paquete>> ListasPaquetes
        {
            get { return listasPaquetes; }
            set { listasPaquetes = value; }
        }

        public List<List<Vehiculo>> ListaVehiculos
        {
            get { return listasVehiculos; }
            set { listasVehiculos = value; }
        }

        public List<Repartidor> ListaRepartidores
        {
            get { return listaRepartidores; }
            set { listaRepartidores = value; }
        }

        public List<Cliente> ListaClientes
        {
            get { return listaClientes; }
            set { listaClientes = value; }
        }
    }
}
