
using DoctorWho.Db.Entities;
namespace DoctorWho.Db.Interfaces.IReporitories
{
    public interface IAuthorRepository
    {
        void CreateAuthor(Author author);
        void DeleteAuthor(int authorId);
        Author RetriveAuthor(int authorId);
        void UpdateAuthor(Author author);
    }
}