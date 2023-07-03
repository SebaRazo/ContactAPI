using AutoMapper;
using ContactAPI.Entities;
using ContactAPI.Models.DTOs;

namespace ContactAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
                CreateMap<User, CreateUser>();
                CreateMap<User, GetUserByIdReponse>();

                CreateMap<CreateUser, User>();
        }
    }
}

