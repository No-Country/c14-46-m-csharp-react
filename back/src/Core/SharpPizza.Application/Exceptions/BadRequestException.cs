using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpPizza.Application.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message): base(message)
        {
        }
    }
}