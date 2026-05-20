namespace MS.Catalogo.DataManagement.Models
{
    public class ExtraAdicionalFiltroDataModel
    {
        public string? NombreFiltro { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}