namespace GoXelaDelivery
{
    internal static class InicializadorDatos
    {
        public static void CargarDatosPrueba(Delivery delivery)
        {

            Cliente cliente1 = new Cliente("Carlos Mendoza", 77612345, "carlos@gmail.com", "Zona 3, Quetzaltenango", Municipio.Quetzaltenango);
            Cliente cliente2 = new Cliente("Ana Lucia Ramos", 77654321, "ana.ramos@gmail.com", "Zona 1, Salcajá", Municipio.Salcaja);
            Cliente cliente3 = new Cliente("Mario Lopez", 55443322, "mario@gmail.com", "Centro, Almolonga", Municipio.Almolonga);

            delivery.IngresarCliente(cliente1);
            delivery.IngresarCliente(cliente2);
            delivery.IngresarCliente(cliente3);


            Repartidor repBicicleta = new Repartidor("Luis Gomez", 44332211, 10101, Enums.TipoLicencia.B, Enums.EstadoRepartidor.Disponible);
            Repartidor repMoto = new Repartidor("Jorge Morales", 55667788, 20202, Enums.TipoLicencia.M, Enums.EstadoRepartidor.Disponible);
            Repartidor repCarro = new Repartidor("Pedro Hernandez", 33221100, 30303, Enums.TipoLicencia.C, Enums.EstadoRepartidor.Disponible);

            delivery.IngresarRepartidor(repBicicleta);
            delivery.IngresarRepartidor(repMoto);
            delivery.IngresarRepartidor(repCarro);

            Bicicleta bici = new Bicicleta("N/A", "Trek", 2022, Enums.EstadoVehiculo.Disponible, Enums.TipoVehiculo.Bicicleta, Enums.TipoEspecializacion.Estandar);
            Motocicleta moto = new Motocicleta("M-102XYZ", "Honda", 2023, Enums.EstadoVehiculo.Disponible, Enums.TipoVehiculo.Motocicleta, Enums.TipoEspecializacion.Acolchado);
            Carro carro = new Carro("P-554ABC", "Toyota", 2021, Enums.EstadoVehiculo.Disponible, Enums.TipoVehiculo.Automovil, Enums.TipoEspecializacion.Refrigerado);

            delivery.IngresarVehiculo(bici);
            delivery.IngresarVehiculo(moto);
            delivery.IngresarVehiculo(carro);


            PaqueteEstandar paqEstandar = new PaqueteEstandar(Enums.TipoPaquete.Estandar, "Ropa y calzado", 5, 250, cliente1, "Zona 1, Quetzaltenango", Municipio.Quetzaltenango);
            PaqueteFragil paqFragil = new PaqueteFragil(Enums.TipoPaquete.Fragil, "Vajilla de ceramica", 12, 600, cliente2, "Zona 3, Quetzaltenango", Municipio.Quetzaltenango);
            ProductoRefrigerado paqRefri = new ProductoRefrigerado(Enums.TipoPaquete.ProductoRefrigerado, "Medicamentos termicos", 30, 1500, cliente3, "Zona 1, Salcajá", Municipio.Salcaja);

            delivery.IngresarPaquete(paqEstandar);
            delivery.IngresarPaquete(paqFragil);
            delivery.IngresarPaquete(paqRefri);
        }
    }
}