using DoctorWho.Domain.Entities;

namespace DoctorWho.Domain.Interfaces.IReporitories
{
    public interface IAuthorRepository
    {
        void CreateAuthor(Author author);
        void DeleteAuthor(int authorId);
        Author RetriveAuthor(int authorId);
        void UpdateAuthor(Author author);
    }
}