using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;


namespace DatabaseUtility
{
    class Employee
    {
        public int employeeID;
        public String firstName;
        public String lastName;
        public String streetAddress;
        public String city;
        public String province;
        public String postalCode;
        public String title;
    }

    class Customer
    {
        public int customerID;
        public String firstName;
        public String lastName;
        public String streetAddress;
        public String city;
        public String province;
        public String postalCode;
    }

    class Reservation
    {
        public int reservationID;
        public int customerID;
        public DateTime checkInDate;
        public DateTime checkOutDate;
        public int roomNumber;
    }

    class Room
    {
        public int roomNumber;
        public int roomTypeID;
        public int roomFloor;
    }

    class SingleRoom : Room
    {

        public String bedSize;
        public int numberOfBeds;
        public Boolean isAvailable;
        public String specialItems;
        public int maxCapacity;
        public double billAmount;
    }

    class Suite : Room
    {
        public String bedSize;
        public int numberOfBeds;
        public Boolean isAvailable;
        public String specialItems;
        public int maxCapacity;
        public double billAmount;
    }

    class ConferenceRoom : Room
    {
        public Boolean isAvailable;
        public String specialItems;
        public int maxCapacity;
        public double billAmount;
        public int numberOfChair;
        public Boolean soundSystemRequired;
    }

    class Bill
    {
        public int billID;
        public int customerID;
        public double billAmount;
        public int roomTypeID;
        public Boolean isPaid;
    }

    class RoomService
    {
        public int roomServiceID;
        public String itemOrdered;
        public int customerID;
        public int roomNumber;
        public String specialInstructions;
        public double totalPrice;
        public DateTime timeOrderedFor;
    }

    class CreditCard
    {
        public int cardNumber;
        public int customerID;
        public int csvNumber;
        public DateTime expiryDate;
        public String nameOnCard;
        public String cardType;
    }

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
            command.CommandText = "INSERT INTO Employee (employeeID, firstName,lastName,streetAddress,city,province,postalCode,title) VALUES (?employeeID ?firstName,?lastName,?streetAddress,?city,?province,?postalCode, ?title)";
            command.Parameters.AddWithValue("?employeeID", e.employeeID);
            command.Parameters.AddWithValue("?firstName", e.firstName);
            command.Parameters.AddWithValue("?lastName", e.lastName);
            command.Parameters.AddWithValue("?streetAddress", e.streetAddress);
            command.Parameters.AddWithValue("?city", e.city);
            command.Parameters.AddWithValue("?province", e.province);
            command.Parameters.AddWithValue("?postalCode", e.postalCode);
            command.Parameters.AddWithValue("?title", e.title);
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
                e.employeeID = reader.GetInt32(0);
                e.firstName = reader.GetString(1);
                e.lastName = reader.GetString(2);
                e.streetAddress = reader.GetString(3);
                e.city = reader.GetString(4);
                e.province = reader.GetString(5);
                e.postalCode = reader.GetString(6);
                e.title = reader.GetString(7);
            }

            return e;
        }

        public void UpdateEmployee(Employee e)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Employee SET firstName = ?firstName,lastName = ?lastName,streetAddress = ?streetAddress,city=?city,province=?province,postalCode=?postalCode,title=?title WHERE employeeID=?employeeID";
            command.Parameters.AddWithValue("?employeeID", e.employeeID);
            command.Parameters.AddWithValue("?firstName", e.firstName);
            command.Parameters.AddWithValue("?lastName", e.lastName);
            command.Parameters.AddWithValue("?streetAddress", e.streetAddress);
            command.Parameters.AddWithValue("?city", e.city);
            command.Parameters.AddWithValue("?province", e.province);
            command.Parameters.AddWithValue("?postalCode", e.postalCode);
            command.Parameters.AddWithValue("?title", e.title);
            command.ExecuteNonQuery();
        }

        public void DeleteEmployee(Employee e)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE Employee WHERE employeeID=?employeeID";
            command.Parameters.AddWithValue("?employeeID", e.employeeID);
            command.ExecuteNonQuery();
        }

        public void insertCustomer(Customer c)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Customer (customerID, firstName,lastName,streetAddress,city,province,postalCode) VALUES (?customerID ?firstName,?lastName,?streetAddress,?city,?province,?postalCode)";
            command.Parameters.AddWithValue("?customerID", c.customerID);
            command.Parameters.AddWithValue("?firstName", c.firstName);
            command.Parameters.AddWithValue("?lastName", c.lastName);
            command.Parameters.AddWithValue("?streetAddress", c.streetAddress);
            command.Parameters.AddWithValue("?city", c.city);
            command.Parameters.AddWithValue("?province", c.province);
            command.Parameters.AddWithValue("?postalCode", c.postalCode);
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
                c.customerID = reader.GetInt32(0);
                c.firstName = reader.GetString(1);
                c.lastName = reader.GetString(2);
                c.streetAddress = reader.GetString(3);
                c.city = reader.GetString(4);
                c.province = reader.GetString(5);
                c.postalCode = reader.GetString(6);

            }

            return c;
        }

        public void UpdateCustomer(Customer c)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Customer SET firstName = ?firstName,lastName = ?lastName,streetAddress = ?streetAddress,city=?city,province=?province,postalCode=?postalCode WHERE customerID=?customerID";
            command.Parameters.AddWithValue("?customerID", c.customerID);
            command.Parameters.AddWithValue("?firstName", c.firstName);
            command.Parameters.AddWithValue("?lastName", c.lastName);
            command.Parameters.AddWithValue("?streetAddress", c.streetAddress);
            command.Parameters.AddWithValue("?city", c.city);
            command.Parameters.AddWithValue("?province", c.province);
            command.Parameters.AddWithValue("?postalCode", c.postalCode);
            command.ExecuteNonQuery();
        }

        public void DeleteCustomer(Customer c)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE Customer WHERE customerID=?customerID";
            command.Parameters.AddWithValue("?customerID", c.customerID);
            command.ExecuteNonQuery();
        }

        public void insertReservation(Reservation r)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Reservation (reservationID, customerID, checkInDate, checkOutDate, roomNumber) VALUES (?reservationID, ?customerID, ?checkInDate, ?checkOutDate, ?roomNumber)";
            command.Parameters.AddWithValue("?reservationID", r.reservationID);
            command.Parameters.AddWithValue("?customerID", r.customerID);
            command.Parameters.AddWithValue("?checkInDate", r.checkInDate);
            command.Parameters.AddWithValue("?checkOutDate", r.checkOutDate);
            command.Parameters.AddWithValue("?roomNumber", r.roomNumber);

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
                r.reservationID = reader.GetInt32(0);
                r.customerID = reader.GetInt32(1);
                r.checkInDate = reader.GetDateTime(2);
                r.checkOutDate = reader.GetDateTime(3);
                r.roomNumber = reader.GetInt32(4);


            }

            return r;
        }

        public void UpdateReservation(Reservation r)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Reservation SET customerID = ?customerID, checkInDate = ?checkInDate, checkOutDate = ?checkOutDate, roomNumber = ?roomNumber WHERE reservationID=?reservationID";
            command.Parameters.AddWithValue("?customerID", r.customerID);
            command.Parameters.AddWithValue("?checkInDate", r.checkInDate);
            command.Parameters.AddWithValue("?checkOutDate", r.checkOutDate);
            command.Parameters.AddWithValue("?roomNumber", r.roomNumber);

            command.ExecuteNonQuery();
        }

        public void DeleteReservation(Reservation r)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE Reservation WHERE reservationID=?reservationID";
            command.Parameters.AddWithValue("?reservationID", r.reservationID);
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

        public void InsertSingleRoom(SingleRoom sr)
        {
            sr.roomTypeID = GetNewRoomTypeID();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO RoomType (roomTypeID, bedSize, numberOfBeds, availability, specialItems, billAmount, maxCapacity, type) VALUES (?roomTypeID, ?bedSize, ?numberOfBeds, ?availability, ?specialItems, ?billAmount, ?maxCapacity, ?type)";
            command.Parameters.AddWithValue("?roomTypeID", sr.roomTypeID);
            command.Parameters.AddWithValue("?bedSize", sr.bedSize);
            command.Parameters.AddWithValue("?numberOfBeds", sr.numberOfBeds);
            if (sr.isAvailable == true)
            {
                command.Parameters.AddWithValue("?availability", "T");
            }
            else
            {
                command.Parameters.AddWithValue("?availability", "F");
            }
            command.Parameters.AddWithValue("?specialItems", sr.specialItems);
            command.Parameters.AddWithValue("?billAmount", Convert.ToInt32(sr.billAmount * 100));
            command.Parameters.AddWithValue("?maxCapacity", sr.maxCapacity);
            command.Parameters.AddWithValue("?type", "SingleRoom");

            command.ExecuteNonQuery();

            MySqlCommand command2 = connection.CreateCommand();
            command2.CommandText = "INSERT INTO Room (roomNumber,roomTypeID,roomFloor) VALUES (?roomNumber,?roomTypeID,?roomFloor)";
            command2.Parameters.AddWithValue("?roomNumber", sr.roomNumber);
            command2.Parameters.AddWithValue("?roomTypeID", sr.roomTypeID);
            command2.Parameters.AddWithValue("?roomFloor", sr.roomFloor);

            command2.ExecuteNonQuery();

        }

        public void DeleteSingleRoom(SingleRoom sr)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE Room WHERE roomNumber = ?roomNumber";
            command.Parameters.AddWithValue("?roomNumber", sr.roomNumber);
            command.ExecuteNonQuery();

            MySqlCommand command2 = connection.CreateCommand();
            command.CommandText = "DELETE RoomType WHERE roomTypeID = ?roomTypeID";
            command.Parameters.AddWithValue("?roomTypeID", sr.roomTypeID);
            command.ExecuteNonQuery();
        }

        public void UpdateSingleRoom(SingleRoom sr)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Room SET roomTypeID = ?roomTypeID, roomFloor = ?roomFloor WHERE roomNumber = ?roomNumber";
            command.Parameters.AddWithValue("?roomTypeID", sr.roomTypeID);
            command.Parameters.AddWithValue("?roomFloor", sr.roomFloor);
            command.Parameters.AddWithValue("?roomNumber", sr.roomNumber);
            command.ExecuteNonQuery();

            MySqlCommand command2 = connection.CreateCommand();
            command2.CommandText = "UPDATE RoomType SET bedSize = ?bedSize, numberOfBeds = ?numberOfBeds, availability = ?availability, specialItems = ?specialItems, billAmount = ?billAmount, maxCapacity = ?maxCapacity, type = ?type WHERE roomTypeID = ?roomTypeID";
            command2.Parameters.AddWithValue("?bedSize", sr.bedSize);
            command2.Parameters.AddWithValue("?numberOfBeds", sr.numberOfBeds);
            if (sr.isAvailable == true)
            {
                command2.Parameters.AddWithValue("?availability", "T");
            }
            else
            {
                command2.Parameters.AddWithValue("?availability", "F");
            }
            command2.Parameters.AddWithValue("?specialItems", sr.specialItems);
            command2.Parameters.AddWithValue("?billAmount", Convert.ToInt32(sr.billAmount * 100));
            command2.Parameters.AddWithValue("?maxCapacity", sr.maxCapacity);
            command2.Parameters.AddWithValue("?type", "SingleRoom");
            command2.Parameters.AddWithValue("?roomTypeID", sr.roomTypeID);
            command.ExecuteNonQuery();
        }

        public void InsertSuite(Suite s)
        {
            s.roomTypeID = GetNewRoomTypeID();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO RoomType (roomTypeID, bedSize, numberOfBeds, availability, specialItems, billAmount, maxCapacity, type) VALUES (?roomTypeID, ?bedSize, ?numberOfBeds, ?availability, ?specialItems, ?billAmount, ?maxCapacity, ?type)";
            command.Parameters.AddWithValue("?roomTypeID", s.roomTypeID);
            command.Parameters.AddWithValue("?bedSize", s.bedSize);
            command.Parameters.AddWithValue("?numberOfBeds", s.numberOfBeds);
            if (s.isAvailable == true)
            {
                command.Parameters.AddWithValue("?availability", "T");
            }
            else
            {
                command.Parameters.AddWithValue("?availability", "F");
            }
            command.Parameters.AddWithValue("?specialItems", s.specialItems);
            command.Parameters.AddWithValue("?billAmount", Convert.ToInt32(s.billAmount * 100));
            command.Parameters.AddWithValue("?maxCapacity", s.maxCapacity);
            command.Parameters.AddWithValue("?type", "Suite");

            command.ExecuteNonQuery();

            MySqlCommand command2 = connection.CreateCommand();
            command2.CommandText = "INSERT INTO Room (roomNumber,roomTypeID,roomFloor) VALUES (?roomNumber,?roomTypeID,?roomFloor)";
            command2.Parameters.AddWithValue("?roomNumber", s.roomNumber);
            command2.Parameters.AddWithValue("?roomTypeID", s.roomTypeID);
            command2.Parameters.AddWithValue("?roomFloor", s.roomFloor);

            command2.ExecuteNonQuery();

        }

        public void DeleteSuite(Suite s)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE Room WHERE roomNumber = ?roomNumber";
            command.Parameters.AddWithValue("?roomNumber", s.roomNumber);
            command.ExecuteNonQuery();

            MySqlCommand command2 = connection.CreateCommand();
            command.CommandText = "DELETE RoomType WHERE roomTypeID = ?roomTypeID";
            command.Parameters.AddWithValue("?roomTypeID", s.roomTypeID);
            command.ExecuteNonQuery();
        }

        public void UpdateSuite(Suite s)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Room SET roomTypeID = ?roomTypeID, roomFloor = ?roomFloor WHERE roomNumber = ?roomNumber";
            command.Parameters.AddWithValue("?roomTypeID", s.roomTypeID);
            command.Parameters.AddWithValue("?roomFloor", s.roomFloor);
            command.Parameters.AddWithValue("?roomNumber", s.roomNumber);
            command.ExecuteNonQuery();

            MySqlCommand command2 = connection.CreateCommand();
            command2.CommandText = "UPDATE RoomType SET bedSize = ?bedSize, numberOfBeds = ?numberOfBeds, availability = ?availability, specialItems = ?specialItems, billAmount = ?billAmount, maxCapacity = ?maxCapacity, type = ?type WHERE roomTypeID = ?roomTypeID";
            command2.Parameters.AddWithValue("?bedSize", s.bedSize);
            command2.Parameters.AddWithValue("?numberOfBeds", s.numberOfBeds);
            if (s.isAvailable == true)
            {
                command2.Parameters.AddWithValue("?availability", "T");
            }
            else
            {
                command2.Parameters.AddWithValue("?availability", "F");
            }
            command2.Parameters.AddWithValue("?specialItems", s.specialItems);
            command2.Parameters.AddWithValue("?billAmount", Convert.ToInt32(s.billAmount * 100));
            command2.Parameters.AddWithValue("?maxCapacity", s.maxCapacity);
            command2.Parameters.AddWithValue("?type", "Suite");
            command2.Parameters.AddWithValue("?roomTypeID", s.roomTypeID);
            command.ExecuteNonQuery();
        }

        public void InsertConferenceRoom(ConferenceRoom cr)
        {
            cr.roomTypeID = GetNewRoomTypeID();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO RoomType (roomTypeID, bedSize, numberOfBeds, availability, specialItems, billAmount, maxCapacity, type) VALUES (?roomTypeID, ?bedSize, ?numberOfBeds, ?availability, ?specialItems, ?billAmount, ?maxCapacity, ?type)";
            command.Parameters.AddWithValue("?roomTypeID", cr.roomTypeID);
            if (cr.soundSystemRequired)
            {
                command.Parameters.AddWithValue("?bedSize", "T");
            }
            else
            {
                command.Parameters.AddWithValue("?bedSize", "F");
            }

            command.Parameters.AddWithValue("?numberOfBeds", cr.numberOfChair);
            if (cr.isAvailable == true)
            {
                command.Parameters.AddWithValue("?availability", "T");
            }
            else
            {
                command.Parameters.AddWithValue("?availability", "F");
            }
            command.Parameters.AddWithValue("?specialItems", cr.specialItems);
            command.Parameters.AddWithValue("?billAmount", Convert.ToInt32(cr.billAmount * 100));
            command.Parameters.AddWithValue("?maxCapacity", cr.maxCapacity);
            command.Parameters.AddWithValue("?type", "ConferenceRoom");

            command.ExecuteNonQuery();

            MySqlCommand command2 = connection.CreateCommand();
            command2.CommandText = "INSERT INTO Room (roomNumber,roomTypeID,roomFloor) VALUES (?roomNumber,?roomTypeID,?roomFloor)";
            command2.Parameters.AddWithValue("?roomNumber", cr.roomNumber);
            command2.Parameters.AddWithValue("?roomTypeID", cr.roomTypeID);
            command2.Parameters.AddWithValue("?roomFloor", cr.roomFloor);

            command2.ExecuteNonQuery();

        }

        public void DeleteConferenceRoom(ConferenceRoom cr)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE Room WHERE roomNumber = ?roomNumber";
            command.Parameters.AddWithValue("?roomNumber", cr.roomNumber);
            command.ExecuteNonQuery();

            MySqlCommand command2 = connection.CreateCommand();
            command.CommandText = "DELETE RoomType WHERE roomTypeID = ?roomTypeID";
            command.Parameters.AddWithValue("?roomTypeID", cr.roomTypeID);
            command.ExecuteNonQuery();
        }

        public void UpdateConferenceRoom(ConferenceRoom cr)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Room SET roomTypeID = ?roomTypeID, roomFloor = ?roomFloor WHERE roomNumber = ?roomNumber";
            command.Parameters.AddWithValue("?roomTypeID", cr.roomTypeID);
            command.Parameters.AddWithValue("?roomFloor", cr.roomFloor);
            command.Parameters.AddWithValue("?roomNumber", cr.roomNumber);
            command.ExecuteNonQuery();

            MySqlCommand command2 = connection.CreateCommand();
            command2.CommandText = "UPDATE RoomType SET bedSize = ?bedSize, numberOfBeds = ?numberOfBeds, availability = ?availability, specialItems = ?specialItems, billAmount = ?billAmount, maxCapacity = ?maxCapacity, type = ?type WHERE roomTypeID = ?roomTypeID";
            if (cr.soundSystemRequired)
            {
                command2.Parameters.AddWithValue("?bedSize", "T");
            }
            else
            {
                command2.Parameters.AddWithValue("?bedSize", "F");
            }

            command2.Parameters.AddWithValue("?numberOfBeds", cr.numberOfChair);
            if (cr.isAvailable == true)
            {
                command2.Parameters.AddWithValue("?availability", "T");
            }
            else
            {
                command2.Parameters.AddWithValue("?availability", "F");
            }
            command2.Parameters.AddWithValue("?specialItems", cr.specialItems);
            command2.Parameters.AddWithValue("?billAmount", Convert.ToInt32(cr.billAmount * 100));
            command2.Parameters.AddWithValue("?maxCapacity", cr.maxCapacity);
            command2.Parameters.AddWithValue("?type", "ConferenceRoom");
            command2.Parameters.AddWithValue("?roomTypeID", cr.roomTypeID);
            command.ExecuteNonQuery();
        }


        public Room FindRoomByRoomNumber(int roomNumber)
        {


            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT R.roomNumber, R.roomFloor, R.roomTypeID, RT.bedsize, RT.numberOfBeds, RT.availability, RT.specialItems, RT.billAmount, RT.maxCapacity, RT.type FROM Room AS R, RoomType AS RT WHERE R.roomNumber = ?roomNumber and R.roomTypeID = RT.roomTypeID";
            command.Parameters.AddWithValue("?roomNumber", roomNumber);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(9) == "SingleRoom")
                {
                    SingleRoom r = new SingleRoom();

                    r.roomNumber = reader.GetInt32(0);
                    r.roomFloor = reader.GetInt32(1);
                    r.roomTypeID = reader.GetInt32(2);
                    r.bedSize = reader.GetString(3);
                    r.numberOfBeds = reader.GetInt32(4);
                    if (reader.GetString(5) == "T")
                    {
                        r.isAvailable = true;
                    }
                    else
                    {
                        r.isAvailable = false;
                    }
                    r.specialItems = reader.GetString(6);
                    r.billAmount = reader.GetInt32(7) / 100;
                    r.maxCapacity = reader.GetInt32(8);
                    return r;
                }

                if (reader.GetString(9) == "Suite")
                {
                    Suite r = new Suite();

                    r.roomNumber = reader.GetInt32(0);
                    r.roomFloor = reader.GetInt32(1);
                    r.roomTypeID = reader.GetInt32(2);
                    r.bedSize = reader.GetString(3);
                    r.numberOfBeds = reader.GetInt32(4);
                    if (reader.GetString(5) == "T")
                    {
                        r.isAvailable = true;
                    }
                    else
                    {
                        r.isAvailable = false;
                    }
                    r.specialItems = reader.GetString(6);
                    r.billAmount = reader.GetInt32(7) / 100;
                    r.maxCapacity = reader.GetInt32(8);
                    return r;
                }

                if (reader.GetString(9) == "ConferenceRoom")
                {
                    ConferenceRoom r = new ConferenceRoom();

                    r.roomNumber = reader.GetInt32(0);
                    r.roomFloor = reader.GetInt32(1);
                    r.roomTypeID = reader.GetInt32(2);
                    if (reader.GetString(3).Trim() == "T")
                    {
                        r.soundSystemRequired = true;
                    }
                    else
                    {
                        r.soundSystemRequired = false;
                    }

                    r.numberOfChair = reader.GetInt32(4);
                    if (reader.GetString(5) == "T")
                    {
                        r.isAvailable = true;
                    }
                    else
                    {
                        r.isAvailable = false;
                    }
                    r.specialItems = reader.GetString(6);
                    r.billAmount = reader.GetInt32(7) / 100;
                    r.maxCapacity = reader.GetInt32(8);
                    return r;
                }
            }

            return null;
        }

        public void insertBill(Bill b)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Reservation (billID, customerID, roomTypeID, isPaid) VALUES (?billID, ?customerID, ?roomTypeID, ?isPaid)";
            command.Parameters.AddWithValue("?billID", b.billID);
            command.Parameters.AddWithValue("?customerID", b.customerID);
            command.Parameters.AddWithValue("?roomTypeID", b.roomTypeID);
            if (b.isPaid)
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
                b.billID = reader.GetInt32(0);
                b.customerID = reader.GetInt32(1);
                b.roomTypeID = reader.GetInt32(2);
                if (reader.GetString(3) == "T")
                {
                    b.isPaid = true;
                }
                else
                {
                    b.isPaid = false;
                }
                b.billAmount = reader.GetInt32(4) / 100;
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
            command.CommandText = "UPDATE Bill SET customerID = ?customerID, roomTypeID = ?roomTypeID, isPaid = ?isPaid WHERE billID=?billID";
            command.Parameters.AddWithValue("?customerID", b.customerID);
            command.Parameters.AddWithValue("?roomTypeID", b.roomTypeID);
            if (b.isPaid)
            {
                command.Parameters.AddWithValue("?isPaid", "T");
            }
            else
            {
                command.Parameters.AddWithValue("?isPaid", "F");
            }

            command.Parameters.AddWithValue("?billID", b.billID);

            command.ExecuteNonQuery();
        }

        public void DeleteBill(Bill b)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE Bill WHERE billID=?billID";
            command.Parameters.AddWithValue("?reservationID", b.billID);
            command.ExecuteNonQuery();
        }

        public void insertRoomService(RoomService rs)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO RoomService (roomServiceID, itemOrdered, customerID, roomNumber, specialInstructions, totalPrice, timeOrderedFor) VALUES (?roomServiceID, ?itemOrdered, ?customerID, ?roomNumber, ?specialInstructions, ?totalPrice, ?timeOrderedFor)";
            command.Parameters.AddWithValue("?roomServiceID", rs.roomServiceID);
            command.Parameters.AddWithValue("?itemOrdered", rs.itemOrdered);
            command.Parameters.AddWithValue("?customerID", rs.customerID);
            command.Parameters.AddWithValue("?roomNumber", rs.roomNumber);
            command.Parameters.AddWithValue("?specialInstructions", rs.specialInstructions);
            command.Parameters.AddWithValue("?totalPrice", Convert.ToInt32(rs.totalPrice * 100));
            command.Parameters.AddWithValue("?timeOrderedFor", rs.timeOrderedFor);
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
                r.roomServiceID = reader.GetInt32(0);
                r.itemOrdered = reader.GetString(1);
                r.customerID = reader.GetInt32(2);
                r.roomNumber = reader.GetInt32(3);
                r.specialInstructions = reader.GetString(4);
                r.totalPrice = reader.GetInt32(5) / 100;
                r.timeOrderedFor = reader.GetDateTime(6);

            }

            return r;
        }

        public void UpdateRoomService(RoomService rs)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Reservation SET itemOrdered = ?itemOrdered, customerID = ?customerID, roomNumber = ?roomNumber, specialInstructions = ?specialInstructions, totalPrice = ?totalPrice, timeOrderedFor = ?timeOrderedFor WHERE roomServiceID = ?roomServiceID";
            command.Parameters.AddWithValue("?itemOrdered", rs.itemOrdered);
            command.Parameters.AddWithValue("?customerID", rs.customerID);
            command.Parameters.AddWithValue("?roomNumber", rs.roomNumber);
            command.Parameters.AddWithValue("?specialInstructions", rs.specialInstructions);
            command.Parameters.AddWithValue("?totalPrice", Convert.ToInt32(rs.totalPrice * 100));
            command.Parameters.AddWithValue("?timeOrderedFor", rs.timeOrderedFor);
            command.Parameters.AddWithValue("?roomServiceID", rs.roomServiceID);

            command.ExecuteNonQuery();
        }

        public void DeleteRoomService(RoomService r)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE RoomService WHERE roomServiceID=?roomServiceID";
            command.Parameters.AddWithValue("?roomServiceID", r.roomServiceID);
            command.ExecuteNonQuery();
        }

        public void insertCreditCard(CreditCard cc)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO CreditCard (cardNumber, customerID, csvNumber, expiryDate, nameOnCard, cardType) VALUES (?cardNumber, ?customerID, ?csvNumber, ?expiryDate, ?nameOnCard, ?cardType)";
            command.Parameters.AddWithValue("?cardNumber", cc.cardNumber);
            command.Parameters.AddWithValue("?customerID", cc.customerID);
            command.Parameters.AddWithValue("?csvNumber", cc.csvNumber);
            command.Parameters.AddWithValue("?expiryDate", cc.expiryDate);
            command.Parameters.AddWithValue("?nameOnCard", cc.nameOnCard);
            command.Parameters.AddWithValue("?cardType", cc.cardType);
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
                cc.cardNumber = reader.GetInt32(0);
                cc.customerID = reader.GetInt32(1);
                cc.csvNumber = reader.GetInt32(2);
                cc.expiryDate = reader.GetDateTime(3);
                cc.nameOnCard = reader.GetString(4);
                cc.cardType = reader.GetString(5);
            }

            return cc;
        }

        public void UpdateCreditCard(CreditCard cc)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE CreditCard SET customerID = ?customerID, csvNumber = ?csvNumber, expiryDate = ?expiryDate, nameOnCard = ?nameOnCard, cardType = ?cardType WHERE cardNumber = ?cardNumber";
            command.Parameters.AddWithValue("?customerID", cc.customerID);
            command.Parameters.AddWithValue("?csvNumber", cc.csvNumber);
            command.Parameters.AddWithValue("?expiryDate", cc.expiryDate);
            command.Parameters.AddWithValue("?nameOnCard", cc.nameOnCard);
            command.Parameters.AddWithValue("?cardType", cc.cardType);
            command.Parameters.AddWithValue("?cardNumber", cc.cardNumber);

            command.ExecuteNonQuery();
        }

        public void DeleteCreditCard(CreditCard cc)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE CreditCard WHERE cardNumber = ?cardNumber";
            command.Parameters.AddWithValue("?cardNumber", cc.cardNumber);
            command.ExecuteNonQuery();
        }

    }
}
