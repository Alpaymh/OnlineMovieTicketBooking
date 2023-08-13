using OnlineMovieTicketBooking.Helpers;
using System.ComponentModel.DataAnnotations;

namespace OnlineMovieTicketBooking.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı " + ErrorMessages.RequiredField)]
        [StringLength(30, ErrorMessage = "Kullanıcı Adı " + ErrorMessages.MaxLength30)]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Şifre " + ErrorMessages.RequiredField)]
        [StringLength(100, ErrorMessage = "Şifre " + ErrorMessages.MaxLength100)]
        public string Sifre { get; set; }
    }
}
