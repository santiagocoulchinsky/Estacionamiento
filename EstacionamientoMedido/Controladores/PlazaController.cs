using EstacionamientoMedido.Modelos;
using EstacionamientoMedido.Validaciones;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Controladores
{
    internal class PlazaController
    {
        Repositorio repo = Repositorio.ObtenerInstancia();

        public void GuardarPlaza(PlazaEstacionamiento v)
        {
            PlazaValidator valida = new PlazaValidator();

            ValidationResult resultadoValidacion = valida.Validate(v);

            if (resultadoValidacion.IsValid)
            {
                repo.PlazasEstacionamiento.Add(v);
            }
            else
            {
                foreach (var item in resultadoValidacion.Errors)
                {
                    Console.WriteLine(item.ErrorMessage);
                }
            }

        }
        


        public List<PlazaEstacionamiento> ObtenerPlazas()
        {
            return repo.PlazasEstacionamiento;
        }
        public PlazaEstacionamiento ObtenerPlazaPorNombre(string plaza)
        {
            // Esto es sin usar LinQ
            //Vehiculo vehiculoBuscado = repo.Vehiculos.Find(x => x.Patente == patente);

            PlazaEstacionamiento plazaBuscada = repo.PlazasEstacionamiento.Where(x => x.Nombre == plaza).FirstOrDefault();

            return plazaBuscada;
        }
    }
}
