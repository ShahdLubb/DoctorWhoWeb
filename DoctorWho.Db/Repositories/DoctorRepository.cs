using DoctorWho.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class DoctorRepository
    {
        private readonly DoctorWhoCoreDbContext _context;
        public DoctorRepository()
        {
            _context = new DoctorWhoCoreDbContext();
        }
        public void CreateDoctor( Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }
        public Doctor RetriveDoctor(int doctorId)
        {
            var doctor = _context.Doctors.Find(doctorId);
            return doctor;
        }
        public void UpdateDoctor( Doctor doctor)
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
