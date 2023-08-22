using Microsoft.AspNetCore.Mvc;
using OnlineMovieTicketBooking.Data;
using OnlineMovieTicketBooking.Models;

namespace OnlineMovieTicketBooking.Controllers
{
    public class TheaterController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public TheaterController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            var sorgu = (from salon in _appDbContext.SinemaSalonlari
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
    }
}
