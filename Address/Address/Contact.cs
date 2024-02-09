using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookMain
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
        public string Email { get; set; }
    
        public Contact(string firstName, string lastName, string address ,string city,string state,string zip,string phone,string email)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phone;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
            Email = email;


        }
        //first,last,address,city,state,zip,phone,email

    }
}
