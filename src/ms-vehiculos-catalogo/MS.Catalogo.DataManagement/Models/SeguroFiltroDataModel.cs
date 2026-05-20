namespace MS.Catalogo.DataManagement.Models
{
    public class SeguroFiltroDataModel
    {
        public string? NombreFiltro { get; set; }
        public string? CoberturaFiltro { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}