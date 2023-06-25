using DoctorWho.Domain.Entities;

namespace DoctorWho.Domain.Interfaces.IReporitories
{
    public interface IEnemyRepository
    {
        void CreateEnemy(Enemy enemy);
        void DeleteEnemy(int enemyId);
        Enemy RetriveEnemy(int enemyId);
        void UpdateEnemy(Enemy enemy);
    }
}