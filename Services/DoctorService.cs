using AutoMapper;
using DoctorWho.Db.Interfaces.IReporitories;
using DoctorWho.Domain.Entities;
using DoctorWho.Services.Interfaces;

namespace DoctorWho.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }
        public Doctor GetDoctor(int DoctorId)
        {
            var Doctor = _doctorRepository.RetriveDoctor(DoctorId);
            return _mapper.Map<Doctor>(Doctor);

        }
        public Doctor GetDoctorByName(String DoctorName)
        {
            var Doctor = _doctorRepository.GetAllDoctors().FirstOrDefault(d => d.DoctorName.Equals(DoctorName));
            return _mapper.Map<Doctor>(Doctor);

        }

        public List<Doctor> GetAllDoctors()
        {
            var Doctors = _doctorRepository.GetAllDoctors();
            return _mapper.Map<IEnumerable<Doctor>>(Doctors).ToList();
        }
        public bool DeleteDoctor(int DoctorId)
        {
            var doctor = _doctorRepository.RetriveDoctor(DoctorId);
            if (doctor == null)
            {
                return false;
            }

            _doctorRepository.DeleteDoctor(doctor.DoctorId);
            return true;
        }

        public Doctor CreateDoctor(Doctor doctor)
        {
            var recivedDoctor = _mapper.Map<Db.Entities.Doctor>(doctor);
            _doctorRepository.CreateDoctor(recivedDoctor);
            return _mapper.Map<Doctor>(recivedDoctor);
        }

        public void UpdateDoctor(Doctor doctor)
        {
            var existingDoctor = _mapper.Map<Db.Entities.Doctor>(doctor);
            _doctorRepository.UpdateDoctor(existingDoctor);
        }
    }
}