﻿using CaloriesManagementWeb.Helpers;
using CaloriesManagementWeb.Interfaces;
using CaloriesManagementWeb.Models;
using CaloriesManagementWeb.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace CaloriesManagementWeb.Controllers {
    public class CalendarController : Controller {

        private readonly IDayUserRepository _dayUserRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public CalendarController(IDayUserRepository dayUserRepository, IUserRepository userRepository, UserManager<User> userManager) {
            _dayUserRepository = dayUserRepository;
            _userRepository = userRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        [Route("calendar/day/{date}")]
        public IActionResult Day(int date) {
            Day_User? model;
            if (!User.Identity.IsAuthenticated) {
                model = new Day_User();
            } else if (date / 10000 < 1990 || date / 10000 > 2029 || !Basic.IsValidDate(date)) {
                model = new Day_User() { NoDayWarning = true };
            } else {
                var userId = _userManager.GetUserId(HttpContext.User);
                model = _dayUserRepository.GetByDateAndUserId(date, userId);
                if (model is null) {
                    model = new Day_User() { Date = date, UserId = userId, GainedCalories = 0 };
                    _dayUserRepository.Add(model);
                }
                ViewBag.DailyCalories = _userRepository.GetById(userId).DailyCalories;
            }
            return View(model);
        }

        [HttpPost]
        [Route("calendar/day/{date}")]
        public IActionResult Day(int date, int gainedCalories, string submitButton) {
            var userId = _userManager.GetUserId(HttpContext.User);
            Day_User? model = _dayUserRepository.GetByDateAndUserId(date, userId);
            switch (submitButton) {
                case "+":
                    model.GainedCalories += gainedCalories;
                    break;
                case "-":
                    model.GainedCalories -= gainedCalories;
                    break;
            }
            _dayUserRepository.Update(model);
            ViewBag.DailyCalories = _userRepository.GetById(userId).DailyCalories;
            return View(model);
        }
    }
}