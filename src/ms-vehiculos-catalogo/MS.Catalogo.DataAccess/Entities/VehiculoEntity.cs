namespace MS.Catalogo.DataAccess.Entities
{
    /// <summary>
    /// ACTUALIZACIÓN NECESARIA: Se añaden VEH_marca y VEH_disponibilidad
    /// que estaban presentes en la BD (Base_de_datos_microservicios.txt) y en el
    /// BusinessMapper pero ausentes en la Entity original.
    /// También se actualiza VehiculoConfiguration para mapear estas columnas.
    /// </summary>
    public class VehiculoEntity
    {
        public Guid VEH_id { get; set; }
        public Guid CAT_id { get; set; }
        public Guid SUC_id { get; set; }
        public string VEH_placa { get; set; } = string.Empty;
        public string VEH_marca { get; set; } = string.Empty; 
        public string VEH_modelo { get; set; } = string.Empty;
        public int VEH_anio { get; set; }
        public string? VEH_color { get; set; }
        public decimal VEH_kilometraje { get; set; }               
        public bool VEH_disponibilidad { get; set; }             
        public string VEH_estado { get; set; } = "ACTIVO";
        public string? VEH_imagenUrl { get; set; }

        public DateTime? VEH_fechaCreacion { get; set; }
        public string? VEH_usuarioCreacion { get; set; }
        public DateTime? VEH_fechaModificacion { get; set; }
        public string? VEH_usuarioModificacion { get; set; }

        // Navegación
        public virtual CategoriaVehiculoEntity Categoria { get; set; } = null!;
        public virtual SucursalEntity Sucursal { get; set; } = null!;
        public virtual ICollection<MantenimientoEntity> Mantenimientos { get; set; } = new List<MantenimientoEntity>();
    }
}