using AutoMapper;
using DoctorWho.Domain.Entities;
using DoctorWho.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Profiles
{
    public class EpisodeProfile : Profile
    {
        public EpisodeProfile()
        {
            CreateMap<Episode, EpisodeDTO>()
                .ForMember(episode=>episode.Doctor
                ,opt=>opt.MapFrom(episodeDTO=>episodeDTO.Doctor))
                .ForMember(episode => episode.Author
                , opt => opt.MapFrom(episodeDTO => episodeDTO.Author));
            CreateMap<EpisodeDTO, Episode>()
                .ForMember(episode => episode.Doctor
                ,opt => opt.MapFrom(episodeDTO => episodeDTO.Doctor))
                .ForMember(episode => episode.Author
                , opt => opt.MapFrom(episodeDTO => episodeDTO.Author));
        }

    }
}
