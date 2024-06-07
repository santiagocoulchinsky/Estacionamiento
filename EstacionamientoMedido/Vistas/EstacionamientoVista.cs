using EstacionamientoMedido.Controladores;
using EstacionamientoMedido.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Vistas
{
    public class EstacionamientoVista
    {
        VehiculoController controladorVehiculo = new VehiculoController();
        VehiculoVista vistaVehiculo = new VehiculoVista();
        PlazaVista vistaPlaza = new PlazaVista();
        EstacionamientoController controladorEstacionamiento = new EstacionamientoController();
        PlazaController controladorPlaza = new PlazaController();

        public void IniciarEstacionamiento()
        {
            Console.WriteLine();
            Console.Write("Ingrese patente de entrada: ");
            string patente = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Ingrese plaza: ");
            string plaza = Console.ReadLine();


            if ((!controladorPlaza.PlazaOcupada(plaza)) && (controladorPlaza.ExistePlaza(plaza)))
            {
                controladorPlaza.AsignaPlaza(plaza);

                if (!controladorVehiculo.ExistePatente(patente))
                {

                    vistaVehiculo.CrearVehiculo();
                   
                }

                if (!controladorEstacionamiento.YaEstaEstacionado(patente))
                {

                    controladorEstacionamiento.IniciarEstacionamiento(patente, plaza);
                    
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Ya hay un vehiculo estacionado con esta patente");
                    Console.WriteLine();
                }

                

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Elija una plaza disponible, o cree una nueva.");
                Console.WriteLine();
            }

        }

        public void FinalizarEstacionamiento()
        {
            Console.WriteLine();
            Console.Write("Ingrese patente de salida: ");
            string patente = Console.ReadLine();

            controladorEstacionamiento.FinalizarEstacionamiento(patente);
        }

        public void VerEstacionamientos()
        {
            List<Estacionamiento> estacionamientos = controladorEstacionamiento.ObtenerTodos();
            //List<PlazaEstacionamiento> Plazas = controladorPlaza.ObtenerPlazas();

            if (estacionamientos.Count == 0)
            {
                Console.WriteLine("\nNo hay estacionamientos iniciados.");
            }
            else
            {
                foreach (var item in estacionamientos)
                {
                    if (item.Estado == Enumeraciones.EstadoEstacionamiento.Activo)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n > {item.VehiculoEstacionado.Patente} - {item.Entrada} - {item.VehiculoEstacionado.Modelo} - {item.Plaza.Nombre}");

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n > {item.VehiculoEstacionado.Patente} - {item.Entrada} / {item.Salida}");
                    }

                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                //foreach (var item in Plazas)
                //{
                //    //if (item.EstadoPlaza == Enumeraciones.EstadoPlaza.ocupada)
                //    {
                //        Console.ForegroundColor = ConsoleColor.Green;
                //        Console.WriteLine($" > {item.Nombre}");
                //    }
                    
                //}
            }
        }
        public void VerEstacionamiento()
        {
            Console.WriteLine();
            Console.Write("Ingrese patente: ");
            string patente = Console.ReadLine();

            List<Estacionamiento> estacionamientos = controladorEstacionamiento.ObtenerEstacionamientosPorPatente(patente);

            if (controladorVehiculo.ExistePatente(patente))
            {
                foreach (var item in estacionamientos)
                {
                    if (item.Estado == Enumeraciones.EstadoEstacionamiento.Activo)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n > {item.VehiculoEstacionado.Patente} - {item.Entrada} - {item.Plaza.Nombre}");

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n > {item.VehiculoEstacionado.Patente} - {item.Entrada} / {item.Salida}");
                    }
                }
                
            }
            else
            {
                Console.WriteLine("\nNo hay estacionamientos iniciados con esa patente.");
            }
            //else
            //{
            //    foreach (var item in estacionamientos)
            //    {
            //        if (item.Estado == Enumeraciones.EstadoEstacionamiento.Activo)
            //        {
            //            Console.ForegroundColor = ConsoleColor.Green;
            //            Console.WriteLine($" > {item.VehiculoEstacionado.Patente} - {item.Entrada}");

            //        }
            //        else
            //        {
            //            Console.ForegroundColor = ConsoleColor.Red;
            //            Console.WriteLine($" > {item.VehiculoEstacionado.Patente} - {item.Entrada} / {item.Salida}");
            //        }

            //        Console.ForegroundColor = ConsoleColor.Gray;
            //    }
            //}
        }
    }
}