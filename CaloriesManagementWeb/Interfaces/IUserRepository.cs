using CaloriesManagementWeb.Models;

namespace CaloriesManagementWeb.Interfaces {
    public interface IUserRepository {

        public User? GetById(string? id);

        public bool Update(User user);

        public bool Save();
    }
}
