using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.Interfaces;

namespace Application.Contracts.Base
{
    public class ServiceManager : IServiceManager
    {
        private readonly IBookService _bookService;
        private readonly IAuthenticationService _authencationService;

        public ServiceManager(IBookService bookService,
            IAuthenticationService authencationService
          )
        {
            _bookService = bookService;
            
            _authencationService = authencationService;
      
        }

        public IBookService BookService => _bookService;
      
        public IAuthenticationService AuthenticationService => _authencationService;

    }

}
