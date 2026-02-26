using Contact_Manager_CLI.Interfaces;
using Contact_Manager_CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager_CLI.Search
{
    public class SearchByName : IContactSearch
    {
        public Contact? Search(List<Contact> contacts, string name)
        {
            return contacts
                .FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
        }
    }
}
