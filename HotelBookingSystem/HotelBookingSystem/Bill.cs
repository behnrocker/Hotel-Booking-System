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
        private double totalPrice;

        public Bill()
        {

        }

        public Bill(int id, int custID, int roomType, Boolean paid, double price)
        {
            billID = id;
            customerID = custID;
            roomTypeID = roomType;
            isPaid = paid;
            totalPrice = price;
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
    }
}
