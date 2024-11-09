using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CaloriesManagementWeb.Models {
    public class User : IdentityUser {
        public int? DailyCalories { get; set; } = 0;
    }
}
