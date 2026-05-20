namespace MS.Catalogo.DataManagement.Models
{
    /// <summary>
    /// Modelo de datos para la capa DataManagement del microservicio Catálogo.
    /// Prefijos de columna SQL preservados para consistencia con Entity y BusinessMapper.
    /// </summary>
    public class VehiculoDataModel
    {
        public Guid VEH_id { get; set; }
        public Guid CAT_id { get; set; }
        public Guid SUC_id { get; set; }
        public string VEH_placa { get; set; } = string.Empty;
        public string VEH_modelo { get; set; } = string.Empty;
        public int VEH_anio { get; set; }
        public string? VEH_color { get; set; }
        public decimal VEH_kilometraje { get; set; }
        public string VEH_estado { get; set; } = "Disponible";
        public string? VEH_imagenUrl { get; set; }
        public string VEH_marca { get; set; } = string.Empty;
        public bool VEH_disponibilidad { get; set; }
        public string? VEH_modificadoDesdeIp { get; set; }
        public string? VEH_modificadoDesdeServicio { get; set; }
        public string? VEH_modificadoDesdeEquipo { get; set; }

        public string? VEH_usuarioCreacion { get; set; }
        public DateTime VEH_fechaCreacion { get; set; }
        public string? VEH_usuarioModificacion { get; set; }
        public DateTime? VEH_fechaModificacion { get; set; }
    }
}
