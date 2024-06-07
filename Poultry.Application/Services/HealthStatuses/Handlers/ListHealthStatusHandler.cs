using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.HealthStatuses.Dtos;
using Poultry.Application.Services.HealthStatuses.Queries;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.HealthStatuses.Handlers;

public class ListHealthStatusHandler : IRequestHandler<HealthStatusListQuery, ResultDto<List<HealthStatusResponseDto>>>
{

    private readonly DatabaseContext _context;

    public ListHealthStatusHandler(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<ResultDto<List<HealthStatusResponseDto>>> Handle(HealthStatusListQuery request, CancellationToken cancellationToken)
    {
        var query = await _context.HealthStatuses.AsNoTracking()
                .Select(x => new HealthStatusResponseDto(x))
                .ToListAsync(cancellationToken);

        return ResultDto<List<HealthStatusResponseDto>>.Success(query);
    }

}
