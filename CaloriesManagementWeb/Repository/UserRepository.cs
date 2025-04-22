using CaloriesManagementWeb.Data;
using CaloriesManagementWeb.Interfaces;
using CaloriesManagementWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CaloriesManagementWeb.Repository
{
    public class UserRepository : IUserRepository
    {

        ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByIdAsync(string id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(User user)
        {
            _context.Update(user);
            return await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
