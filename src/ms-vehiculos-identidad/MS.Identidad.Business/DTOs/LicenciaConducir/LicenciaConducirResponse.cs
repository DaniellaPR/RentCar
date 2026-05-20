namespace MS.Identidad.Business.DTOs.LicenciaConducir;

public class LicenciaConducirResponse
{
    public Guid LIC_id { get; set; }
    public Guid CLI_id { get; set; }
    public string LIC_numero { get; set; } = null!;
    public string LIC_categoria { get; set; } = null!;
    public DateTime LIC_vigencia { get; set; }
}
