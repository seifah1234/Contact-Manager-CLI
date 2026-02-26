using Contact_Manager_CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager_CLI.Interfaces
{
    public interface IContactFilter
    {
        public List<Contact> Filter(List<Contact> contacts, string filter);
    }
}
