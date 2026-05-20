namespace MS.Alquiler.DataManagement.Models
{
    /// <summary>
    /// Detalle de reserva: un ítem puede ser un Seguro (SEG_id) o un Extra (EXT_id), nunca ambos null.
    /// Refleja el CHECK constraint de la tabla SQL: (SEG_id IS NOT NULL OR EXT_id IS NOT NULL).
    /// </summary>
    public class ReservaDetalleDataModel
    {
        public Guid REX_id { get; set; }
        public Guid RES_id { get; set; }
        public Guid? SEG_id { get; set; }
        public Guid? EXT_id { get; set; }
        public int REX_cantidad { get; set; } = 1;

        public string? REX_usuarioCreacion { get; set; }
        public DateTime REX_fechaCreacion { get; set; }
        public string? REX_usuarioModificacion { get; set; }
        public DateTime? REX_fechaModificacion { get; set; }
    }
}
