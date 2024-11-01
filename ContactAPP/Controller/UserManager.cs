using ContactAPP.Models;
using ContactAPP.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAPP.Controller
{
    internal class UserManager
    {

       public List<User> _users = new List<User>();


        User user1 = new User(1, "Pranay", "Raut", true, true);
        Contact contact1 = new Contact(101, "John", "Doe", true);
        Contact contact2 = new Contact(102, "Jane", "Doe", true);
        ContactDetails contactDetails1 = new ContactDetails(1001, ContactDetailType.NUMBER, "7498091987");
        ContactDetails contactDetails2 = new ContactDetails(1002, ContactDetailType.EMAIL, "pranay@gmail.com");
        

        User user2 = new User(2, "Bhagwan", "kuvare", false, true);
        Contact contact3 = new Contact(103, "Yash", "Doe", true);
        ContactDetails contactDetails3 = new ContactDetails(1003, ContactDetailType.NUMBER, "8888444942");
        ContactDetails contactDetails4 = new ContactDetails(1004, ContactDetailType.EMAIL, "bhagwan@gmail.com");

        User user3 = new User(3, "Prasad", "Raut", false, true);
        Contact contact4 = new Contact(104, "Dobby", "Doe", true);
        ContactDetails contactDetails5 = new ContactDetails(1005, ContactDetailType.NUMBER, "9834381208");

        public UserManager()    
        {
            contact1.Details.Add(contactDetails1);
            contact1.Details.Add(contactDetails2);
            contact3.Details.Add(contactDetails3);
            contact3.Details.Add(contactDetails4);
            contact4.Details.Add(contactDetails5);

            user1.Contacts.Add(contact1);
            user1.Contacts.Add(contact2);
            user2.Contacts.Add(contact3);
            user3.Contacts.Add(contact4);

            _users.Add(user1);
            _users.Add(user2);
            _users.Add(user3);
        }
        public void AddUser(int userID, string firstNAme, string lastName, bool isAdmin, bool isActive)
        {
            User user = new User(userID, firstNAme, lastName, isAdmin, isActive);
            _users.Add(user);
        }

        public bool DeleteUser(int userId)
        {
            User user = _users.FirstOrDefault(u => u.UserId == userId && u.IsActive);
            if (user != null)
            {
                user.IsActive = false;  
                return true;
            }
            return false;
        } 

        public void ModifyUser(User user, string firstName, string lastName, bool isAdmin, bool isActive)
        {
            user.FirstName = firstName;
            user.LastName = lastName;
            user.IsAdmin = isAdmin;
            user.IsActive = isActive;
        }
        public User FindUser(int userId)
        {
            return _users.FirstOrDefault(u => u.UserId == userId && u.IsActive);
        }

        public List<User> GetAllUsers()
        {
            return _users.Where(u => u.IsActive).ToList();
        }

        // Contact 

        public void AddContact(int contactId, string firstName, string lastName, bool isActive, List<Contact> list)
        {
            Contact contact = new Contact(contactId, firstName, lastName, isActive);
            list.Add(contact);
        }

        public Contact FindContact(int contactId, User user)
        {
            Contact contact = user.Contacts.Where(c =>  c.ContactId == contactId && c.IsActive).FirstOrDefault();
            return contact;
        }

        public List<Contact> GetAllContacts(User user)
        {
            return user.Contacts.Where(_c => _c.IsActive).ToList();
        }

        public bool DeleteContact(int contactId, User user)
        {
            Contact contact = user.Contacts.Where(c => c.ContactId == contactId && c.IsActive).FirstOrDefault();
            if (contact != null)
            {
                contact.IsActive = false;
                return true;
            }
            return false;
        }

        public void ModifyContact(Contact contact, string firstName, string lastName, bool isActive)
        {
            contact.FirstName = firstName;
            contact.LastName = lastName;
            contact.IsActive = isActive;

        }

        // Contact Details

        public void AddContactDetails(int id, ContactDetailType contactDetailType, string contact, List<ContactDetails> list)
        {
            ContactDetails contactDetails = new ContactDetails(id, contactDetailType, contact); 
            list.Add(contactDetails);
        }

        public List<ContactDetails> GetContactDetails(Contact contact)
        {
            return contact.Details;
        }
    }
}
