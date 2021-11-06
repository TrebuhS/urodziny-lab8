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
                IsLeapYear = DateTime.IsLeapYear(DateTime.Today.Year)
            };
            return View(viewModel);
        }

        private int CalculateDaysToBirthday(DateTime birthdayDate)
        {
            DateTime today = DateTime.Today;
            DateTime next = new DateTime(today.Year, birthdayDate.Month, birthdayDate.Day);

            if (next < today)
                next = next.AddYears(1);

            return (next - today).Days;
        }
    }
}
