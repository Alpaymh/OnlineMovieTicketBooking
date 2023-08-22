using OnlineMovieTicketBooking.Helpers;
using System.ComponentModel.DataAnnotations;

namespace OnlineMovieTicketBooking.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string KategoriAdi { get; set; }
        public string FilmAdi { get; set; }
        public string Resim { get; set; }
        public string Dil { get; set; }
        public string Aciklama { get; set; }
        public bool AktifMi { get; set; } = false;
    }

    public class CreateMovieModel
    {
        public int KategoriID { get; set; }
        [StringLength(50, ErrorMessage = "Film Adı " + ErrorMessages.MaxLength50)]
        [Required(ErrorMessage = "Film Adı " + ErrorMessages.RequiredField)]
        public string FilmAdi { get; set; }
        [StringLength(50, ErrorMessage = "Resim " + ErrorMessages.MaxLength50)]
        [Required(ErrorMessage = "Resim " + ErrorMessages.RequiredField)]
        public string Resim { get; set; }
        [StringLength(30, ErrorMessage = "Dil " + ErrorMessages.MaxLength30)]
        [Required(ErrorMessage = "Dil " + ErrorMessages.RequiredField)]
        public string Dil { get; set; }
        [Required(ErrorMessage = "Açıklama " + ErrorMessages.RequiredField)]
        public string Aciklama { get; set; }
    }

    public class EditMovieModel : CreateMovieModel
    {
        public bool AktifMi { get; set; } = false;
    }
}
