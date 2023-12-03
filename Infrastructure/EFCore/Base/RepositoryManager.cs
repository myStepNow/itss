using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repositories.Interfaces;

namespace Infrastructure.Repositories.Base
{
    public class RepositoryManager : IRepositoryManager
    {

        private readonly RepositoryContext _context;
        private readonly IBookRepository _bookRepository;

        public RepositoryManager(RepositoryContext context,
            IBookRepository bookRepository)
        {
            _context = context;
            _bookRepository = bookRepository;
    
        }

        public IBookRepository Book => _bookRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
