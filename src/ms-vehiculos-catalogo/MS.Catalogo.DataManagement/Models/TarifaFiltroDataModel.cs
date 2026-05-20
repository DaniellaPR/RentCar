using System;

namespace MS.Catalogo.DataManagement.Models
{
    public class TarifaFiltroDataModel
    {
        public Guid? CategoriaIdFiltro { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}