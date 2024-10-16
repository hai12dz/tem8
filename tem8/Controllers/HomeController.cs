using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using tem8.Models;

namespace tem8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        QlgiaiBongDaContext db = new QlgiaiBongDaContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var lsttrandau = db.Trandaus.Take(8).ToList();
            ViewBag.DanhSachTrongTai = db.Trongtais.Take(12).ToList();

            return View(lsttrandau);

        }


        public IActionResult IndexNew()
        {
            var lsttrandau = db.Trandaus.Take(8).ToList();
            ViewBag.DanhSachTrongTai = db.Trongtais.Take(12).ToList();
           ViewBag.lsttrongtai = db.Trongtais.Take(12).ToList();
            return View(lsttrandau);

        }
        [HttpGet]
            [Route("Edit")]

        public IActionResult Edit(string? id)
        {

            var trongtai = db.Trongtais.Where(x => x.TrongTaiId == id).SingleOrDefault();

            return View(trongtai);

        }
        [HttpPost]
        [Route("Edit")]

        public IActionResult Edit(Trongtai trongtai)
        {

            db.Update(trongtai);
            db.SaveChanges();
            return RedirectToAction("IndexNew", "Home");


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
