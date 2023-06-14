using DoctorWho.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db
{
    public static class EnemyCRUD
    {
        public static void CreateEnemy(Enemy enemy)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            _context.Enemies.Add(enemy);
            _context.SaveChanges();
        }
        public static Enemy RetriveDoctor(int enemyId)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            var enemy = _context.Enemies.Find(enemyId);
            return enemy;
        }
        public static void UpdateDoctor(Enemy enemy)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            _context.Enemies.Update(enemy);
            _context.SaveChanges();
        }

        public static void DeleteDoctor(int enemyId)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            var enemy = _context.Enemies.Find(enemyId);
            if (enemy != null)
            {
                _context.Enemies.Remove(enemy);
                _context.SaveChanges();
            }
        }
    }
}
