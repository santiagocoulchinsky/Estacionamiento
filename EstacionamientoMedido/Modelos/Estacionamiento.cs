using EstacionamientoMedido.Enumeraciones;


namespace EstacionamientoMedido.Modelos
{
    public class Estacionamiento: BaseEntidad
    { 
        public Estacionamiento() { }
        public Estacionamiento(Vehiculo vehiculo, int precioHora, PlazaEstacionamiento plaza)
        {
            Entrada = DateTime.Now;
            Estado = EstadoEstacionamiento.Activo;
            VehiculoEstacionadoId = vehiculo.Id;
            PrecioHora = precioHora;
            PlazaId = plaza.Id;
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
        public DateTime Entrada { get; set; }
        public DateTime Salida { get; set; }
        public EstadoPlaza PlazaOcupada { get; set; }
        public int PrecioHora { get; set; }
        public Vehiculo VehiculoEstacionado { get; set; }
        public int VehiculoEstacionadoId {  get; set; }
        public PlazaEstacionamiento Plaza { get; set; }
        //public PlazaEstacionamiento Estacionamento { get; set; }
        public int PlazaId {  get; set; }
        public int TotalEstacionamiento { get; set; }
        public EstadoEstacionamiento Estado { get; set; }
        public List<Registro> VehiculosEstacionados { get; set; }

    }
}