using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMovieTicketBooking.Models
{
    [Table("Uyeler")]
    public class Uye
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string? Ad { get; set; }
        [StringLength(50)]
        public string? Soyad { get; set; }
        [Required]
        [StringLength(30)]
        public string UserName { get; set; }
        public string Telefon { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string Sifre { get; set; }
        public bool Admin { get; set; } = false; 
        public ICollection<Bilet> Biletler { get; set; }
    }
}
