using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.HumiditySensors.Dtos;
using Poultry.Application.Services.HumiditySensors.Queries;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.HumiditySensors.Handlers;

public class ListHumiditySensorHandler : IRequestHandler<HumiditySensorListQuery, ResultDto<List<HumiditySensorResponseDto>>>
{

    private readonly DatabaseContext _context;

    public ListHumiditySensorHandler(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<ResultDto<List<HumiditySensorResponseDto>>> Handle(HumiditySensorListQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.HumiditySensors.AsNoTracking()
            .Select(x => new HumiditySensorResponseDto(x))
            .ToListAsync(cancellationToken);

        return ResultDto<List<HumiditySensorResponseDto>>.Success(query);
    }

}
