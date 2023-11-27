using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Exceptions.BadRequestException;

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

        public async Task<BookDto> CreateOneBookAsync(BookDtoForInsertion book)
        {
            var entity = mapper.Map<Book>(book);
            manager.Book.CreateOneBook(entity);
            await manager.SaveAsync();
            return mapper.Map<BookDto>(entity);
        }

        public async Task DeleteOneBookAsync(int id, bool trackChanges)
        {
            var entity = await GetOneBookByIdAndCheckExists(id, trackChanges);
            manager.Book.DeleteOneBook(entity);
            await manager.SaveAsync();
        }

        public async Task<(IEnumerable<BookDto> books, MetaData metaData)> GetAllBooksAsync(BookParameters bookParameters, bool trackChanges)
        {
            if (!bookParameters.ValidPriceRange)
                throw new PriceOutOfRangeBadRequestException();

            var booksWithMetaData = await manager.Book.GetAllBooksAsync(bookParameters, trackChanges);
            var booksDto = mapper.Map<IEnumerable<BookDto>>(booksWithMetaData);
            return (booksDto, booksWithMetaData.MetaData);
        }

        public async Task<BookDto> GetOneBookByIdAsync(int id, bool trackChanges)
        {
            var entity = await GetOneBookByIdAndCheckExists(id, trackChanges);
            return mapper.Map<BookDto>(entity);
        }

        public async Task<(BookDtoForUpdate bookDtoForUpdate, Book book)> GetOneBookForPatchAsync(int id, bool trackChanges)
        {
            var book = await GetOneBookByIdAndCheckExists(id, trackChanges);
            var bookDtoForUpdate = mapper.Map<BookDtoForUpdate>(book);
            return (bookDtoForUpdate, book);
        }

        public async Task SaveChangesForPatchAsync(BookDtoForUpdate bookDtoForUpdate, Book book)
        {
            mapper.Map(bookDtoForUpdate, book);
            await manager.SaveAsync();
        }

        public async Task UpdateOneBookAsync(int id, BookDtoForUpdate bookDto, bool trackChanges)
        {
            var entity = await GetOneBookByIdAndCheckExists(id, trackChanges);
            //Mapping
            entity = mapper.Map<Book>(bookDto);

            manager.Book.UpdateOneBook(entity);
            await manager.SaveAsync();
        }

        private async Task<Book> GetOneBookByIdAndCheckExists(int id, bool trackChanges)
        {
            var entity = await manager.Book.GetOneBookByIdAsync(id, trackChanges);
            if (entity is null)
                throw new BookNotFoundException(id);
            return entity;
        }
    }
}
