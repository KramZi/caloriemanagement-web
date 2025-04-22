using CaloriesManagementWeb.Helpers;
using Microsoft.AspNetCore.Mvc;
using CaloriesManagementWeb.ViewModel;
using CaloriesManagementWeb.Models;
using Microsoft.AspNetCore.Identity;
using CaloriesManagementWeb.Interfaces;

namespace CaloriesManagementWeb.Controllers
{
    public class CalculatorController : Controller
    {

        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public CalculatorController(
            IUserRepository userRepository,
            UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new CalculatorViewModel();
            if (User.Identity.IsAuthenticated)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                var user = await _userRepository.GetByIdAsync(userId);
                model.DailyCalories = user?.DailyCalories ?? 0;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CalculatorViewModel model)
        {
            float? Height = Formula.ToCentimeter(model.Height, model.Height_Unit);
            float? Weight = Formula.ToKilogram(model.Weight, model.Weight_Unit);
            model.TDEE = (int?)Formula.TDEE(
                model.Age,
                Height,
                Weight,
                model.Gender,
                model.Activity);

            if (User.Identity.IsAuthenticated)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                var user = await _userRepository.GetByIdAsync(userId);
                model.DailyCalories = user?.DailyCalories ?? 0;
            }
            model.PostMethod = true;

            return View(model);
        }
    }
}
