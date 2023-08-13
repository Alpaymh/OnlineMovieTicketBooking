using OnlineMovieTicketBooking.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMovieTicketBooking.Entities
{
    [Table("SinemaSalonlari")]
    public class SinemaSalonu
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Salon Adı " + ErrorMessages.MaxLength50)]
        [Required(ErrorMessage = "Salon Adı" + ErrorMessages.RequiredField)]
        public string SalonAdi { get; set; }
        [StringLength(50, ErrorMessage = "Adres " + ErrorMessages.MaxLength50)]
        [Required(ErrorMessage = "Adres " + ErrorMessages.RequiredField)]
        public string Adres { get; set; }
        [StringLength(15, ErrorMessage = "Telefon " + ErrorMessages.MaxLength15)]
        [Required(ErrorMessage = "Telefon " + ErrorMessages.RequiredField)]
        public string Telefon { get; set; }
        public bool PopulerSalon { get; set; } = false;

        public ICollection<Seans> Seanslar { get; set; }
    }
}
