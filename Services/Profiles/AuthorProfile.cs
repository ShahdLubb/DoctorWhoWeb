using AutoMapper;


namespace DoctorWho.Services.Profiles
{
    public class AuthorProfile:Profile
    {
        public AuthorProfile()
        {
            CreateMap<Db.Entities.Author, Domain.Entities.Author>();
            CreateMap<Domain.Entities.Author, Db.Entities.Author>();
        }
    }
}
