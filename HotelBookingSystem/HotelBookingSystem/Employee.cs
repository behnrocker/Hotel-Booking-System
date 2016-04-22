//Name: Behn McIlwaine, Marco Saad, Manon Miron
//Date: April 22, 2016
//Class: CIS-2261
//Final Project: Hotel Booking System
//Notes: The class for the Employee object. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    class Employee
    {
        private int employeeID;
        private String firstName;
        private String lastName;
        private String streetAddress;
        private String city;
        private String province;
        private String postalCode;
        private String title;

        public Employee()
        {

        }

        public Employee(String fName, String lName, String address, String cty, String prov, String postal, String titl)
        {
            firstName = fName;
            lastName = lName;
            streetAddress = address;
            city = cty;
            province = prov;
            postalCode = postal;
            title = titl;
        }

        public Employee(int id, String fName, String lName, String address, String cty, String prov, String postal, String titl)
        {
            employeeID = id;
            firstName = fName;
            lastName = lName;
            streetAddress = address;
            city = cty;
            province = prov;
            postalCode = postal;
            title = titl;
        }

        public int EmployeeID
        {
            get
            {
                return employeeID;
            }

            set
            {
                employeeID = value;
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

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }
    }
}
