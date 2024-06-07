using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.VentilationSensors.Dtos;
using Poultry.Application.Services.VentilationSensors.Queries;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.VentilationSensors.Handlers;

public class ListVentilationSensorHandler : IRequestHandler<VentilationSensorListQuery, ResultDto<List<VentilationSensorResponseDto>>>
{
    private readonly DatabaseContext _context;

    public ListVentilationSensorHandler(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<ResultDto<List<VentilationSensorResponseDto>>> Handle(VentilationSensorListQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.VentilationSensors.AsNoTracking()
            .Select(x => new VentilationSensorResponseDto(x))
            .ToListAsync(cancellationToken);

        return ResultDto<List<VentilationSensorResponseDto>>.Success(query);
    }

}
