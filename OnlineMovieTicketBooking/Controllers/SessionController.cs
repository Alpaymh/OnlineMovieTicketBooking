using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineMovieTicketBooking.Data;
using OnlineMovieTicketBooking.Entities;
using OnlineMovieTicketBooking.Models;

namespace OnlineMovieTicketBooking.Controllers
{
    public class SessionController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public SessionController(AppDbContext appDbContext, IMapper mapper, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var sorgu = (from seans in _appDbContext.Seanslar
                        join salon in _appDbContext.SinemaSalonlari on seans.SalonId equals salon.Id
                        join film in _appDbContext.Filmler on seans.FilmId equals film.Id
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

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateSessionModel model)
        {
            if (ModelState.IsValid)
            {
                
                var yeniSeans = new Seans
                {
                    SalonId = model.SalonId,
                    FilmId = model.FilmId,
                    Tarih = model.Tarih,
                    Saat = model.Saat
                };
                _appDbContext.Seanslar.Add(yeniSeans);
                _appDbContext.SaveChanges();

                return RedirectToAction("Index"); // Index sayfasına yönlendir
            }

            // Hata durumunda aynı sayfayı tekrar göster
            return View("Index", model);
        }

        public IActionResult Edit(int id)
        {
            Seans seans = _appDbContext.Seanslar.Find(id);
            EditSessionModel model = _mapper.Map<EditSessionModel>(seans);

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id, EditSessionModel model)
        {
            if (ModelState.IsValid)
            {
                Seans seans = _appDbContext.Seanslar.Find(id);

                _mapper.Map(model, seans);
                _appDbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Seans seans = _appDbContext.Seanslar.Find(id);

            if (seans != null)
            {
                _appDbContext.Seanslar.Remove(seans);
                _appDbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
