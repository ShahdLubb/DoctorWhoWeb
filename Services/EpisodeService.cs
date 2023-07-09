using AutoMapper;
using DoctorWho.Db.Interfaces.IReporitories;
using DoctorWho.Domain.Entities;
using DoctorWho.Domain.Interfaces;

namespace DoctorWho.Services
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IMapper _mapper;
        public EpisodeService(IEpisodeRepository episodeRepository, IMapper mapper)
        {
            _episodeRepository = episodeRepository;
            _mapper = mapper;
        }
        public Episode GetEpisode(int EpisodeId)
        {
            var Episode = _episodeRepository.RetriveEpisode(EpisodeId);
            return _mapper.Map<Episode>(Episode);

        }
        public Episode GetEpisodeByNumberAndSeries(int EpisodeNumber, int SeriesNumber)
        {
            var Episode = _episodeRepository.GetAllEpisodes()
                                            .FirstOrDefault(e => (e.EpisodeNumber == EpisodeNumber)
                                             && (e.SeriesNumber == SeriesNumber)); ;
            return _mapper.Map<Episode>(Episode);

        }

        public List<Episode> GetAllEpisodes()
        {
            var Episodes = _episodeRepository.GetAllEpisodes();
            return _mapper.Map<IEnumerable<Episode>>(Episodes).ToList();
        }
        public bool DeleteEpisode(int EpisodeId)
        {
            var episode = _episodeRepository.RetriveEpisode(EpisodeId);
            if (episode == null)
            {
                return false;
            }

            _episodeRepository.DeleteEpisode(episode.EpisodeId);
            return true;
        }

        public Episode CreateEpisode(Episode episode)
        {
            var recivedEpisode = _mapper.Map<Db.Entities.Episode>(episode);
            _episodeRepository.CreateEpisode(recivedEpisode);
            return _mapper.Map<Episode>(recivedEpisode);
        }

        public void UpdateEpisode(Episode episode)
        {
            var existingEpisode = _mapper.Map<Db.Entities.Episode>(episode);
            _episodeRepository.UpdateEpisode(existingEpisode);
        }
        public void AddEnemyToEpisode(Episode episode,Enemy enemy)
        {
            _episodeRepository.AddEnemyToEpisode(episode.EpisodeId,enemy.EnemyId);

        }
        public void AddCompanionToEpisode(Episode episode, Companion companion)
        {
            _episodeRepository.AddEnemyToEpisode(episode.EpisodeId, companion.CompanionId);

        }
    }
}
