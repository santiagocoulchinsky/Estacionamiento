using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Modelos
{
    public class Registro
    {
        public Estacionamiento Estacionamiento { get; set; }
        public int EstacionamientoId {  get; set; }
        public Vehiculo Vehiculo { get; set; }
        public int VehiculoId { get; set;}
    }
}
