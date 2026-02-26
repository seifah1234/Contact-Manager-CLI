using Contact_Manager_CLI.Interfaces;
using Contact_Manager_CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager_CLI.Filter
{
    public class FilterByEmail : IContactFilter
    {
        public List<Contact> Filter(List<Contact> contacts, string keyword)
        {
            return contacts
                .Where(c => c.Email.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
