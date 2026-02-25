using Contact_Manager_CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager_CLI.Interfaces
{
    public interface IContactStorage
    {
        public void Save(List<Contact> contacts);

        public List<Contact> Load();
    }
}
