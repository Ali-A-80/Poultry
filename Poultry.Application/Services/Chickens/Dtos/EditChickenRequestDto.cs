using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Chickens.Dtos
{
    public class EditChickenRequestDto
    {
        public long Id { get; set; }
        public bool Gender { get; set; }
        public byte Age { get; set; }
        public ChickenType ChickenType { get; set; }
        public int Weight { get; set; }
        public byte LayingRate { get; set; }
    }
}
