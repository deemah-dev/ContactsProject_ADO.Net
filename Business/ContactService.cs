using DataAccess;
using Modules;
using System.Data;

namespace Business
{
    public static class ContactService
    {
        public static Contact FindContact(int id)
        {
            if (CRUD.IsExist(id))
            {
                Contact contact = CRUD.Read(id);
                return contact;
            }
            return null;
        }

        public static bool UpdateContact(int id, Contact contact)
        {
            if (CRUD.IsExist(id))
            {
                return CRUD.Update(id, contact);
            }
            return false;
        }

        public static bool AddNewContact(Contact contact)
        {
            return CRUD.Create(contact);
        }

        public static bool DeleteContact(int id)
        {
            if (CRUD.IsExist(id))
            {
                return CRUD.Delete(id);
            }
            return false;
        }

        public static bool IsExistContact(int id)
        {
            return CRUD.IsExist(id);
        }

        public static DataTable ContactsDataTable()
        {
            return CRUD.GetAll();
        }
    }
}
