using AutoMapper;
using DoctorWho.Domain.Entities;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Profiles
{
    public class DoctorProfile:Profile
    {
        public DoctorProfile() {
            CreateMap<Doctor, DoctorDTO>();
        }
    }
}
