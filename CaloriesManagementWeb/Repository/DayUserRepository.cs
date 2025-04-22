using CaloriesManagementWeb.Data;
using CaloriesManagementWeb.Interfaces;
using CaloriesManagementWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CaloriesManagementWeb.Repository
{
    public class DayUserRepository : IDayUserRepository
    {

        ApplicationDbContext _context;

        public DayUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Day_User?> GetByDate(int? date)
        {
            return _context.Day_User.Where(d => d.Date == date);
        }

        public async Task<Day_User?> GetByDateAndUserIdAsync(int? date, string? userId)
        {
            return await GetByDate(date)
                .Where(d => d.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> AddAsync(Day_User dayUser)
        {
            await _context.AddAsync(dayUser);
            return await SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Day_User dayUser)
        {
            _context.Update(dayUser);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Day_User dayUser)
        {
            _context.Remove(dayUser);
            return await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
