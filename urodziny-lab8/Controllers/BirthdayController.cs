using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using urodziny_lab8.Models;

namespace urodziny_lab8.Controllers
{
    public class BirthdayController : Controller
    {

        [Route("/")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(BirthdayModel birthday)
        {
            var viewModel = new BirthdayCalculationsViewModel
            {
                Name = birthday.Name,
                DaysToBirthday = CalculateDaysToBirthday(birthday.BirthDate),
                IsLeapYear = DateTime.IsLeapYear(birthday.BirthDate.Year)
            };
            return View(viewModel);
        }

        private int CalculateDaysToBirthday(DateTime birthdayDate)
        {
            DateTime today = DateTime.Today;
            DateTime previous = new DateTime(today.Year, birthdayDate.Month, birthdayDate.Day);

            if (previous > today)
                previous = previous.AddYears(-1);

            return (today - previous).Days;
        }
    }
}
