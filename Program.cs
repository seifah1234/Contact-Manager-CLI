using Contact_Manager_CLI.Interfaces;
using Contact_Manager_CLI.Models;
using Contact_Manager_CLI.Search;
using Contact_Manager_CLI.Services;

IContactStorage storage = new JsonStorageService();
ContactService service = new ContactService(storage);



while (true)
{
    Console.WriteLine("Contacts List: \n");
    var list = service.GetContacts();
    foreach (var contact in list)
    {
        Console.WriteLine(contact);
    }
    if (list.Count == 0)
    {
        Console.WriteLine("No Contacts Found!");
    }
    Console.WriteLine("\n\nMain Menu:");
    Console.WriteLine(" 1- Add Contact");
    Console.WriteLine(" 2- Edit Contact");
    Console.WriteLine(" 3- Delete Contact");
    Console.WriteLine(" 4- View Contact");
    Console.WriteLine(" 5- List Contacts");
    Console.WriteLine(" 6- Search");
    Console.WriteLine(" 7- Filter");
    Console.WriteLine(" 8- Save");
    Console.WriteLine(" 9- Exit");

    Console.WriteLine("Enter your choice: ");
    string choice = Console.ReadLine();
    if (choice == "1")
    {
        Console.WriteLine("Enter Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Phone Number: ");
        string phone = Console.ReadLine();
        Console.WriteLine("Enter Email: ");
        string email = Console.ReadLine();
        Contact contact = new Contact(name, phone, email);
        service.AddContact(contact);
    }
    else if (choice == "2")
    {
        Console.WriteLine("Enter Id of the Contact: ");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter New Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter New Phone Number: ");
        string phone = Console.ReadLine();
        Console.WriteLine("Enter New Email: ");
        string email = Console.ReadLine();
        Contact contact = new Contact(name, phone, email);
        service.EditContact(id, contact);
    }
    else if (choice == "3")
    {
        Console.WriteLine("Enter Id of the Contact: ");
        int id = int.Parse(Console.ReadLine());
        service.DeleteContact(id);
    }
    else if (choice == "4")
    {
        Console.WriteLine("Enter Id of the Contact: ");
        int id = int.Parse(Console.ReadLine());
        Contact contact = service.ViewContact(id);
        if (contact != null)
        {
            Console.WriteLine(contact);
        }
        else
        {
            Console.WriteLine("Contact not Found!");
        }
    }
    else if (choice == "5")
    {
        foreach (var contact in service.GetContacts())
        {
            Console.WriteLine(contact);
        }
    }
    else if (choice == "8")
    {
        service.Save();
    }
    else if (choice == "9")
    {
        break;
    }
    else if (choice == "6")
    {

        Console.WriteLine("Enter search keyword:");
        string keyword = Console.ReadLine();

        Console.WriteLine("Search by:");
        Console.WriteLine("1 - Name");
        Console.WriteLine("2 - Email");
        Console.WriteLine("3 - Phone");

        choice = Console.ReadLine();

        IContactSearch strategy = choice switch
        {
            "1" => new SearchByName(),
            "2" => new SearchByEmail(),
            "3" => new SearchByPhone(),
            _ => null
        };

        if (strategy != null)
        {
            var results = service.Search(strategy, keyword);

            foreach (var contact in results)
            {
                Console.WriteLine(contact.ToString());
            }
        }
    }
}