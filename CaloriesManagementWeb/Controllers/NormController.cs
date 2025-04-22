using CaloriesManagementWeb.Interfaces;
using CaloriesManagementWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CaloriesManagementWeb.Controllers
{
    public class NormController : Controller
    {

        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public NormController(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            User model;
            if (!User.Identity.IsAuthenticated)
            {
                model = new User();
            } else
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                model = await _userRepository.GetByIdAsync(userId);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(float? dailyCalories)
        {
            User model;
            if (!User.Identity.IsAuthenticated)
            {
                model = new User();
            } else
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                model = await _userRepository.GetByIdAsync(userId);
                if (dailyCalories is not null)
                {
                    model.DailyCalories = (int?)dailyCalories;
                    await _userRepository.UpdateAsync(model);
                }
            }
            return View(model);
        }
    }
}
