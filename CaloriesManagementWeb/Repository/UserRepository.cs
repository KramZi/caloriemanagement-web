using CaloriesManagementWeb.Data;
using CaloriesManagementWeb.Interfaces;
using CaloriesManagementWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CaloriesManagementWeb.Repository {
    public class UserRepository : IUserRepository {

        ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) {
            _context = context;
        }

        public User? GetById(string? id) {
            return _context.User.Find(id);
        }

        public bool Update(User user) {
            _context.Update(user);
            return Save();
        }

        public bool Save() {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
