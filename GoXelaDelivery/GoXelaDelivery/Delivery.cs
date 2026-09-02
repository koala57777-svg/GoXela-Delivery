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
            Console.WriteLine();
            if (listasPaquetes[0] == null || listasPaquetes[0].Count == 0)
            {
                Console.Write("Hay ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("0 ");
                Console.ResetColor();
                Console.Write("Paquetes de tipo Documento");
            }
            else if (listasPaquetes[0].Count == 1)
            {
                Console.Write("Hay ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{listasPaquetes[0].Count} ");
                Console.ResetColor();
                Console.Write("Paquete de tipo Documento");
            }
            else
            {
                Console.Write("Hay ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{listasPaquetes[0].Count} ");
                Console.ResetColor();
                Console.Write("Paquetes de tipo Documento");
            }
            if (listasPaquetes[1] == null || listasPaquetes[1].Count == 0)
            {
                Console.Write("Hay ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("0 ");
                Console.ResetColor();
                Console.Write("Paquetes de tipo Documento");
            }
            else if (listasPaquetes[1].Count == 1)
            {
                Console.Write("Hay ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{listasPaquetes[1].Count} ");
                Console.ResetColor();
                Console.Write("Paquete de tipo Estándar");
            }
            else
            {
                Console.Write("Hay ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{listasPaquetes[1].Count} ");
                Console.ResetColor();
                Console.Write("Paquetes de tipo Estándar");
            }
            if (listasPaquetes[2] == null || listasPaquetes[2].Count == 0)
            {
                Console.Write("Hay ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("0 ");
                Console.ResetColor();
                Console.Write("Paquetes de tipo Frágil");
            }
            else if (listasPaquetes[2].Count == 1)
            {
                Console.Write("Hay ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{listasPaquetes[2].Count} ");
                Console.ResetColor();
                Console.Write("Paquete de tipo Frágil");
            }
            else
            {
                Console.Write("Hay ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{listasPaquetes[2].Count} ");
                Console.ResetColor();
                Console.Write("Paquetes de tipo Frágil");
            }
            if (listasPaquetes[3] == null || listasPaquetes[3].Count == 0)
            {
                Console.Write("Hay ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("0 ");
                Console.ResetColor();
                Console.Write("Paquetes de tipo Producto Refrigerado");
            }
            else if (listasPaquetes[3].Count == 1)
            {
                Console.Write("Hay ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{listasPaquetes[3].Count} ");
                Console.ResetColor();
                Console.Write("Paquete de tipo Producto Refrigerado");
            }
            else
            {
                Console.Write("Hay ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{listasPaquetes[3].Count} ");
                Console.ResetColor();
                Console.Write("Paquetes de tipo Producto Refrigerado");
            }
            LimpiarConsola();
        }

        protected void MostrarTotalIngresos()
        {
            Console.WriteLine();
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("Total de Ingresos Generado: Q" + TotalIngresos);
            Console.ResetColor();
            LimpiarConsola();
        }

        protected void MostrarEntregaConMayorCosto()
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
                EntregasFinalizadas = listaEntregas.Where(entrega => entrega.EstadoEntrega == EstadoEntrega.Entregada).ToList();
                MayorCostoDeEntrega = EntregasFinalizadas.Max(entrega => entrega.Total);
                EntregaConMayorCosto = EntregasFinalizadas.Where(entrega => entrega.Total == MayorCostoDeEntrega).ToList();
                if (MayorCostoDeEntrega == 0 || EntregasFinalizadas.Count == 0 || EntregasFinalizadas == null)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No hay ninguna Entrega con el Mayor Costo");
                    Console.ResetColor();
                }
                else
                {
                    if (EntregasFinalizadas.Count == 1)
                    {
                        LaEntrega = EntregasFinalizadas.First();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("La Entrega con Mayor Costo es: ");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        LaEntrega.MostrarInformacion();
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("(Empate) Las Entregas con Mayor Costo son: ");
                        Console.ResetColor();
                        foreach (Entrega entrega in EntregasFinalizadas)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            entrega.MostrarInformacion();
                            Console.ResetColor();
                            Console.WriteLine();
                        }
                    }
                }
            }
            LimpiarConsola();
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
