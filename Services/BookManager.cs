using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager manager;
        private readonly ILoggerService logger;
        private readonly IMapper mapper;
        public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            this.manager = manager;
            this.logger = logger;
            this.mapper = mapper;
        }

        public Book CreateOneBook(Book book)
        {
            if (book is null)
                throw new ArgumentNullException(nameof(book));

            manager.Book.CreateOneBook(book);
            manager.Save();
            return book;
        }

        public void DeleteOneBook(int id, bool trackChanges)
        {
            var entity = manager.Book.GetOneBookById(id, trackChanges);
            if (entity is null)
                throw new BookNotFoundException(id);
            manager.Book.DeleteOneBook(entity);
            manager.Save();
        }

        public IEnumerable<BookDto> GetAllBooks(bool trackChanges)
        {
            var books = manager.Book.GetAllBooks(trackChanges);
            return mapper.Map<IEnumerable<BookDto>>(books);
        }

        public Book GetOneBookById(int id, bool trackChanges)
        {
            var entity = manager.Book.GetOneBookById(id, trackChanges);
            if (entity is null) throw new BookNotFoundException(id);
            return entity;
        }

        public void UpdateOneBook(int id, BookDtoForUpdate bookDto, bool trackChanges)
        {
            var entity = manager.Book.GetOneBookById(id, trackChanges);
            if (entity is null)
                throw new BookNotFoundException(id);

            //Mapping
            entity = mapper.Map<Book>(bookDto);

            manager.Book.UpdateOneBook(entity);
            manager.Save();
        }
    }
}
