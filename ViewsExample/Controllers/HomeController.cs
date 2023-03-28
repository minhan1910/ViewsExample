using Microsoft.AspNetCore.Mvc;
using ViewsExample.Models;

namespace ViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {

            ViewData["pageTitle"] = "Asp.net Core Demo App";

            List<Person> persons = new()
            {
                new Person() { Name = "Hung", DateOfBirth = Convert.ToDateTime("2002-01-01"), PersonGender = Gender.Male},
                new Person() { Name = "Thinh", DateOfBirth = Convert.ToDateTime("2002-05-06"), PersonGender = Gender.Male},
                new Person() { Name = "Bun", DateOfBirth = Convert.ToDateTime("2002-04-04"), PersonGender = Gender.Male},
                new Person() { Name = "Pnu", DateOfBirth = Convert.ToDateTime("2002-03-03"), PersonGender = Gender.Other},
                new Person() { Name = "Di", DateOfBirth = Convert.ToDateTime("2002-02-02"), PersonGender = Gender.Female},
            };

            ViewData["persons"] = persons;

            return View(); // Views/Home/Index.cshtml

            //retrun View("abc"); // abc.cshtml
            //return new ViewResult() { ViewName = "abc" };
        }
    }
}
