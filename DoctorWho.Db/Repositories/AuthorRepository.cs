
using DoctorWho.Domain.Entities;
using DoctorWho.Domain.Interfaces.IReporitories;

namespace DoctorWho.Db.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DoctorWhoCoreDbContext _context;
        public AuthorRepository()
        {
            _context = new DoctorWhoCoreDbContext();
        }
        public void CreateAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
        public Author RetriveAuthor(int authorId)
        {
            var author = _context.Authors.Find(authorId);
            return author;
        }
        public void UpdateAuthor(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }

        public void DeleteAuthor(int authorId)
        {
            var author = _context.Authors.Find(authorId);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}
