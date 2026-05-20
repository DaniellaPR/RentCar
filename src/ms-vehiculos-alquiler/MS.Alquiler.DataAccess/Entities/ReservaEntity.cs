using System;
using System.Collections.Generic;

namespace MS.Alquiler.DataAccess.Entities
{
    public class ReservaEntity
    {
        public Guid RES_id { get; set; }

        // Simples Guids, la integridad se maneja por lógica/API, no por base de datos
        public Guid CLI_id { get; set; }
        public Guid VEH_id { get; set; }

        public DateTime RES_fechaReserva { get; set; }
        public DateTime RES_fechaInicio { get; set; }
        public DateTime RES_fechaFin { get; set; }
        public string RES_estado { get; set; } = string.Empty;
        public decimal RES_total { get; set; }

        // Auditoría
        public DateTime? RES_fechaCreacion { get; set; }
        public string? RES_usuarioCreacion { get; set; }
        public DateTime? RES_fechaModificacion { get; set; }
        public string? RES_usuarioModificacion { get; set; }

        // Navegación INTERNA (solo hacia tablas de este mismo microservicio)
        public virtual ICollection<ReservaDetalleEntity> Detalles { get; set; } = new List<ReservaDetalleEntity>();
        public virtual ICollection<PagoEntity> Pagos { get; set; } = new List<PagoEntity>();
    }
}