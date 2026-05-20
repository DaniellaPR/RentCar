using System;

namespace MS.Catalogo.DataManagement.Models
{
    public class VehiculoFiltroDataModel
    {
        public Guid? CategoriaIdFiltro { get; set; }
        public Guid? SucursalIdFiltro { get; set; }
        public string? PlacaFiltro { get; set; }
        public string? EstadoFiltro { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}