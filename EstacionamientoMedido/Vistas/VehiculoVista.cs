using EstacionamientoMedido.Controladores;
using EstacionamientoMedido.Modelos;
using Microsoft.EntityFrameworkCore;
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
                Console.WriteLine($" > Coche: {item.Patente} - {item.Marca} {item.Modelo} - De: {item.Cliente.Nombre}");
                Console.WriteLine("---------------------------------");
            }
            Console.WriteLine();
        }

        public void CrearVehiculo()
        {


            Console.Write("\nPertenece a cliente nro: ");
            int n = int.Parse(Console.ReadLine());

            using (var context = new AppDbContext())
            {
                Cliente client = context.Clientes
                    .Where(x=> x.Id == n)
                    .First();
                if (client != null)
                {
                    var VehiculoCargar = new Vehiculo();
                    
                    Console.Write("\nMarca: ");
                    VehiculoCargar.Marca = Console.ReadLine();
                    Console.Write("Patente: ");
                    VehiculoCargar.Patente = Console.ReadLine();
                    Console.Write("Color: ");
                    VehiculoCargar.Color = Console.ReadLine();
                    Console.Write("Modelo: ");
                    VehiculoCargar.Modelo = Console.ReadLine();
                    VehiculoCargar.ClienteId = client.Id;

                    //context.Vehiculos.Add(VehiculoCargar);
               

                    vehiculoController.GuardarVehiculo(VehiculoCargar);
                }
                else
                {
                    Console.WriteLine("El cliente no esta registrado");
                }

            }
        }
    }
}

