using Microsoft.AspNetCore.Mvc;
using OnlineMovieTicketBooking.Data;
using OnlineMovieTicketBooking.Entities;
using System.Security.Claims;

namespace OnlineMovieTicketBooking.Controllers
{
    public class PaymentController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;

        public PaymentController(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
        }
        public IActionResult Index()
        {

            // Hata durumunda aynı sayfayı tekrar göster
            return View();
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            int seansId = id;
            int uyeid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Uye uye = _appDbContext.Uyeler.SingleOrDefault(x => x.Id == uyeid);

            

            var yeniSiparis = new Siparis
            {
                UyeID = uyeid,
                SeansID = seansId,
                SatinAlmaTarihi = DateTime.Now
            };
            _appDbContext.Siparişler.Add(yeniSiparis);
            _appDbContext.SaveChanges();



            // Hata durumunda aynı sayfayı tekrar göster
            return RedirectToAction("PurchasedTicket", "Account");
        }
    }
}
