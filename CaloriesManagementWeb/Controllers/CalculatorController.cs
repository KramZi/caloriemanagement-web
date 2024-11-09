using CaloriesManagementWeb.Helpers;
using Microsoft.AspNetCore.Mvc;
using CaloriesManagementWeb.ViewModel;
using CaloriesManagementWeb.Models;
using Microsoft.AspNetCore.Identity;
using CaloriesManagementWeb.Interfaces;

namespace CaloriesManagementWeb.Controllers {
	public class CalculatorController : Controller {

		private readonly IUserRepository _userRepository;
		private readonly UserManager<User> _userManager;

		public CalculatorController(IUserRepository userRepository, UserManager<User> userManager) {
			_userRepository = userRepository;
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Index() {
			var model = new CalculatorViewModel();
			if (User.Identity.IsAuthenticated) {
				var userId = _userManager.GetUserId(HttpContext.User);
				model.DailyCalories = _userRepository.GetById(userId).DailyCalories;
			}
			return View(model);
		}

		[HttpPost]
		public IActionResult Index(CalculatorViewModel model) {
			float? Height = Formula.ToCentimeter(model.Height, model.Height_Unit);
			float? Weight = Formula.ToKilogram(model.Weight, model.Weight_Unit);
			model.TDEE = (int?)Formula.TDEE(model.Age, Height, Weight, model.Gender, model.Activity);
			if (User.Identity.IsAuthenticated) {
				var userId = _userManager.GetUserId(HttpContext.User);
				model.DailyCalories = _userRepository.GetById(userId).DailyCalories;
			}
			model.PostMethod = true;
			return View(model);
		}
	}
}
