﻿using EstacionamientoMedido.Enumeraciones;
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


            PlazaEstacionamiento plazaBuscada = repo.PlazasEstacionamiento.Where(x => x.Nombre == plaza).FirstOrDefault();

            return plazaBuscada;
        }
        public bool PlazaOcupada(string plaza)
        {
            bool resultado;

            resultado = repo.Estacionamientos
                .Where(x => x.Plaza.Nombre == plaza)
                .Where(x => x.PlazaOcupada == EstadoPlaza.ocupada)
                .Any();

            return resultado;
        }

        public void AsignaPlaza(string plaza)
        {
            PlazaEstacionamiento PlazaCargar = new PlazaEstacionamiento();

            PlazaCargar.Nombre = plaza;

            //GuardarPlaza(PlazaCargar);
        }
        public bool ExistePlaza(string plaza)
        {
            return repo.PlazasEstacionamiento.Any(x => x.Nombre == plaza);

            //bool resultado;

            //resultado = repo.Vehiculos.Any(x=> x.Patente == patente);
            //resultado = repo.Vehiculos.Where(x => x.Patente == patente).Any();

            //return resultado;
        }
    }
}
