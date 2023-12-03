using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DataTransferObjects.Book;
using Domain.Models.LinkModel.Base;
using Microsoft.AspNetCore.Http;

namespace Application.Contracts.Interfaces
{
    public interface IBookLinks
    {
        LinkResponse TryGenerateLinks(IEnumerable<BookDto> booksDto,
            string fields, HttpContext httpContext);
    }
}
