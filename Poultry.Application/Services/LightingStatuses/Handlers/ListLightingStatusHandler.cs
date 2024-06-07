using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.LightingStatuses.Dtos;
using Poultry.Application.Services.LightingStatuses.Queries;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.LightingStatuses.Handlers;

public class ListLightingStatusHandler : IRequestHandler<LightingStatusListQuery, ResultDto<List<LightingStatusResponseDto>>>
{
    private readonly DatabaseContext _context;

    public ListLightingStatusHandler(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<ResultDto<List<LightingStatusResponseDto>>> Handle(LightingStatusListQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.LightingStatuses.AsNoTracking()
            .Select(x => new LightingStatusResponseDto(x))
            .ToListAsync(cancellationToken);

        return ResultDto<List<LightingStatusResponseDto>>.Success(query);
    }

}
