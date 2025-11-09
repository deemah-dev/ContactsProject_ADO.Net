using Business;
using Modules;
using System;
using System.Data;

namespace Presentation
{
    internal class Program
    {
        static void testAddNewContact()
        {
            bool Done = ContactService.AddNewContact(new Contact { FirstName = "Ahmed", LastName = "Alaa", Email = "AA@gmail.com", Phone = "09876543", Address = "Amman", CountryID = 1, DateOfBirth = DateTime.Now, ImagePath = "" });

            if (Done)
            {
                Console.WriteLine("Add New Contact Done Successfully");
                return;
            }
            Console.WriteLine("Falied To Add New Contact");
        }
        static void testFindContact(int id)
        {
            Contact contact = ContactService.FindContact(id);
            if (contact != null)
            {
                Console.WriteLine($"First Name: {contact.FirstName}");
                Console.WriteLine($"Last Name: {contact.LastName}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine($"Phone: {contact.Phone}");
                Console.WriteLine($"Address: {contact.Address}");
                Console.WriteLine($"DateOfBirth: {contact.DateOfBirth}");
                Console.WriteLine($"CountryID: {contact.CountryID}");
                Console.WriteLine($"ImagePath: {contact.ImagePath}");
                return;
            }
            Console.WriteLine($"Contact With ID {id} Not Found");
        }
        static void testUpdateContact(int id)
        {
            bool Done = ContactService.UpdateContact(id, new Contact { FirstName = "Ali", LastName = "Othman", Email = "AA@gmail.com", Phone = "09876543", Address = "Amman", CountryID = 1, DateOfBirth = DateTime.Now, ImagePath = "" });
            if(Done)
            {
                Console.WriteLine("Update Contact Done Successfully");
                return;
            }
            Console.WriteLine("Falied To Update Contact");
        }
        static void testDaleteContact(int id)
        {
            bool Done = ContactService.DeleteContact(id);
            if (Done)
            {
                Console.WriteLine("Contact Deleted Successfully");
                return;
            }
            Console.WriteLine("Failed To Delete Contact");
        }
        static void testDataTable()
        {
            DataTable dataTable = ContactService.ContactsDataTable();
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["ContactID"]} - {row["FirstName"]} {row["LastName"]}");
            }
        }
        static void testIsExistContact(int id)
        {
            bool Exist = ContactService.IsExistContact(id);

            if (Exist)
            {
                Console.WriteLine($"Contact With ID {id} Is Exist");
                return;
            }
            Console.WriteLine($"Contact With ID {id} Is Not Exist");
        }
        static void Main(string[] args)
        {
            //testAddNewContact();
            //testUpdateContact(11);
            //testFindContact(4);
            //testDaleteContact(11);
            //testDataTable();
            //testIsExistContact(11);
            Console.ReadKey();
        }
    }
}
