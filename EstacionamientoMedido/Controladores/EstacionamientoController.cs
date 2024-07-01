using EstacionamientoMedido.Modelos;
using EstacionamientoMedido.Enumeraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EstacionamientoMedido.Controladores
{
    public class EstacionamientoController
    {
        //Repositorio repo = Repositorio.ObtenerInstancia();
        VehiculoController controladorVehiculo = new VehiculoController();
        PlazaController controladorPlaza = new PlazaController();   
        private const int PrecioPorHora = 2000;
        public void IniciarEstacionamiento(string patente, string plaza)
        {
            Vehiculo vehiculo = controladorVehiculo.ObtenerVehiculoPorPatente(patente);
            PlazaEstacionamiento plaz = controladorPlaza.ObtenerPlazaPorNombre(plaza);

            Estacionamiento estacionamiento = new Estacionamiento(vehiculo, PrecioPorHora, plaz);

            using (AppDbContext context = new AppDbContext())
            {
                context.Database.EnsureCreated();
                context.Set<Estacionamiento>().Add(estacionamiento);
                context.SaveChanges();
            }

            //repo.Estacionamientos.Add(estacionamiento);
        }
        public Estacionamiento FinalizarEstacionamiento(string patente)
        {
            Estacionamiento salidaVehiculo = new Estacionamiento();

            using (AppDbContext context = new AppDbContext())
            {
                salidaVehiculo = context.Set<Estacionamiento>()
                .Where(x => x.VehiculoEstacionado.Patente == patente)
                .OrderBy(x => x.Entrada)
                .Last();
            }

            salidaVehiculo.SalidaEstacionamiento();

            using (AppDbContext context = new AppDbContext())
            {
                context.Database.EnsureCreated();
                context.Set<Estacionamiento>().Remove(salidaVehiculo);
                context.SaveChanges();
            }

            using (AppDbContext context = new AppDbContext())
            {
                context.Database.EnsureCreated();
                context.Set<Estacionamiento>().Add(salidaVehiculo);
                context.SaveChanges();
            }

            return salidaVehiculo;

            //Estacionamiento salidaVehiculo = repo.Estacionamientos
            //    .Where(x => x.VehiculoEstacionado.Patente == patente)
            //    .OrderBy(x => x.Entrada)
            //    .Single();

            //repo.Estacionamientos.Remove(salidaVehiculo);

            //salidaVehiculo.SalidaEstacionamiento();

            //repo.Estacionamientos.Add(salidaVehiculo);

            //return salidaVehiculo;
        }
        public List<Estacionamiento> ObtenerTodos()
        {
            List<Estacionamiento> es;
            using (AppDbContext context = new AppDbContext())
            {
                context.Database.EnsureCreated();
                es = context.Set<Estacionamiento>()
                    .Include(x=> x.VehiculoEstacionado)
                    .Include(x=> x.Plaza)
                    .ToList();

            }
            return es;
            
            //return repo.Estacionamientos;
        }
        public List<Estacionamiento> ObtenerEstacionamientosPorPatente(string patente)
        {
            List<Estacionamiento> esta;
            using (AppDbContext context = new AppDbContext())
            {
                esta = context.Set<Estacionamiento>()
                    .Where(x => x.VehiculoEstacionado.Patente == patente)
                    .Include(x => x.VehiculoEstacionado)
                    .Include(x => x.Plaza)
                    .ToList();
            }

            return esta;
            //estacionamientos = repo.Estacionamientos
            //    .Where(x => x.VehiculoEstacionado.Patente == patente)
            //    .ToList();

        }

        public bool YaEstaEstacionado(string patente)
        {
            bool resultado;

            using (AppDbContext context = new AppDbContext())
            {
                resultado = context.Set<Estacionamiento>()
                    .Where(x => x.VehiculoEstacionado.Patente == patente)
                    .Where(x => x.Estado == EstadoEstacionamiento.Activo)
                    .Any();
            }
            return resultado;

            //resultado = repo.Estacionamientos
            //    .Where(x => x.VehiculoEstacionado.Patente == patente)
            //    .Where(x => x.Estado == EstadoEstacionamiento.Activo)
            //    .Any();

            //return resultado;
        }
    }
}