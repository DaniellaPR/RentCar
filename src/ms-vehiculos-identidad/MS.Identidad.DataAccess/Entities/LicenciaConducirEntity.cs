using System;

namespace MS.Identidad.DataAccess.Entities
{
    public class LicenciaConducirEntity
    {
        public Guid LIC_id { get; set; }
        public Guid CLI_id { get; set; }
        public string LIC_numero { get; set; } = string.Empty;
        public string LIC_categoria { get; set; } = string.Empty;
        public DateTime LIC_vigencia { get; set; }

        public DateTime? LIC_fechaCreacion { get; set; }
        public string? LIC_usuarioCreacion { get; set; }
        public DateTime? LIC_fechaModificacion { get; set; }
        public string? LIC_usuarioModificacion { get; set; }

        public virtual ClienteEntity Cliente { get; set; } = null!;
    }
}