using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//For the DBUtil class.
using DatabaseUtility;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace HotelBookingSystem
{
    public partial class Form1 : Form
    {
        //Object lists that will hold the data from the database.
        List<Customer> customerList = new List<Customer>();
        List<Reservation> reservationList = new List<Reservation>();
        List<Room> roomList = new List<Room>();
        List<Bill> billList = new List<Bill>();
        List<CreditCard> creditCardList = new List<CreditCard>();
        List<Employee> employeeList = new List<Employee>();
        List<RoomService> roomServiceList = new List<RoomService>();
        List<Reservation> checkedInReservationList = new List<Reservation>();
        List<Reservation> checkedOutReservationList = new List<Reservation>();

        //Database Utility object.
        DBUtil dbUtil = new DBUtil();

        public Form1()
        {
            InitializeComponent();

            //Connect to Database.
            try
            {
                dbUtil.Open();

                //Read from Database, and fill lists. 
                customerListBuilder();
                reservationListBuilder();
                roomListBuilder();
                creditCardListBuilder(); 
                employeeListBuilder();
                roomServiceListBuilder();
                billListBuilder();
                checkInListBuilder();
            }
            catch
            {
                MessageBox.Show("Error connecting to database. Please check connection to the database.");
            }
            finally
            {
                dbUtil.Close();
            }
        }

        //---------------------------WELCOME TAB---------------------------\\


        //---------------------------CHECK-IN TAB---------------------------\\

        //NOT WORKING
        //Filter button
        private void button1_Click(object sender, EventArgs e)
        {
            //Gathers info from fields, stores as variables. Removes leading and trailing spaces.

            //Searches object list for fields that are valid. If variable is blank, that field is not searched.
        }

        //NOT WORKING
        //Check-in button
        private void button2_Click(object sender, EventArgs e)
        {
            //Flags reservation as checked in on DB.

        }

        //---------------------------CHECK-OUT TAB---------------------------\\

        //NOT WORKING
        //Filter button
        private void button4_Click(object sender, EventArgs e)
        {
            //Gathers info from fields, stores as variables. Removes leading and trailing spaces.

            //Searches object list for fields that are valid. If variable is blank, that field is not searched.
        }

        //NOT WORKING
        //Check-out button
        private void button3_Click(object sender, EventArgs e)
        {
            //Flags reservation as checked out on DB.
        }

        //---------------------------RESERVATION TAB---------------------------\\

        //WORKING
        //Reservations Tab > Create New Reservation Button
        private void button5_Click(object sender, EventArgs e)
        {

            Form2 newReservationForm = new Form2();
            newReservationForm.Show();
        }

        //NOT WORKING
        //When the date is changed in the calendar, the reservation ListBox updates with only reservations
        //from that specified day. (Calendar in Reservations tab)
        private void monthCalendar3_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        //NOT WORKING
        //View button
        private void button6_Click(object sender, EventArgs e)
        {
            //Opens another window with information about the reservation.
        }

        //---------------------------ROOM SERVICE TAB---------------------------\\

        //NOT WORKING
        //Order button (Submits order)
        private void button8_Click(object sender, EventArgs e)
        {

            //Gather variables, create String, and display on the dialog box.

            DialogResult dialogResult = MessageBox.Show("DISPLAY HERE", "Order confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Process room service order.

                //Clear all fields.
            }
            else if (dialogResult == DialogResult.No)
            {
                //Go back to original form.
            }
        }

        //NOT WORKING
        //Filter button
        private void button7_Click(object sender, EventArgs e)
        {
            //Gathers info from fields, stores as variables. Removes leading and trailing spaces.

            //Searches object list for fields that are valid. If variable is blank, that field is not searched.
        }

        //---------------------------CUSTOMERS TAB---------------------------\\

        //WORKING
        //Customer > Add new customer button
        private void button9_Click(object sender, EventArgs e)
        {
            Form3 newCustomerForm = new Form3();
            newCustomerForm.Show();
        }

        //WORKING
        //View button
        private void button14_Click(object sender, EventArgs e)
        {
            //Making sure something is chosen in the listBox. Error appears if nothing chosen, form opens
            //if a customer is highlighted.
            if(listBox5.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a customer.");
            } else
            {
                //Creating the form object.
                Form4 viewCustomerForm = new Form4();

                //Passing the customer object to the new form.
                viewCustomerForm.loadCustomer(customerList[listBox5.SelectedIndex]);

                //Searching for credit card owner.
                //If nothing found, nothing is passed.
                //viewCustomerForm.loadCreditCard();

                viewCustomerForm.Show();
            }
        }

        //---------------------------BILLS TAB---------------------------\\

        //WORKING
        //View button
        private void button16_Click(object sender, EventArgs e)
        {
            //Making sure something is chosen in the listBox. Error appears if nothing chosen, form opens
            //if a customer is highlighted.
            if (listBox8.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a bill.");
            }
            else
            {
                //Creating the form object.
                Form5 viewBillForm = new Form5();

                //Passing the bill object to the new form.
                viewBillForm.loadBill(billList[listBox8.SelectedIndex]);

                //Passing the customer object to the new form, depending on customer ID on bill object.
                Customer customerToLoad = new Customer();
                int customerListSize = customerList.Count();
                int customerID = billList[listBox8.SelectedIndex].CustomerID;

                for (int x = 0; x < customerListSize; x++)
                {
                    if(customerList[x].CustomerID == customerID)
                    {
                        customerToLoad = customerList[x];
                    }
                }
                
                viewBillForm.loadCustomer(customerToLoad);

                //Passing the reservation object to the new form, depdening on reservation ID on bill object
                Reservation reservationToLoad = new Reservation();
                int reservationListSize = reservationList.Count();
                int reservationID = billList[listBox8.SelectedIndex].ReservationID;

                for (int x = 0; x < reservationListSize; x++)
                {
                    if (reservationList[x].ReservationID == reservationID)
                    {
                        reservationToLoad = reservationList[x];
                    }
                }

                viewBillForm.loadReservation(reservationToLoad);

                //Passing the room object to the new form, depending on room ID on reservation object previously loaded
                Room roomToLoad = new Room();
                int roomListSize = roomList.Count();
                int roomID = reservationToLoad.RoomNumber;

                for (int x = 0; x < roomListSize; x++)
                {
                    if(roomList[x].RoomNumber == roomID)
                    {
                        roomToLoad = roomList[x];
                    }
                }

                viewBillForm.loadRoom(roomToLoad);

                //Passes a (potentially blank) room service object, based on the room service ID on the bill object
                RoomService roomServiceToLoad = new RoomService();
                int roomServiceListSize = roomServiceList.Count();
                int roomServiceID = billList[listBox8.SelectedIndex].RoomServiceID;

                for (int x = 0; x < roomServiceListSize; x++)
                {
                    if(roomServiceList[x].RoomServiceID == roomServiceID)
                    {
                        roomServiceToLoad = roomServiceList[x];
                    }
                }

                viewBillForm.loadRoomService(roomServiceToLoad);

                viewBillForm.Show();
            }
        }

        //WORKING
        //Pay bill button
        private void button17_Click(object sender, EventArgs e)
        {
            if(listBox8.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a bill.");
            } else
            {
                RoomService roomServiceToLoad = new RoomService();
                int roomServiceListSize = roomServiceList.Count();
                int roomServiceID = billList[listBox8.SelectedIndex].RoomServiceID;

                for (int x = 0; x < roomServiceListSize; x++)
                {
                    if (roomServiceList[x].RoomServiceID == roomServiceID)
                    {
                        roomServiceToLoad = roomServiceList[x];
                    }
                }

                Form6 paymentForm = new Form6();
                paymentForm.loadBill(billList[listBox8.SelectedIndex]);
                paymentForm.loadRoomService(roomServiceToLoad);
                paymentForm.Show();
            }
        }

        //---------------------------REPORTS TAB---------------------------\\

        //---------------------------ADMIN TAB---------------------------\\

        //WORKING
        //Login button
        private void button18_Click(object sender, EventArgs e)
        {
            //If button says Login, login actions run. If it says Logout, it reverses everything.
            if(button18.Text == "Login")
            {
                if (textBox21.Text == "admin" && textBox22.Text == "admin123")
                {
                    //Lists and buttons become active.
                    listBox6.Enabled = true;
                    listBox7.Enabled = true;
                    button10.Enabled = true;
                    button11.Enabled = true;
                    button12.Enabled = true;
                    button13.Enabled = true;

                    //Disables textfields.
                    textBox21.Enabled = false;
                    textBox22.Enabled = false;

                    //Changes button text.
                    button18.Text = "Logout";
                }
                else
                {
                    MessageBox.Show("Invalid login");
                }
            } else
            {
                //Lists and buttons become inactive.
                listBox6.Enabled = false;
                listBox7.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;

                //Enables textfields.
                textBox21.Enabled = true;
                textBox22.Enabled = true;

                //Clears textfields.
                textBox21.Text = "";
                textBox22.Text = "";

                //Changes button text.
                button18.Text = "Login";
            }
        }

        //NOT WORKING
        //Delete User
        private void button10_Click(object sender, EventArgs e)
        {

        }

        //NOT WORKING
        //Create User
        private void button11_Click(object sender, EventArgs e)
        {

        }

        //NOT WORKING
        //Delete Room
        private void button12_Click(object sender, EventArgs e)
        {

        }

        //NOT WORKING
        //Create Room
        private void button13_Click(object sender, EventArgs e)
        {

        }

        //---------------------------LIST BUILDERS---------------------------\\

        //WORKING
        //Builds the customer object list.
        private void customerListBuilder()
        {
            //Clears existing list, to make sure all data is up to date in the list.
            customerList.Clear();

            MySqlCommand command = new MySqlCommand("SELECT * from CUSTOMER", dbUtil.Connection);
            MySqlDataReader reader = command.ExecuteReader();

            //Uses existing DB connection. Fills the customer objects, and adds to list.
            try {
                while (reader.Read())
                {
                    int customerID = reader.GetInt32(0);
                    String firstName = reader.GetString(1);
                    String lastName = reader.GetString(2);
                    String streetAddress = reader.GetString(3);
                    String city = reader.GetString(4);
                    String province = reader.GetString(5);
                    String postalCode = reader.GetString(6);

                    Customer customer = new Customer(customerID, firstName, lastName, streetAddress, city, province, postalCode);
                    customerList.Add(customer);
                }
            } catch(Exception e)
            {
                MessageBox.Show("Error constructing Customer List. Please try again. \n\n" + e.ToString());
            } finally
            {
                reader.Close();
            }

            //Displays customers in listBox
            int listSize = customerList.Count();

            for (int x = 0; x < listSize; x++)
            {
                String displayString = (customerList[x].FirstName + " " + customerList[x].LastName);
                listBox5.Items.Add(displayString);
            }
        }

        //WORKING
        //Builds the reservation object list.
        private void reservationListBuilder()
        {
            //Clears existing list, if needed.
            reservationList.Clear();

            MySqlCommand command = new MySqlCommand("SELECT * from RESERVATION", dbUtil.Connection);
            MySqlDataReader reader = command.ExecuteReader();

            //Uses existing DB connection. Fills the customer objects, and adds to list.
            try
            {
                while (reader.Read())
                {
                    int reservationID = reader.GetInt32(0);
                    int customerID = reader.GetInt32(1);
                    DateTime checkInDate = reader.GetDateTime(2);
                    DateTime checkOutDate = reader.GetDateTime(3);
                    int roomNumber = reader.GetInt32(4);
                    String checkedInString = reader.GetString(5);
                    Boolean checkedIn = true;

                    if(checkedInString == "0")
                    {
                        checkedIn = false;
                    }

                    Reservation reservation = new Reservation(customerID, reservationID, roomNumber, checkInDate, checkOutDate, checkedIn);
                    reservationList.Add(reservation);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error constructing Reservation List. Please try again. \n\n" + e.ToString());
            } finally
            {
                reader.Close();
            }

            //Displays reservations in listBox.
            int listSize = reservationList.Count();

            for (int x = 0; x < listSize; x++)
            {
                String displayString = ("Reservation " + reservationList[x].ReservationID + " - Customer " + reservationList[x].CustomerID);
                listBox3.Items.Add(displayString);
            }
        }
        
        //WORKING
        //Builds the room object list.
        private void roomListBuilder()
        {
            //Clears existing list, if needed.
            roomList.Clear();

            MySqlCommand command = new MySqlCommand("SELECT * from ROOM", dbUtil.Connection);
            MySqlDataReader reader = command.ExecuteReader();

            //Uses existing DB connection. Fills the customer objects, and adds to list.
            try
            {
                while (reader.Read())
                {
                    int roomNumber = reader.GetInt32(0);
                    int roomTypeID = reader.GetInt32(1);
                    int roomFloor = reader.GetInt32(2);

                    Room room = new Room(roomNumber, roomTypeID, roomFloor);
                    roomList.Add(room);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Error constructing Room List. Please try again. \n\n" + e.ToString());
            } finally
            {
                reader.Close();
            }

            int listSize = roomList.Count();

            for (int x = 0; x < listSize; x++)
            {
                String displayString = ("Room " + roomList[x].RoomNumber.ToString());
                listBox7.Items.Add(displayString);
            }
        }

        //WORKING
        //Builds the bill object list.
        private void billListBuilder()
        {
            //Clears existing list, to make sure all data is up to date in the list.
            billList.Clear();

            MySqlCommand command = new MySqlCommand("SELECT * from BILL", dbUtil.Connection);
            MySqlDataReader reader = command.ExecuteReader();

            //Uses existing DB connection. Fills the customer objects, and adds to list.
            try
            {
                while (reader.Read())
                {
                    int billID = reader.GetInt32(0);
                    int customerID = reader.GetInt32(1);
                    int roomTypeID = reader.GetInt32(2);
                    Boolean isPaid = true;
                    String isPaidString = reader.GetString(3);
                    double totalPrice = reader.GetDouble(4);
                    int reservationID = reader.GetInt32(5);
                    int roomServiceID = reader.GetInt32(6);

                    //Figures out boolean
                    if (isPaidString == "0")
                    {
                        isPaid = false;
                    }

                    Bill bill = new Bill(billID, customerID, roomTypeID, isPaid, totalPrice, reservationID, roomServiceID);
                    billList.Add(bill);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Error constructing Bill List. Please try again. \n\n" + e.ToString());
            } finally
            {
                reader.Close();
            }

            //Displays customers in listBox
            int listSize = billList.Count();
            RoomService roomService = new RoomService();
            int roomServiceListSize = roomServiceList.Count();
            double roomServiceCost;
            double roomCost;

            for (int x = 0; x < listSize; x++)
            {
                //Sets room service ID to current bill's room service ID.
                int roomServiceID = billList[x].RoomServiceID;
                roomServiceCost = 0.00;
                roomCost = 0.00;

                if (roomServiceID != 0)
                {
                    for(int y = 0; y < roomServiceListSize; y++)
                    {
                        if(roomServiceList[y].RoomServiceID == roomServiceID)
                        {
                            roomService = roomServiceList[y];
                        }
                    }

                    roomServiceCost = roomService.TotalPrice;
                }

                roomCost = billList[x].TotalPrice;
                double finalPrice = (roomCost + roomServiceCost);
                String displayString = (billList[x].BillID + " - $" + finalPrice);
                listBox8.Items.Add(displayString);
            }
        }

        //NOT NEEDED??
        //Builds the credit card object list.
        private void creditCardListBuilder()
        {
            //Clears existing list, if needed.
            creditCardList.Clear();

            //Get connection to DB, and executes queries

            //Fills the credit card objects, and adds to list.
            //DEBUG
            createFakeCreditCards();

            //int listSize = creditCardList.Count();

            //for (int x = 0; x < listSize; x++)
            //{
            //    String displayString = (creditCardList[x].NameOnCard);
            //    listBox6.Items.Add(displayString);
            //}
        }

        //WORKING
        //Builds the employee object list.
        private void employeeListBuilder()
        {
            //Clears existing list, if needed.
            employeeList.Clear();

            MySqlCommand command = new MySqlCommand("SELECT * from EMPLOYEE", dbUtil.Connection);
            MySqlDataReader reader = command.ExecuteReader();

            //Uses existing DB connection. Fills the customer objects, and adds to list.
            try
            {
                while (reader.Read())
                {
                    int employeeID = reader.GetInt32(0);
                    String firstName = reader.GetString(1);
                    String lastName = reader.GetString(2);
                    String streetAddress = reader.GetString(3);
                    String city = reader.GetString(4);
                    String province = reader.GetString(5);
                    String postalCode = reader.GetString(6);
                    String title = reader.GetString(7);

                    Employee employee = new Employee(employeeID, firstName, lastName, streetAddress, city, province, postalCode, title);
                    employeeList.Add(employee);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Error constructing Employee List. Please try again. \n\n" + e.ToString());
            } finally
            {
                reader.Close();
            }

            //Displays Employees in listBox
            int listSize = employeeList.Count();

            for (int x = 0; x < listSize; x++)
            {
                String displayString = (employeeList[x].FirstName + " " + employeeList[x].LastName);
                listBox6.Items.Add(displayString);
            }
        }

        //WORKING
        //Builds the room service object list.
        private void roomServiceListBuilder()
        {
            //Clears existing list, if needed.
            roomServiceList.Clear();

            MySqlCommand command = new MySqlCommand("SELECT * from ROOMSERVICE", dbUtil.Connection);
            MySqlDataReader reader = command.ExecuteReader();

            //Uses existing DB connection. Fills the customer objects, and adds to list.
            try
            {
                while (reader.Read())
                {
                    int roomServiceID = reader.GetInt32(0);
                    String itemOrdered = reader.GetString(1);
                    int customerID = reader.GetInt32(2);
                    int roomNumber = reader.GetInt32(3);
                    String specialInstructions = reader.GetString(4);
                    double totalPrice = reader.GetDouble(5);
                    DateTime timeOrderedFor = reader.GetDateTime(6);

                    RoomService roomService = new RoomService(roomServiceID, itemOrdered, customerID, roomNumber, specialInstructions, totalPrice, timeOrderedFor);
                    roomServiceList.Add(roomService);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Error constructing Room Service List. Please try again. \n\n" + e.ToString());
            } finally
            {
                reader.Close();
            }

            int listSize = roomServiceList.Count();

            for (int x = 0; x < listSize; x++)
            {
                String displayString = ("Reservation " + reservationList[x].ReservationID.ToString());
                listBox4.Items.Add(displayString);
            }
        }

        //WORKING
        //Builds the check in/check out lists. Bases each list on if the resrvation is currently checked in
        private void checkInListBuilder()
        {
            //Clears existing lists, if needed.
            checkedInReservationList.Clear();
            checkedOutReservationList.Clear();

            int resListSize = reservationList.Count();

            //Parses the reservation list, and sorts the reservations to the correct checkIn list, depending on
            //boolean status.
            for (int x = 0; x < resListSize; x++)
            {
                if (reservationList[x].IsCheckedIn == true)
                {
                    checkedInReservationList.Add(reservationList[x]);
                } else
                {
                    checkedOutReservationList.Add(reservationList[x]);
                }
            }

            int checkInListSize = checkedInReservationList.Count();
            int checkOutListSize = checkedOutReservationList.Count();

            //Builds checked in list (goes to the check out tab)
            for (int x = 0; x < checkInListSize; x++)
            {
                String displayString = ("Reservation " + checkedInReservationList[x].ReservationID.ToString());
                listBox2.Items.Add(displayString);
            }

            //Builds checked out list (goes to the check in tab)
            for (int x = 0; x < checkOutListSize; x++)
            {
                String displayString = ("Reservation " + checkedOutReservationList[x].ReservationID.ToString());
                listBox1.Items.Add(displayString);
            }
        }


        //---------------------------DEBUG---------------------------\\

        //Fills the object lists with some placeholders until the DB is ready
        public void createFakeCreditCards()
        {
            CreditCard fakeCard1 = new CreditCard("1234123412341234", "1", "123", "09/17", "Behn McIlwaine", "Visa");
            CreditCard fakeCard2 = new CreditCard("5555555555555554", "2", "245", "10/18", "Testy Testerson", "Mastercard");
            CreditCard fakeCard3 = new CreditCard("8264924472662847", "3", "262", "03/17", "Michelle Testerson", "Discover");

            creditCardList.Add(fakeCard1);
            creditCardList.Add(fakeCard2);
            creditCardList.Add(fakeCard3);
        }
    }
}
