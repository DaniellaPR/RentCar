using MS.Catalogo.Business.DTOs.HorarioAtencion;
using MS.Catalogo.Business.Exceptions;
using MS.Catalogo.Business.Interfaces;
using MS.Catalogo.Business.Mappers;
using MS.Catalogo.Business.Validators;
using MS.Catalogo.DataManagement.Interfaces;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.Business.Services;

public class HorarioAtencionService : IHorarioAtencionService
{
    private readonly IUnitOfWork _unitOfWork;

    public HorarioAtencionService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<IEnumerable<HorarioAtencionResponse>> GetAllAsync()
    {
        var filtro = new HorarioAtencionFiltroDataModel { PageSize = 1000 };
        var result = await _unitOfWork.HorariosAtencion.GetPagedAsync(filtro);
        return result.Items.Select(h => h.ToResponse());
    }

    public async Task<HorarioAtencionResponse> GetByIdAsync(Guid id)
    {
        var horario = await _unitOfWork.HorariosAtencion.GetByIdAsync(id)
            ?? throw new NotFoundException("HorarioAtencion", id);

        return horario.ToResponse();
    }

    public async Task<HorarioAtencionResponse> CreateAsync(CrearHorarioAtencionRequest request)
    {
        var dataModel = request.ToDataModel();
        await _unitOfWork.HorariosAtencion.AddAsync(dataModel);
        await _unitOfWork.CommitAsync();

        return dataModel.ToResponse();
    }

    public async Task<HorarioAtencionResponse> UpdateAsync(Guid id, ActualizarHorarioAtencionRequest request)
    {
        request.HOR_id = id;
        HorarioAtencionValidator.ValidarActualizacion(request);

        var horario = await _unitOfWork.HorariosAtencion.GetByIdAsync(id)
            ?? throw new NotFoundException("Horario de Atención", id);

        horario.SUC_id = request.SUC_id;
        horario.HOR_diaSemana = request.HOR_diaSemana.ToString();
        horario.HOR_apertura = request.HOR_horaApertura;
        horario.HOR_cierre = request.HOR_horaCierre;
        horario.HOR_usuarioModificacion = request.HOR_usuarioModificacion;
        horario.HOR_fechaModificacion = DateTime.UtcNow;

        await _unitOfWork.HorariosAtencion.DeleteAsync(id);
        await _unitOfWork.CommitAsync();

        return horario.ToResponse();
    }

    public async Task DeleteAsync(Guid id, string usuarioModificacion)
    {
        var horario = await _unitOfWork.HorariosAtencion.GetByIdAsync(id)
            ?? throw new NotFoundException("HorarioAtencion", id);

        await _unitOfWork.HorariosAtencion.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
    }
}
