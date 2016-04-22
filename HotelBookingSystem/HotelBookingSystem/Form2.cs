//Name: Behn McIlwaine, Marco Saad, Manon Miron
//Date: April 22, 2016
//Class: CIS-2261
//Final Project: Hotel Booking System
//Notes: The form to create new reservations

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelBookingSystem
{
    public partial class Form2 : Form
    {
        //Object lists that will hold the data from the database.
        List<Customer> customerList = new List<Customer>();
        List<Reservation> reservationList = new List<Reservation>();
        List<Room> roomList = new List<Room>();
        DBUtil dbUtil = new DBUtil();

        //DEBUG dates for use
        DateTime currentDate = DateTime.Now;
        DateTime currentDatePlus2 = DateTime.Now.AddDays(2);

        public Form2()
        {
            InitializeComponent();

            try
            {
                dbUtil.Open();

                customerListBuilder();
                roomListBuilder();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database. Please check connection to the database.");
            }
            finally
            {
                dbUtil.Close();
            }

            //DEBUG. Defaults text boxes to today's date.
            textBox9.Text = currentDate.ToLongDateString();
            textBox10.Text = currentDatePlus2.ToLongDateString();

        }

        //Create New Reservation button
        private void button3_Click(object sender, EventArgs e)
        {
            int customerSelectedIndex = listBox1.SelectedIndex;
            int roomSelectedIndex = listBox2.SelectedIndex;

            if (customerSelectedIndex < 0 || roomSelectedIndex < 0)
            {
                MessageBox.Show("Please make sure both a customer and room are chosen.");
            }
            else
            {
                if (textBox9.Text == "" || textBox10.Text == "")
                {
                    MessageBox.Show("Please ensure check in date and time are entered");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to create this reservation?", "Are you sure?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        DBUtil dbUtil = new DBUtil();
                        int customerID = customerList[customerSelectedIndex].CustomerID;
                        int roomNumber = roomList[roomSelectedIndex].RoomNumber;

                        try
                        {
                            //Connects to DB.
                            dbUtil.Open();

                            //Get new reservation ID
                            int reservationID = dbUtil.GetNewReservationID();

                            //Creates reservation object
                            Reservation reservation = new Reservation(customerID, reservationID, roomNumber.ToString(), currentDate, currentDatePlus2);

                            //Writes to DB
                            dbUtil.insertReservation(reservation);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            MessageBox.Show("Successfully created.");

                            ((Form1)Application.OpenForms["Form1"]).updateAllLists();

                            dbUtil.Close();
                            this.Close();
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //Nothing happens.
                    }
                }

            }
        }

        //Refresh button
        private void button2_Click(object sender, EventArgs e)
        {
            //Reconnects to DB, refills customer list.



        }

        //Check in date Text Box
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            //When clicked, a new window pops up with a calendar. Clicking the calendar date sets the date
            //in the textBox.
        }

        //Check out date Text Box
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            //When clicked, a new window pops up with a calendar. Clicking the calendar date sets the date
            //in the textBox.
            //Defaults to two days
        }

        //Room type combo box
        //Filters the Room listBox, depending on room type chosen.
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Filters room list, depending on selected index, which matches up with room ID.
        private void filterRoomList(int selectedIndex)
        {
            listBox2.Items.Clear();
            List<Room> filteredRoomList = new List<Room>();
            int listSize = roomList.Count();

            for (int x = 0; x < listSize; x++)
            {
                if (roomList[x].RoomTypeID == selectedIndex)
                {
                    filteredRoomList.Add(roomList[x]);
                }
            }

            int filteredListSize = filteredRoomList.Count();

            for (int y = 0; y < listSize; y++)
            {
                listBox2.Items.Add("Room " + filteredRoomList[y].RoomNumber.ToString());
            }

        }

        //Room listbox
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBox2.SelectedIndex;
            textBox7.Text = roomList[selectedIndex].RoomNumber.ToString();
            comboBox1.SelectedIndex = roomList[selectedIndex].RoomTypeID;
        }

        //Create new customer button
        private void button1_Click(object sender, EventArgs e)
        {
            //Opens create new customer form. 
            Form3 newCustomerForm = new Form3();
            newCustomerForm.Show();

            //When form is closed, list is refreshed. (POSSIBLY ADD REFRESH BUTTON).
        }

        //Builds the customer object list.
        private void customerListBuilder()
        {
            //Clears existing list, to make sure all data is up to date in the list.
            customerList.Clear();

            MySqlCommand command = new MySqlCommand("SELECT * from CUSTOMER", dbUtil.Connection);
            MySqlDataReader reader = command.ExecuteReader();

            //Uses existing DB connection. Fills the customer objects, and adds to list.
            try
            {
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
            }
            catch (Exception e)
            {
                MessageBox.Show("Error constructing Customer List. Please try again. \n\n" + e.ToString());
            }
            finally
            {
                reader.Close();
            }

            //Displays customers in listBox
            int listSize = customerList.Count();

            for (int x = 0; x < listSize; x++)
            {
                String displayString = (customerList[x].FirstName + " " + customerList[x].LastName);
                listBox1.Items.Add(displayString);
            }

        }

        //Builds the room object list.
        private void roomListBuilder()
        {
            //Clears existing list, if needed.
            roomList.Clear();
            listBox2.Items.Clear();

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
            catch (Exception e)
            {
                MessageBox.Show("Error constructing Room List. Please try again. \n\n" + e.ToString());
            }
            finally
            {
                reader.Close();
            }

            int listSize = roomList.Count();

            for (int x = 0; x < listSize; x++)
            {
                String displayString = ("Room " + roomList[x].RoomNumber.ToString());
                listBox2.Items.Add(displayString);
            }
        }

        //Builds the reservation object list.
        private void reservationListBuilder()
        {
            //Clears existing list, if needed.

            //Get connection to DB, and executes queries

            //Fills the reservation objects, and adds to list.
        }

        //Customer ListBox
        //When the Customer choice is changed, the textboxes update.
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedItem = listBox1.SelectedIndex.ToString();
            int selectedItemInt = Int32.Parse(selectedItem);

            Customer selectedCustomer = customerList[selectedItemInt];

            textBox1.Text = selectedCustomer.FirstName;
            textBox2.Text = selectedCustomer.LastName;
            textBox3.Text = selectedCustomer.StreetAddress;
            textBox4.Text = selectedCustomer.City;
            textBox5.Text = selectedCustomer.Province;
            textBox6.Text = selectedCustomer.PostalCode;
        }

        //Loads customer list
        internal void loadCustomerList(List<Customer> custList)
        {
            customerList = custList;
        }

        //Loads reservation list
        internal void loadReservationList(List<Reservation> resList)
        {
            reservationList = resList;
        }

        //Loads room list
        internal void loadRoomList(List<Room> rmList)
        {
            roomList = rmList;
        }


    }
}