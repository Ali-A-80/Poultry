using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.TemperatureSensors.Dtos;
using Poultry.Application.Services.TemperatureSensors.Queries;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.TemperatureSensors.Handlers;

public class ListTemperatureSensorHandler : IRequestHandler<TemperatureSensorListQuery, ResultDto<List<TemperatureSensorResponseDto>>>
{

    private readonly DatabaseContext _context;

    public ListTemperatureSensorHandler(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<ResultDto<List<TemperatureSensorResponseDto>>> Handle(TemperatureSensorListQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.TemperatureSensors.AsNoTracking()
            .Select(x => new TemperatureSensorResponseDto(x))
            .ToListAsync(cancellationToken);

        return ResultDto<List<TemperatureSensorResponseDto>>.Success(query);
    }

}
