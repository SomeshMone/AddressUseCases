using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AddressBookMain
{
    public class AddressBook
    {
        public List<Contact> contacts=new List<Contact>();

        public IEnumerable<Contact> SearchByCityOrState(string searchLocation)
        {
            return contacts
                .Where(contact => contact.City.Equals(searchLocation, StringComparison.OrdinalIgnoreCase) ||
                                 contact.State.Equals(searchLocation, StringComparison.OrdinalIgnoreCase));
        }

        //public AddressBook()
        //{
        //    contacts = new List<Contact>();
        //}

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public void DisplayContacts()
        {
            foreach (var contact in contacts)
            {
               Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}, Phone: {contact.PhoneNumber} , Address :{contact.Address} , Email:{contact.Email},City");
            }
            //for(int i=0; i<contacts.Count; i++)
            //{
            //    Console.WriteLine(contacts[i].FirstName+" " + contacts[i].LastName);
            //}
        }

        public Contact FindContactIndex(int index)
        {
            for(int j=0; j<contacts.Count; j++)
            {
                if (index == j)
                {
                    return contacts[index];
                }
            }
            return null;
        }
        public void DeleteContact(int index)
        {
            Contact contactToDelete = FindContactIndex(index);

            if (contactToDelete != null)
            {
                contacts.Remove(contactToDelete);
                Console.WriteLine($"Contact {contactToDelete.FirstName} {contactToDelete.LastName} deleted successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
        public Contact FindContactByName(string firstName, string lastName)
        {
            foreach (var contact in contacts)
            {
                if ((contact.FirstName==firstName) && (contact.LastName==lastName))
                {
                    return contact;
                }
            }

            
            return null;
        }
        


        public void EditContact(string firstName, string lastName)
        {
            Contact existingContact = FindContactByName(firstName, lastName);

            if (existingContact != null)
            {
                Console.WriteLine($"Editing contact: {existingContact.FirstName} {existingContact.LastName}");

                Console.WriteLine("Enter new Firstname");
                existingContact.FirstName = Console.ReadLine();

                Console.WriteLine("Enter new last name");
                existingContact.LastName = Console.ReadLine();

                Console.WriteLine("Enter new address");
                existingContact.Address = Console.ReadLine();

                Console.WriteLine("Enter new city name");
                existingContact.City = Console.ReadLine();

                Console.WriteLine("Enter new state name");
                existingContact.State = Console.ReadLine();

                Console.WriteLine("Enter new zip code");
                existingContact.Zip = Console.ReadLine();

                Console.WriteLine("Enter new phone number");
                existingContact.PhoneNumber = Console.ReadLine();

                Console.WriteLine("Enter new email id");
                existingContact.Email = Console.ReadLine();

                Console.WriteLine("Contact updated successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

    }
}
