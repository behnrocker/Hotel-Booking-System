//Name: Behn McIlwaine, Marco Saad, Manon Miron
//Date: April 22, 2016
//Class: CIS-2261
//Final Project: Hotel Booking System
//Notes: The class used to store reservations

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    class Reservation
    {
        private int reservationID;
        private int customerID;
        private DateTime checkInDate;
        private DateTime checkOutDate;
        private int roomNumber;
        private Boolean isCheckedIn;
        private int isCheckedInInt;

        public Reservation()
        {
            IsCheckedIn = false;
        }

        public Reservation(int cust, int res, String room, DateTime checkin, DateTime checkout)
        {
            //Convert Room Number to int
            //DEBUG
            int roomInt = Int32.Parse(room);

            customerID = cust;
            reservationID = res;
            checkInDate = checkin;
            checkOutDate = checkout;
            roomNumber = roomInt;
            isCheckedIn = false;
            isCheckedInInt = 0;
        }

        public Reservation(int cust, int res, int room, DateTime checkin, DateTime checkout, Boolean checkedIn)
        {
            customerID = cust;
            reservationID = res;
            checkInDate = checkin;
            checkOutDate = checkout;
            roomNumber = room;
            isCheckedIn = checkedIn;

            if (isCheckedIn)
            {
                isCheckedInInt = 1;
            } else
            {
                isCheckedInInt = 0;
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

        public DateTime CheckInDate
        {
            get
            {
                return checkInDate;
            }

            set
            {
                checkInDate = value;
            }
        }

        public DateTime CheckOutDate
        {
            get
            {
                return checkOutDate;
            }

            set
            {
                checkOutDate = value;
            }
        }

        public int RoomNumber
        {
            get
            {
                return roomNumber;
            }

            set
            {
                roomNumber = value;
            }
        }

        public bool IsCheckedIn
        {
            get
            {
                return isCheckedIn;
            }

            set
            {
                isCheckedIn = value;

                if(value == true)
                {
                    isCheckedInInt = 1;
                } else
                {
                    isCheckedInInt = 0;
                }
            }
        }

        public int IsCheckedInInt
        {
            get
            {
                return isCheckedInInt;
            }

            set
            {
                isCheckedInInt = value;
            }
        }
    }
}
