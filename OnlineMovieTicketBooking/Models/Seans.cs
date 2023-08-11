using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMovieTicketBooking.Models
{
    [Table("Seanslar")]
    public class Seans
    {
        public int Id { get; set; }
        [Required]
        public int SalonId { get; set; }
        [Required]
        public int FilmId { get; set; }
        public DateTime Tarih { get; set; }
        public TimeSpan Saat { get; set; }

        public SinemaSalonu Salon { get; set; }
        public Film Film { get; set; }
        public ICollection<Bilet> Biletler { get; set; }

    }
}
