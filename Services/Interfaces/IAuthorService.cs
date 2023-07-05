using DoctorWho.Domain.Entities;

namespace DoctorWho.Services.Interfaces
{
    public interface IAuthorService
    {
        Author GetAuthor(int AuthorId);
    }
}