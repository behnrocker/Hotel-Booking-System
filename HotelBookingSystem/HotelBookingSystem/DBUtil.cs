//Name: Behn McIlwaine, Marco Saad, Manon Miron
//Date: April 22, 2016
//Class: CIS-2261
//Final Project: Hotel Booking System
//Notes: This is the class where most of the database interactions are handled. Major functions (like 
//       Opening, Writing, and Updating) are in here.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;


namespace HotelBookingSystem
{
    class DBUtil
    {
        public DBUtil()
        {
        }

        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBUtil _instance = null;
        public static DBUtil Instance()
        {
            if (_instance == null)
                _instance = new DBUtil();
            return _instance;
        }

        public bool Open()
        {
            bool result = false;
            if (Connection == null)
            {
                string connstring = "SERVER=" + "localhost" + ";" + "DATABASE=" + "SleepEasyDB" + ";" + "UID=" + "admin" + ";" + "PASSWORD=" + "admin" + ";";
                connection = new MySqlConnection(connstring);
                connection.Open();
                result = true;
            }

            return result;
        }

        public void Close()
        {
            connection.Close();
        }

        public void InsertEmployee(Employee e)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Employee (employeeID,firstName,lastName,streetAddress,city,province,postalCode,title) VALUES (?employeeID,?firstName,?lastName,?streetAddress,?city,?province,?postalCode,?title)";
            command.Parameters.AddWithValue("?employeeID", e.EmployeeID);
            command.Parameters.AddWithValue("?firstName", e.FirstName);
            command.Parameters.AddWithValue("?lastName", e.LastName);
            command.Parameters.AddWithValue("?streetAddress", e.StreetAddress);
            command.Parameters.AddWithValue("?city", e.City);
            command.Parameters.AddWithValue("?province", e.Province);
            command.Parameters.AddWithValue("?postalCode", e.PostalCode);
            command.Parameters.AddWithValue("?title", e.Title);
            command.ExecuteNonQuery();
        }

        public int GetNewEmployeeID()
        {
            int result = 1; //default value if null is read

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT MAX(employeeID) FROM Employee";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result = reader.GetInt32(0) + 1;
            }

            reader.Close();

            return result;
        }

        public Employee FindEmployeeById(int employeeID)
        {
            Employee e = new Employee(); //default value if null is read

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT employeeID,firstName,lastName,streetAddress,city,province,postalCode,title FROM Employee WHERE employeeID = ?employeeID";
            command.Parameters.AddWithValue("?employeeID", employeeID);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                e.EmployeeID = reader.GetInt32(0);
                e.FirstName = reader.GetString(1);
                e.LastName = reader.GetString(2);
                e.StreetAddress = reader.GetString(3);
                e.City = reader.GetString(4);
                e.Province = reader.GetString(5);
                e.PostalCode = reader.GetString(6);
                e.Title = reader.GetString(7);
            }

            return e;
        }

        public void UpdateEmployee(Employee e)
        {
            MySqlCommand command = connection.CreateCommand();
            command.Parameters.AddWithValue("?employeeID", e.EmployeeID);
            command.Parameters.AddWithValue("?firstName", e.FirstName);
            command.Parameters.AddWithValue("?lastName", e.LastName);
            command.Parameters.AddWithValue("?streetAddress", e.StreetAddress);
            command.Parameters.AddWithValue("?city", e.City);
            command.Parameters.AddWithValue("?province", e.Province);
            command.Parameters.AddWithValue("?postalCode", e.PostalCode);
            command.Parameters.AddWithValue("?title", e.Title);
            command.ExecuteNonQuery();
        }

        public void DeleteEmployee(Employee e)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM EMPLOYEE WHERE employeeID=?employeeID";
            command.Parameters.AddWithValue("?employeeID", e.EmployeeID);
            command.ExecuteNonQuery();
        }

        public void insertCustomer(Customer c)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Customer (customerID,firstName,lastName,streetAddress,city,province,postalCode) VALUES (?customerID,?firstName,?lastName,?streetAddress,?city,?province,?postalCode)";
            command.Parameters.AddWithValue("?customerID", c.CustomerID);
            command.Parameters.AddWithValue("?firstName", c.FirstName);
            command.Parameters.AddWithValue("?lastName", c.LastName);
            command.Parameters.AddWithValue("?streetAddress", c.StreetAddress);
            command.Parameters.AddWithValue("?city", c.City);
            command.Parameters.AddWithValue("?province", c.Province);
            command.Parameters.AddWithValue("?postalCode", c.PostalCode);
            command.ExecuteNonQuery();

        }

        public int GetNewCustomerID()
        {
            int result = 1; //default value if null is read

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT MAX(customerID) FROM Customer";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result = reader.GetInt32(0) + 1;
            }

            reader.Close();

            return result;
        }

        public Customer FindCustomerById(int customerID)
        {
            Customer c = new Customer(); //default value if null is read

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT customerID, firstName,lastName,streetAddress,city,province,postalCode FROM Customer WHERE customerID = ?customerID";
            command.Parameters.AddWithValue("?customerID", customerID);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                c.CustomerID = reader.GetInt32(0);
                c.FirstName = reader.GetString(1);
                c.LastName = reader.GetString(2);
                c.StreetAddress = reader.GetString(3);
                c.City = reader.GetString(4);
                c.Province = reader.GetString(5);
                c.PostalCode = reader.GetString(6);

            }

            return c;
        }

        public void UpdateCustomer(Customer c)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Customer SET firstName = ?firstName,lastName = ?lastName,streetAddress = ?streetAddress,city=?city,province=?province,postalCode=?postalCode WHERE customerID=?customerID";
            command.Parameters.AddWithValue("?customerID", c.CustomerID);
            command.Parameters.AddWithValue("?firstName", c.FirstName);
            command.Parameters.AddWithValue("?lastName", c.LastName);
            command.Parameters.AddWithValue("?streetAddress", c.StreetAddress);
            command.Parameters.AddWithValue("?city", c.City);
            command.Parameters.AddWithValue("?province", c.Province);
            command.Parameters.AddWithValue("?postalCode", c.PostalCode);
            command.ExecuteNonQuery();
        }

        public void DeleteCustomer(Customer c)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE Customer WHERE customerID=?customerID";
            command.Parameters.AddWithValue("?customerID", c.CustomerID);
            command.ExecuteNonQuery();
        }

        public void insertReservation(Reservation r)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Reservation (reservationID, customerID, checkInDate, checkOutDate, roomNumber, checkedIn) VALUES (?reservationID, ?customerID, ?checkInDate, ?checkOutDate, ?roomNumber, ?isCheckedIn)";
            command.Parameters.AddWithValue("?reservationID", r.ReservationID);
            command.Parameters.AddWithValue("?customerID", r.CustomerID);
            command.Parameters.AddWithValue("?checkInDate", r.CheckInDate);
            command.Parameters.AddWithValue("?checkOutDate", r.CheckOutDate);
            command.Parameters.AddWithValue("?roomNumber", r.RoomNumber);
            command.Parameters.AddWithValue("?isCheckedIn", r.IsCheckedInInt);

            command.ExecuteNonQuery();

        }

        public int GetNewReservationID()
        {
            int result = 1; //default value if null is read

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT MAX(reservationID) FROM Reservation";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result = reader.GetInt32(0) + 1;
            }

            reader.Close();

            return result;
        }

        public Reservation FindReservationById(int reservationID)
        {
            Reservation r = new Reservation(); //default value if null is read

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT reservationID, customerID, checkInDate, checkOutDate, roomNumber FROM Reservation WHERE reservationID = ?reservationID";
            command.Parameters.AddWithValue("?reservationID", reservationID);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                r.ReservationID = reader.GetInt32(0);
                r.CustomerID = reader.GetInt32(1);
                r.CheckInDate = reader.GetDateTime(2);
                r.CheckOutDate = reader.GetDateTime(3);
                r.RoomNumber = reader.GetInt32(4);


            }

            return r;
        }

        public void UpdateReservation(Reservation r)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Reservation SET customerID = ?customerID, checkInDate = ?checkInDate, checkOutDate = ?checkOutDate, roomNumber = ?roomNumber, checkedIn = ?isCheckedIn WHERE reservationID=?reservationID";
            command.Parameters.AddWithValue("?reservationID", r.ReservationID);
            command.Parameters.AddWithValue("?customerID", r.CustomerID);
            command.Parameters.AddWithValue("?checkInDate", r.CheckInDate);
            command.Parameters.AddWithValue("?checkOutDate", r.CheckOutDate);
            command.Parameters.AddWithValue("?roomNumber", r.RoomNumber);
            command.Parameters.AddWithValue("?isCheckedIn", r.IsCheckedInInt);

            command.ExecuteNonQuery();
        }

        public void DeleteReservation(Reservation r)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE Reservation WHERE reservationID=?reservationID";
            command.Parameters.AddWithValue("?reservationID", r.ReservationID);
            command.ExecuteNonQuery();
        }

        public int GetNewRoomNumber()
        {
            int result = 1; //default value if null is read

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT MAX(roomNumber) FROM Room";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result = reader.GetInt32(0) + 1;
            }

            reader.Close();

            return result;
        }

        public int GetNewRoomTypeID()
        {
            int result = 1; //default value if null is read

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT MAX(roomTypeID) FROM Room";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result = reader.GetInt32(0) + 1;
            }

            return result;
        }

        public void InsertRoom(Room rm)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Room (roomNumber,roomTypeID,roomFloor) VALUES (?roomNumber,?roomTypeID,?roomFloor)";
            command.Parameters.AddWithValue("?roomNumber", rm.RoomNumber);
            command.Parameters.AddWithValue("?roomTypeID", rm.RoomTypeID);
            command.Parameters.AddWithValue("?roomFloor", rm.RoomFloor);
            command.ExecuteNonQuery();
        }

        //public void InsertSingleRoom(SingleRoom sr)
        //{
        //    sr.roomTypeID = GetNewRoomTypeID();

        //    MySqlCommand command = connection.CreateCommand();
        //    command.CommandText = "INSERT INTO RoomType (roomTypeID, bedSize, numberOfBeds, availability, specialItems, billAmount, maxCapacity, type) VALUES (?roomTypeID, ?bedSize, ?numberOfBeds, ?availability, ?specialItems, ?billAmount, ?maxCapacity, ?type)";
        //    command.Parameters.AddWithValue("?roomTypeID", sr.roomTypeID);
        //    command.Parameters.AddWithValue("?bedSize", sr.bedSize);
        //    command.Parameters.AddWithValue("?numberOfBeds", sr.numberOfBeds);
        //    if (sr.isAvailable == true)
        //    {
        //        command.Parameters.AddWithValue("?availability", "T");
        //    }
        //    else
        //    {
        //        command.Parameters.AddWithValue("?availability", "F");
        //    }
        //    command.Parameters.AddWithValue("?specialItems", sr.specialItems);
        //    command.Parameters.AddWithValue("?billAmount", Convert.ToInt32(sr.billAmount * 100));
        //    command.Parameters.AddWithValue("?maxCapacity", sr.maxCapacity);
        //    command.Parameters.AddWithValue("?type", "SingleRoom");

        //    command.ExecuteNonQuery();

        //    MySqlCommand command2 = connection.CreateCommand();
        //    command2.CommandText = "INSERT INTO Room (roomNumber,roomTypeID,roomFloor) VALUES (?roomNumber,?roomTypeID,?roomFloor)";
        //    command2.Parameters.AddWithValue("?roomNumber", sr.roomNumber);
        //    command2.Parameters.AddWithValue("?roomTypeID", sr.roomTypeID);
        //    command2.Parameters.AddWithValue("?roomFloor", sr.roomFloor);

        //    command2.ExecuteNonQuery();

        //}

        //public void DeleteSingleRoom(SingleRoom sr)
        //{
        //    MySqlCommand command = connection.CreateCommand();
        //    command.CommandText = "DELETE Room WHERE roomNumber = ?roomNumber";
        //    command.Parameters.AddWithValue("?roomNumber", sr.roomNumber);
        //    command.ExecuteNonQuery();

        //    MySqlCommand command2 = connection.CreateCommand();
        //    command.CommandText = "DELETE RoomType WHERE roomTypeID = ?roomTypeID";
        //    command.Parameters.AddWithValue("?roomTypeID", sr.roomTypeID);
        //    command.ExecuteNonQuery();
        //}

        //public void UpdateSingleRoom(SingleRoom sr)
        //{
        //    MySqlCommand command = connection.CreateCommand();
        //    command.CommandText = "UPDATE Room SET roomTypeID = ?roomTypeID, roomFloor = ?roomFloor WHERE roomNumber = ?roomNumber";
        //    command.Parameters.AddWithValue("?roomTypeID", sr.roomTypeID);
        //    command.Parameters.AddWithValue("?roomFloor", sr.roomFloor);
        //    command.Parameters.AddWithValue("?roomNumber", sr.roomNumber);
        //    command.ExecuteNonQuery();

        //    MySqlCommand command2 = connection.CreateCommand();
        //    command2.CommandText = "UPDATE RoomType SET bedSize = ?bedSize, numberOfBeds = ?numberOfBeds, availability = ?availability, specialItems = ?specialItems, billAmount = ?billAmount, maxCapacity = ?maxCapacity, type = ?type WHERE roomTypeID = ?roomTypeID";
        //    command2.Parameters.AddWithValue("?bedSize", sr.bedSize);
        //    command2.Parameters.AddWithValue("?numberOfBeds", sr.numberOfBeds);
        //    if (sr.isAvailable == true)
        //    {
        //        command2.Parameters.AddWithValue("?availability", "T");
        //    }
        //    else
        //    {
        //        command2.Parameters.AddWithValue("?availability", "F");
        //    }
        //    command2.Parameters.AddWithValue("?specialItems", sr.specialItems);
        //    command2.Parameters.AddWithValue("?billAmount", Convert.ToInt32(sr.billAmount * 100));
        //    command2.Parameters.AddWithValue("?maxCapacity", sr.maxCapacity);
        //    command2.Parameters.AddWithValue("?type", "SingleRoom");
        //    command2.Parameters.AddWithValue("?roomTypeID", sr.roomTypeID);
        //    command.ExecuteNonQuery();
        //}

        //public void InsertSuite(Suite s)
        //{
        //    s.roomTypeID = GetNewRoomTypeID();

        //    MySqlCommand command = connection.CreateCommand();
        //    command.CommandText = "INSERT INTO RoomType (roomTypeID, bedSize, numberOfBeds, availability, specialItems, billAmount, maxCapacity, type) VALUES (?roomTypeID, ?bedSize, ?numberOfBeds, ?availability, ?specialItems, ?billAmount, ?maxCapacity, ?type)";
        //    command.Parameters.AddWithValue("?roomTypeID", s.roomTypeID);
        //    command.Parameters.AddWithValue("?bedSize", s.bedSize);
        //    command.Parameters.AddWithValue("?numberOfBeds", s.numberOfBeds);
        //    if (s.isAvailable == true)
        //    {
        //        command.Parameters.AddWithValue("?availability", "T");
        //    }
        //    else
        //    {
        //        command.Parameters.AddWithValue("?availability", "F");
        //    }
        //    command.Parameters.AddWithValue("?specialItems", s.specialItems);
        //    command.Parameters.AddWithValue("?billAmount", Convert.ToInt32(s.billAmount * 100));
        //    command.Parameters.AddWithValue("?maxCapacity", s.maxCapacity);
        //    command.Parameters.AddWithValue("?type", "Suite");

        //    command.ExecuteNonQuery();

        //    MySqlCommand command2 = connection.CreateCommand();
        //    command2.CommandText = "INSERT INTO Room (roomNumber,roomTypeID,roomFloor) VALUES (?roomNumber,?roomTypeID,?roomFloor)";
        //    command2.Parameters.AddWithValue("?roomNumber", s.roomNumber);
        //    command2.Parameters.AddWithValue("?roomTypeID", s.roomTypeID);
        //    command2.Parameters.AddWithValue("?roomFloor", s.roomFloor);

        //    command2.ExecuteNonQuery();

        //}

        //public void DeleteSuite(Suite s)
        //{
        //    MySqlCommand command = connection.CreateCommand();
        //    command.CommandText = "DELETE Room WHERE roomNumber = ?roomNumber";
        //    command.Parameters.AddWithValue("?roomNumber", s.roomNumber);
        //    command.ExecuteNonQuery();

        //    MySqlCommand command2 = connection.CreateCommand();
        //    command.CommandText = "DELETE RoomType WHERE roomTypeID = ?roomTypeID";
        //    command.Parameters.AddWithValue("?roomTypeID", s.roomTypeID);
        //    command.ExecuteNonQuery();
        //}

        //public void UpdateSuite(Suite s)
        //{
        //    MySqlCommand command = connection.CreateCommand();
        //    command.CommandText = "UPDATE Room SET roomTypeID = ?roomTypeID, roomFloor = ?roomFloor WHERE roomNumber = ?roomNumber";
        //    command.Parameters.AddWithValue("?roomTypeID", s.roomTypeID);
        //    command.Parameters.AddWithValue("?roomFloor", s.roomFloor);
        //    command.Parameters.AddWithValue("?roomNumber", s.roomNumber);
        //    command.ExecuteNonQuery();

        //    MySqlCommand command2 = connection.CreateCommand();
        //    command2.CommandText = "UPDATE RoomType SET bedSize = ?bedSize, numberOfBeds = ?numberOfBeds, availability = ?availability, specialItems = ?specialItems, billAmount = ?billAmount, maxCapacity = ?maxCapacity, type = ?type WHERE roomTypeID = ?roomTypeID";
        //    command2.Parameters.AddWithValue("?bedSize", s.bedSize);
        //    command2.Parameters.AddWithValue("?numberOfBeds", s.numberOfBeds);
        //    if (s.isAvailable == true)
        //    {
        //        command2.Parameters.AddWithValue("?availability", "T");
        //    }
        //    else
        //    {
        //        command2.Parameters.AddWithValue("?availability", "F");
        //    }
        //    command2.Parameters.AddWithValue("?specialItems", s.specialItems);
        //    command2.Parameters.AddWithValue("?billAmount", Convert.ToInt32(s.billAmount * 100));
        //    command2.Parameters.AddWithValue("?maxCapacity", s.maxCapacity);
        //    command2.Parameters.AddWithValue("?type", "Suite");
        //    command2.Parameters.AddWithValue("?roomTypeID", s.roomTypeID);
        //    command.ExecuteNonQuery();
        //}

        //public void InsertConferenceRoom(ConferenceRoom cr)
        //{
        //    cr.roomTypeID = GetNewRoomTypeID();

        //    MySqlCommand command = connection.CreateCommand();
        //    command.CommandText = "INSERT INTO RoomType (roomTypeID, bedSize, numberOfBeds, availability, specialItems, billAmount, maxCapacity, type) VALUES (?roomTypeID, ?bedSize, ?numberOfBeds, ?availability, ?specialItems, ?billAmount, ?maxCapacity, ?type)";
        //    command.Parameters.AddWithValue("?roomTypeID", cr.roomTypeID);
        //    if (cr.soundSystemRequired)
        //    {
        //        command.Parameters.AddWithValue("?bedSize", "T");
        //    }
        //    else
        //    {
        //        command.Parameters.AddWithValue("?bedSize", "F");
        //    }

        //    command.Parameters.AddWithValue("?numberOfBeds", cr.numberOfChair);
        //    if (cr.isAvailable == true)
        //    {
        //        command.Parameters.AddWithValue("?availability", "T");
        //    }
        //    else
        //    {
        //        command.Parameters.AddWithValue("?availability", "F");
        //    }
        //    command.Parameters.AddWithValue("?specialItems", cr.specialItems);
        //    command.Parameters.AddWithValue("?billAmount", Convert.ToInt32(cr.billAmount * 100));
        //    command.Parameters.AddWithValue("?maxCapacity", cr.maxCapacity);
        //    command.Parameters.AddWithValue("?type", "ConferenceRoom");

        //    command.ExecuteNonQuery();

        //    MySqlCommand command2 = connection.CreateCommand();
        //    command2.CommandText = "INSERT INTO Room (roomNumber,roomTypeID,roomFloor) VALUES (?roomNumber,?roomTypeID,?roomFloor)";
        //    command2.Parameters.AddWithValue("?roomNumber", cr.roomNumber);
        //    command2.Parameters.AddWithValue("?roomTypeID", cr.roomTypeID);
        //    command2.Parameters.AddWithValue("?roomFloor", cr.roomFloor);

        //    command2.ExecuteNonQuery();

        //}

        //public void DeleteConferenceRoom(ConferenceRoom cr)
        //{
        //    MySqlCommand command = connection.CreateCommand();
        //    command.CommandText = "DELETE Room WHERE roomNumber = ?roomNumber";
        //    command.Parameters.AddWithValue("?roomNumber", cr.roomNumber);
        //    command.ExecuteNonQuery();

        //    MySqlCommand command2 = connection.CreateCommand();
        //    command.CommandText = "DELETE RoomType WHERE roomTypeID = ?roomTypeID";
        //    command.Parameters.AddWithValue("?roomTypeID", cr.roomTypeID);
        //    command.ExecuteNonQuery();
        //}

        //public void UpdateConferenceRoom(ConferenceRoom cr)
        //{
        //    MySqlCommand command = connection.CreateCommand();
        //    command.CommandText = "UPDATE Room SET roomTypeID = ?roomTypeID, roomFloor = ?roomFloor WHERE roomNumber = ?roomNumber";
        //    command.Parameters.AddWithValue("?roomTypeID", cr.roomTypeID);
        //    command.Parameters.AddWithValue("?roomFloor", cr.roomFloor);
        //    command.Parameters.AddWithValue("?roomNumber", cr.roomNumber);
        //    command.ExecuteNonQuery();

        //    MySqlCommand command2 = connection.CreateCommand();
        //    command2.CommandText = "UPDATE RoomType SET bedSize = ?bedSize, numberOfBeds = ?numberOfBeds, availability = ?availability, specialItems = ?specialItems, billAmount = ?billAmount, maxCapacity = ?maxCapacity, type = ?type WHERE roomTypeID = ?roomTypeID";
        //    if (cr.soundSystemRequired)
        //    {
        //        command2.Parameters.AddWithValue("?bedSize", "T");
        //    }
        //    else
        //    {
        //        command2.Parameters.AddWithValue("?bedSize", "F");
        //    }

        //    command2.Parameters.AddWithValue("?numberOfBeds", cr.numberOfChair);
        //    if (cr.isAvailable == true)
        //    {
        //        command2.Parameters.AddWithValue("?availability", "T");
        //    }
        //    else
        //    {
        //        command2.Parameters.AddWithValue("?availability", "F");
        //    }
        //    command2.Parameters.AddWithValue("?specialItems", cr.specialItems);
        //    command2.Parameters.AddWithValue("?billAmount", Convert.ToInt32(cr.billAmount * 100));
        //    command2.Parameters.AddWithValue("?maxCapacity", cr.maxCapacity);
        //    command2.Parameters.AddWithValue("?type", "ConferenceRoom");
        //    command2.Parameters.AddWithValue("?roomTypeID", cr.roomTypeID);
        //    command.ExecuteNonQuery();
        //}


        //public Room FindRoomByRoomNumber(int roomNumber)
        //{


        //    MySqlCommand command = connection.CreateCommand();
        //    command.CommandText = "SELECT R.roomNumber, R.roomFloor, R.roomTypeID, RT.bedsize, RT.numberOfBeds, RT.availability, RT.specialItems, RT.billAmount, RT.maxCapacity, RT.type FROM Room AS R, RoomType AS RT WHERE R.roomNumber = ?roomNumber and R.roomTypeID = RT.roomTypeID";
        //    command.Parameters.AddWithValue("?roomNumber", roomNumber);
        //    MySqlDataReader reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        if (reader.GetString(9) == "SingleRoom")
        //        {
        //            SingleRoom r = new SingleRoom();

        //            r.roomNumber = reader.GetInt32(0);
        //            r.roomFloor = reader.GetInt32(1);
        //            r.roomTypeID = reader.GetInt32(2);
        //            r.bedSize = reader.GetString(3);
        //            r.numberOfBeds = reader.GetInt32(4);
        //            if (reader.GetString(5) == "T")
        //            {
        //                r.isAvailable = true;
        //            }
        //            else
        //            {
        //                r.isAvailable = false;
        //            }
        //            r.specialItems = reader.GetString(6);
        //            r.billAmount = reader.GetInt32(7) / 100;
        //            r.maxCapacity = reader.GetInt32(8);
        //            return r;
        //        }

        //        if (reader.GetString(9) == "Suite")
        //        {
        //            Suite r = new Suite();

        //            r.roomNumber = reader.GetInt32(0);
        //            r.roomFloor = reader.GetInt32(1);
        //            r.roomTypeID = reader.GetInt32(2);
        //            r.bedSize = reader.GetString(3);
        //            r.numberOfBeds = reader.GetInt32(4);
        //            if (reader.GetString(5) == "T")
        //            {
        //                r.isAvailable = true;
        //            }
        //            else
        //            {
        //                r.isAvailable = false;
        //            }
        //            r.specialItems = reader.GetString(6);
        //            r.billAmount = reader.GetInt32(7) / 100;
        //            r.maxCapacity = reader.GetInt32(8);
        //            return r;
        //        }

        //        if (reader.GetString(9) == "ConferenceRoom")
        //        {
        //            ConferenceRoom r = new ConferenceRoom();

        //            r.roomNumber = reader.GetInt32(0);
        //            r.roomFloor = reader.GetInt32(1);
        //            r.roomTypeID = reader.GetInt32(2);
        //            if (reader.GetString(3).Trim() == "T")
        //            {
        //                r.soundSystemRequired = true;
        //            }
        //            else
        //            {
        //                r.soundSystemRequired = false;
        //            }

        //            r.numberOfChair = reader.GetInt32(4);
        //            if (reader.GetString(5) == "T")
        //            {
        //                r.isAvailable = true;
        //            }
        //            else
        //            {
        //                r.isAvailable = false;
        //            }
        //            r.specialItems = reader.GetString(6);
        //            r.billAmount = reader.GetInt32(7) / 100;
        //            r.maxCapacity = reader.GetInt32(8);
        //            return r;
        //        }
        //    }

        //    return null;
        //}

        public void deleteRoom(Room r)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM ROOM WHERE roomNumber=?roomNumber";
            command.Parameters.AddWithValue("?roomNumber", r.RoomNumber);
            command.ExecuteNonQuery();
        }

        public void insertBill(Bill b)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Reservation (billID, customerID, roomTypeID, isPaid) VALUES (?billID, ?customerID, ?roomTypeID, ?isPaid)";
            command.Parameters.AddWithValue("?billID", b.BillID);
            command.Parameters.AddWithValue("?customerID", b.CustomerID);
            command.Parameters.AddWithValue("?roomTypeID", b.RoomTypeID);
            if (b.IsPaid)
            {
                command.Parameters.AddWithValue("?isPaid", "T");
            }
            else
            {
                command.Parameters.AddWithValue("?isPaid", "F");
            }

            command.ExecuteNonQuery();

        }

        public int GetNewBillID()
        {
            int result = 1; //default value if null is read

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT MAX(billID) FROM Bill";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result = reader.GetInt32(0) + 1;
            }

            return result;
        }

        public Bill FindBillById(int billID)
        {
            Bill b = new Bill(); //default value if null is read

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT B.billID, B.customerID, B.roomTypeID, B.isPaid, RT.billAmount FROM Bill AS B, RoomType AS RT WHERE B.billID = ?billID and B.roomTypeID = RT.roomTypeID";
            command.Parameters.AddWithValue("?billID", billID);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                b.BillID = reader.GetInt32(0);
                b.CustomerID = reader.GetInt32(1);
                b.RoomTypeID = reader.GetInt32(2);
                if (reader.GetString(3) == "T")
                {
                    b.IsPaid = true;
                }
                else
                {
                    b.IsPaid = false;
                }
                b.TotalPrice = reader.GetInt32(4) / 100;
            }

            return b;
        }

        public double FindBillAmountByRoomTypeID(int roomTypeID)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT billAmount FROM RoomType WHERE roomTypeID = ?roomTypeID";
            command.Parameters.AddWithValue("?roomTypeID", roomTypeID);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                return reader.GetInt32(0) / 100;
            }
            return 0;
        }


        public void UpdateBill(Bill b)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Bill SET customerID = ?customerID, roomTypeID = ?roomTypeID, isPaid = ?isPaidInt, totalPrice = ?totalPrice, reservationID = ?reservationID, roomServiceID = ?roomServiceID WHERE billID=?billID";
            command.Parameters.AddWithValue("?customerID", b.CustomerID);
            command.Parameters.AddWithValue("?roomTypeID", b.RoomTypeID);
            if (b.IsPaid)
            {
                command.Parameters.AddWithValue("?isPaidInt", 1);
            }
            else
            {
                command.Parameters.AddWithValue("?isPaidInt", 0);
            }
            command.Parameters.AddWithValue("?totalPrice", b.TotalPrice);
            command.Parameters.AddWithValue("?reservationID", b.ReservationID);
            command.Parameters.AddWithValue("?roomServiceID", b.RoomServiceID);
            command.Parameters.AddWithValue("?billID", b.BillID);

            command.ExecuteNonQuery();
        }

        public void DeleteBill(Bill b)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE Bill WHERE billID=?billID";
            command.Parameters.AddWithValue("?reservationID", b.BillID);
            command.ExecuteNonQuery();
        }

        public void insertRoomService(RoomService rs)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO RoomService (roomServiceID, itemOrdered, customerID, roomNumber, specialInstructions, totalPrice, timeOrderedFor) VALUES (?roomServiceID, ?itemOrdered, ?customerID, ?roomNumber, ?specialInstructions, ?totalPrice, ?timeOrderedFor)";
            command.Parameters.AddWithValue("?roomServiceID", rs.RoomServiceID);
            command.Parameters.AddWithValue("?itemOrdered", rs.ItemOrdered);
            command.Parameters.AddWithValue("?customerID", rs.CustomerID);
            command.Parameters.AddWithValue("?roomNumber", rs.RoomNumber);
            command.Parameters.AddWithValue("?specialInstructions", rs.SpecialInstructions);
            command.Parameters.AddWithValue("?totalPrice", Convert.ToInt32(rs.TotalPrice * 100));
            command.Parameters.AddWithValue("?timeOrderedFor", rs.TimeOrderedFor);
            command.ExecuteNonQuery();

        }

        public int GetNewRoomServiceID()
        {
            int result = 1; //default value if null is read

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT MAX(roomServiceID) FROM RoomService";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result = reader.GetInt32(0) + 1;
            }

            reader.Close();

            return result;
        }

        public RoomService FindRoomServiceById(int roomServiceID)
        {
            RoomService r = new RoomService(); //default value if null is read

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT roomServiceID, itemOrdered, customerID, roomNumber, specialInstructions, totalPrice, timeOrderedFor FROM RoomService WHERE roomServiceID = ?roomServiceID";
            command.Parameters.AddWithValue("?roomServiceID", roomServiceID);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                r.RoomServiceID = reader.GetInt32(0);
                r.ItemOrdered = reader.GetString(1);
                r.CustomerID = reader.GetInt32(2);
                r.RoomNumber = reader.GetInt32(3);
                r.SpecialInstructions = reader.GetString(4);
                r.TotalPrice = reader.GetInt32(5) / 100;
                r.TimeOrderedFor = reader.GetDateTime(6);

            }

            return r;
        }

        public void UpdateRoomService(RoomService rs)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Reservation SET itemOrdered = ?itemOrdered, customerID = ?customerID, roomNumber = ?roomNumber, specialInstructions = ?specialInstructions, totalPrice = ?totalPrice, timeOrderedFor = ?timeOrderedFor WHERE roomServiceID = ?roomServiceID";
            command.Parameters.AddWithValue("?itemOrdered", rs.ItemOrdered);
            command.Parameters.AddWithValue("?customerID", rs.CustomerID);
            command.Parameters.AddWithValue("?roomNumber", rs.RoomNumber);
            command.Parameters.AddWithValue("?specialInstructions", rs.SpecialInstructions);
            command.Parameters.AddWithValue("?totalPrice", Convert.ToInt32(rs.TotalPrice * 100));
            command.Parameters.AddWithValue("?timeOrderedFor", rs.TimeOrderedFor);
            command.Parameters.AddWithValue("?roomServiceID", rs.RoomServiceID);

            command.ExecuteNonQuery();
        }

        public void DeleteRoomService(RoomService r)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE RoomService WHERE roomServiceID=?roomServiceID";
            command.Parameters.AddWithValue("?roomServiceID", r.RoomServiceID);
            command.ExecuteNonQuery();
        }

        public void insertCreditCard(CreditCard cc)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO CreditCard (cardNumber, customerID, csvNumber, expiryDate, nameOnCard, cardType) VALUES (?cardNumber, ?customerID, ?csvNumber, ?expiryDate, ?nameOnCard, ?cardType)";
            command.Parameters.AddWithValue("?cardNumber", cc.CardNumber);
            command.Parameters.AddWithValue("?customerID", cc.CustomerID);
            command.Parameters.AddWithValue("?csvNumber", cc.CsvNumber);
            command.Parameters.AddWithValue("?expiryDate", cc.ExpiryDate);
            command.Parameters.AddWithValue("?nameOnCard", cc.NameOnCard);
            command.Parameters.AddWithValue("?cardType", cc.CardType);
            command.ExecuteNonQuery();

        }

        public CreditCard FindCreditCardById(int cardNumber)
        {
            CreditCard cc = new CreditCard(); //default value if null is read

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT cardNumber, customerID, csvNumber, expiryDate, nameOnCard, cardType FROM CreditCard WHERE cardNumber = ?cardNumber";
            command.Parameters.AddWithValue("?cardNumber", cardNumber);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cc.CardNumber = reader.GetInt32(0).ToString();
                cc.CustomerID = reader.GetInt32(1);
                cc.CsvNumber = reader.GetInt32(2);
                cc.ExpiryDate = reader.GetDateTime(3);
                cc.NameOnCard = reader.GetString(4);
                cc.CardType = reader.GetString(5);
            }

            return cc;
        }

        public void UpdateCreditCard(CreditCard cc)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE CreditCard SET customerID = ?customerID, csvNumber = ?csvNumber, expiryDate = ?expiryDate, nameOnCard = ?nameOnCard, cardType = ?cardType WHERE cardNumber = ?cardNumber";
            command.Parameters.AddWithValue("?customerID", cc.CustomerID);
            command.Parameters.AddWithValue("?csvNumber", cc.CsvNumber);
            command.Parameters.AddWithValue("?expiryDate", cc.ExpiryDate);
            command.Parameters.AddWithValue("?nameOnCard", cc.NameOnCard);
            command.Parameters.AddWithValue("?cardType", cc.CardType);
            command.Parameters.AddWithValue("?cardNumber", cc.CardNumber);

            command.ExecuteNonQuery();
        }

        public void DeleteCreditCard(CreditCard cc)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE CreditCard WHERE cardNumber = ?cardNumber";
            command.Parameters.AddWithValue("?cardNumber", cc.CardNumber);
            command.ExecuteNonQuery();
        }

    }
}
