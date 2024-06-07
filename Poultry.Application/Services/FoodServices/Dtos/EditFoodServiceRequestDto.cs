using Poultry.Domain.Entities;

namespace Poultry.Application.Services.FoodServices.Dtos
{
    public class EditFoodServiceRequestDto
    {
        public long Id { get; set; }
        public FoodType FoodType { get; set; }
        public int Amount { get; set; }
    }
}
