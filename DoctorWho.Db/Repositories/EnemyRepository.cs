using DoctorWho.Db.Entities;
using DoctorWho.Db.Interfaces.IReporitories;
namespace DoctorWho.Db.Repositories
{
    public class EnemyRepository : IEnemyRepository
    {
        private readonly DoctorWhoCoreDbContext _context;
        public EnemyRepository(DoctorWhoCoreDbContext contex)
        {
            _context = contex;
        }
        public void CreateEnemy(Enemy enemy)
        {
            _context.Enemies.Add(enemy);
            _context.SaveChanges();
        }
        public Enemy RetriveEnemy(int enemyId)
        {
            var enemy = _context.Enemies.Find(enemyId);
            return enemy;
        }
        public void UpdateEnemy(Enemy enemy)
        {
            _context.Enemies.Update(enemy);
            _context.SaveChanges();
        }

        public void DeleteEnemy(int enemyId)
        {
            var enemy = _context.Enemies.Find(enemyId);
            if (enemy != null)
            {
                _context.Enemies.Remove(enemy);
                _context.SaveChanges();
            }
        }
    }
}
