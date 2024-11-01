using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAPP.Models
{
    internal class User
    {
        public int UserId { get; set; }    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public List<Contact> Contacts { get; set; }

        public User(int userID, string firstNAme, string lastName, bool isAdmin, bool isActive) 
        { 
            
            UserId = userID;
            FirstName = firstNAme;
            LastName = lastName;
            IsActive = isActive;
            IsAdmin = isAdmin;
            Contacts = new List<Contact>();
        }

    }
}
