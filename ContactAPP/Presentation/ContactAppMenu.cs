using ContactAPP.Controller;
using ContactAPP.Exceptions;
using ContactAPP.Models;
using ContactAPP.Type;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAPP.Presentation
{
    internal class ContactAppMenu
    {
        private UserManager _userManager = new UserManager();

        public void ShowMenu()
        {
            try
            {
                Console.WriteLine("Enter the Id To Access the Operation");
                int id = int.Parse(Console.ReadLine());
                var user = _userManager.FindUser(id);
                FindMenu(user);
            }
            catch (NoSuchUserExistException nu)
            {
                Console.WriteLine(nu.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FindMenu(User user)
        {
            if (user.IsAdmin)
            {
                ShowAdminMenu();
                return;
            }
            ShowStaffMenu(user);
        }
        public void ShowAdminMenu()
        {
            Console.WriteLine("\nWelcome User\n");
            while (true)
            {
                Console.WriteLine("\nMain Menu:\n" +
                    "1. ADD User\n" +
                    "2. Modify User\n" +
                    "3. Delete User\n" +
                    "4. Display All User\n" +
                    "5. Find User\n" +
                    "6. Exit\n\n" +
                    "Enter your Operation\n ");
               
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddUser();
                        break;
                    case 2:
                        ModifyUser();
                        break;
                    case 3:
                        DeleteUser();
                        break;
                    case 4:
                        DisplayAllUsers();
                        break;
                    case 5:
                        FindUser();
                        break;
                    case 6:
                        Environment.Exit(0);
                        return;
                    default:
                        Console.WriteLine("Invalid choice Please try again");
                        break;
                }
            }
        }


        public void AddUser()
        {
            Console.Write("Enter User ID: ");
            int userId = int.Parse(Console.ReadLine());
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Is Admin (true/false): ");
            bool isAdmin = bool.Parse(Console.ReadLine());
            Console.Write("Is Active (true/false): ");
            bool isActive = bool.Parse(Console.ReadLine());

            _userManager.AddUser(userId, firstName, lastName, isAdmin, isActive);
            Console.WriteLine("User added successfully.");
        }

        public void ModifyUser()
        {
            try
            {
                Console.WriteLine("Enter the User ID to Modify the user ");
                int id = int.Parse(Console.ReadLine());

                var user = _userManager.FindUser(id);

                Console.WriteLine("Enter the First Name");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter the Last Name");
                string lastName = Console.ReadLine();
                Console.Write("Is Admin (true/false): ");
                bool isAdmin = bool.Parse(Console.ReadLine());
                Console.Write("Is Active (true/false): ");
                bool isActive = bool.Parse(Console.ReadLine());

                _userManager.ModifyUser(user, firstName, lastName, isAdmin, isActive);

                Console.WriteLine("Succesfully Modified");
            }
            catch (NoSuchUserExistException nu)
            {
                Console.WriteLine(nu.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
             



        }
        public void DeleteUser()
        {
            Console.Write("Enter User ID to delete: ");
            int userId = int.Parse(Console.ReadLine());

            bool deleted = _userManager.DeleteUser(userId);
            if (deleted)
            {
                Console.WriteLine("User delete successfully");
                return;
            }
       
            Console.WriteLine("User not found or already inactive");
        }

        public void DisplayAllUsers()
        {
            var users = _userManager.GetAllUsers();
            if (users.Count > 0)
            {
                Console.WriteLine("Active Users:");
                foreach (var user in users)
                {
                    Console.WriteLine($"UserID: {user.UserId}, Name: {user.FirstName} {user.LastName}, IsAdmin: {user.IsAdmin}");
                    return;
                }
            }
            
            Console.WriteLine("No active users found.");
            
        }

        public void FindUser()
        {
            Console.Write("Enter User ID to find: ");
            int userId = int.Parse(Console.ReadLine());

            var user = _userManager.FindUser(userId);
            if (user != null)
            {
                Console.WriteLine($"UserID: {user.UserId}, Name: {user.FirstName} {user.LastName}, IsAdmin: {user.IsAdmin}, IsActive: {user.IsActive}");
                return;
            }
           
            Console.WriteLine("User not found or inactive.");
            
        }


        // Staff Operarion

        public void ShowStaffMenu(User user)
        {
            Console.WriteLine("\nWelcome Staff\n");

            bool check = true;
            while (check)
            {
                Console.WriteLine("\nWhat do want to do\n" +
                "1. Work on Contacts\n" +
                "2. Work on Contact Detail\n" +
                "3. Exit\n" +
                "Enter your Operation\n ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        OperationOnContact(user);
                        break;
                    case 2:
                        OperationOnContactDetails(user);
                        break;
                    case 3:
                        check = false ;
                        break;

                    default:
                        Console.WriteLine("Enter valid Number");
                        break;

                }


            }
        }

        // contact staff operation
        public void OperationOnContact(User user)
        {
            bool check1 = true;
            while (check1)
            {
                Console.WriteLine("\n1. Add New Contact\n" +
                    "2. Modify Contact\n" +
                    "3. Delete Contact\n" +
                    "4. Display All Contact\n" +
                    "5. Find Contact\n" +
                    "6. Logout");

                int choice = int.Parse (Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddContact(user.Contacts);
                        break;
                    case 2:
                        ModifyContact(user);
                        break;
                    case 3:
                        DeleteContact(user);
                        break;
                    case 4:
                        DisplayAllContact(user);
                        break;
                    case 5:
                        FindContact(user);
                        break;
                    case 6:
                        check1 = false ;
                        break;
                    default :
                        Console.WriteLine("Enter Valid Input");
                        break;
                }
            }

        }

        public void AddContact(List<Contact> list)
        {
            Console.WriteLine("Enter the Contact Id");
            int id = int.Parse (Console.ReadLine());
            Console.WriteLine("Enter The First Name ");
            string firstName = Console.ReadLine ();
            Console.WriteLine("Enter the Last Name");
            string lastName = Console.ReadLine ();
            Console.Write("Is Active (true/false): ");
            bool isActive = bool.Parse(Console.ReadLine());

            _userManager.AddContact(id, firstName, lastName, isActive, list);
            Console.WriteLine("Contact Added Successfully");
        }

        public void ModifyContact(User user)
        {
            try
            {
                Console.WriteLine("Enter the Contact No to Modify");
                int id = int.Parse(Console.ReadLine());

                var contact = _userManager.FindContact(id, user);

                Console.WriteLine("Enter The First Name ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter the Last Name");
                string lastName = Console.ReadLine();
                Console.Write("Is Active (true/false): ");
                bool isActive = bool.Parse(Console.ReadLine());

                _userManager.ModifyContact(contact, firstName, lastName, isActive);
                Console.WriteLine("Succesfully modified");
            }
            catch (NoSuchContactExistException nc)
            {
                Console.WriteLine(nc.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
               
        }
        public void DeleteContact(User user)
        {
            Console.WriteLine("Enter the Contact Id to Delete Contact");
            int id = int.Parse(Console.ReadLine());
            bool deleted = _userManager.DeleteContact(id, user);
            if (deleted)
            {
                Console.WriteLine("Deleted Contact succesfully");
                return;
            }

            Console.WriteLine("No such Contact available");
                
        }

        public void DisplayAllContact(User user)
        {
            var contacts = _userManager.GetAllContacts(user);
            if (contacts.Count > 0)
            {
                Console.WriteLine("Active Contacts:");
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"UserID: {contact.ContactId}, Name: {contact.FirstName} {contact.LastName}");
                }
                return;
            }
            Console.WriteLine("No active Contacts found with this Staff");



        }

        public void FindContact(User User)
        {
            try
            {
                Console.WriteLine("Enter the Contact Id");
                int id = int.Parse(Console.ReadLine());

                var contact = _userManager.FindContact(id, User);

                Console.WriteLine($"Contact Id {contact.ContactId}, Name : {contact.FirstName} {contact.LastName}");
            }
            catch (NoSuchContactExistException nc)
            {
                Console.WriteLine(nc.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
              

           
        }
        // Contact Deatail Staff Operation
        public void OperationOnContactDetails(User user)
        {
            try
            {
                Console.WriteLine("Enter The Contact Id To access The contact detail operation");
                int id = int.Parse(Console.ReadLine());
                var contact = _userManager.FindContact(id, user);
                ContactDetailMenu(contact);
            }
            catch (NoSuchContactExistException nfe)
            {
                Console.WriteLine(nfe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public void ContactDetailMenu(Contact contact)
        {
            bool check2 = true;
            while (check2)
            {
                Console.WriteLine("\n1. Add New Contact Details\n" +
                    "2. Display All Contact Details\n" + 
                    "3. Logout");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddContactDetail(contact.Details);
                        break;
                    case 2:
                        DisplayAllContactDetail(contact);
                        break;
                    case 3:
                        check2 = false;
                        break;
                    default:
                        Console.WriteLine("Enter Valid Input");
                        break;
                }
            }
        }

        public void AddContactDetail(List<ContactDetails> list)
        {
            Console.WriteLine("Enter the Contact Details Id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the value 1 for Contact type Number \n" +
                "Or neter value 2 For Email");
            int value = int.Parse(Console.ReadLine());

            ContactDetailType contactDetailType = (value == 1) ? ContactDetailType.NUMBER : ContactDetailType.EMAIL; ;

            Console.WriteLine("Enter the Contact Value");
            string contactValue = Console.ReadLine();

            _userManager.AddContactDetails(id, contactDetailType, contactValue, list);
            Console.WriteLine("Contact Added Successfully");
        }

        public void DisplayAllContactDetail(Contact contact)
        {
            var contactDetails = _userManager.GetContactDetails(contact);
            if (contactDetails.Count > 0)
            {
                Console.WriteLine("Contact Details :");
                foreach (var detail in contactDetails)
                {
                    Console.WriteLine($"UserID: {detail.ContactDetailsId}, Contact Type : {detail.ContactType}, Contact : {detail.Contact}");
                }
                return;
            }
            Console.WriteLine("No active Contacts found with this Staff");
        }
      
    }

}
