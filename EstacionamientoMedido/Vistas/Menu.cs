using EstacionamientoMedido.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Vistas
{
    public class Menu
    {
        ClienteVista vistaCliente = new ClienteVista();
        VehiculoVista vistaVehiculo = new VehiculoVista();
        EstacionamientoVista vistaEstacionamiento = new EstacionamientoVista();
        PlazaVista vistaPlaza = new PlazaVista();

        public void MostrarMenu()
        {
            int eleccion;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1- Iniciar estacionamiento");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("2- Terminar estacionamiento");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------");
            Console.WriteLine("3- Cargar un cliente");
            Console.WriteLine("4- Cargar Nueva Plaza");
            Console.WriteLine("5- Ver clientes registrados");
            Console.WriteLine("---------------------------");
            Console.WriteLine("6- Cargar Vehiculo");
            Console.WriteLine("7- Ver vehiculos y plazas cargadas");
            Console.WriteLine("8- Ver estacionamientos");
            Console.WriteLine("9- Ver estacionamiento por patente");
            
            Console.WriteLine("---------------------------");
            Console.WriteLine("10- Salir");
            Console.WriteLine();
            Console.Write("Opcion: ");
            eleccion = int.Parse(Console.ReadLine());

            switch (eleccion)
            {
                case 1:
                    Console.WriteLine();
                    vistaEstacionamiento.IniciarEstacionamiento();

                    Console.WriteLine();
                    MostrarMenu();

                    break;

                case 2:

                    vistaEstacionamiento.FinalizarEstacionamiento();
                    Console.WriteLine();
                    MostrarMenu();

                    break;

                case 3:

                    vistaCliente.CargarDatosCliente();

                    Console.WriteLine();
                    MostrarMenu();

                    break;

                case 4:
                    vistaPlaza.AsignarPlaza();
                    Console.WriteLine();
                    MostrarMenu();
                    break;


                case 5:

                    vistaCliente.MostrarClientesRegistrados();

                    Console.WriteLine();
                    MostrarMenu();
                    break;

                case 6:
                    vistaVehiculo.CrearVehiculo();
                    Console.WriteLine();
                    MostrarMenu();

                    break;

                case 7:
                    vistaVehiculo.ListarVehiculos();
                    vistaPlaza.ListarPlazas();
                    Console.WriteLine();
                    MostrarMenu();
                    break;

                case 8: // ver estacionmaientos
                    vistaEstacionamiento.VerEstacionamientos();
                    Console.WriteLine();
                    MostrarMenu();
                    break;

                case 9: //ver estacionamiento por patente
                    //vistaEstacionamiento.VerEstacionamiento();
                    Console.WriteLine();
                    MostrarMenu();
                    break;

                case 10:
                    Environment.Exit(0);
                    break;

                default:
                    Console.Clear();
                    MostrarMenu();
                    break;
            }
        }
    }
}