using CaloriesManagementWeb.Data;
using CaloriesManagementWeb.Interfaces;
using CaloriesManagementWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CaloriesManagementWeb.Repository {
    public class DayUserRepository : IDayUserRepository {

        ApplicationDbContext _context;

        public DayUserRepository(ApplicationDbContext context) {
            _context = context;
        }

        public IQueryable<Day_User?> GetByDate(int? date) {
            return _context.Day_User.Where(d => d.Date == date);
        }

        public Day_User? GetByDateAndUserId(int? date, string? userId) {
            return this.GetByDate(date).Where(d => d.UserId == userId).FirstOrDefault();
        }

        public bool Add(Day_User day_user) {
            _context.Add(day_user);
            return Save();
        }

        public bool Update(Day_User day_user) {
            _context.Update(day_user);
            return Save();
        }

        public bool Delete(Day_User day_user) {
            _context.Remove(day_user);
            return Save();
        }

        public bool Save() {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
