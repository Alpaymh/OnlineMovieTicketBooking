using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMovieTicketBooking.Models
{
    [Table("Filmler")]
    public class Film
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string FilmAdi { get; set; }
        [StringLength(50)]
        [Required]
        public string Resim { get; set; }
        [StringLength(30)]
        [Required]
        public string Tur { get; set; }
        [StringLength(30)]
        [Required]
        public string Dil { get; set; }
        [Required]
        public string Aciklama { get; set; }
    }
}
