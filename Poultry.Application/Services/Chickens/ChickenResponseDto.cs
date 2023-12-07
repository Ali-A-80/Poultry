using Poultry.Application.Services.HealthStatuses;
using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Chickens
{
    public class ChickenResponseDto
    {
        public ChickenResponseDto(Chicken chicken)
        {
            Id = chicken.Id;
            Gender = chicken.Gender;
            Age = chicken.Age;
            ChickenType = chicken.ChickenType;
            Weight = chicken.Weight;
            LayingRate = chicken.LayingRate;
            HealthStatus = new HealthStatusResponseDto(chicken.HealthStatus);
        }

        public long Id { get; set; }
        public bool Gender { get; set; }
        public byte Age { get; set; }
        public ChickenType ChickenType { get; set; }
        public int Weight { get; set; }
        public byte LayingRate { get; set; }
        public HealthStatusResponseDto HealthStatus { get; set; }
    }
}
