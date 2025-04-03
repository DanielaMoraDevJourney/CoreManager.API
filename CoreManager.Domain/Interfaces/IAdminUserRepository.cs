using CoreManager.API.CoreManager.Domain.Models;

namespace CoreManager.API.CoreManager.Domain.Interfaces
{
    public interface IAdminUserRepository
    {
        Task<IEnumerable<AdminUser>> GetAllAsync();
        Task<AdminUser?> GetByIdAsync(Guid id);
        Task<AdminUser?> GetByUsernameAsync(string username);
        Task AddAsync(AdminUser user);
        Task UpdateAsync(AdminUser user);
        Task DeleteAsync(Guid id);
    }
}
