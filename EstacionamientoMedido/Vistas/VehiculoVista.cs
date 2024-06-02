using EstacionamientoMedido.Controladores;
using EstacionamientoMedido.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Vistas
{
    public class VehiculoVista
    {
        VehiculoController vehiculoController = new VehiculoController();

        public void ListarVehiculos()
        {
            var vehiculos = vehiculoController.ObtenerTodos();

            Console.WriteLine("\n Vehículos cargados:");
            Console.WriteLine();
            foreach (var item in vehiculos)
            {
                Console.WriteLine($" > Coche: {item.Patente} - {item.Marca} {item.Modelo}");
                Console.WriteLine("---------------------------------");
            }
            Console.WriteLine();
        }

        public void CrearVehiculo()
        {
            Vehiculo VehiculoCargar = new Vehiculo();

            Console.Write("Marca: ");
            VehiculoCargar.Marca = Console.ReadLine();
            Console.Write("Patente: ");
            VehiculoCargar.Patente = Console.ReadLine();
            Console.Write("Color: ");
            VehiculoCargar.Color = Console.ReadLine();
            Console.Write("Modelo: ");
            VehiculoCargar.Modelo = Console.ReadLine();

            vehiculoController.GuardarVehiculo(VehiculoCargar);
        }
    }
}
