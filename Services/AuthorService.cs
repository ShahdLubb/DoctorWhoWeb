using AutoMapper;
using DoctorWho.Db.Interfaces.IReporitories;
using DoctorWho.Domain.Entities;
using DoctorWho.Domain.Interfaces;

namespace DoctorWho.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public Author GetAuthor(int AuthorId)
        {
            var Author = _authorRepository.RetriveAuthor(AuthorId);
            return _mapper.Map<Author>(Author);

        }
    }
}
