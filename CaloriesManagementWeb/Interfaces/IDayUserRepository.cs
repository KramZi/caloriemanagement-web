using CaloriesManagementWeb.Models;

namespace CaloriesManagementWeb.Interfaces {
    public interface IDayUserRepository {

        public IQueryable<Day_User?> GetByDate(int? date);

        public Day_User? GetByDateAndUserId(int? date, string? userId);

        public bool Add(Day_User day_user);

        public bool Delete(Day_User day_user);

        public bool Update(Day_User day_user);

        public bool Save();
    }
}
