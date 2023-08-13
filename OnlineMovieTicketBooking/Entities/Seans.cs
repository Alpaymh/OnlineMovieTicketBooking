using OnlineMovieTicketBooking.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMovieTicketBooking.Entities
{
    [Table("Seanslar")]
    public class Seans
    {
        public int Id { get; set; }
        [Required]
        public int SalonId { get; set; }
        [Required]
        public int FilmId { get; set; }
        [Required(ErrorMessage = "Tarih " + ErrorMessages.RequiredField)]
        public DateTime Tarih { get; set; }
        [Required(ErrorMessage = "Saat " + ErrorMessages.RequiredField)]
        public TimeSpan Saat { get; set; }

        public SinemaSalonu Salon { get; set; }
        public Film Film { get; set; }
        public ICollection<Bilet> Biletler { get; set; }

    }
}
