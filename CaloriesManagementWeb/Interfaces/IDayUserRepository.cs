using CaloriesManagementWeb.Models;

namespace CaloriesManagementWeb.Interfaces
{
    public interface IDayUserRepository
    {

        IQueryable<Day_User?> GetByDate(int? date);

        Task<Day_User?> GetByDateAndUserIdAsync(int? date, string? userId);

        Task<bool> AddAsync(Day_User dayUser);

        Task<bool> UpdateAsync(Day_User dayUser);

        Task<bool> DeleteAsync(Day_User dayUser);
    }
}
