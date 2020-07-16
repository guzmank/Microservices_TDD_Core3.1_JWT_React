using Home.Framework.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Home.Framework.Services.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactsDto>> GetContacts();

        Task<bool> SaveContact(ContactsDto contact);

        Task<bool> DeleteContact(int contactId);
    }
}
