using AutoMapper;
using DoctorWho.Domain.Entities;
using DoctorWho.Services.Interfaces;
using DoctorWho.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDoctorService _doctorService;
        public DoctorController(IMapper mapper, IDoctorService doctorService) {
            _mapper = mapper;
            _doctorService=doctorService;
        }
        [HttpGet("{DoctorId}",Name ="GetADoctor")]
        public ActionResult<DoctorDTO> GetDoctor(int DoctorId)
        {
            var Doctor = _doctorService.GetDoctor(DoctorId);
            if (Doctor == null)
            {
                return NotFound();
            }
            else
            { 
                return Ok(_mapper.Map<DoctorDTO>(Doctor));
            }
        }

        [HttpGet]
        public ActionResult<List<DoctorDTO>> GetAllDoctors() {
            var Doctors = _doctorService.GetAllDoctors();
            return Ok(_mapper.Map<IEnumerable<DoctorDTO>>(Doctors));
        }

        [HttpPut]
        public ActionResult<DoctorDTO> UpsertDoctor([FromBody]DoctorDTO doctor)
        {
            var existingDoctor = _doctorService.GetDoctorByName(doctor.DoctorName);
            Doctor recivedDoctor = _mapper.Map<Doctor>(doctor);
            if (existingDoctor == null)
            {
                // Doctor does not exist, create a new one
               var createdDoctor= _doctorService.CreateDoctor(recivedDoctor);
                var RouteValues = new { DoctorId = createdDoctor.DoctorId };
                return CreatedAtRoute("GetADoctor", RouteValues, _mapper.Map<DoctorDTO>(createdDoctor));
            }
            else
            {
                // Doctor exists, update the properties
                existingDoctor.DoctorName = recivedDoctor.DoctorName;
                existingDoctor.DoctorNumber = recivedDoctor.DoctorNumber;
                existingDoctor.BirthDate = recivedDoctor.BirthDate;
                existingDoctor.FirstEpisodeDate = recivedDoctor.FirstEpisodeDate;
                existingDoctor.LastEpisodeDate = recivedDoctor.LastEpisodeDate;
                _doctorService.UpdateDoctor(existingDoctor);
                return Ok(_mapper.Map<DoctorDTO>(existingDoctor));
            }
        }
        [HttpDelete("{DoctorId}")]
        public IActionResult DeleteDoctor(int DoctorId)
        {
            var doctor = _doctorService.GetDoctor(DoctorId);
            if (doctor == null)
            {
                return NotFound();
            }

            _doctorService.DeleteDoctor(doctor.DoctorId);
            return NoContent();
        }
    }
}
