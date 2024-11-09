using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaloriesManagementWeb.Models {
    public class Day_User {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public int? Date { get; set; }
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public int? GainedCalories { get; set; }
        public bool? NoDayWarning { get; set; } = false;
    }
}
