using AutoMapper;
using ContactAPI.Entities;
using ContactAPI.Models.DTOs;

namespace ContactAPI.Profiles
{
    public class ContactProfile : Profile
    {
       public ContactProfile()
        {
            CreateMap<CreateContact, Contact>();
        }
    }
}
