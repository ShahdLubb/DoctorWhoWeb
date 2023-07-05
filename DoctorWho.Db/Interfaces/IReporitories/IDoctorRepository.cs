using DoctorWho.Db.Entities;
namespace DoctorWho.Db.Interfaces.IReporitories
{
    public interface IDoctorRepository
    {
        void CreateDoctor(Doctor doctor);
        void DeleteDoctor(int doctorId);
        List<Doctor> GetAllDoctors();
        Doctor RetriveDoctor(int doctorId);
        void UpdateDoctor(Doctor doctor);
    }
}