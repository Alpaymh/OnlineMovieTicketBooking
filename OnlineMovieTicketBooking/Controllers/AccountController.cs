using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt.Extensions;
using OnlineMovieTicketBooking.Data;
using OnlineMovieTicketBooking.Entities;
using OnlineMovieTicketBooking.Models;
using System.Security.Claims;

namespace OnlineMovieTicketBooking.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;

        public AccountController(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid) 
            {
                string md5Salt = _configuration.GetValue<string>("AppSettings:MD5Salt");
                string saltedPassword = model.Sifre + md5Salt;
                string hashedPassword = saltedPassword.MD5();

                Uye uye = _appDbContext.Uyeler.SingleOrDefault(x => x.KullaniciAdi.ToLower() == model.KullaniciAdi.ToLower() &&
                x.Sifre == hashedPassword);

                if (uye != null) 
                {
                    if (uye.Kilit) 
                    {
                        ModelState.AddModelError(nameof(model.KullaniciAdi), "Sistemde kullanıcı bulunamadı.");
                        return View(model);
                    }
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, uye.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, uye.Ad ?? String.Empty));
                    claims.Add(new Claim(ClaimTypes.Name, uye.Soyad ?? String.Empty));
                    claims.Add(new Claim("UserName", uye.KullaniciAdi));

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme );
                    
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("","Kullanıcı adı veya şifre hatalıdır.");
                }
            }
            
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_appDbContext.Uyeler.All(x => x.KullaniciAdi.ToLower() == model.KullaniciAdi.ToLower()))
                {
                    ModelState.AddModelError("", "Bu kullanıcı adı kullanılmıştır.");
                    View(model);
                }
                if (_appDbContext.Uyeler.All(x => x.Email.ToLower() == model.Email.ToLower()))
                {
                    ModelState.AddModelError("", "E-mail adresi zaten kullanılmaktadır.");
                    View(model);
                }

                string md5Salt = _configuration.GetValue<string>("AppSettings:MD5Salt");
                string saltedPassword = model.Sifre + md5Salt;
                string hashedPassword = saltedPassword.MD5();

                Uye uye = new Uye
                {
                    Ad = model.Ad,
                    Soyad = model.Soyad,
                    KullaniciAdi = model.KullaniciAdi,
                    Telefon = model.Telefon,
                    Email = model.Email,
                    Sifre = hashedPassword,
                    Admin = false
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
            return View();
        }

        public IActionResult Lagout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}
