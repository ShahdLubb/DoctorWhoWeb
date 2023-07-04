using DoctorWho.Domain.Entities;

namespace DoctorWho.Domain.Interfaces.IReporitories
{
    public interface IEpisodeRepository
    {
        void AddCompanionToEpisode(Episode episode, Companion companion);
        void AddCompanionToEpisode(int episodeId, int companionId);
        void AddEnemyToEpisode(Episode episode, Enemy enemy);
        void AddEnemyToEpisode(int episodeId, int enemyId);
        void CreateEpisode(Episode episode);
        void DeleteEpisode(int episodeId);
        Episode RetriveEpisode(int episodeId);
        void UpdateEpisode(Episode episode);
         List<Episode> GetAllEpisodes();
    }
}