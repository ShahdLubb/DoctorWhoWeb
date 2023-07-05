using DoctorWho.Db.Entities;
using DoctorWho.Db.Entities;
namespace DoctorWho.Db.Interfaces.IReporitories
{
    public interface IEnemyRepository
    {
        void CreateEnemy(Enemy enemy);
        void DeleteEnemy(int enemyId);
        Enemy RetriveEnemy(int enemyId);
        void UpdateEnemy(Enemy enemy);
    }
}