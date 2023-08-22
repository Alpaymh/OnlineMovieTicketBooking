using OnlineMovieTicketBooking.Helpers;
using System.ComponentModel.DataAnnotations;

namespace OnlineMovieTicketBooking.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string KategoriAdi { get; set; }
        public string FilmAdi { get; set; }
        public string Resim { get; set; }
        public string Dil { get; set; }
        public string Aciklama { get; set; }
        public bool AktifMi { get; set; }
    }
}
