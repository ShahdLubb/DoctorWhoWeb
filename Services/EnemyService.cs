using AutoMapper;
using DoctorWho.Db.Interfaces.IReporitories;
using DoctorWho.Domain.Entities;
using DoctorWho.Services.Interfaces;

namespace DoctorWho.Services
{
    public class EnemyService : IEnemyService
    {
        private readonly IEnemyRepository _enemyRepository;
        private readonly IMapper _mapper;
        public EnemyService(IEnemyRepository enemyRepository, IMapper mapper)
        {
            _enemyRepository = enemyRepository;
            _mapper = mapper;
        }
        public Enemy GetEnemy(int EnemyId)
        {
            var Enemy = _enemyRepository.RetriveEnemy(EnemyId);
            return _mapper.Map<Enemy>(Enemy);

        }
    }
}
