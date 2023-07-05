using AutoMapper;
namespace DoctorWho.Services.Profiles
{
    public class EpisodeProfile : Profile
    {
        public EpisodeProfile()
        {
            CreateMap<Db.Entities.Episode, Domain.Entities.Episode>()
                .ForMember(episode=>episode.Doctor
                ,opt=>opt.MapFrom(episodeDTO=>episodeDTO.Doctor))
                .ForMember(episode => episode.Author
                , opt => opt.MapFrom(episodeDTO => episodeDTO.Author))
                .ForMember(episode => episode.Companions
                , opt => opt.MapFrom(episodeDTO => episodeDTO.Companions))
                .ForMember(episode => episode.Enemies
                , opt => opt.MapFrom(episodeDTO => episodeDTO.Enemies));

            CreateMap<Domain.Entities.Episode, Db.Entities.Episode>()
                .ForMember(episode => episode.Doctor
                ,opt => opt.MapFrom(episodeDTO => episodeDTO.Doctor))
                .ForMember(episode => episode.Author
                , opt => opt.MapFrom(episodeDTO => episodeDTO.Author))
                .ForMember(episode => episode.Companions
                , opt => opt.MapFrom(episodeDTO => episodeDTO.Companions))
                .ForMember(episode => episode.Enemies
                , opt => opt.MapFrom(episodeDTO => episodeDTO.Enemies));
        }

    }
}
