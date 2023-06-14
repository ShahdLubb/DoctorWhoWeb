using DoctorWho.Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db
{
    public static class AuthorCRUD
    {
        public static void CreateAuthor(Author author)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
        public static Author RetriveAuthor(int authorId)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            var author = _context.Authors.Find(authorId);
            return author;
        }
        public static void UpdateAuthor(Author author)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            _context.Authors.Update(author);
            _context.SaveChanges();
        }

        public static void DeleteAuthor(int authorId)
        {
            DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
            var author = _context.Authors.Find(authorId);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}
