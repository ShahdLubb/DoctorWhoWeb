using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho
{
    internal class Program
    {

        static void Main(string[] args)
        {
            ConnectExistingEpisodesAndEnemies();
            ConnectExistingEpisodesAndCompanions();
        }
        public static void ConnectExistingEpisodesAndEnemies()
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext(); //existing database
            var Episodes = _context.Episodes.ToList();
            var Enemies = _context.Enemies.ToList();
            Episodes[0].Enemies.Add(Enemies[0]);
            Episodes[1].Enemies.Add(Enemies[1]);
            Episodes[2].Enemies.Add(Enemies[2]);
            Episodes[3].Enemies.Add(Enemies[3]);
            Episodes[4].Enemies.Add(Enemies[4]);
            Episodes[5].Enemies.Add(Enemies[0]);
            Episodes[6].Enemies.Add(Enemies[4]);
            Episodes[7].Enemies.Add(Enemies[6]);
            Episodes[8].Enemies.Add(Enemies[5]);
            Episodes[9].Enemies.Add(Enemies[7]);
            var debugview = _context.ChangeTracker.DebugView.ShortView;
            _context.SaveChanges();
        }

        public static void ConnectExistingEpisodesAndCompanions()
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext(); //existing database
            var Episodes = _context.Episodes.ToList();
            var companions = _context.Companions.ToList();
            Episodes[0].Companions.Add(companions[0]);
            Episodes[1].Companions.Add(companions[1]);
            Episodes[2].Companions.Add(companions[2]);
            Episodes[3].Companions.Add(companions[3]);
            Episodes[4].Companions.Add(companions[4]);
            Episodes[5].Companions.Add(companions[0]);
            Episodes[6].Companions.Add(companions[1]);
            Episodes[7].Companions.Add(companions[5]);
            Episodes[8].Companions.Add(companions[6]);
            Episodes[9].Companions.Add(companions[2]);
            var debugview = _context.ChangeTracker.DebugView.ShortView;
            _context.SaveChanges();
        }
    }
}