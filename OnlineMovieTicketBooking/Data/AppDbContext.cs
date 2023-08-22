using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineMovieTicketBooking.Entities;

namespace OnlineMovieTicketBooking.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Uye> Uyeler { get; set; }
        public virtual DbSet<SinemaSalonu> SinemaSalonlari { get; set; }
        public virtual DbSet<Film> Filmler { get; set; }
        public virtual DbSet<Seans> Seanslar { get; set; }
        public virtual DbSet<Siparis> Siparişler { get; set; }
        public virtual DbSet<Rol> Roller { get; set; }
        public virtual DbSet<Kategori> Kategoriler { get; set; }

    }
}
