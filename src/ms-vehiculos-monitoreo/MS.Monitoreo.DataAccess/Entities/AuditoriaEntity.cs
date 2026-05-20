using System;

namespace MS.Monitoreo.DataAccess.Entities
{
    public class AuditoriaEntity
    {
        public Guid AUD_id { get; set; }
        public string AUD_nombreTabla { get; set; } = string.Empty;
        public string AUD_operacion { get; set; } = string.Empty;
        public string? AUD_usuario { get; set; }
        public DateTime? AUD_fecha { get; set; }

        // Lo mapearemos como string en C#, pero en la BD será un JSONB nativo
        public string? AUD_detalleJsonb { get; set; }
    }
}