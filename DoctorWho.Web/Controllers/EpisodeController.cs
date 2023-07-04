using AutoMapper;
using DoctorWho.Db.Repositories;
using DoctorWho.Domain.Entities;
using DoctorWho.Domain.Interfaces.IReporitories;
using DoctorWho.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [Route("api/episodes")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IEnemyRepository _enemyRepository;
        private readonly ICompanionRepository _companionRepository;
        private readonly IMapper _mapper;
        public EpisodeController(IEpisodeRepository episodeRepository,
            IDoctorRepository doctorRepository, 
            IAuthorRepository authorRepository,
            IEnemyRepository enemyRepository,
            ICompanionRepository companionRepository,
            IMapper mapper) {
            _episodeRepository = episodeRepository;
            _doctorRepository = doctorRepository;
            _authorRepository = authorRepository;
            _enemyRepository = enemyRepository;
            _companionRepository= companionRepository;
            _mapper = mapper;
            

        }
        [HttpGet("{EpisodeId}", Name = "GetAnEpisode")]
        public ActionResult GetEpisode(int EpisodeId) {
            var episode = _episodeRepository.RetriveEpisode(EpisodeId);
            if (episode == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mapper.Map<EpisodeDTO>(episode));
            }

        }
        [HttpGet]
        public ActionResult<List<EpisodeDTO>> GetAllEpisodes()
        {
            var episodes = _episodeRepository.GetAllEpisodes();
            return Ok(_mapper.Map<IEnumerable<EpisodeDTO>>(episodes));
        }

        [HttpPost]
        public IActionResult CreateEpisode([FromBody] CreateEpisodeDTO toCreateEpisode)
        {
            // check if Episode already exists
            Episode? exsistingEpisode = _episodeRepository.GetAllEpisodes()
                                                         .FirstOrDefault(e=>(e.EpisodeNumber==toCreateEpisode.EpisodeNumber) 
                                                          && (e.SeriesNumber==toCreateEpisode.SeriesNumber));
            if(exsistingEpisode != null)
            {
                return BadRequest($"Episode number '{toCreateEpisode.EpisodeNumber}' in series number'{toCreateEpisode.SeriesNumber}' already exists!");
            }
            // check id doctor and author exists by their Id
            var doctor = _doctorRepository.RetriveDoctor(toCreateEpisode.DoctorId);
            var author = _authorRepository.RetriveAuthor(toCreateEpisode.AuthorId);
            if(doctor== null && author==null) {
                return BadRequest("both doctor and author don't exist");
            }
            else if (doctor == null)
            {
                return BadRequest("doctor doesn't exist");
            }
            else if(author == null)
            {
                return BadRequest("author doesn't exist");
            }

            //Creating the episode
            Episode episode = _mapper.Map<Episode>(toCreateEpisode);
            _episodeRepository.CreateEpisode(episode);
            var RouteValues = new { EpisodeId = episode.EpisodeId };
            return CreatedAtRoute("GetAnEpisode", RouteValues, _mapper.Map<EpisodeDTO>(episode));

        }
        [HttpPost("AddEnemyToEpisode")]
        public ActionResult AddEnemyToEpisode([FromBody] AddEnemyToEpisodeDTO enemyToEpisode)
        {
            var episode = _episodeRepository.RetriveEpisode(enemyToEpisode.EpisodeId);
            var enemy=_enemyRepository.RetriveEnemy(enemyToEpisode.EnemyId);
            if(episode == null && enemy == null)
            {
                return BadRequest("episode and enemy don't exist");
            }
            else if(episode == null)
            {
                return BadRequest("episode  doesn't exist");
            }
            else if (enemy == null)
            {
                return BadRequest("enemy doesn't exist");
            }
            else
            {
                _episodeRepository.AddEnemyToEpisode(episode, enemy);
                return Ok();
            }

        }
        [HttpPost("AddCompanionToEpisode")]
        public ActionResult AddCompanionToEpisode([FromBody] AddCompanionToEpisodeDTO CompanionToEpisode)
        {
            var episode = _episodeRepository.RetriveEpisode(CompanionToEpisode.EpisodeId);
            var Companion = _companionRepository.RetriveCompanion(CompanionToEpisode.CompanionId);
            if (episode == null && Companion == null)
            {
                return BadRequest("episode and Companion don't exist");
            }
            else if (episode == null)
            {
                return BadRequest("episode  doesn't exist");
            }
            else if (Companion == null)
            {
                return BadRequest("Companion doesn't exist");
            }
            else
            {
                _episodeRepository.AddCompanionToEpisode(episode, Companion);
                return Ok();
            }

        }
    }
}
