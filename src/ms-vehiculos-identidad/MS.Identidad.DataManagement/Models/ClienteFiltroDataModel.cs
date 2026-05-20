namespace MS.Identidad.DataManagement.Models
{
    public class ClienteFiltroDataModel
    {
        public string? CedulaFiltro { get; set; }
        public string? ApellidosFiltro { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}