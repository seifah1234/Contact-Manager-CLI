using Contact_Manager_CLI.Interfaces;
using Contact_Manager_CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager_CLI.Search
{
    public class SearchByPhone : IContactSearch
    {
        public List<Contact> Search(List<Contact> contacts, string keyword)
        {
            return contacts
                .Where(c => c.Phone.Contains(keyword)).ToList();
        }
    }
}
