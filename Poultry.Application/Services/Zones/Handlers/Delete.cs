using MediatR;
using Microsoft.EntityFrameworkCore;
using Poultry.Application.Core;
using Poultry.Application.Services.Zones.Commands;
using Poultry.Persistance.Contexts;

namespace Poultry.Application.Services.Zones.Handlers;

public class Delete
{

    public class Handler : IRequestHandler<ZoneDeleteCommand, ResultDto<Unit>>
    {
        private readonly DatabaseContext _context;

        public Handler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto<Unit>> Handle(ZoneDeleteCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var validation = new ZoneDeleteValidator();
            var validationResult = await validation.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return ResultDto<Unit>.Failure(new List<string> { $"{validationResult.Errors[0].ErrorMessage}" });
            #endregion

            var zone = await _context.Zones.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (zone is null)
                return ResultDto<Unit>.Failure(new List<string> { "مورد با شناسه مورد نظر یافت نشد" });

            zone.IsRemoved = true;
            zone.RemoveTime = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);

            return ResultDto<Unit>.Success(Unit.Value);
        }
    }
}
