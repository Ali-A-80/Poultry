using MediatR;
using Poultry.Application.Core;
using Poultry.Application.Services.Chickens.Commands;
using Poultry.Application.Services.Chickens.Dtos;
using Poultry.Domain.Entities;
using Poultry.Persistance.Repositories.Chickens;
using Poultry.Persistance.Repositories.HealthStatuses;

namespace Poultry.Application.Services.Chickens.Handlers;

public class CreateChickenHandler : IRequestHandler<CreateChickenCommand, ResultDto<ChickenResponseDto>>
{
    private readonly IChickenCommandRepository _chickenCommandRepository;
    private readonly IHealthStatusCommandRepository _healthStatusCommandRepository;

    public CreateChickenHandler(IChickenCommandRepository chickenCommandRepository, IHealthStatusCommandRepository healthStatusCommandRepository)
    {
        _chickenCommandRepository = chickenCommandRepository;
        _healthStatusCommandRepository = healthStatusCommandRepository;
    }

    public async Task<ResultDto<ChickenResponseDto>> Handle(CreateChickenCommand request, CancellationToken cancellationToken)
    {
        var chicken = new Chicken
        {
            Age = request.Age,
            ChickenType = request.ChickenType,
            Gender = request.Gender,
            LayingRate = request.LayingRate,
            Weight = request.Weight
        };


        await _chickenCommandRepository.AddChicken(chicken, cancellationToken);

        var rand = new Random();

        var healthStatus = new HealthStatus
        {
            Chicken = chicken,
            BodyTemprature = rand.Next(36, 43),
            CheckupDate = DateTime.Now,
            HealthLevel = HealthLevel.Healthy
        };

        await _healthStatusCommandRepository.AddHealthStatus(healthStatus, cancellationToken);

        return ResultDto<ChickenResponseDto>.Success(new ChickenResponseDto(chicken));
    }
}

