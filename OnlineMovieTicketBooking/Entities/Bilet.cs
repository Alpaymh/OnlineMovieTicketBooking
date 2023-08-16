using OnlineMovieTicketBooking.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMovieTicketBooking.Entities
{
    [Table("Biletler")]
    public class Bilet
    {
        public int Id { get; set; }
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public int UyeID { get; set; }
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public int SeansID { get; set; }
        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public DateTime SatinAlmaTarihi { get; set; } = DateTime.Now;
        public Uye Uye { get; set; }
        public Seans Seans { get; set; }
    }
}
