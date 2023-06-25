using DoctorWho.Domain.Entities;

namespace DoctorWho.Domain.Interfaces.IReporitories
{
    public interface ICompanionRepository
    {
        void CreateCompanion(Companion companion);
        void DeleteCompanion(int companionId);
        Companion RetriveCompanion(int companionId);
        void UpdateCompanion(Companion companion);
    }
}