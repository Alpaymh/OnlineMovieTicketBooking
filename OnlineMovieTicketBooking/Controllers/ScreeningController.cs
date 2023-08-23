using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineMovieTicketBooking.Data;
using OnlineMovieTicketBooking.Entities;
using OnlineMovieTicketBooking.Models;

namespace OnlineMovieTicketBooking.Controllers
{
    public class ScreeningController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ScreeningController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [Authorize]
        public IActionResult Index(int id)
        {
            var sorgu = (from seans in _appDbContext.Seanslar
                         join salon in _appDbContext.SinemaSalonlari on seans.SalonId equals salon.Id
                         join film in _appDbContext.Filmler on seans.FilmId equals film.Id
                         where film.Id == id
                         orderby salon.SalonAdi ascending, seans.Tarih
                         select new SessionModel
                         {
                             SeansId = seans.Id,
                             SalonAdi = salon.SalonAdi,
                             Fiyat = salon.Fiyat,
                             FilmAdi = film.FilmAdi,
                             Tarih = seans.Tarih,
                             Saat = seans.Saat
                         }).ToList();
            return View(sorgu);
        }
    }
}
