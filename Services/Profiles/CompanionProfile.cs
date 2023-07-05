using AutoMapper;


namespace DoctorWho.Services.Profiles
{
    public class CompanionProfile : Profile
    {
        public CompanionProfile()
        {
            CreateMap<Db.Entities.Companion, Domain.Entities.Companion>();
            CreateMap<Domain.Entities.Companion, Db.Entities.Companion>();
        }
    }
}
