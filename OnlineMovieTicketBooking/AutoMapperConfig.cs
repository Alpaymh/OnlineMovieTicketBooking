using AutoMapper;
using OnlineMovieTicketBooking.Entities;
using OnlineMovieTicketBooking.Models;

namespace OnlineMovieTicketBooking
{
    //AutoMapper özelliğini kullanmak için Profile'i miras alıyoruz.
    public class AutoMapperConfig:Profile 
    {
        public AutoMapperConfig()
        {
            //Uye listesini UserModel listesine çevir demiş oluyoruz.(Öğretmiş oluyoruz.)
            //Reverse Map fonksiyonu ile de tersini de çevirmeyi öğren diyoruz.
            CreateMap<Uye, UserModel>().ReverseMap();
            CreateMap<Uye, CreateUserModel>().ReverseMap();
            CreateMap<Uye, EditUserModel>().ReverseMap();
            CreateMap<Film, CreateMovieModel>().ReverseMap();
            CreateMap<Film, EditMovieModel>().ReverseMap();
            CreateMap<SinemaSalonu, CinemaModel>().ReverseMap();
            CreateMap<SinemaSalonu, CreateCinemaModel>().ReverseMap();
            CreateMap<SinemaSalonu, EditCinemaModel>().ReverseMap();
            CreateMap<Seans, EditSessionModel>().ReverseMap();
            CreateMap<Siparis, EditOrderModel>().ReverseMap();



        }

    }
}
