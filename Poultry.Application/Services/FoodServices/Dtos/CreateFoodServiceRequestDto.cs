using Poultry.Domain.Entities;

namespace Poultry.Application.Services.FoodServices.Dtos
{
    public class CreateFoodServiceRequestDto
    {
        public FoodType FoodType { get; set; }
        public int Amount { get; set; }
    }
}
