using CoreManager.API.CoreManager.Domain.Models;

namespace CoreManager.API.CoreManager.Domain.DTOs
{
    public class UserMapper
    {
        public static UserDto ToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                Phone = user.Phone,
                BirthDate = user.BirthDate
            };
        }

        public static User ToDomain(CreateUserDto dto)
        {
            return new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                BirthDate = dto.BirthDate
            };
        }

        public static User ToDomain(UpdateUserDto dto)
        {
            return new User
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                BirthDate = dto.BirthDate
            };
        }
    }
}

