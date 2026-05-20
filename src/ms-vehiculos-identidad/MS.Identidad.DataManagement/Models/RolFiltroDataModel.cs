namespace MS.Identidad.DataManagement.Models
{
    public class RolFiltroDataModel
    {
        public string? NombreFiltro { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}