
namespace Contact_Manager_CLI.Models
{
    public class Contact
    {    
        public Contact(string name, string phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;
            CreatedAt = DateTime.Now;
        }
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public override string ToString()
        {
            return $"({Id}): {Name} - {Phone} - {Email} Created At: {CreatedAt}";
        }
    }
}
