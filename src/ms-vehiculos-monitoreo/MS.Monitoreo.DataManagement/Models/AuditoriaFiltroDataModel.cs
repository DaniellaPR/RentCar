namespace MS.Monitoreo.DataManagement.Models
{
    public class AuditoriaFiltroDataModel
    {
        public string? NombreTablaFiltro { get; set; }
        public string? OperacionFiltro { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}