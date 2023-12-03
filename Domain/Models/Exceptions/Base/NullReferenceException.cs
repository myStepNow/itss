using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Exceptions.Base
{
    public class NullReferenceException : Exception
    {
        protected NullReferenceException(string message) :
            base(message)
        {

        }
    }
}
