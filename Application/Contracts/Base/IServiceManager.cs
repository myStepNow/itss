using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.Interfaces;

namespace Application.Contracts.Base
{
    public interface IServiceManager
    {
        IBookService BookService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
