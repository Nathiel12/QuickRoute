namespace QuickRoute.Data.Models
{
    public class OrdenDetalle
    {
        public int OrdenDetalleId { get; set; }
        public int OrdenId { get; set; }
        public int CarroId { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }

        public virtual Carros Carro { get; set; }
        public virtual Orden Orden { get; set; }
    }
}
