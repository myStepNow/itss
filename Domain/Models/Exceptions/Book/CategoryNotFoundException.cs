using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Exceptions.Base;

namespace Domain.Models.Exceptions.Book
{
    public sealed class CategoryNotFoundException
        : NotFoundException
    {
        public CategoryNotFoundException(int id)
            : base($"Category with id : {id} could not found.")
        {

        }
    }
}
