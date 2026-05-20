using System;

namespace MS.Catalogo.DataManagement.Models
{
    public class HorarioAtencionFiltroDataModel
    {
        public Guid? SucursalIdFiltro { get; set; }
        public string? DiaSemanaFiltro { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}