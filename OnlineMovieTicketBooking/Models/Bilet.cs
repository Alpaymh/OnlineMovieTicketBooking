using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMovieTicketBooking.Models
{
    [Table("Biletler")]
    public class Bilet
    {
        public int Id { get; set; }
        [Required]
        public int UyeID { get; set; }
        [Required]
        public int SeansID { get; set; }
        [Required]
        public DateTime SatinAlmaTarihi { get; set; } = DateTime.Now;

        public Uye Uye { get; set; } 
        public Seans Seans { get; set; }
    }
}
