using System;

namespace MS.Alquiler.DataManagement.Models
{
    public class PagoFiltroDataModel
    {
        public Guid? ReservaIdFiltro { get; set; }
        public string? MetodoFiltro { get; set; }
        public string? EstadoFiltro { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}