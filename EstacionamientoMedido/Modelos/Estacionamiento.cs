using EstacionamientoMedido.Enumeraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Modelos
{
    public class Estacionamiento
    {
        public Estacionamiento(Vehiculo vehiculo, int precioHora, PlazaEstacionamiento plaza)
        {
            Entrada = DateTime.Now;
            Estado = EstadoEstacionamiento.Activo;
            VehiculoEstacionado = vehiculo;
            PrecioHora = precioHora;
            Plaza = plaza;
            PlazaOcupada = EstadoPlaza.ocupada;
        }
        public void SalidaEstacionamiento()
        {
            Estado = EstadoEstacionamiento.Terminado;

            PlazaOcupada = EstadoPlaza.libre;

            Salida = DateTime.Now;

            TimeSpan tiempo = Salida - Entrada;

            double horas = tiempo.TotalHours;

            if (horas < 1)
            {
                TotalEstacionamiento = PrecioHora;
            }
            else
            {
                TotalEstacionamiento = Convert.ToInt32(horas * PrecioHora);
            }
        }
        public DateTime Entrada { get; private set; }
        public DateTime Salida { get; set; }
        public EstadoPlaza PlazaOcupada { get; set; }
        public int PrecioHora { get; private set; }
        public Vehiculo VehiculoEstacionado { get; private set; }
        public PlazaEstacionamiento Plaza { get; private set; }
        public int TotalEstacionamiento { get; set; }
        public EstadoEstacionamiento Estado { get; set; }
        

    }
}