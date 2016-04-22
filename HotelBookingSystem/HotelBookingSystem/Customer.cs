//Name: Behn McIlwaine, Marco Saad, Manon Miron
//Date: April 22, 2016
//Class: CIS-2261
//Final Project: Hotel Booking System
//Notes: The class for the Customer object. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    class Customer
    {
        private int customerID;
        private String firstName;
        private String lastName;
        private String streetAddress;
        private String city;
        private String province;
        private String postalCode;

        public Customer()
        {

        }

        public Customer(String fName, String lName, String address, String cty, String prov, String postal)
        {
            firstName = fName;
            lastName = lName;
            streetAddress = address;
            city = cty;
            province = prov;
            postalCode = postal;
        }

        public Customer(int id, String fName, String lName, String address, String cty, String prov, String postal)
        {
            customerID = id;
            firstName = fName;
            lastName = lName;
            streetAddress = address;
            city = cty;
            province = prov;
            postalCode = postal;
        }

        public int CustomerID
        {
            get
            {
                return customerID;
            }

            set
            {
                customerID = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public string StreetAddress
        {
            get
            {
                return streetAddress;
            }

            set
            {
                streetAddress = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
            }
        }

        public string Province
        {
            get
            {
                return province;
            }

            set
            {
                province = value;
            }
        }

        public string PostalCode
        {
            get
            {
                return postalCode;
            }

            set
            {
                postalCode = value;
            }
        }
    }
}
