using Contact_Manager_CLI.Interfaces;
using Contact_Manager_CLI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Contact_Manager_CLI.Services
{
    public class ContactService
    {
        private IContactStorage _contactStorage;
        private readonly List<Contact> _contacts;

        public ContactService(IContactStorage contactStorage) 
        {
            _contactStorage = contactStorage;
            _contacts = _contactStorage.Load();
        }
        public void AddContact(Contact contact)
        {
            contact.Id = _contacts.Any() ? _contacts.Max(c => c.Id) + 1 : 1;
            contact.CreatedAt = DateTime.Now;
            _contacts.Add(contact);
        }

        public bool DeleteContact(int id)
        {
            var contact = _contacts.FirstOrDefault(x => x.Id == id);
            if (contact != null)
            {
                _contacts.Remove(contact);
                return true;
            }
            return false;
        }

        public bool EditContact(int id, Contact newContact)
        {
            var contact = _contacts.FirstOrDefault(x => x.Id == id);
            if (contact != null)
            {
                contact.Email = newContact.Email;
                contact.Phone = newContact.Phone;
                contact.Name = newContact.Name;
                return true;
            }
            return false;
        }

        public List<Contact> GetContacts()
        {
            return new List<Contact>(_contacts);
        }

      
        public Contact? Search(IContactSearch search, string keyword)
        {
            return search.Search(_contacts, keyword);
        }
      
        public List<Contact> Filter(IContactFilter search, string keyword)
        {
            return search.Filter(_contacts, keyword);
        }

        public void Save()
        {
            _contactStorage.Save(_contacts);
        }

        public Contact? ViewContact(int id)
        {
            Contact? contact = _contacts.FirstOrDefault(c => c.Id == id);
            return contact;
        }
    }
}
