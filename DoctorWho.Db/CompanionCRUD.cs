using DoctorWho.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db
{
    public static class CompanionCRUD
    {
        public static void CreateCompanion(Companion companion)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            _context.Companions.Add(companion);
            _context.SaveChanges();
        }
        public static Companion RetriveCompanion(int companionId)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            var companion = _context.Companions.Find(companionId);
            return companion;
        }
        public static void UpdateCompanion(Companion companion)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            _context.Companions.Update(companion);
            _context.SaveChanges();
        }

        public static void DeleteCompanion(int companionId)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            var companion = _context.Companions.Find(companionId);
            if (companion != null)
            {
                _context.Companions.Remove(companion);
                _context.SaveChanges();
            }
        }
    }
}
