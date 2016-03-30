using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    class Room
    {

        private readonly String REGULAR_ROOM = "Standard Room";
        private const String LUXURY_ROOM = "Luxury Suite";
        private const String CONFERENCE_ROOM = "Conference Room";

        private int roomNumber;
        private int roomTypeID;
        private String roomTypeString;
        private int roomFloor;

        public Room()
        {

        }

        public Room(int number, int type, int floor)
        {
            roomNumber = number;
            roomTypeID = type;
            roomFloor = floor;

            if(type == 0)
            {
                roomTypeString = REGULAR_ROOM;
            } else if(type == 1)
            {
                roomTypeString = LUXURY_ROOM;
            } else if(type == 2)
            {
                roomTypeString = CONFERENCE_ROOM;
            } else
            {
                roomTypeString = "";
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

        public int RoomFloor
        {
            get
            {
                return roomFloor;
            }

            set
            {
                roomFloor = value;
            }
        }

        public string RoomTypeString
        {
            get
            {
                return roomTypeString;
            }

            set
            {
                roomTypeString = value;
            }
        }
    }
}
