using CaloriesManagementWeb.Models;

namespace CaloriesManagementWeb.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(string id);

        Task<bool> UpdateAsync(User user);
    }
}
