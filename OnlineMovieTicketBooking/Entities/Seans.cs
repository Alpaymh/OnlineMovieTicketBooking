using OnlineMovieTicketBooking.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMovieTicketBooking.Entities
{
    [Table("Seanslar")]
        public class Seans
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "SalonID " + ErrorMessages.RequiredField)]
            public int SalonId { get; set; }
            [Required(ErrorMessage = "FilmID " + ErrorMessages.RequiredField)]
            public int FilmId { get; set; }
            public DateTime Tarih { get; set; }
            public TimeSpan Saat { get; set; }
            public SinemaSalonu Salon { get; set; }
            public Film Film { get; set; }
            public ICollection<Siparis> Siparişler { get; set; }
        }
}
