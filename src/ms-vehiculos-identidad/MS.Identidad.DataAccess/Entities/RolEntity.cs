using System;
using System.Collections.Generic;

namespace MS.Identidad.DataAccess.Entities
{
    public class RolEntity
    {
        public Guid ROL_id { get; set; }
        public string ROL_nombre { get; set; } = string.Empty;
        public string? ROL_descripcion { get; set; }

        public DateTime? ROL_fechaCreacion { get; set; }
        public string? ROL_usuarioCreacion { get; set; }
        public DateTime? ROL_fechaModificacion { get; set; }
        public string? ROL_usuarioModificacion { get; set; }

        public virtual ICollection<UsuarioAppEntity> UsuariosApp { get; set; } = new List<UsuarioAppEntity>();
    }
}