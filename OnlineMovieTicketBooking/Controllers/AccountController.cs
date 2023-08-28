using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETCore.Encrypt.Extensions;
using OnlineMovieTicketBooking.Data;
using OnlineMovieTicketBooking.Entities;
using OnlineMovieTicketBooking.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace OnlineMovieTicketBooking.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;

        public AccountController(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                string hashedPassword = MD5HashedPassword(model.Sifre);

                Uye uye = _appDbContext.Uyeler.SingleOrDefault(x => x.KullaniciAdi.ToLower() == model.KullaniciAdi.ToLower() &&
                x.Sifre == hashedPassword);

                
                if (uye != null)
                {
                    if (uye.Kilit)
                    {
                        ModelState.AddModelError(nameof(model.KullaniciAdi), "Sistemde kullanıcı bulunamadı.");
                        return View(model);
                    }
                    //Rol Tablosundaki verileri çekerek uye tablosundaki rolID'yi karşılaştırarak uyenin admin veya uye olduğunu uygulamaya bildirir.
                    var roller = await _appDbContext.Roller.ToListAsync();
                    string rolName = "";
                    foreach (Rol rol in roller)
                    {
                        if (uye.RolID == rol.Id)
                        {
                            rolName = rol.RolAdi;
                        }
                    }

                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, uye.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, uye.Ad ?? String.Empty));
                    claims.Add(new Claim(ClaimTypes.Name, uye.Soyad ?? String.Empty));
                    claims.Add(new Claim(ClaimTypes.Role, rolName));
                    claims.Add(new Claim("UserName", uye.KullaniciAdi));

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalıdır.");
                }
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

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_appDbContext.Uyeler.Any(x => x.KullaniciAdi.ToLower() == model.KullaniciAdi.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.TekrarSifre), "Bu kullanıcı adı kullanılmıştır.");
                    return View(model);
                }
                if (_appDbContext.Uyeler.Any(x => x.Email.ToLower() == model.Email.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.TekrarSifre), "E-mail adresi zaten kullanılmaktadır.");
                    return View(model);
                }

                string hashedPassword = MD5HashedPassword(model.Sifre);

                Uye uye = new Uye
                {
                    Ad = model.Ad,
                    Soyad = model.Soyad,
                    KullaniciAdi = model.KullaniciAdi,
                    Telefon = model.Telefon,
                    Email = model.Email,
                    Sifre = hashedPassword
                };
                _appDbContext.Uyeler.Add(uye);
                int affectedRowCount =  _appDbContext.SaveChanges();

                if (affectedRowCount == 0)
                {
                    ModelState.AddModelError("","Kayıt olma işlemi başarız oldu.");
                }
                else
                {
                    return RedirectToAction(nameof(Login));
                }
            }

            return View(model);
        }
        public IActionResult Profile()
        {
            return ProfileInfoLoader();
        }
        private Uye UyeBul()
        {
            int uyeid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Uye uye = _appDbContext.Uyeler.SingleOrDefault(x => x.Id == uyeid);
            return uye;
        }

        private IActionResult ProfileInfoLoader()
        {
            Uye uye = UyeBul();
            ViewData["Name"] = uye.Ad;
            ViewData["Surname"] = uye.Soyad;
            ViewData["UserName"] = uye.KullaniciAdi;
            ViewData["Tel"] = uye.Telefon;
            ViewData["Email"] = uye.Email;
            ViewData["ProfileImage"] = uye.ProfilResimDosyası;

            return View();
        }

        [HttpPost]
        public IActionResult ProfileChangeName([Required(ErrorMessage = "Ad alanı boş bırakılamaz.")][StringLength(50)] string? name)
        {
            if (ModelState.IsValid)
            {
                Uye uye = UyeBul();
                uye.Ad = name;
                _appDbContext.SaveChanges();

                return RedirectToAction(nameof(Profile));
            }
            ProfileInfoLoader();
            return View("Profile");
        }

        public IActionResult ProfileChangeSurname([Required(ErrorMessage = "Soyad alanı boş bırakılamaz.")][StringLength(50)] string? surname)
        {
            if (ModelState.IsValid)
            {
                Uye uye = UyeBul();
                uye.Soyad = surname;
                _appDbContext.SaveChanges();

                return RedirectToAction(nameof(Profile));
            }
            ProfileInfoLoader();
            return View("Profile");
        }

        public IActionResult ProfileChangeUserName([Required(ErrorMessage = "Kullanıcı adı alanı boş bırakılamaz.")][StringLength(30)] string? username)
        {
            if (ModelState.IsValid)
            {
                Uye uye = UyeBul();
                uye.KullaniciAdi = username;
                _appDbContext.SaveChanges();

                return RedirectToAction(nameof(Profile));
            }
            ProfileInfoLoader();
            return View("Profile");
        }

        public IActionResult ProfileChangeTel([Required(ErrorMessage = "Telefon alanı boş bırakılamaz.")][StringLength(15)] string? tel)
        {
            if (ModelState.IsValid)
            {
                Uye uye = UyeBul();
                uye.Telefon = tel;
                _appDbContext.SaveChanges();

                return RedirectToAction(nameof(Profile));
            }
            ProfileInfoLoader();
            return View("Profile");
        }

        public IActionResult ProfileChangeEmail([Required(ErrorMessage = "Email alanı boş bırakılamaz.")] string? email)
        {
            if (ModelState.IsValid)
            {
                Uye uye = UyeBul();
                uye.Email = email;
                _appDbContext.SaveChanges();

                return RedirectToAction(nameof(Profile));
            }
            ProfileInfoLoader();
            return View("Profile");
        }
        

        public IActionResult ProfileChangePassword([Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")][StringLength(100)] string? password)
        {
            if (ModelState.IsValid)
            {
                Uye uye = UyeBul();
                string hashedPassword = MD5HashedPassword(password);

                uye.Sifre = hashedPassword;
                _appDbContext.SaveChanges();

                ViewData["result"] = "PasswordChanged";
            }
            ProfileInfoLoader();
            return View("Profile");
        }

        public IActionResult ProfileChangeImage([Required(ErrorMessage = "Resim alanı boş bırakılamaz.")] IFormFile file)
        {
            if (ModelState.IsValid)
            {
                int uyeid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                Uye uye = _appDbContext.Uyeler.SingleOrDefault(x => x.Id == uyeid);

                string fileName = $"p_{uyeid}.jpg";
                Stream stream = new FileStream($"wwwroot/uploads/{fileName}", FileMode.OpenOrCreate);

                file.CopyTo(stream);
                stream.Close();
                stream.Dispose();

                uye.ProfilResimDosyası = fileName;
                _appDbContext.SaveChanges();

                return RedirectToAction(nameof(Profile));
            }
            ProfileInfoLoader();
            return View("Profile");
        }

        public IActionResult PurchasedTicket()
        {
            Uye uye = UyeBul();

            var sorgu = (from siparis in _appDbContext.Siparişler
                         join uyeler in _appDbContext.Uyeler on siparis.UyeID equals uyeler.Id
                         join seans in _appDbContext.Seanslar on siparis.SeansID equals seans.Id
                         join salon in _appDbContext.SinemaSalonlari on seans.SalonId equals salon.Id
                         join film in _appDbContext.Filmler on seans.FilmId equals film.Id
                         where siparis.UyeID == uye.Id
                         select new OrderModel
                         {
                             Id = siparis.Id,
                             UyeAdi = uyeler.Ad,
                             UyeSoyadi = uyeler.Soyad,
                             UyeKullaniciAdi = uyeler.KullaniciAdi,
                             UyeTelefon = uyeler.Telefon,
                             UyeEmail = uyeler.Email,
                             SalonAdi = salon.SalonAdi,
                             FilmAdi = film.FilmAdi,
                             FilmTarih = seans.Tarih,
                             FilmSaat = seans.Saat,
                             SatinAlmaTarihi = siparis.SatinAlmaTarihi,
                             Fiyat = salon.Fiyat
                         }).ToList();
            return View(sorgu);
        }

        public IActionResult Lagout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}
