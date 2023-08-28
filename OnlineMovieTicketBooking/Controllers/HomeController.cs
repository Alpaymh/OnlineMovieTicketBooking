using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineMovieTicketBooking.Data;
using OnlineMovieTicketBooking.Models;
using System.Diagnostics;

namespace OnlineMovieTicketBooking.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var sorgu = (from salon in _appDbContext.SinemaSalonlari
                         where salon.PopulerSalon == true
                         select new TheaterModel
                         {
                             Id = salon.Id,
                             SalonAdi = salon.SalonAdi,
                             Adres = salon.Adres,
                             Telefon = salon.Telefon,
                             PopulerSalon = salon.PopulerSalon,
                             Resim = salon.Resim,
                             Fiyat = salon.Fiyat
                         }).ToList();
            return View(sorgu);
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}