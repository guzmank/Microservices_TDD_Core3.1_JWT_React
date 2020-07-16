using Home.Framework.Data.Entities;
using Home.Framework.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Home.Framework.Data.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly HomeDBContext _dbContext;
        private readonly DbSet<ContactsEntity> _contactsEntity;

        public ContactsRepository(HomeDBContext dbContext)
        {
            _dbContext = dbContext;
            _contactsEntity = _dbContext.Set<ContactsEntity>();
        }

        public async Task<IEnumerable<ContactsEntity>> GetContacts()
        {
            if (_contactsEntity != null)
            {
                return await (from a in _contactsEntity.AsNoTracking()
                              select new ContactsEntity
                              {
                                  ContactId = a.ContactId,
                                  FirstName = a.FirstName,
                                  LastName = a.LastName,
                                  Email = a.Email,
                                  Phone = a.Phone
                              }).ToArrayAsync();
            }

            return null;
        }

        public async Task<bool> SaveContact(ContactsEntity contactModel)
        {
            if (_contactsEntity != null)
            {
                ContactsEntity contact = await _contactsEntity.Where(x => x.ContactId == contactModel.ContactId).FirstOrDefaultAsync();

                if (contact == null)
                {
                    contact = new ContactsEntity()
                    {
                        FirstName = contactModel.FirstName,
                        LastName = contactModel.LastName,
                        Email = contactModel.Email,
                        Phone = contactModel.Phone
                    };

                    _dbContext.Add(contact);
                }
                else
                {
                    contact.FirstName = contactModel.FirstName;
                    contact.LastName = contactModel.LastName;
                    contact.Email = contactModel.Email;
                    contact.Phone = contactModel.Phone;
                }

                return await _dbContext.SaveChangesAsync() >= 1;
            }

            return false;
        }

        public async Task<bool> DeleteContact(int contactId)
        {
            if (_contactsEntity != null)
            {
                ContactsEntity contact = _contactsEntity.Where(x => x.ContactId == contactId).FirstOrDefault();

                if (contact != null)
                {
                    _dbContext.Remove(contact);
                }

                return await _dbContext.SaveChangesAsync() >= 1;
            }

            return false;
        }
    }
}
