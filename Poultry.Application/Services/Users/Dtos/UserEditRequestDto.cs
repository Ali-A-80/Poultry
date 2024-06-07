namespace Poultry.Application.Services.Users.Dtos
{
    public class UserEditRequestDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
