using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineMovieTicketBooking.Data;
using OnlineMovieTicketBooking.Entities;
using OnlineMovieTicketBooking.Models;

namespace OnlineMovieTicketBooking.Controllers
{
    [Authorize(Roles = "admin")]
    public class CinemaController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CinemaController(AppDbContext appDbContext, IMapper mapper, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            List<SinemaSalonu> salonlar = _appDbContext.SinemaSalonlari.ToList();
            List<CinemaModel> cinema = salonlar.Select(x => _mapper.Map<CinemaModel>(x)).ToList();


            // LINQ işlemleri ile veri çekme kodu.
            //List<CinemaModel> model = new List<CinemaModel>();
            // var cinema = _appDbContext.Filmler.Select(x => new CinemaModel
            //    {Id = x.Id, SalonAdi = x.SalonAdi, Adres=x.Adres, Telefon=x.Telefon, PopulerSalon = x.PopulerSalon, Resim = x.Resim}).ToList();


            return View(cinema);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateCinemaModel model)
        {
            if (ModelState.IsValid)
            {
                SinemaSalonu salonlar = _mapper.Map<SinemaSalonu>(model);
                _appDbContext.SinemaSalonlari.Add(salonlar);
                _appDbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        public IActionResult Edit(int id)
        {
            SinemaSalonu salonlar = _appDbContext.SinemaSalonlari.Find(id);
            EditCinemaModel model = _mapper.Map<EditCinemaModel>(salonlar);

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id, EditCinemaModel model)
        {
            if (ModelState.IsValid)
            {
                SinemaSalonu salonlar = _appDbContext.SinemaSalonlari.Find(id);

                _mapper.Map(model, salonlar);
                _appDbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            SinemaSalonu salonlar = _appDbContext.SinemaSalonlari.Find(id);

            if (salonlar != null)
            {
                _appDbContext.SinemaSalonlari.Remove(salonlar);
                _appDbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }




    }
}
