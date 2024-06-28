using EstacionamientoMedido.Enumeraciones;

namespace EstacionamientoMedido.Modelos
{
    public class PlazaEstacionamiento: BaseEntidad
    {
        public PlazaEstacionamiento()
        {
            EstadoPlaza = EstadoPlaza.libre;
        }
        
        public string Nombre { get; set; }

        public EstadoPlaza EstadoPlaza { get; set; }
        

    }
}