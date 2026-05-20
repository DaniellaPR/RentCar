// MS.Catalogo.Business/DTOs/Vehiculo/VehiculoResponse.cs
// ACTUALIZACIÓN: añadido PrecioPorDia (viene de Tarifa.TAR_precioDiario)
// y CategoriaNombre/SucursalNombre que el VehiculoService ya calcula.

namespace MS.Catalogo.Business.DTOs.Vehiculo;

public class VehiculoResponse
{
    public Guid    VEH_id            { get; set; }
    public Guid    CAT_id            { get; set; }
    public string  CategoriaNombre   { get; set; } = string.Empty;
    public Guid    SUC_id            { get; set; }
    public string  SucursalNombre    { get; set; } = string.Empty;
    public string  VEH_placa         { get; set; } = null!;
    public string  VEH_marca         { get; set; } = null!;
    public string  VEH_modelo        { get; set; } = null!;
    public int     VEH_anio          { get; set; }
    public string? VEH_color         { get; set; }
    public decimal VEH_kilometraje   { get; set; }
    public bool    VEH_disponibilidad { get; set; }
    public string? VEH_imagenUrl     { get; set; }
    public string  VEH_estado        { get; set; } = "ACTIVO";

    // ← NUEVO: precio diario de la tarifa de esta categoría
    // VehiculoService.GetByIdAsync lo puebla haciendo _unitOfWork.Tarifas.GetByCategoriaAsync(CAT_id)
    public decimal PrecioPorDia      { get; set; }
}
