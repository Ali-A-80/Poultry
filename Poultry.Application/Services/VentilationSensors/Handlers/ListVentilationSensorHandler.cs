using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.VentilationSensors.Dtos;
using Poultry.Application.Services.VentilationSensors.Queries;
using Poultry.Domain.Repositories.VentilationSensors;

namespace Poultry.Application.Services.VentilationSensors.Handlers;

public class ListVentilationSensorHandler : IRequestHandler<VentilationSensorListQuery, ResultDto<List<VentilationSensorResponseDto>>>
{
    private readonly IVentilationSensorQueryRepository _ventilationSensorQueryRepository;

    public ListVentilationSensorHandler(IVentilationSensorQueryRepository ventilationSensorQueryRepository)
    {
        _ventilationSensorQueryRepository = ventilationSensorQueryRepository;
    }

    public async Task<ResultDto<List<VentilationSensorResponseDto>>> Handle(VentilationSensorListQuery request, CancellationToken cancellationToken)
    {
        var query = _ventilationSensorQueryRepository.GetAll();

        var result = await query.Select(x => new VentilationSensorResponseDto(x)).ToListAsync(cancellationToken);

        return ResultDto<List<VentilationSensorResponseDto>>.Success(result);
    }

}
