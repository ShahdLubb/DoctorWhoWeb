using DoctorWho.Domain.Entities;

namespace DoctorWho.Services.Interfaces
{
    public interface IEnemyService
    {
        Enemy GetEnemy(int EnemyId);
    }
}