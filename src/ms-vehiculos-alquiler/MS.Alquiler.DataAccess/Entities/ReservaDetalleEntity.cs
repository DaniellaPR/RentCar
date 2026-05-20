using System;

namespace MS.Alquiler.DataAccess.Entities
{
    public class ReservaDetalleEntity
    {
        public Guid DET_id { get; set; }
        public Guid RES_id { get; set; }

        // Simple Guid hacia el ms-catalogo
        public Guid EXT_id { get; set; }

        public int DET_cantidad { get; set; }
        public decimal DET_subtotal { get; set; }

        // Auditoría
        public DateTime? DET_fechaCreacion { get; set; }
        public string? DET_usuarioCreacion { get; set; }
        public DateTime? DET_fechaModificacion { get; set; }
        public string? DET_usuarioModificacion { get; set; }

        // Navegación
        public virtual ReservaEntity Reserva { get; set; } = null!;
    }
}