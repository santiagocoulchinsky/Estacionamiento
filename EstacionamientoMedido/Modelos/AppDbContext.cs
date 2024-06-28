using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Modelos
{
    class AppDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //Cambio de ruta de creación de la DB del proyecto
            var rutaBase = AppDomain.CurrentDomain.BaseDirectory;
            var rutaProyecto = Path.GetFullPath(Path.Combine(rutaBase, @"..\..\..\"));
            var rutaBd = Path.Combine(rutaProyecto, "sqlite.db");

            optionsBuilder.UseSqlite($"Data Source={rutaBd}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasMany(x => x.Vehiculos)
                .WithOne(x => x.Cliente)
                .HasForeignKey(x => x.ClienteId)
                .IsRequired();

            modelBuilder.Entity<Registro>()
                .HasKey(x=> new {x.VehiculoId, x.EstacionamientoId});

            modelBuilder.Entity<Registro>()
                .HasOne(x => x.Vehiculo)
                .WithMany(x => x.Estacionamientos)
                .HasForeignKey(x => x.VehiculoId);

            modelBuilder.Entity<Registro>()
                .HasOne(x => x.Estacionamiento)
                .WithMany(x => x.VehiculosEstacionados)
                .HasForeignKey(x => x.EstacionamientoId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<PlazaEstacionamiento> PlazaEstacionamientos { get; set; }
        public DbSet<Estacionamiento> Estacionamientos { get; set; }
        public DbSet<Registro> Registros { get; set; }
    }
}