using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext context;
        private readonly Lazy<IBookRepository> bookRepository;

        public RepositoryManager(RepositoryContext context)
        {
            this.context = context;
            this.bookRepository = new Lazy<IBookRepository>(() => new BookRepository(context));
        }

        public IBookRepository Book => bookRepository.Value;

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
