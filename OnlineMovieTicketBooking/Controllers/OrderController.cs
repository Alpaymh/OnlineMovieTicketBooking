using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineMovieTicketBooking.Data;
using OnlineMovieTicketBooking.Entities;
using OnlineMovieTicketBooking.Models;

namespace OnlineMovieTicketBooking.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public OrderController(AppDbContext appDbContext, IMapper mapper, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var sorgu = (from siparis in _appDbContext.Siparişler
                         join uye in _appDbContext.Uyeler on siparis.UyeID equals uye.Id
                         join seans in _appDbContext.Seanslar on siparis.SeansID equals seans.Id
                         join salon in _appDbContext.SinemaSalonlari on seans.SalonId equals salon.Id
                         join film in _appDbContext.Filmler on seans.FilmId equals film.Id
                         select new OrderModel
                         {
                             Id = siparis.Id,
                             UyeAdi = uye.Ad,
                             UyeSoyadi = uye.Soyad,
                             UyeKullaniciAdi = uye.KullaniciAdi,
                             UyeTelefon = uye.Telefon,
                             UyeEmail = uye.Email,
                             SalonAdi = salon.SalonAdi,
                             FilmAdi = film.FilmAdi,
                             FilmTarih = seans.Tarih,
                             FilmSaat = seans.Saat,
                             SatinAlmaTarihi = siparis.SatinAlmaTarihi,
                             Fiyat = salon.Fiyat
                         }).ToList();

            
            
            return View(sorgu);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreateOrderModel model)
        {
            if (ModelState.IsValid)
            {

                var yeniSiparis = new Siparis
                {
                    UyeID = model.UyeID,
                    SeansID = model.SeansID,
                    SatinAlmaTarihi = DateTime.Now
                };
                _appDbContext.Siparişler.Add(yeniSiparis);
                _appDbContext.SaveChanges();

                return RedirectToAction("Index"); // Index sayfasına yönlendir
            }

            // Hata durumunda aynı sayfayı tekrar göster
            return View("Index", model);
        }

        public IActionResult Edit(int id)
        {
            Siparis siparis = _appDbContext.Siparişler.Find(id);
            EditOrderModel model = _mapper.Map<EditOrderModel>(siparis);

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id, EditOrderModel model)
        {
            if (ModelState.IsValid)
            {
                Siparis siparis = _appDbContext.Siparişler.Find(id);

                _mapper.Map(model, siparis);
                _appDbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Siparis siparis = _appDbContext.Siparişler.Find(id);

            if (siparis != null)
            {
                _appDbContext.Siparişler.Remove(siparis);
                _appDbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
