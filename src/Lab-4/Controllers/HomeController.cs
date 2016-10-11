using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab_4.Models;

namespace Lab_4.Controllers
{
    public class HomeController : Controller
    {
        static PersonRepo people = new PersonRepo();

        public IActionResult Index()
        {
            DateTime current = DateTime.Now;
            if (current.Hour < 12) {
                ViewData["ToD"] = "Morning";
                ViewData["AMPM"] = "am";
            }
            else if (current.Hour >= 18) {
                ViewData["ToD"] = "Evening";
                ViewData["AMPM"] = "pm";
            }
            else
            {
                ViewData["ToD"] = "Afternoon";
                ViewData["AMPM"] = "pm";
            }

            if (DateTime.IsLeapYear(current.Year) == true)
                ViewData["Days Left"] = 366 - current.DayOfYear;
            else
                ViewData["Days Left"] = 365 - current.DayOfYear;
            ViewData["Day"] = current.DayOfWeek;
            ViewData["Month"] = current.ToString("MMMM");
            ViewData["Date"] = current.Day;
            ViewData["Time"] = current.ToString("hh:mm");
            ViewData["Year"] = current.Year;
            ViewData["Next Year"] = current.AddYears(1).Year;
            return View(people);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult PersonInfo()
        {
            ViewData["Heading"] = "Enter the Person information.";
            return View();
        }

        [HttpPost]
        public IActionResult PersonInfo(Person person)
        {
            if (ModelState.IsValid)
            {
                if (DateTime.Today.Month < person.BirthDate.Month)
                    person.Age = (DateTime.Today.Year - person.BirthDate.Year) - 1;
                else
                    person.Age = DateTime.Today.Year - person.BirthDate.Year;
                people.PersonList.Add(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }
    }
}
