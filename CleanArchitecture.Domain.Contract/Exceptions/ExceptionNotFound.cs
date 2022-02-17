using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Contract.Exceptions
{
    public class ExceptionNotFound : Exception
    {
        public ExceptionNotFound(string Name, object Key) : base($@"Entity  \{Name}\   ({Key} Was NotFound)")
        {
        }
    }
}
