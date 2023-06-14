using DoctorWho.Db.Models;

namespace DoctorWho.Db.Repositories
{
    public class CompanionRepository
    {
        private readonly DoctorWhoCoreDbContext _context;
        public CompanionRepository()
        {
            _context = new DoctorWhoCoreDbContext();
        }
        public void CreateCompanion(Companion companion)
        {
            _context.Companions.Add(companion);
            _context.SaveChanges();
        }
        public Companion RetriveCompanion(int companionId)
        {
            var companion = _context.Companions.Find(companionId);
            return companion;
        }
        public void UpdateCompanion(Companion companion)
        {
            _context.Companions.Update(companion);
            _context.SaveChanges();
        }

        public void DeleteCompanion(int companionId)
        {
            var companion = _context.Companions.Find(companionId);
            if (companion != null)
            {
                _context.Companions.Remove(companion);
                _context.SaveChanges();
            }
        }
    }
}
