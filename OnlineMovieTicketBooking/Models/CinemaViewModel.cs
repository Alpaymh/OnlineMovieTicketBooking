using OnlineMovieTicketBooking.Helpers;
using System.ComponentModel.DataAnnotations;

namespace OnlineMovieTicketBooking.Models
{
    public class CinemaModel
    {
        public int Id { get; set; }
        public string SalonAdi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public bool PopulerSalon { get; set; } = false;
        public string Resim { get; set; } = "no-cinema";
        public double Fiyat { get; set; }
    }

    public class CreateCinemaModel : EditCinemaModel
    {
        public int Id { get; set; }
    }

    public class EditCinemaModel
    {
        [StringLength(50, ErrorMessage = "Salon Adı " + ErrorMessages.MaxLength50)]
        [Required(ErrorMessage = "Salon Adı" + ErrorMessages.RequiredField)]
        public string SalonAdi { get; set; }
        [StringLength(100, ErrorMessage = "Adres " + ErrorMessages.MaxLength50)]
        [Required(ErrorMessage = "Adres " + ErrorMessages.RequiredField)]
        public string Adres { get; set; }
        [StringLength(15, ErrorMessage = "Telefon " + ErrorMessages.MaxLength15)]
        [Required(ErrorMessage = "Telefon " + ErrorMessages.RequiredField)]
        public string Telefon { get; set; }
        public bool PopulerSalon { get; set; } = false;
        public string Resim { get; set; } = "s_1.jpg";
        public double Fiyat { get; set; }
    }


}
