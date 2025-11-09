using DataAccess;
using Modules;
using System.Data;

namespace Business
{
    public static class ContactService
    {
        public static bool AddNewContact(Contact contact)
        {
            return ContactsCRUD.Create(contact);
        }

        public static Contact FindContact(int id)
        {
            if (ContactsCRUD.IsExist(id))
            {
                Contact contact = ContactsCRUD.Read(id);
                return contact;
            }
            return null;
        }

        public static bool UpdateContact(int id, Contact contact)
        {
            if (ContactsCRUD.IsExist(id))
            {
                return ContactsCRUD.Update(id, contact);
            }
            return false;
        }

        public static bool DeleteContact(int id)
        {
            if (ContactsCRUD.IsExist(id))
            {
                return ContactsCRUD.Delete(id);
            }
            return false;
        }

        public static bool IsExistContact(int id)
        {
            return ContactsCRUD.IsExist(id);
        }

        public static DataTable ContactsDataTable()
        {
            return ContactsCRUD.GetAll();
        }
    }
}
