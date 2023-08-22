using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMovieTicketBooking.Entities
{
    [Table("Kategoriler")]
    public class Kategori
    {
        public int Id { get; set; }
        public string KategoriAdi { get; set; }
        public ICollection<Film> Filmler { get; set; }
    }
}
