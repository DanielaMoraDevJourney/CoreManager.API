using CoreManager.API.CoreManager.Domain.Interfaces;
using CoreManager.API.CoreManager.Domain.Models;

namespace CoreManager.API.CoreManager.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor que cero.");

            return await _repository.GetByIdAsync(id);
        }

        public async Task<User> CreateAsync(User user)
        {
            ValidateUser(user);
            return await _repository.AddAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            if (user.Id <= 0)
                throw new ArgumentException("El ID del usuario no es válido.");

            ValidateUser(user);
            await _repository.UpdateAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID no es válido.");

            await _repository.DeleteAsync(id);
        }

        private void ValidateUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName))
                throw new ArgumentException("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(user.LastName))
                throw new ArgumentException("El apellido es obligatorio.");

            if (string.IsNullOrWhiteSpace(user.Email) || !user.Email.Contains("@"))
                throw new ArgumentException("El correo electrónico no es válido.");

            if (string.IsNullOrWhiteSpace(user.Phone))
                throw new ArgumentException("El celular es obligatorio.");

            if (user.BirthDate == default)
                throw new ArgumentException("La fecha de nacimiento es obligatoria.");
        }
    }
}
