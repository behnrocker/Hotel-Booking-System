using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    class PaymentProcessor
    {

        private int billID;
        private double totalPrice;
        private String cardNumber;
        private int csvNumber;
        private String nameOnCard;
        private String cardType;
        private Boolean wasSuccessful;

        public PaymentProcessor()
        {

        }

        public PaymentProcessor(int bill, double price, String cNumber, int csv, String name, String type)
        {
            billID = bill;
            totalPrice = price;
            cardNumber = cNumber;
            csvNumber = csv;
            nameOnCard = name;
            cardType = type;
        }

        public int BillID
        {
            get
            {
                return billID;
            }

            set
            {
                billID = value;
            }
        }

        public double TotalPrice
        {
            get
            {
                return totalPrice;
            }

            set
            {
                totalPrice = value;
            }
        }

        public string CardNumber
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

        public bool WasSuccessful
        {
            get
            {
                return wasSuccessful;
            }

            set
            {
                wasSuccessful = value;
            }
        }

        //To be used if a blank object is created.
        public void processPayment(int bill, double price, String cNumber, int csv, String name, String type)
        {
            billID = bill;
            totalPrice = price;
            cardNumber = cNumber;
            csvNumber = csv;
            nameOnCard = name;
            cardType = type;

            //TEST CARD NEEDED
            //With current setup, there is no connection to payment processing companies. A dummy card/information needs
            //to be used until the system is set up in the hotel, and accounts are created.
            if(cardNumber == "5554555455545554" && csvNumber == 999 && cardType == "Visa")
            {
                //Once set up in hotel, the following needs to be filled in
                //Remove if statement with dummy card.
                //Send number/CSV/name to credit card authoriziation agency.
                //Receive response. If cleared, proceed.
                //Charge card. Wait for response to make sure payment clears.
                //Receive response. If payment clears, bill is marked as paid. If not, error is thrown.

                //Mark bill paid in DB.

                //Mark successful in class
                WasSuccessful = true;

            }
            else
            {
                //MessageBox.Show("Invalid credit card details. Please try again.");
            }
        }

        //To be used if a filled object has already been created.
        public void processPayment()
        {

        }

}
}
