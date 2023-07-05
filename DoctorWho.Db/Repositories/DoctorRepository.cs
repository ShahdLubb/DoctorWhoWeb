using DoctorWho.Db.Entities;
using DoctorWho.Db.Interfaces.IReporitories;
namespace DoctorWho.Db.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DoctorWhoCoreDbContext _context;
        public DoctorRepository(DoctorWhoCoreDbContext contex)
        {
            _context = contex;
        }
        public void CreateDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }
        public Doctor RetriveDoctor(int doctorId)
        {
            var doctor = _context.Doctors.Find(doctorId);
            return doctor;
        }
        public void UpdateDoctor(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
        }

        public void DeleteDoctor(int doctorId)
        {
            var doctor = _context.Doctors.Find(doctorId);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
        }
        public List<Doctor> GetAllDoctors()
        {
            return _context.Doctors.ToList();
        }
    }
}
