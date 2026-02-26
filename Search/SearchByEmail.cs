using Contact_Manager_CLI.Interfaces;
using Contact_Manager_CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager_CLI.Search
{
    public class SearchByEmail : IContactSearch
    {
        public Contact? Search(List<Contact> contacts, string email)
        {
            return contacts
                .FirstOrDefault(c => c.Email.ToLower() == email.ToLower());
        }
    }
}
