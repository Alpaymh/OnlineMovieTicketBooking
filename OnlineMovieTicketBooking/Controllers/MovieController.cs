using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineMovieTicketBooking.Data;
using OnlineMovieTicketBooking.Entities;
using OnlineMovieTicketBooking.Models;

namespace OnlineMovieTicketBooking.Controllers
{
    [Authorize(Roles = "admin")]
    public class MovieController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public MovieController(AppDbContext appDbContext, IMapper mapper, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var sorgu = (from film in _appDbContext.Filmler
                         join kategori in _appDbContext.Kategoriler on film.KategoriID equals kategori.Id
                         select new MovieModel
                         {
                             Id = film.Id,
                             KategoriAdi = kategori.KategoriAdi,
                             FilmAdi = film.FilmAdi,
                             Resim = film.Resim,
                             Dil = film.Dil,
                             Aciklama = film.Aciklama,
                             AktifMi = film.AktifMi
                         }).ToList();
            return View(sorgu);

        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateMovieModel model)
        {
            if (ModelState.IsValid)
            {
                Film film = _mapper.Map<Film>(model);
                _appDbContext.Filmler.Add(film);
                _appDbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            Film film = _appDbContext.Filmler.Find(id);
            EditMovieModel model = _mapper.Map<EditMovieModel>(film);
                
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id, EditMovieModel model)
        {
            if (ModelState.IsValid)
            {
                Film film = _appDbContext.Filmler.Find(id);

                _mapper.Map(model, film);
                _appDbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Film film = _appDbContext.Filmler.Find(id);

            if (film != null)
            {
                _appDbContext.Filmler.Remove(film);
                _appDbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }




    }
}
