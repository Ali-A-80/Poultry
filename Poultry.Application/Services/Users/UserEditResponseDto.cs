using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Users
{
    public class UserEditResponseDto
    {
        public UserEditResponseDto(UserResponseDto userResponseDto)
        {
            Token = userResponseDto.Token;
        }

        public string Token { get; set; }
    }
}
