using System;

namespace MS.Identidad.DataManagement.Models
{
    public class LicenciaConducirFiltroDataModel
    {
        public Guid? ClienteIdFiltro { get; set; }
        public string? NumeroFiltro { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}