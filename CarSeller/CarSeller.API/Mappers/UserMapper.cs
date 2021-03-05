using AutoMapper;
using CarSeller.Entities.Models;
using CarSeller.Entities.ViewModels;

namespace CarSeller.API.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            this.CreateMap<RegisterViewModel, User>();
            this.CreateMap<User, RegisterViewModel>();
        }
    }
}
