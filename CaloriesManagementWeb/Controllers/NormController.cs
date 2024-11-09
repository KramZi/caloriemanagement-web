using CaloriesManagementWeb.Interfaces;
using CaloriesManagementWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CaloriesManagementWeb.Controllers {
	public class NormController : Controller {

		private readonly IUserRepository _userRepository;
		private readonly UserManager<User> _userManager;

		public NormController(IUserRepository userRepository, UserManager<User> userManager) {
			_userRepository = userRepository;
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Index() {
			User model;
			if (!User.Identity.IsAuthenticated) {
				model = new User();
			} else {
				var userId = _userManager.GetUserId(HttpContext.User);
				model = _userRepository.GetById(userId);
			}
			return View(model);
		}

		[HttpPost]
		public IActionResult Index(float? dailyCalories) {
			User model;
			if (!User.Identity.IsAuthenticated) {
				model = new User();
			} else {
				var userId = _userManager.GetUserId(HttpContext.User);
				model = _userRepository.GetById(userId);
				if (dailyCalories is not null) {
					model.DailyCalories = (int?)dailyCalories;
					_userRepository.Update(model);
				}
			}
			return View(model);
		}
	}
}
