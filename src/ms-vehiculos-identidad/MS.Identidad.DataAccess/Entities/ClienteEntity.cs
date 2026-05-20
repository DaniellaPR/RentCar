using System;
using System.Collections.Generic;

namespace MS.Identidad.DataAccess.Entities
{
    public class ClienteEntity
    {
        public Guid CLI_id { get; set; }
        public string CLI_nombres { get; set; } = string.Empty;
        public string CLI_apellidos { get; set; } = string.Empty;
        public string CLI_cedula { get; set; } = string.Empty;
        public string? CLI_telefono { get; set; }

        public DateTime? CLI_fechaCreacion { get; set; }
        public string? CLI_usuarioCreacion { get; set; }
        public DateTime? CLI_fechaModificacion { get; set; }
        public string? CLI_usuarioModificacion { get; set; }

        public virtual ICollection<LicenciaConducirEntity> Licencias { get; set; } = new List<LicenciaConducirEntity>();
    }
}