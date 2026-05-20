// PARTE 5 — MS.Identidad.DataManagement/Models/UsuarioAppFiltroDataModel.cs
// CORRECCIÓN: EstadoFiltro cambia de bool? a string? para alinearse con USU_estado (string "ACTIVO"/"INACTIVO").
//             El UsuarioAppDataService filtra por USU_estado == filtro.EstadoFiltro.

namespace MS.Identidad.DataManagement.Models;

public class UsuarioAppFiltroDataModel
{
    public Guid? RolIdFiltro { get; set; }
    public string? CorreoFiltro { get; set; }
    /// <summary>Filtra por estado. Valores: "ACTIVO", "INACTIVO". Null = sin filtro.</summary>
    public string? EstadoFiltro { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}