using OnlineMovieTicketBooking.Helpers;
using System.ComponentModel.DataAnnotations;

namespace OnlineMovieTicketBooking.Models
{
    public class SessionModel
    {
        public int SeansId { get; set; }
        public string SalonAdi { get; set; }
        public double Fiyat { get; set; }
        public string FilmAdi { get; set; }
        public DateTime Tarih { get; set; }
        public TimeSpan Saat { get; set; }
    }


    public class CreateSessionModel
    {
        [Required(ErrorMessage = "SalonID " + ErrorMessages.RequiredField)]
        public int SalonId { get; set; }
        [Required(ErrorMessage = "FilmID " + ErrorMessages.RequiredField)]
        public int FilmId { get; set; }
        public DateTime Tarih { get; set; }
        public TimeSpan Saat { get; set; }
    }

    public class EditSessionModel : CreateSessionModel
    {
        
    }
}
