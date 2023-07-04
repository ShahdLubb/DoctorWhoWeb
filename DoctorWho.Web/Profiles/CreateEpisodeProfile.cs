using AutoMapper;
using DoctorWho.Domain.Entities;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Profiles
{
    public class CreateEpisodeProfile : Profile
    {
        public CreateEpisodeProfile()
        {
            CreateMap<Episode, CreateEpisodeDTO>();
            CreateMap<CreateEpisodeDTO, Episode>();
        }
    }
}
