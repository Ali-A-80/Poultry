using Poultry.Domain.Entities;

namespace Poultry.Application.Services.FoodServices
{
    public class FoodServiceResponseDto
    {
        public FoodServiceResponseDto(FoodService foodService)
        {
            FoodType = foodService.FoodType;
            Amount = foodService.Amount;
        }

        public FoodType FoodType { get; set; }
        public int Amount { get; set; }
    }
}
