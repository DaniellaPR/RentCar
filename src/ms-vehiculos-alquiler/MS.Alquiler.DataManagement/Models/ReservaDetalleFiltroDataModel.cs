using System;

namespace MS.Alquiler.DataManagement.Models
{
    public class ReservaDetalleFiltroDataModel
    {
        public Guid? ReservaIdFiltro { get; set; }
        public Guid? ExtraIdFiltro { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}