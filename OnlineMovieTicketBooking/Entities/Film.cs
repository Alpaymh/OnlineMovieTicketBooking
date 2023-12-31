﻿using OnlineMovieTicketBooking.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineMovieTicketBooking.Entities
{
    [Table("Filmler")]
    public class Film
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Film Adı " + ErrorMessages.MaxLength50)]
        [Required(ErrorMessage = "Film Adı " + ErrorMessages.RequiredField)]
        public int KategoriID { get; set; }
        public string FilmAdi { get; set; }
        [StringLength(50, ErrorMessage = "Resim " + ErrorMessages.MaxLength50)]
        [Required(ErrorMessage = "Resim " + ErrorMessages.RequiredField)]
        public string Resim { get; set; }
        [StringLength(30, ErrorMessage = "Dil " + ErrorMessages.MaxLength30)]
        [Required(ErrorMessage = "Dil " + ErrorMessages.RequiredField)]
        public string Dil { get; set; }
        [Required(ErrorMessage = "Açıklama " + ErrorMessages.RequiredField)]
        public string Aciklama { get; set; }
        public bool AktifMi { get; set; } = false;
        public Kategori Kategori { get; set; }

    }
}
