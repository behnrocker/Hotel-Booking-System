﻿using System;
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

        public Reservation()
        {

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
    }
}