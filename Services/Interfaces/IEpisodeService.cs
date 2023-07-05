using DoctorWho.Domain.Entities;

namespace DoctorWho.Services.Interfaces
{
    public interface IEpisodeService
    {
        Episode CreateEpisode(Episode episode);
        bool DeleteEpisode(int EpisodeId);
        List<Episode> GetAllEpisodes();
        Episode GetEpisode(int EpisodeId);
        Episode GetEpisodeByNumberAndSeries(int EpisodeNumber, int SeriesNumber);
        void UpdateEpisode(Episode episode);
        void AddEnemyToEpisode(Episode episode, Enemy enemy);
        void AddCompanionToEpisode(Episode episode, Companion companion);
    }
}