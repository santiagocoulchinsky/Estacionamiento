using EstacionamientoMedido.Controladores;
using EstacionamientoMedido.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Vistas
{
    internal class PlazaVista
    {
        PlazaController plazaController = new PlazaController();
        public void ListarPlazas()
        {
            var plazas = plazaController.ObtenerPlazas();

            Console.WriteLine(" Plazas cargadas:");
            Console.WriteLine();
            foreach (var item in plazas)
            {
                Console.WriteLine($" > Plaza {item.Nombre}");
                Console.WriteLine("---------------------------");
            }
            Console.WriteLine();
        }
        public void AsignarPlaza()
        {
            PlazaEstacionamiento PlazaCargar = new PlazaEstacionamiento();
            Console.Write("Nombre plaza: ");
            PlazaCargar.Nombre = Console.ReadLine();

            plazaController.GuardarPlaza(PlazaCargar);
        }
        
    }
}
