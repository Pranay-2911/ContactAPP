using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAPP.Models
{
    internal class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public List<ContactDetails> Details { get; set; }

        public Contact(int contactId, string firstName, string lastName, bool isActive)
        {
            ContactId = contactId;
            FirstName = firstName; 
            LastName = lastName;
            IsActive = isActive;

            Details = new List<ContactDetails>();
        }

    }
}
