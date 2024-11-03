using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAPP.Exceptions
{
    internal class NoSuchContactExistException : Exception
    {
        public NoSuchContactExistException(string message) : base(message) 
        {
            
        }
    }
}
