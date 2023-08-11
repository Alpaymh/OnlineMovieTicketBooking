using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMovieTicketBooking.Models
{
    [Table("SinemaSalonlari")]
    public class SinemaSalonu
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string SalonAdi { get; set; }
        [StringLength(50)]
        [Required]
        public string Adres { get; set; }
        [StringLength(15)]
        [Required]
        public string Telefon { get; set; }
        public bool PopulerSalon { get; set; } = false;

        public ICollection<Seans> Seanslar { get; set; }
    }
}
