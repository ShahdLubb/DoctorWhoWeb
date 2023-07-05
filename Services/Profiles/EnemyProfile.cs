using AutoMapper;


namespace DoctorWho.Services.Profiles
{
    public class EnemyProfile : Profile
    {
        public EnemyProfile()
        {
            CreateMap<Db.Entities.Enemy, Domain.Entities.Enemy>();
            CreateMap<Domain.Entities.Enemy, Db.Entities.Enemy>();
        }
    }
}
