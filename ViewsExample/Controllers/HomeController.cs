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

            //ViewData["persons"] = persons;
            //ViewBag.persons = persons;



            return View("Index", persons); // Views/Home/Index.cshtml

            //retrun View("abc"); // abc.cshtml
            //return new ViewResult() { ViewName = "abc" };
        }

        [Route("person-details/{name}")]
        public IActionResult Details(string? name)
        {
            if (name == null)
            {
                return Content("Person name can't be null");
            }

            List<Person> people = new()
            {
                new Person() { Name = "Hung", DateOfBirth = Convert.ToDateTime("2002-01-01"), PersonGender = Gender.Male},
                new Person() { Name = "Thinh", DateOfBirth = Convert.ToDateTime("2002-05-06"), PersonGender = Gender.Male},
                new Person() { Name = "Bun", DateOfBirth = Convert.ToDateTime("2002-04-04"), PersonGender = Gender.Male},
                new Person() { Name = "Pnu", DateOfBirth = Convert.ToDateTime("2002-03-03"), PersonGender = Gender.Other},
                new Person() { Name = "Di", DateOfBirth = Convert.ToDateTime("2002-02-02"), PersonGender = Gender.Female},
            };
            
            Person? matchingPerson = people.Where(temp => temp.Name == name).FirstOrDefault();

            if (matchingPerson == null)
            {
                ViewData["error"] = "No matching person by " + name;
                return View(); // return view the same as action method's name
            }

            return View(matchingPerson); // Views/Home/Details.cshtml
        }

        [Route("person-and-product")]
        public IActionResult PersonAndProduct()
        {
            Person person = new() { Name = "Hung", DateOfBirth = Convert.ToDateTime("2002-01-01"), PersonGender = Gender.Male };
            Product product = new() { ProductId = 1, ProductName = "Air Conditinon" };

            PersonAndProductWrapperModel personAndProductWrapperModel = new()
            {
                PersonData = person,
                ProductData = product
            };

            return View(personAndProductWrapperModel);
        }

        [Route("home/all-products")]
        public IActionResult All()
        {
            return View();
            // Views/Home/All.cshtml - first location
            // Views/Shared/All.cshtml - second location
        }
    }
}
