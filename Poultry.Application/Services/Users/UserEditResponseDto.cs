using Poultry.Domain.Entities;

namespace Poultry.Application.Services.Users
{
    public class UserEditResponseDto
    {
        public UserEditResponseDto(UserResponseDto userResponseDto , AppUser user)
        {
            UserName = userResponseDto.UserName;
            Token = userResponseDto.Token;
            Email = user.Email;
            MobileNumber = user.PhoneNumber;
        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Token { get; set; }
    }
}
