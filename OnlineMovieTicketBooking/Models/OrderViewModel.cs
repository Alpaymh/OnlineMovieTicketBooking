using OnlineMovieTicketBooking.Helpers;
using System.ComponentModel.DataAnnotations;

namespace OnlineMovieTicketBooking.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string? UyeAdi { get; set; }
        public string? UyeSoyadi { get; set; }
        public string UyeKullaniciAdi { get; set; }
        public string? UyeTelefon { get; set; }
        public string UyeEmail { get; set; }
        public string SalonAdi { get; set; }
        public string FilmAdi { get; set; }
        public DateTime FilmTarih { get; set; }
        public TimeSpan FilmSaat { get; set; }
        public DateTime SatinAlmaTarihi { get; set; } = DateTime.Now;
        public double Fiyat { get; set; }

    }

    public class CreateOrderModel : EditOrderModel
    {
        public DateTime SatinAlmaTarihi { get; set; } = DateTime.Now;
    }

    public class EditOrderModel
    {
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public int UyeID { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public int SeansID { get; set; }
    }

}
