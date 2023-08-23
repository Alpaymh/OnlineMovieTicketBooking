using Microsoft.AspNetCore.Mvc;
using OnlineMovieTicketBooking.Data;
using OnlineMovieTicketBooking.Models;

namespace OnlineMovieTicketBooking.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            var sorgu = (from film in _appDbContext.Filmler
                         join kategori in _appDbContext.Kategoriler on film.KategoriID equals kategori.Id
                         where film.AktifMi == false
                         select new ProductModel
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

        public IActionResult ProductDetails(int id)
        {
            var sorgu = (from film in _appDbContext.Filmler
                         join kategori in _appDbContext.Kategoriler on film.KategoriID equals kategori.Id
                         where film.Id == id
                         select new ProductModel
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
    }
}
