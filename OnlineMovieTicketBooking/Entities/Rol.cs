using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMovieTicketBooking.Entities
{
    [Table("Roller")]
    public class Rol
    {
        public int Id { get; set; }
        public string RolAdi { get; set; }

        public ICollection<Uye> Uyeler { get; set; }
    }
}
