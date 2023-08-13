using OnlineMovieTicketBooking.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMovieTicketBooking.Entities
{
    [Table("Uyeler")]
    public class Uye
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad " + ErrorMessages.RequiredField)]
        [StringLength(50, ErrorMessage = "Ad " + ErrorMessages.MaxLength50)]
        public string? Ad { get; set; }
        [Required(ErrorMessage = "Soyad " + ErrorMessages.RequiredField)]
        [StringLength(50, ErrorMessage = "Soyad " + ErrorMessages.MaxLength50)]
        public string? Soyad { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı " + ErrorMessages.RequiredField)]
        [StringLength(30, ErrorMessage = "Kullanıcı Adı " + ErrorMessages.MaxLength30)]
        public string KullaniciAdi { get; set; }
        [Required(ErrorMessage = "Telefon " + ErrorMessages.RequiredField)]
        [StringLength(15, ErrorMessage = "Şifre " + ErrorMessages.MaxLength15)]
        public string? Telefon { get; set; }

        [Required(ErrorMessage = "Email " + ErrorMessages.RequiredField)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre " + ErrorMessages.RequiredField)]
        [StringLength(100, ErrorMessage = "Şifre " + ErrorMessages.MaxLength100)]
        public string Sifre { get; set; }
        public bool Kilit { get; set; } = false;
        public bool Admin { get; set; } = false;
        public ICollection<Bilet> Biletler { get; set; }
    }
}

