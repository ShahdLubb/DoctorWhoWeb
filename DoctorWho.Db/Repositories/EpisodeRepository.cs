using DoctorWho.Db.Entities;
using DoctorWho.Db.Interfaces.IReporitories;
using Microsoft.EntityFrameworkCore;
using System;

namespace DoctorWho.Db.Repositories
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly DoctorWhoCoreDbContext _context;
        public EpisodeRepository(DoctorWhoCoreDbContext contex)
        {
            _context = contex;
        }
        public void CreateEpisode(Episode episode)
        {
            _context.Episodes.Add(episode);
            _context.SaveChanges();
        }
        public Episode RetriveEpisode(int episodeId)
        {
            var episode = _context.Episodes.Include(episode => episode.Doctor).Include(episode => episode.Author).FirstOrDefault(episode=>episode.EpisodeId == episodeId);
            return episode;
        }
        public void UpdateEpisode(Episode episode)
        {
            _context.Episodes.Update(episode);
            _context.SaveChanges();
        }

        public void DeleteEpisode(int episodeId)
        {
            var episode = _context.Episodes.Find(episodeId);
            if (episode != null)
            {
                _context.Episodes.Remove(episode);
                _context.SaveChanges();
            }
        }
        public void AddEnemyToEpisode(Episode episode, Enemy enemy)
        {
            if (episode != null && enemy != null)
            {
                if (!episode.Enemies.Contains(enemy))
                {
                    episode.Enemies.Add(enemy);
                    _context.SaveChanges();
                }
            }
            else
            {
                throw new NullReferenceException($"Enemy and Episode can't be null");
            }
        }

        public void AddEnemyToEpisode(int episodeId, int enemyId)
        {
            var episode = RetriveEpisode(episodeId);
            var enemy = _context.Enemies.Find(enemyId);

            AddEnemyToEpisode(episode, enemy);
        }
        public void AddCompanionToEpisode(Episode episode, Companion companion)
        {
            if (episode != null && companion != null)
            {
                if (!episode.Companions.Contains(companion))
                {
                    episode.Companions.Add(companion);
                    _context.SaveChanges();
                }
            }
            else
            {
                throw new NullReferenceException($"Companion and Episode can't be null");
            }
        }
        public void AddCompanionToEpisode(int episodeId, int companionId)
        {
            var episode = RetriveEpisode(episodeId);
            var companion = _context.Companions.Find(companionId);

            AddCompanionToEpisode(episode, companion);
        }
        public List<Episode> GetAllEpisodes()
        {
         return _context.Episodes.Include(episode=>episode.Doctor).Include(episode=>episode.Author).ToList();
        }

    }
}
