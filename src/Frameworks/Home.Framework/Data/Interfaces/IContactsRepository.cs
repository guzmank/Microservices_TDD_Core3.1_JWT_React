using Home.Framework.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Home.Framework.Data.Interfaces
{
    public interface IContactsRepository
    {
        // GET ALL
        Task<IEnumerable<ContactsEntity>> GetContacts();

        // UPDATE - PUT
        Task<bool> SaveContact(ContactsEntity contact);

        // DELETE
        Task<bool> DeleteContact(int contactId);
    }
}
