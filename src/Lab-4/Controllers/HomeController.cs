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
            ViewData["Day"] = current.DayOfWeek;
            ViewData["Month"] = current.ToString("MMMM");
            ViewData["Date"] = current.Day;
            ViewData["Time"] = current.ToString("hh:mm");
            ViewData["Year"] = current.Year;
            return View();
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
            Person person = new Person("John", "Johnson", new DateTime(1965, 10, 21), 51);

            ViewData["title"] = "Person Info";
            return View();
        }

        [HttpPost]
        public IActionResult PersonInfo(Person person)
        {
            return View(person);
        }
    }
}
