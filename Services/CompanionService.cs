using AutoMapper;
using DoctorWho.Db.Interfaces.IReporitories;
using DoctorWho.Domain.Entities;
using DoctorWho.Services.Interfaces;


namespace DoctorWho.Services
{
    public class CompanionService : ICompanionService
    {
        private readonly ICompanionRepository _companionRepository;
        private readonly IMapper _mapper;
        public CompanionService(ICompanionRepository companionRepository, IMapper mapper)
        {
            _companionRepository = companionRepository;
            _mapper = mapper;
        }
        public Companion GetCompanion(int CompanionId)
        {
            var Companion = _companionRepository.RetriveCompanion(CompanionId);
            return _mapper.Map<Companion>(Companion);

        }
    }
}
