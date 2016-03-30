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

        public Form2()
        {
            InitializeComponent();

            customerListBuilder();
            roomListBuilder();

            //Read from DB. Try catch.
            
            //Save in object array: Rooms, customers, reservations
            
        }

        //Create New Reservation button
        private void button3_Click(object sender, EventArgs e)
        {
            //Figure out these
            int customerID;
            int reservationID;

            String roomNumber = textBox7.Text;

            //Figure out these
            DateTime checkIn;
            DateTime checkOut;

            //Reservation reservation = new Reservation(customerID, reservationID, roomNumber, checkIn, checkOut);

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
            //Defaults to the next day
        }

        //Room type combo box
        //Filters the Room listBox, depending on room type chosen.
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterRoomList(comboBox1.SelectedIndex);
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
            //When room is clicked on, the textbox is filled with the room number. Textbox stays inactive
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
            //Clears existing list, if needed.
            customerList.Clear();

            //Get connection to DB, and executes queries

            //Fills the customer objects, and adds to list.
            //DEBUG REPLACE LATER
            createFakeCustomer();

            //Fills listBox with customer names
            int listSize = customerList.Count();

            for(int x = 0; x < listSize; x++)
            {
                String customerFirstName = customerList[x].FirstName;
                String customerLastName = customerList[x].LastName;

                listBox1.Items.Add((customerFirstName + " " + customerLastName));
            }

        }

        //Builds the room object list.
        private void roomListBuilder()
        {
            //Clears existing list, if needed.
            roomList.Clear();

            //Get connection to DB, and executes queries

            //Fills the room objects, and adds to list.
            //DEBUG REPLACE LATER
            createFakeRooms();

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
            reservationList.Clear();

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

        //DEBUG
        private void createFakeReservation()
        {
            DateTime checkIn = new DateTime(2015, 4, 10);
            DateTime checkOut = new DateTime(2015, 4, 12);

            //Reservation fakeReservation = new Reservation(001, 001, 206, checkIn, checkOut);

            //listBox1.Items.Add("001");
        }

        private void createFakeRooms()
        {
            Room fakeRoom1 = new Room(262, 0, 2);
            Room fakeRoom2 = new Room(616, 1, 6);
            Room fakeRoom3 = new Room(716, 2, 7);
            Room fakeRoom4 = new Room(157, 0, 1);
            Room fakeRoom5 = new Room(733, 1, 7);
            Room fakeRoom6 = new Room(826, 2, 8);
            Room fakeRoom7 = new Room(166, 0, 1);
            Room fakeRoom8 = new Room(377, 1, 3);

            roomList.Add(fakeRoom1);
            roomList.Add(fakeRoom2);
            roomList.Add(fakeRoom3);
            roomList.Add(fakeRoom4);
            roomList.Add(fakeRoom5);
            roomList.Add(fakeRoom6);
            roomList.Add(fakeRoom7);
            roomList.Add(fakeRoom8);
        }

        private void createFakeCustomer()
        {
            Customer fakeCustomer1 = new Customer(001, "Behn", "McIlwaine", "36 Beasley Ave.", "Charlottetown", "PEI", "C1A 5Z3");
            Customer fakeCustomer2 = new Customer(001, "Testy", "Testerson", "30 Morley Ave.", "Toronto", "ON", "C1A 2J4");
            Customer fakeCustomer3 = new Customer(001, "Michelle", "Testerson", "322 West Eastnorth St.", "Charlottetown", "PEI", "C1A 5Z3");

            customerList.Add(fakeCustomer1);
            customerList.Add(fakeCustomer2);
            customerList.Add(fakeCustomer3);
        }
    }
}
