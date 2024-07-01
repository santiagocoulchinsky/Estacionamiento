using EstacionamientoMedido.Enumeraciones;
using EstacionamientoMedido.Modelos;
using EstacionamientoMedido.Validaciones;
using FluentValidation.Results;


namespace EstacionamientoMedido.Controladores
{
    internal class PlazaController
    {
        //Repositorio repo = Repositorio.ObtenerInstancia();

        public void GuardarPlaza(PlazaEstacionamiento v)
        {
            PlazaValidator valida = new PlazaValidator();

            ValidationResult resultadoValidacion = valida.Validate(v);

            if (resultadoValidacion.IsValid)
            {
                //repo.PlazasEstacionamiento.Add(v);
                using (AppDbContext context = new AppDbContext())
                {
                    context.Database.EnsureCreated();
                    context.Set<PlazaEstacionamiento>().Add(v);
                    context.SaveChanges();
                }
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
            //return repo.PlazasEstacionamiento;
            List<PlazaEstacionamiento> plaza;
            using (AppDbContext context = new AppDbContext())
            {
                plaza = context.Set<PlazaEstacionamiento>().ToList();
            }
            return plaza;
        }
        public PlazaEstacionamiento ObtenerPlazaPorNombre(string plaza)
        {
            PlazaEstacionamiento plazaBuscada;
            using (AppDbContext context = new AppDbContext())
            {
                plazaBuscada = context.Set<PlazaEstacionamiento>()
                .Where(x => x.Nombre == plaza)
                .First();
            }
            return plazaBuscada;

            //PlazaEstacionamiento plazaBuscada = repo.PlazasEstacionamiento.Where(x => x.Nombre == plaza).FirstOrDefault();

            //return plazaBuscada;
        }




        public bool PlazaOcupada(string plaza)
        {
            bool resultado;
            using (AppDbContext context = new AppDbContext())
            {
                resultado = context.Set<Estacionamiento>()
                    .Where(x => x.Plaza.Nombre == plaza)
                    .Where(x => x.PlazaOcupada == EstadoPlaza.ocupada)
                    .Any();
            }

            return resultado;

            //resultado = repo.Estacionamientos
            //.Where(x => x.Plaza.Nombre == plaza)
            //.Where(x => x.PlazaOcupada == EstadoPlaza.ocupada)
            //.Any();

        }

        public void AsignaPlaza(string plaza)
        {
            PlazaEstacionamiento PlazaCargar = new PlazaEstacionamiento();

            PlazaCargar.Nombre = plaza;

            

            //GuardarPlaza(PlazaCargar);
        }
        public bool ExistePlaza(string plaza)
        {
            bool p;

            using (AppDbContext context = new AppDbContext())
            {
                p = context.Set<PlazaEstacionamiento>().Any(x => x.Nombre == plaza);
            }
            return p;

            //return repo.PlazasEstacionamiento.Any(x => x.Nombre == plaza);

            //bool resultado;

            //resultado = repo.Vehiculos.Any(x=> x.Patente == patente);
            //resultado = repo.Vehiculos.Where(x => x.Patente == patente).Any();

            //return resultado;
        }
    }
}
