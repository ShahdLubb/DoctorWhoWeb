using AutoMapper;
using DoctorWho.Domain.Entities;
using DoctorWho.Web.Models;
using Microsoft.AspNetCore.Mvc;
using DoctorWho.Domain.Interfaces;

namespace DoctorWho.Web.Controllers
{
    [Route("api/episodes")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private readonly IEpisodeService _episodeService;
        private readonly IDoctorService _doctorService;
        private readonly IAuthorService _authorService;
        private readonly IEnemyService _enemyService;
        private readonly ICompanionService _companionService;
        private readonly IMapper _mapper;
        public EpisodeController(IEpisodeService episodeService,
            IDoctorService doctorService, 
            IAuthorService authorService,
            IEnemyService enemyService,
            ICompanionService companionService,
            IMapper mapper) {
            _episodeService = episodeService;
            _doctorService = doctorService;
            _authorService = authorService;
            _enemyService = enemyService;
            _companionService= companionService;
            _mapper = mapper;
            

        }
        [HttpGet("{EpisodeId}", Name = "GetAnEpisode")]
        public ActionResult GetEpisode(int EpisodeId) {
            var episode = _episodeService.GetEpisode(EpisodeId);
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
            var episodes = _episodeService.GetAllEpisodes();
            return Ok(_mapper.Map<IEnumerable<EpisodeDTO>>(episodes));
        }

        [HttpPost]
        public IActionResult CreateEpisode([FromBody] CreateEpisodeDTO toCreateEpisode)
        {
            // check if Episode already exists
            Episode? exsistingEpisode = _episodeService.GetEpisodeByNumberAndSeries(
                toCreateEpisode.EpisodeNumber, toCreateEpisode.SeriesNumber);

            if(exsistingEpisode != null)
            {
                return BadRequest($"Episode number '{toCreateEpisode.EpisodeNumber}' in series number'{toCreateEpisode.SeriesNumber}' already exists!");
            }
            // check id doctor and author exists by their Id
            var doctor = _doctorService.GetDoctor(toCreateEpisode.DoctorId);
            var author = _authorService.GetAuthor(toCreateEpisode.AuthorId);
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
            var createdEpisode=_episodeService.CreateEpisode(episode);
            var RouteValues = new { EpisodeId = createdEpisode.EpisodeId };
            return CreatedAtRoute("GetAnEpisode", RouteValues, _mapper.Map<EpisodeDTO>(createdEpisode));

        }
        [HttpPost("AddEnemyToEpisode")]
        public ActionResult AddEnemyToEpisode([FromBody] AddEnemyToEpisodeDTO enemyToEpisode)
        {
            var episode = _episodeService.GetEpisode(enemyToEpisode.EpisodeId);
            var enemy=_enemyService.GetEnemy(enemyToEpisode.EnemyId);
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
                _episodeService.AddEnemyToEpisode(episode, enemy);
                return Ok();
            }

        }
        [HttpPost("AddCompanionToEpisode")]
        public ActionResult AddCompanionToEpisode([FromBody] AddCompanionToEpisodeDTO CompanionToEpisode)
        {
            var episode = _episodeService.GetEpisode(CompanionToEpisode.EpisodeId);
            var Companion = _companionService.GetCompanion(CompanionToEpisode.CompanionId);
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
                _episodeService.AddCompanionToEpisode(episode, Companion);
                return Ok();
            }

        }
    }
}
