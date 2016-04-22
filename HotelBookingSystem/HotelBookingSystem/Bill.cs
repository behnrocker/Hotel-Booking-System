//Name: Behn McIlwaine, Marco Saad, Manon Miron
//Date: April 22, 2016
//Class: CIS-2261
//Final Project: Hotel Booking System
//Notes: The class for the Bill object. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    class Bill
    {
        private int billID;
        private int customerID;
        private int roomTypeID;
        private Boolean isPaid;
        private int isPaidInt;
        private double totalPrice;
        private int reservationID;
        private int roomServiceID;

        public Bill()
        {
            isPaid = false;
            isPaidInt = 0;
        }

        //For when there is no room service ID
        public Bill(int id, int custID, int roomType, Boolean paid, double price, int resID)
        {
            billID = id;
            customerID = custID;
            roomTypeID = roomType;
            isPaid = paid;
            totalPrice = price;
            reservationID = resID;
            roomServiceID = 0;

            if (isPaid)
            {
                isPaidInt = 1;
            } else
            {
                isPaidInt = 0;
            }
        }

        //For when there is a room service ID
        public Bill(int id, int custID, int roomType, Boolean paid, double price, int resID, int rservID)
        {
            billID = id;
            customerID = custID;
            roomTypeID = roomType;
            isPaid = paid;
            totalPrice = price;
            reservationID = resID;
            roomServiceID = rservID;
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

        public int RoomTypeID
        {
            get
            {
                return roomTypeID;
            }

            set
            {
                roomTypeID = value;
            }
        }

        public bool IsPaid
        {
            get
            {
                return isPaid;
            }

            set
            {
                isPaid = value;

                if (value)
                {
                    isPaidInt = 1;
                }
                else
                {
                    isPaidInt = 0;
                }
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

        public int ReservationID
        {
            get
            {
                return reservationID;
            }

            set
            {
                reservationID = value;
            }
        }

        public int RoomServiceID
        {
            get
            {
                return roomServiceID;
            }

            set
            {
                roomServiceID = value;
            }
        }

        public int IsPaidInt
        {
            get
            {
                return isPaidInt;
            }

            set
            {
                isPaidInt = value;
            }
        }
    }
}
