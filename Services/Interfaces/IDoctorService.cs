using DoctorWho.Domain.Entities;

namespace DoctorWho.Services.Interfaces
{
    public interface IDoctorService
    {
        Doctor CreateDoctor(Doctor doctor);
        bool DeleteDoctor(int DoctorId);
        List<Doctor> GetAllDoctors();
        Doctor GetDoctor(int DoctorId);
        void UpdateDoctor(Doctor doctor);
         Doctor GetDoctorByName(String DoctorName);
    }
}