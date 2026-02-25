using Contact_Manager_CLI.Interfaces;
using Contact_Manager_CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Contact_Manager_CLI.Services
{
    public class JsonStorageService : IContactStorage
    {
        private readonly string _filePath = "data.json";
        public List<Contact> Load()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Contact>();
            }
            List<Contact> list = new List<Contact>();
            string json = File.ReadAllText(_filePath);

            if (string.IsNullOrWhiteSpace(json))
                return new List<Contact>();

            list = JsonSerializer.Deserialize<List<Contact>>(json);
                
            return list ?? new List<Contact>();
        }

        public void Save(List<Contact> contacts)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(contacts, options);

            File.WriteAllText(_filePath, jsonString);
        }
    }
}
