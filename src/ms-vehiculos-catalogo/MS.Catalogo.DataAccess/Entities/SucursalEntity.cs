using System;
using System.Collections.Generic;

namespace MS.Catalogo.DataAccess.Entities
{
    public class SucursalEntity
    {
        public Guid SUC_id { get; set; }
        public string SUC_nombre { get; set; } = string.Empty;
        public string SUC_ciudad { get; set; } = string.Empty;
        public string SUC_direccion { get; set; } = string.Empty;
        public string? SUC_coordenadas { get; set; }
        public DateTime? SUC_fechaCreacion { get; set; }
        public string? SUC_usuarioCreacion { get; set; }
        public DateTime? SUC_fechaModificacion { get; set; }
        public string? SUC_usuarioModificacion { get; set; }

        // Navegación
        public virtual ICollection<HorarioAtencionEntity> HorariosAtencion { get; set; } = new List<HorarioAtencionEntity>();
        public virtual ICollection<VehiculoEntity> Vehiculos { get; set; } = new List<VehiculoEntity>();
    }
}