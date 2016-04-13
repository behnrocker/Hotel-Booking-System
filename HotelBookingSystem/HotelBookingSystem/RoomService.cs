using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    class RoomService
    {
        private int roomServiceID;
        private String itemOrdered;
        private int customerID;
        private int roomNumber;
        private String specialInstructions;
        private double totalPrice;
        private DateTime timeOrderedFor;

        public RoomService()
        {
            roomServiceID = 0;
        }

        public RoomService(String item, int custID, int room, String instructions, double price, DateTime ordered)
        {
            itemOrdered = item;
            customerID = custID;
            roomNumber = room;
            specialInstructions = instructions;
            totalPrice = price;
            timeOrderedFor = ordered;
        }

        public RoomService(int id, String item, int custID, int room, String instructions, double price, DateTime ordered)
        {
            roomServiceID = id;
            itemOrdered = item;
            customerID = custID;
            roomNumber = room;
            specialInstructions = instructions;
            totalPrice = price;
            timeOrderedFor = ordered;
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

        public string ItemOrdered
        {
            get
            {
                return itemOrdered;
            }

            set
            {
                itemOrdered = value;
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

        public string SpecialInstructions
        {
            get
            {
                return specialInstructions;
            }

            set
            {
                specialInstructions = value;
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

        public DateTime TimeOrderedFor
        {
            get
            {
                return timeOrderedFor;
            }

            set
            {
                timeOrderedFor = value;
            }
        }
    }
}
