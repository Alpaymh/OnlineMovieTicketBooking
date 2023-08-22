namespace OnlineMovieTicketBooking.Models
{
    public class TheaterModel
    {
        public int Id { get; set; }
        public string SalonAdi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public bool PopulerSalon { get; set; }
        public string Resim { get; set; }
        public double Fiyat { get; set; }
    }
}
