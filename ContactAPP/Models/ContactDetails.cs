using ContactAPP.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAPP.Models
{
    internal class ContactDetails
    {
        public int ContactDetailsId { get; set; }
        public ContactDetailType ContactType { get; set; }
        public string Contact { get; set; }
        public ContactDetails(int id, ContactDetailType contactDetailType, string contact)
        {
            ContactDetailsId = id;
            ContactType = contactDetailType;
            this.Contact = contact;
        }
    }
}
