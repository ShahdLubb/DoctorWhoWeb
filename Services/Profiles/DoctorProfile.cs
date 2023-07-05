using AutoMapper;


namespace DoctorWho.Services.Profiles
{
    public class DoctorProfile:Profile
    {
        public DoctorProfile() {
            CreateMap<Db.Entities.Doctor, Domain.Entities.Doctor>();
            CreateMap<Domain.Entities.Doctor, Db.Entities.Doctor>();
        }
    }
}
