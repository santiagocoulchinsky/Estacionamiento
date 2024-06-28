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
        ClienteController clienteController = new ClienteController();
        public void ListarVehiculos()
        {
            var vehiculos = vehiculoController.ObtenerTodos();

            Console.WriteLine("\n Vehículos cargados:");
            Console.WriteLine();
            foreach (var item in vehiculos)
            {
                //var clientes = clienteController.ObtenerClientes();
                //foreach (var item2 in clientes)
                Console.WriteLine($" > Coche: {item.Patente} - {item.Marca} {item.Modelo} - De: {item.Cliente.Nombre}");
                Console.WriteLine("---------------------------------");
            }
            Console.WriteLine();
        }

        public void CrearVehiculo()
        {


            Console.Write("Pertenece a cliente nro: ");
            int n = int.Parse(Console.ReadLine());

            using (var context = new AppDbContext())
            {
                Cliente client = context.Clientes
                    .Where(x=> x.Id == n)
                    .First();
                if (client != null)
                {
                    var VehiculoCargar = new Vehiculo();
                    
                    Console.Write("Marca: ");
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

