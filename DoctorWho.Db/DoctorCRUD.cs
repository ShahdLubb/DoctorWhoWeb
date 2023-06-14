using DoctorWho.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db
{
    public static class DoctorCRUD
    {
        public static void CreateDoctor(Doctor doctor)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }
        public static Doctor RetriveDoctor(int doctorId)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            var doctor = _context.Doctors.Find(doctorId);
            return doctor;
        }
        public static void UpdateDoctor(Doctor doctor)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
        }

        public static void DeleteDoctor(int doctorId)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            var doctor = _context.Doctors.Find(doctorId);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
        }
    }
}
