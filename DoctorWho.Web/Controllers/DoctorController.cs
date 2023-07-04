using AutoMapper;
using DoctorWho.Domain.Entities;
using DoctorWho.Domain.Interfaces.IReporitories;
using DoctorWho.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

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
        [HttpGet("{DoctorId}",Name ="GetADoctor")]
        public ActionResult<DoctorDTO> GetDoctor(int DoctorId)
        {
            var Doctor = _doctorRepository.RetriveDoctor(DoctorId);
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
            var Doctors = _doctorRepository.GetAllDoctors();
            return Ok(_mapper.Map<IEnumerable<DoctorDTO>>(Doctors));
        }

        [HttpPut]
        public ActionResult<DoctorDTO> UpsertDoctor([FromBody]DoctorDTO doctor)
        {
            var existingDoctor = _doctorRepository.GetAllDoctors().FirstOrDefault(d => d.DoctorName == doctor.DoctorName);
            Doctor recivedDoctor = _mapper.Map<Doctor>(doctor);
            if (existingDoctor == null)
            {
                // Doctor does not exist, create a new one
                _doctorRepository.CreateDoctor(recivedDoctor);
                var RouteValues = new { DoctorId = recivedDoctor.DoctorId };
                return CreatedAtRoute("GetADoctor", RouteValues, _mapper.Map<DoctorDTO>(recivedDoctor));
            }
            else
            {
                // Doctor exists, update the properties
                existingDoctor.DoctorName = recivedDoctor.DoctorName;
                existingDoctor.DoctorNumber = recivedDoctor.DoctorNumber;
                existingDoctor.BirthDate = recivedDoctor.BirthDate;
                existingDoctor.FirstEpisodeDate = recivedDoctor.FirstEpisodeDate;
                existingDoctor.LastEpisodeDate = recivedDoctor.LastEpisodeDate;
                _doctorRepository.UpdateDoctor(existingDoctor);
                return Ok(_mapper.Map<DoctorDTO>(existingDoctor));
            }
        }
        [HttpDelete("{DoctorId}")]
        public IActionResult DeleteDoctor(int DoctorId)
        {
            var doctor = _doctorRepository.RetriveDoctor(DoctorId);
            if (doctor == null)
            {
                return NotFound();
            }

            _doctorRepository.DeleteDoctor(doctor.DoctorId);
            return NoContent();
        }
    }
}
