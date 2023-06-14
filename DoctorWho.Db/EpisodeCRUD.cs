using DoctorWho.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db
{
    public static class EpisodeCRUD
    {
        public static void CreateEpisode(Episode episode)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            _context.Episodes.Add(episode);
            _context.SaveChanges();
        }
        public static Episode RetriveEpisode(int episodeId)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            var episode = _context.Episodes.Find(episodeId);
            return episode;
        }
        public static void UpdateEpisode(Episode episode)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            _context.Episodes.Update(episode);
            _context.SaveChanges();
        }

        public static void DeleteEpisode(int episodeId)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            var episode = _context.Episodes.Find(episodeId);
            if (episode != null)
            {
                _context.Episodes.Remove(episode);
                _context.SaveChanges();
            }
        }
    }
}
