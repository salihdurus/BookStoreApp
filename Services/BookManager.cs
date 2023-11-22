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
        public BookManager(IRepositoryManager manager, ILoggerService logger)
        {
            this.manager = manager;
            this.logger = logger;
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
            {
                string message = $"Book with id:{id} could not found.";
                logger.LogInfo(message);
                throw new Exception(message);
            }
            manager.Book.DeleteOneBook(entity);
            manager.Save();
        }

        public IEnumerable<Book> GetAllBooks(bool trackChanges)
        {
            return manager.Book.GetAllBooks(trackChanges);
        }

        public Book GetOneBookById(int id, bool trackChanges)
        {
            return manager.Book.GetOneBookById(id, trackChanges);
        }

        public void UpdateOneBook(int id, Book book, bool trackChanges)
        {
            var entity = manager.Book.GetOneBookById(id, trackChanges);
            if (entity is null)
            {
                string message = $"Book with id:{id} could not found.";
                logger.LogInfo(message);
                throw new Exception(message);
            }
            if (book is null)
                throw new ArgumentNullException(nameof(book));

            entity.Title = book.Title;
            entity.Price = book.Price;

            manager.Book.UpdateOneBook(entity);
            manager.Save();
        }
    }
}
