using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt.Extensions;
using OnlineMovieTicketBooking.Data;
using OnlineMovieTicketBooking.Entities;
using OnlineMovieTicketBooking.Models;

namespace OnlineMovieTicketBooking.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserController(AppDbContext appDbContext, IMapper mapper, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            List<Uye> uyeler = _appDbContext.Uyeler.ToList();
            List<UserModel> users = uyeler.Select(x => _mapper.Map<UserModel>(x)).ToList();

            // LINQ işlemleri ile veri çekme kodu.
            //List<UserModel> model = new List<UserModel>();
            // var users = _appDbContext.Uyeler.Select(x => new UserModel 
            //    {Id = x.Id, Ad = x.Ad, Soyad=x.Soyad, KullaniciAdi=x.KullaniciAdi, Telefon = x.Telefon,
            //       Email= x.Email, Kilit= x.Kilit, RolID = x.RolID, ProfilResimDosyası = x.ProfilResimDosyası}).ToList();



            return View(users);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                if (_appDbContext.Uyeler.Any(x => x.KullaniciAdi.ToLower() == model.KullaniciAdi.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.KullaniciAdi),"Kullanıcı adı kullanılmıştır.");
                    return View(model);
                }
                if (_appDbContext.Uyeler.Any(x => x.Email.ToLower() == model.Email.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.Email), "E-mail adresi kullanılmıştır.");
                    return View(model);
                }

                Uye uye = _mapper.Map<Uye>(model);
                var hashSifre = MD5HashedPassword(uye.Sifre);
                uye.Sifre = hashSifre;
                _appDbContext.Uyeler.Add(uye);
                _appDbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        private string MD5HashedPassword(string s)
        {
            string md5Salt = _configuration.GetValue<string>("AppSettings:MD5Salt");
            string salted = s + md5Salt;
            string hashed = salted.MD5();
            return hashed;
        }

        public IActionResult Edit(int id)
        {
            Uye uye = _appDbContext.Uyeler.Find(id);
            EditUserModel model = _mapper.Map<EditUserModel>(uye);

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id, EditUserModel model)
        {
            if (ModelState.IsValid)
            {
                if (_appDbContext.Uyeler.Any(x => x.KullaniciAdi.ToLower() == model.KullaniciAdi.ToLower() &&
                x.Id != id))
                {
                    ModelState.AddModelError(nameof(model.KullaniciAdi), "Kullanıcı adı kullanılmıştır.");
                    return View(model);
                }
                if (_appDbContext.Uyeler.Any(x => x.Email.ToLower() == model.Email.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.Email), "E-mail adresi kullanılmıştır.");
                    return View(model);
                }

                Uye uye = _appDbContext.Uyeler.Find(id);

                _mapper.Map(model, uye);
                _appDbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Uye uye = _appDbContext.Uyeler.Find(id);

            if (uye != null)
            {
                _appDbContext.Uyeler.Remove(uye);
                _appDbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
