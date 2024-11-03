using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAPP.Exceptions
{
    internal class NoSuchUserExistException : Exception 
    {
        public NoSuchUserExistException(string message) : base (message)
        {
            
        }
    }
}
