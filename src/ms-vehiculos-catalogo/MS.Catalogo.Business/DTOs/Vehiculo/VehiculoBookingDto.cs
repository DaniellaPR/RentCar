// MS.Catalogo.Business/DTOs/Vehiculo/VehiculoBookingDto.cs
// Este DTO expone exactamente lo que el Booking Prototipo espera según vehiculos-api.txt.
// Campos internos (VEH_marca, VEH_placa, etc.) se transforman aquí, no en el controller.

namespace MS.Catalogo.Business.DTOs.Vehiculo
{
    // ─── DTO de Vehículo para el Booking (contrato vehiculos-api.txt) ──────────
    public class VehiculoBookingDto
    {
        public string Id           { get; set; } = string.Empty;
        public string Nombre       { get; set; } = string.Empty;   // marca + modelo
        public string Descripcion  { get; set; } = string.Empty;   // color + año
        public decimal PrecioPorDia { get; set; }
        public string Moneda       { get; set; } = "USD";
        public string Categoria    { get; set; } = string.Empty;
        public bool   Disponible   { get; set; }
        public string? ImagenUrl   { get; set; }
    }

    // ─── DTO de Disponibilidad para el Booking ──────────────────────────────────
    public class DisponibilidadVehiculoDto
    {
        public bool   Disponible { get; set; }
        public string Mensaje    { get; set; } = string.Empty;
    }

    // ─── Extensión: VehiculoResponse → VehiculoBookingDto ──────────────────────
    // Centraliza la transformación. El controller solo llama .ToBookingDto().
    public static class VehiculoBookingDtoExtensions
    {
        public static VehiculoBookingDto ToBookingDto(this VehiculoResponse v)
        {
            return new VehiculoBookingDto
            {
                Id          = v.VEH_id.ToString(),
                Nombre      = $"{v.VEH_marca} {v.VEH_modelo}".Trim(),
                Descripcion = $"{v.VEH_color ?? "—"} · {v.VEH_anio}",
                // PrecioPorDia: viene de la tarifa de la categoría.
                // VehiculoResponse aún no lo tiene — se añade abajo con el enrichment.
                // Por ahora se deja en 0 hasta que VehiculoService enriquezca con Tarifa.
                PrecioPorDia = v.PrecioPorDia,
                Moneda      = "USD",
                Categoria   = v.CategoriaNombre,
                Disponible  = v.VEH_disponibilidad,
                ImagenUrl   = v.VEH_imagenUrl
            };
        }
    }
}
