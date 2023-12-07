using Poultry.Domain.Entities;

namespace Poultry.Application.Services.FoodServices
{
    public class FoodServiceRequestDto
    {
        public long? Id { get; set; }
        public FoodType FoodType { get; set; }
        public int Amount { get; set; }
    }
}
