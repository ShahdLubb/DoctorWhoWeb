using DoctorWho.Domain.Entities;

namespace DoctorWho.Services.Interfaces
{
    public interface ICompanionService
    {
        Companion GetCompanion(int CompanionId);
    }
}