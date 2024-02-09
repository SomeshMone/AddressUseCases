using System.Collections.Generic;
using System.Net;
using System.Numerics;

namespace AddressBookMain
{
    public class AddressBookMain
    {
        static void Main(string[] args)
        {
            // Dictionary to store Address Books with their unique names
            Dictionary<string, AddressBook> addressBooks = new Dictionary<string, AddressBook>();

            while (true)
            {
                Console.WriteLine("Address Book Management System");
                Console.WriteLine("1. Create New Address Book");
                Console.WriteLine("2. Access Existing Address Book");
                Console.WriteLine("3. Search Person by City or State");
                Console.WriteLine("4. Exit");


                Console.WriteLine("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the name of the new Address Book: ");
                        string newAddressBookName = Console.ReadLine();

                        // Check if the Address Book name already exists
                        if (addressBooks.ContainsKey(newAddressBookName))
                        {
                            throw new Exception($"Address Book '{newAddressBookName}' already exists.");
                        }

                        AddressBook newAddressBook = new AddressBook();
                        addressBooks.Add(newAddressBookName, newAddressBook);
                        Console.WriteLine($"Address Book '{newAddressBookName}' created successfully.");
                        break;

                    case 2:
                        Console.WriteLine("Enter the name of the Address Book to access: ");
                        string existingAddressBookName = Console.ReadLine();
                        if (addressBooks.ContainsKey(existingAddressBookName))
                        {
                            AddressBook existingAddressBook = addressBooks[existingAddressBookName];
                            // Now you can perform operations on the existing Address Book
                            // (e.g., adding contacts, editing, deleting, etc.)
                            AccessAddressBook(existingAddressBook);
                        }
                        else
                        {
                            Console.WriteLine($"Address Book '{existingAddressBookName}' not found.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter the city or state to search: ");
                        string searchLocation = Console.ReadLine();
                        SearchPersonByCityOrState(addressBooks.Values, searchLocation);
                        break;

                    case 4:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
        

        // Method to access an existing Address Book
        static void AccessAddressBook(AddressBook addressBook)
        {
            // (e.g., adding contacts, editing, deleting, etc.)
            Console.WriteLine("Address Book accessed successfully.");
            Console.WriteLine("Enter Firstname");
            string first = Console.ReadLine();

            Console.WriteLine("Enter last name");
            string last = Console.ReadLine();

            Console.WriteLine("Enter the address");
            string address = Console.ReadLine();

            Console.WriteLine("Enter city name");
            string city = Console.ReadLine();

            Console.WriteLine("Enter state name");
            string state = Console.ReadLine();

            Console.WriteLine("Enter zip code");
            string zip = Console.ReadLine();

            Console.WriteLine("Enter phone number");
            string phone = Console.ReadLine();

            Console.WriteLine("Enter email id");
            string email = Console.ReadLine();

            Contact newContact1 = new Contact(first, last, address, city, state, zip, phone, email);
            addressBook.AddContact(newContact1);
            addressBook.DisplayContacts();



        }
        static void SearchPersonByCityOrState(IEnumerable<AddressBook> addressBooks, string searchLocation)
        {
            var results = addressBooks
        .SelectMany(book => book.contacts
        .Where(contact => contact.City.Equals(searchLocation, StringComparison.OrdinalIgnoreCase) ||
                         contact.State.Equals(searchLocation, StringComparison.OrdinalIgnoreCase)))
    .ToList();


            if (results.Any())
            {
                Console.WriteLine($"Search results in {searchLocation}:");
                foreach (var result in results)
                {
                    Console.WriteLine($"Name: {result.FirstName} {result.LastName}, Phone: {result.PhoneNumber}, Address: {result.Address}, Email: {result.Email}");
                }
            }
            else
            {
                Console.WriteLine($"No results found in {searchLocation}.");
            }
        }
    }
}
