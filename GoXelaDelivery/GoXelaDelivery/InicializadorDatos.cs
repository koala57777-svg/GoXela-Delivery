namespace GoXelaDelivery
{
    internal static class InicializadorDatos
    {
        public static void CargarDatosPrueba(Delivery delivery)
        {
            Cliente cliente1 = new Cliente("Carlos Mendoza", 77612345, "carlos@gmail.com", "Zona 3, Quetzaltenango", Municipio.Quetzaltenango);
            Cliente cliente2 = new Cliente("Ana Lucia Ramos", 77654321, "ana.ramos@gmail.com", "Zona 1, Salcajá", Municipio.Salcaja);
            Cliente cliente3 = new Cliente("Mario Lopez", 55443322, "mario@gmail.com", "Centro, Almolonga", Municipio.Almolonga);
            Cliente cliente4 = new Cliente("Sofia Morales", 44331122, "sofia.morales@gmail.com", "Cantón Chuisuc, Cantel", Municipio.Cantel);
            Cliente cliente5 = new Cliente("Diego Estrada", 55118899, "diego.estrada@gmail.com", "Zona 2, Olintepeque", Municipio.Olintepeque);

            cliente4.SolicitudesRealizadas = 12;

            delivery.IngresarCliente(cliente1);
            delivery.IngresarCliente(cliente2);
            delivery.IngresarCliente(cliente3);
            delivery.IngresarCliente(cliente4);
            delivery.IngresarCliente(cliente5);

            Repartidor repBicicleta = new Repartidor("Luis Gomez", 44332211, 10101, Enums.TipoLicencia.B, Enums.EstadoRepartidor.Disponible);
            Repartidor repMoto = new Repartidor("Jorge Morales", 55667788, 20202, Enums.TipoLicencia.M, Enums.EstadoRepartidor.Disponible);
            Repartidor repCarro = new Repartidor("Pedro Hernandez", 33221100, 30303, Enums.TipoLicencia.C, Enums.EstadoRepartidor.Disponible);
            Repartidor repMoto2 = new Repartidor("Manuel Castillo", 55441133, 40404, Enums.TipoLicencia.M, Enums.EstadoRepartidor.Disponible);
            Repartidor repCarro2 = new Repartidor("Fernando Ruano", 44889900, 50505, Enums.TipoLicencia.C, Enums.EstadoRepartidor.FueraDeServicio);

            delivery.IngresarRepartidor(repBicicleta);
            delivery.IngresarRepartidor(repMoto);
            delivery.IngresarRepartidor(repCarro);
            delivery.IngresarRepartidor(repMoto2);
            delivery.IngresarRepartidor(repCarro2);

            Bicicleta bici = new Bicicleta("N/A", "Trek", 2022, Enums.EstadoVehiculo.Disponible, Enums.TipoVehiculo.Bicicleta, Enums.TipoEspecializacion.Estandar);
            Motocicleta moto = new Motocicleta("M-102XYZ", "Honda", 2023, Enums.EstadoVehiculo.Disponible, Enums.TipoVehiculo.Motocicleta, Enums.TipoEspecializacion.Acolchado);
            Carro carro = new Carro("P-554ABC", "Toyota", 2021, Enums.EstadoVehiculo.Disponible, Enums.TipoVehiculo.Automovil, Enums.TipoEspecializacion.Refrigerado);
            Motocicleta moto2 = new Motocicleta("M-889QWE", "Yamaha", 2024, Enums.EstadoVehiculo.Disponible, Enums.TipoVehiculo.Motocicleta, Enums.TipoEspecializacion.Asegurado);
            Carro carro2 = new Carro("P-332LKJ", "Nissan", 2020, Enums.EstadoVehiculo.EnMantenimiento, Enums.TipoVehiculo.Automovil, Enums.TipoEspecializacion.Estandar);

            delivery.IngresarVehiculo(bici);
            delivery.IngresarVehiculo(moto);
            delivery.IngresarVehiculo(carro);
            delivery.IngresarVehiculo(moto2);
            delivery.IngresarVehiculo(carro2);

            PaqueteEstandar paqEstandar = new PaqueteEstandar(Enums.TipoPaquete.Estandar, "Ropa y calzado", 5, 250, cliente1, "Zona 1, Quetzaltenango", Municipio.Quetzaltenango);
            PaqueteFragil paqFragil = new PaqueteFragil(Enums.TipoPaquete.Fragil, "Vajilla de ceramica", 12, 600, cliente2, "Zona 3, Quetzaltenango", Municipio.Quetzaltenango);
            ProductoRefrigerado paqRefri = new ProductoRefrigerado(Enums.TipoPaquete.ProductoRefrigerado, "Medicamentos termicos", 30, 1500, cliente3, "Zona 1, Salcajá", Municipio.Salcaja);
            Documento paqDoc = new Documento(Enums.TipoPaquete.Documento, "Escrituras notariales", 1, 500, cliente4, "Zona 1, Quetzaltenango", Municipio.Quetzaltenango);
            PaqueteEstandar paqEstandar2 = new PaqueteEstandar(Enums.TipoPaquete.Estandar, "Libros de texto", 8, 300, cliente5, "Centro, Cantel", Municipio.Cantel);
            PaqueteFragil paqFragil2 = new PaqueteFragil(Enums.TipoPaquete.Fragil, "Lámparas decorativas", 10, 850, cliente1, "Zona 1, Olintepeque", Municipio.Olintepeque);

            delivery.IngresarPaquete(paqEstandar);
            delivery.IngresarPaquete(paqFragil);
            delivery.IngresarPaquete(paqRefri);
            delivery.IngresarPaquete(paqDoc);
            delivery.IngresarPaquete(paqEstandar2);
            delivery.IngresarPaquete(paqFragil2);

            double dist1 = GestorDistancias.ObtenerDistancia(paqEstandar.MunicipioOrigen, paqEstandar.MunicipioDestino);
            Globales.ServicioSeleccionado = Enums.TipoServicio.Normal;
            Entrega entrega1 = new Entrega(paqEstandar, Enums.TipoVehiculoGeneral.Bicicleta, dist1, Enums.TipoServicio.Normal, 0);
            entrega1.ClienteEntrega = cliente1;
            entrega1.TarifaBase = entrega1.CalcularTarifaEntrega(paqEstandar, dist1);
            entrega1.VehiculoGeneral = Enums.TipoVehiculoGeneral.Bicicleta;
            paqEstandar.EstadoPaquete = Enums.EstadoPaquete.Asignado;
            cliente1.SolicitudesRealizadas++;
            delivery.IngresarEntrega(entrega1);

            double dist2 = GestorDistancias.ObtenerDistancia(paqFragil.MunicipioOrigen, paqFragil.MunicipioDestino);
            Globales.ServicioSeleccionado = Enums.TipoServicio.Prioritario;
            Entrega entrega2 = new Entrega(paqFragil, Enums.TipoVehiculoGeneral.Motocicleta, dist2, Enums.TipoServicio.Prioritario, 0);
            entrega2.ClienteEntrega = cliente2;
            entrega2.TarifaBase = entrega2.CalcularTarifaEntrega(paqFragil, dist2);
            entrega2.VehiculoGeneral = Enums.TipoVehiculoGeneral.Motocicleta;
            paqFragil.EstadoPaquete = Enums.EstadoPaquete.Asignado;
            cliente2.SolicitudesRealizadas++;
            entrega2.RepartidorAsignado = repMoto;
            entrega2.VehiculoAsigando = moto;
            moto.RepartidorAsignado = repMoto;
            repMoto.EstadoDisponibilidad = Enums.EstadoRepartidor.Asignado;
            moto.EstadoVehiculo = Enums.EstadoVehiculo.Asignado;
            entrega2.EstadoEntrega = Enums.EstadoEntrega.Cofirmado;
            entrega2.CalcularTotalEntregaConfirmada(entrega2);
            delivery.IngresarEntrega(entrega2);

            double dist3 = GestorDistancias.ObtenerDistancia(paqRefri.MunicipioOrigen, paqRefri.MunicipioDestino);
            Globales.ServicioSeleccionado = Enums.TipoServicio.Urgente;
            Entrega entrega3 = new Entrega(paqRefri, Enums.TipoVehiculoGeneral.Automovil, dist3, Enums.TipoServicio.Urgente, 0);
            entrega3.ClienteEntrega = cliente3;
            entrega3.TarifaBase = entrega3.CalcularTarifaEntrega(paqRefri, dist3);
            entrega3.VehiculoGeneral = Enums.TipoVehiculoGeneral.Automovil;
            paqRefri.EstadoPaquete = Enums.EstadoPaquete.Asignado;
            cliente3.SolicitudesRealizadas++;
            entrega3.RepartidorAsignado = repCarro;
            entrega3.VehiculoAsigando = carro;
            carro.RepartidorAsignado = repCarro;
            entrega3.EstadoEntrega = Enums.EstadoEntrega.Entregada;
            entrega3.CalcularTotalEntregaConfirmada(entrega3);
            repCarro.CantidadEntregasRealizadas++;
            repCarro.CalificacionTotal += 5.0;
            repCarro.CalificacionPromedio = 5.0;
            carro.EntregasRealizadas++;
            delivery.TotalIngresos += entrega3.Total;
            delivery.IngresarEntrega(entrega3);

            double dist4 = GestorDistancias.ObtenerDistancia(paqDoc.MunicipioOrigen, paqDoc.MunicipioDestino);
            Globales.ServicioSeleccionado = Enums.TipoServicio.Normal;
            Entrega entrega4 = new Entrega(paqDoc, Enums.TipoVehiculoGeneral.Motocicleta, dist4, Enums.TipoServicio.Normal, 0);
            entrega4.ClienteEntrega = cliente4;
            entrega4.TarifaBase = entrega4.CalcularTarifaEntrega(paqDoc, dist4);
            entrega4.VehiculoGeneral = Enums.TipoVehiculoGeneral.Motocicleta;
            paqDoc.EstadoPaquete = Enums.EstadoPaquete.Asignado;
            cliente4.SolicitudesRealizadas++;
            entrega4.RepartidorAsignado = repMoto2;
            entrega4.VehiculoAsigando = moto2;
            moto2.RepartidorAsignado = repMoto2;
            entrega4.EstadoEntrega = Enums.EstadoEntrega.EnRuta;
            entrega4.CalcularTotalEntregaConfirmada(entrega4);
            delivery.IngresarEntrega(entrega4);

            Incidente inc1 = new Incidente(Enums.TipoIncidencia.ProblemasClimaticos, "Fuerte lluvia impide el paso", entrega4);
            inc1.AccionTomada = "Esperar a que baje la intensidad";
            entrega4.AgregarIncidenteAEntrega(entrega4, inc1);

            double dist5 = GestorDistancias.ObtenerDistancia(paqEstandar2.MunicipioOrigen, paqEstandar2.MunicipioDestino);
            Globales.ServicioSeleccionado = Enums.TipoServicio.Normal;
            Entrega entrega5 = new Entrega(paqEstandar2, Enums.TipoVehiculoGeneral.Bicicleta, dist5, Enums.TipoServicio.Normal, 0);
            entrega5.ClienteEntrega = cliente5;
            entrega5.TarifaBase = entrega5.CalcularTarifaEntrega(paqEstandar2, dist5);
            entrega5.VehiculoGeneral = Enums.TipoVehiculoGeneral.Bicicleta;
            paqEstandar2.EstadoPaquete = Enums.EstadoPaquete.Asignado;
            cliente5.SolicitudesRealizadas++;
            entrega5.EstadoEntrega = Enums.EstadoEntrega.Cancelada;
            delivery.IngresarEntrega(entrega5);
        }
    }
}