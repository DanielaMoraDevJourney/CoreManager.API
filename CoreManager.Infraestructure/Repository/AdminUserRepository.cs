using CoreManager.API.CoreManager.Domain.Interfaces;
using CoreManager.API.CoreManager.Domain.Models;
using CoreManager.API.CoreManager.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CoreManager.API.CoreManager.Infraestructure.Repository
{

    public class AdminUserRepository : IAdminUserRepository
    {
        private readonly AppDbContext _context;

        public AdminUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AdminUser>> GetAllAsync() =>
            await _context.AdminUsers.ToListAsync();

        public async Task<AdminUser?> GetByIdAsync(Guid id) =>
            await _context.AdminUsers.FindAsync(id);

        public async Task<AdminUser?> GetByUsernameAsync(string username) =>
            await _context.AdminUsers.FirstOrDefaultAsync(u => u.Username == username);

        public async Task AddAsync(AdminUser user)
        {
            await _context.AdminUsers.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AdminUser user)
        {
            _context.AdminUsers.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.AdminUsers.FindAsync(id);
            if (user != null)
            {
                _context.AdminUsers.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
