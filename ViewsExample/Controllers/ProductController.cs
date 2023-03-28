using Microsoft.AspNetCore.Mvc;

namespace ViewsExample.Controllers
{
    public class ProductController : Controller
    {
        [Route("products/all")]
        public IActionResult All()
        {
            return View();  
            // Views/Products/All.cshtml - first location
            // Views/Shared/All.cshtml - second location
        }
    }
}
