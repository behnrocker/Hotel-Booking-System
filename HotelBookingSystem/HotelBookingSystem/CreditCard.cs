using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    class CreditCard
    {
        private String cardNumber;
        private int customerID;
        private int csvNumber;
        private DateTime expiryDate;
        private String nameOnCard;
        private String cardType;

        public CreditCard()
        {

        }

        public CreditCard(String number, String id, String csv, String expiry, String name, String type)
        {
            //Convert expiry to DateTime.
            DateTime expiryDateTime;

            //Convert number, id and csv to int
            //int numberInt = Int32.Parse(number);
            int idInt = Int32.Parse(id);
            int csvInt = Int32.Parse(csv);

            cardNumber = number;
            customerID = idInt;
            csvNumber = csvInt;
            //expiryDate = expiryDateTime;
            nameOnCard = name;
            cardType = type;

        }

        public String CardNumber
        {
            get
            {
                return cardNumber;
            }

            set
            {
                cardNumber = value;
            }
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

        public int CsvNumber
        {
            get
            {
                return csvNumber;
            }

            set
            {
                csvNumber = value;
            }
        }

        public DateTime ExpiryDate
        {
            get
            {
                return expiryDate;
            }

            set
            {
                expiryDate = value;
            }
        }

        public string NameOnCard
        {
            get
            {
                return nameOnCard;
            }

            set
            {
                nameOnCard = value;
            }
        }

        public string CardType
        {
            get
            {
                return cardType;
            }

            set
            {
                cardType = value;
            }
        }
    }
}
