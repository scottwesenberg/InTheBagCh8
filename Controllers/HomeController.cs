using InTheBag.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace InTheBag.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult IndexViewBag()
        {
            IList<string> WishList = new List<string>();
            WishList.Add("Peace");
            WishList.Add("Health");
            WishList.Add("Hapiness");
            ViewBag.WishList = WishList;
            return View();
        }
        public IActionResult IndexViewData()
        {
            IList<string> WishList = new List<string>();
            WishList.Add("Quies");
            WishList.Add("Salutem");
            WishList.Add("Beatitudinem");
            ViewData["WishList"] = WishList;
            return View();
        }
        public IActionResult IndexTempData()
        {
            IList<string> WishList = new List<string>();
            WishList.Add("La Paz");
            WishList.Add("La Salud");
            WishList.Add("L:a Felicidad");
            TempData["WishList"] = WishList;

            return View();
        }
        public IActionResult WishIndex() 
        {
            Wishes myWishes = new Wishes { ID = 1, wish1 = "Healthy", wish2 = "Wealthy", wish3 = "Wise" };
            string jsonWishes = JsonSerializer.Serialize(myWishes);
            HttpContext.Session.SetString("wish", jsonWishes);
            return View();
        }
        public IActionResult NewWishIndex()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewWishIndex(Wishes Model)
        {
            Wishes myWishes = new Wishes { ID = 2, wish1 = Model.wish1, wish2 = Model.wish2, wish3 = Model.wish3 };
            string jsonWishes = JsonSerializer.Serialize(myWishes);
            HttpContext.Session.SetString("wish", jsonWishes);

            return View("WishIndex");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}