namespace MS.Monitoreo.Business.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
    public NotFoundException(string entity, object key) : base($"La entidad {entity} con clave {key} no fue encontrada.") { }
}