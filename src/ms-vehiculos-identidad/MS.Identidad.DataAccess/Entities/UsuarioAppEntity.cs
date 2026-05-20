using System;

namespace MS.Identidad.DataAccess.Entities
{
    public class UsuarioAppEntity
    {
        public Guid USU_id { get; set; }

        public Guid ROL_id { get; set; }

        public string USU_email { get; set; } = string.Empty;

        public string USU_passwordHash { get; set; } = string.Empty;

        public DateTime? USU_fechaCreacion { get; set; }

        public string? USU_usuarioCreacion { get; set; }

        public DateTime? USU_fechaModificacion { get; set; }

        public string? USU_usuarioModificacion { get; set; }

        public virtual RolEntity Rol { get; set; } = null!;
    }
}