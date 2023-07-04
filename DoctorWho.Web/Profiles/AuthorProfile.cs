using AutoMapper;
using DoctorWho.Domain.Entities;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Profiles
{
    public class AuthorProfile:Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorDTO, Author>();
        }
    }
}
