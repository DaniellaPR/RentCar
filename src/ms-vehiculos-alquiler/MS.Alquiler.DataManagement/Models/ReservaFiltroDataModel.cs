using System;

namespace MS.Alquiler.DataManagement.Models
{
    public class ReservaFiltroDataModel
    {
        public Guid? ClienteIdFiltro { get; set; }
        public Guid? VehiculoIdFiltro { get; set; }
        public string? EstadoFiltro { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}