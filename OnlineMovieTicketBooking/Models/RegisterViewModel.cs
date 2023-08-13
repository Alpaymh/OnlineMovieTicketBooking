using OnlineMovieTicketBooking.Helpers;
using System.ComponentModel.DataAnnotations;

namespace OnlineMovieTicketBooking.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ad " + ErrorMessages.RequiredField)]
        [StringLength(50, ErrorMessage = "Ad " + ErrorMessages.MaxLength50)]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Soyad " + ErrorMessages.RequiredField)]
        [StringLength(50, ErrorMessage = "Soyad " + ErrorMessages.MaxLength50)]
        public string Soyad { get; set; }

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

        [Required(ErrorMessage = "Şifre Tekrarı " + ErrorMessages.RequiredField)]
        [StringLength(100, ErrorMessage = "Şifre Tekrarı " + ErrorMessages.MaxLength100)]
        [Compare(nameof(Sifre), ErrorMessage = "Şifreler Uyuşmuyor.")]
        public string TekrarSifre { get; set; }
    }
}
