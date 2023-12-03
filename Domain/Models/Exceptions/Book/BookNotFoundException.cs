using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Exceptions.Base;

namespace Domain.Models.Exceptions.Book
{
    public sealed class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(int id)
            : base($"The book with id : {id} could not found.")
        {
        }
    }
}
