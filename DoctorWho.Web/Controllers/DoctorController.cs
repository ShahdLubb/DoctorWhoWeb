using AutoMapper;
using DoctorWho.Domain.Interfaces.IReporitories;
using DoctorWho.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDoctorRepository _doctorRepository;
        public DoctorController(IMapper mapper, IDoctorRepository doctorRepository) {
            _mapper = mapper;
            _doctorRepository=doctorRepository;
        }
        [HttpGet]
        public ActionResult<List<DoctorDTO>> GetAllDoctors() {
            var Doctors = _doctorRepository.GetAllDoctors();
            return Ok(_mapper.Map<IEnumerable<DoctorDTO>>(Doctors));
        }
    }
}
