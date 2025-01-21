using techshop_api.Dtos.User;
using techshop_api.Models;

namespace techshop_api.Mappers
{
    public static class UserMapper
    {
        public static User ToUserFromPostDto(this PostUserDto userDto)
        {
            return new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password
            };
        }
    }
}
