using EstacionamientoMedido.Enumeraciones;
using EstacionamientoMedido.Helpers;
using EstacionamientoMedido.Modelos;
using EstacionamientoMedido.Validaciones;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Controladores
{
    public class VehiculoController
    {
        //Repositorio repo = Repositorio.ObtenerInstancia();

        public bool ExistePatente(string patente)
        {
            

            bool resultado;
            using (AppDbContext context = new AppDbContext())
            {
                resultado = context.Set<Vehiculo>()
                    .Any(x => x.Patente == patente);
            }

            return resultado;

            //bool resultado;

            //resultado = repo.Vehiculos.Any(x=> x.Patente == patente);
            //resultado = repo.Vehiculos.Where(x => x.Patente == patente).Any();

            //return resultado;
        }

        public void GuardarVehiculo(Vehiculo v)
        {
            VehiculoValidator valida = new VehiculoValidator();

            ValidationResult resultadoValidacion = valida.Validate(v);

            if (resultadoValidacion.IsValid)
            {
                using (AppDbContext context = new AppDbContext())
                {
                    
                    context.Database.EnsureCreated();

                    context.Set<Vehiculo>().Add(v);
                    context.SaveChanges();
                }

                //repo.Vehiculos.Add(v);
            }
            else
            {
                foreach (var item in resultadoValidacion.Errors)
                {
                    Console.WriteLine(item.ErrorMessage);
                }
            }

        }

        public List<Vehiculo> ObtenerTodos()
        {
            List<Vehiculo> vehiculos;
            using (AppDbContext context = new AppDbContext())
            {
                vehiculos = context.Set<Vehiculo>()
                    .Include(x=>x.Cliente)
                    .ToList();

                
            }
            return vehiculos;
            //return repo.Vehiculos;
        }

        //public Vehiculo Modificar(Vehiculo v)
        //{
        //    Vehiculo vehiculoBorrar = repo.Vehiculos.Find(x => x.Patente == v.Patente);

        //    repo.Vehiculos.Remove(vehiculoBorrar);

        //    repo.Vehiculos.Add(v);

        //    return v;
        //}

        //public void Eliminar(Vehiculo c)
        //{
        //    Vehiculo vehiculoAEliminar = repo.Vehiculos.Find(x => x.Patente == c.Patente);

        //    repo.Vehiculos.Remove(vehiculoAEliminar);
        //}

        public Vehiculo ObtenerVehiculoPorPatente(string patente)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Vehiculo vehiculoBuscado = context.Set<Vehiculo>()
                    .Where(x=> x.Patente == patente)
                    .First();

                return vehiculoBuscado;
            }


            //Vehiculo vehiculoBuscado = repo.Vehiculos.Where(x => x.Patente == patente).FirstOrDefault();

            // Esto es sin usar LinQ
            //Vehiculo vehiculoBuscado = repo.Vehiculos.Find(x => x.Patente == patente);

            //return vehiculoBuscado;

        }
    }
}
