using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Contract.Exceptions
{
    public class ExceptionUserNotFound : Exception
    {
        public ExceptionUserNotFound(string Name,object Key) : base($@"Username & Password Not Match  /{Name}/  ({Key})")
        {

        }
    }
}
