using System;

namespace MS.Alquiler.DataAccess.Entities
{
    public class PagoEntity
    {
        public Guid PAG_id { get; set; }
        public Guid RES_id { get; set; }
        public decimal PAG_monto { get; set; }
        public string PAG_metodo { get; set; } = string.Empty;
        public string PAG_estado { get; set; } = string.Empty;
        public DateTime? PAG_fechaPago { get; set; }

        // Navegación
        public virtual ReservaEntity Reserva { get; set; } = null!;
    }
}