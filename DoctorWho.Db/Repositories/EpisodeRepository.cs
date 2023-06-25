using DoctorWho.Domain.Entities;
using DoctorWho.Domain.Interfaces.IReporitories;
namespace DoctorWho.Db.Repositories
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly DoctorWhoCoreDbContext _context;
        public EpisodeRepository()
        {
            _context = new DoctorWhoCoreDbContext();
        }
        public void CreateEpisode(Episode episode)
        {
            _context.Episodes.Add(episode);
            _context.SaveChanges();
        }
        public Episode RetriveEpisode(int episodeId)
        {
            var episode = _context.Episodes.Find(episodeId);
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
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            if (episode != null && enemy != null)
            {
                episode.Enemies.Add(enemy);
                _context.SaveChanges();
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

            if (episode != null && enemy != null)
            {
                episode.Enemies.Add(enemy);
                _context.SaveChanges();
            }
        }
        public void AddCompanionToEpisode(Episode episode, Companion companion)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            if (episode != null && companion != null)
            {
                episode.Companions.Add(companion);
                _context.SaveChanges();
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

            if (episode != null && companion != null)
            {
                episode.Companions.Add(companion);
                _context.SaveChanges();
            }
        }

    }
}
