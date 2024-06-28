using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Modelos
{
    public class Vehiculo: BaseEntidad
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string Patente { get; set; }
        public int ClienteId {  get; set; }
        public Cliente Cliente { get; set; }
        
        public List<Registro> Estacionamientos { get; set; }
    }
}