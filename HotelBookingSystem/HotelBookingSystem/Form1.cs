﻿using System;
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

        public Form1()
        {
            InitializeComponent();

            //Read from Database, and fill lists. 
            customerListBuilder();
            reservationListBuilder();
            roomListBuilder();
            billListBuilder();
            creditCardListBuilder();
            employeeListBuilder();
            roomServiceListBuilder();
        }

        //---------------------------WELCOME TAB---------------------------\\

        //Sign in button
        private void button15_Click(object sender, EventArgs e)
        {
            //Make sure fields aren't empty.

            
            //Checks that username/password match
            //DEBUG
            if(textBox19.Text == "testuser" && textBox20.Text == "password")
            {
                //Welcome message appears.
                label23.Text = "Welcome, testuser";
                
                //Enables tabs for navigation.
                tabControl1.Enabled = true;
            } else
            {
                MessageBox.Show("Invalid login");
            }
        }

        //---------------------------CHECK-IN TAB---------------------------\\

        //Filter button
        private void button1_Click(object sender, EventArgs e)
        {
            //Gathers info from fields, stores as variables. Removes leading and trailing spaces.

            //Searches object list for fields that are valid. If variable is blank, that field is not searched.
        }

        //Check-in button
        private void button2_Click(object sender, EventArgs e)
        {
            //Flags reservation as checked in on DB.

        }

        //---------------------------CHECK-OUT TAB---------------------------\\

        //Filter button
        private void button4_Click(object sender, EventArgs e)
        {
            //Gathers info from fields, stores as variables. Removes leading and trailing spaces.

            //Searches object list for fields that are valid. If variable is blank, that field is not searched.
        }

        //Check-out button
        private void button3_Click(object sender, EventArgs e)
        {
            //Flags reservation as checked out on DB.
        }

        //---------------------------RESERVATION TAB---------------------------\\

        //Reservations Tab > Create New Reservation Button
        private void button5_Click(object sender, EventArgs e)
        {

            Form2 newReservationForm = new Form2();
            newReservationForm.Show();
        }

        //When the date is changed in the calendar, the reservation ListBox updates with only reservations
        //from that specified day. (Calendar in Reservations tab)
        private void monthCalendar3_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        //View button
        private void button6_Click(object sender, EventArgs e)
        {
            //Opens another window with information about the reservation.
        }

        //---------------------------ROOM SERVICE TAB---------------------------\\

        
        //Order button
        private void button8_Click(object sender, EventArgs e)
        {

            //Gather variables, create String, and display on the dialog box.

            DialogResult dialogResult = MessageBox.Show("DISPLAY HERE", "Order confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Process room service order. Add price to user's bill.
            }
            else if (dialogResult == DialogResult.No)
            {
                //Go back to original form.
            }
        }

        //Filter button
        private void button7_Click(object sender, EventArgs e)
        {
            //Gathers info from fields, stores as variables. Removes leading and trailing spaces.

            //Searches object list for fields that are valid. If variable is blank, that field is not searched.
        }

        //---------------------------CUSTOMERS TAB---------------------------\\

        //Customer > Add new customer button
        private void button9_Click(object sender, EventArgs e)
        {
            Form3 newCustomerForm = new Form3();
            newCustomerForm.Show();
        }

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
                //Displaying what is in the bill object.
                
                
                //Creating the form object.
                //Form5 viewBillForm = new Form5();

                //Passing the customer object to the new form.
                //viewBillForm.loadBill(billList[listBox8.SelectedIndex]);

                //viewBillForm.Show();
            }
        }

        //Pay bill button
        private void button17_Click(object sender, EventArgs e)
        {

        }

        //---------------------------REPORTS TAB---------------------------\\

        //---------------------------ADMIN TAB---------------------------\\

        //Delete User
        private void button10_Click(object sender, EventArgs e)
        {

        }

        //Create User
        private void button11_Click(object sender, EventArgs e)
        {

        }

        //Delete Room
        private void button12_Click(object sender, EventArgs e)
        {

        }

        //Create Room
        private void button13_Click(object sender, EventArgs e)
        {

        }

        //---------------------------LIST BUILDERS---------------------------\\

        //Builds the customer object list.
        private void customerListBuilder()
        {
            //Clears existing list, if needed.
            customerList.Clear();

            //Get connection to DB, and executes queries

            //Fills the customer objects, and adds to list.
            //DEBUG
            createFakeCustomers();

            int listSize = customerList.Count();

            for (int x = 0; x < listSize; x++)
            {
                String displayString = (customerList[x].FirstName + " " + customerList[x].LastName);
                listBox5.Items.Add(displayString);
            }
        }

        //Builds the reservation object list.
        private void reservationListBuilder()
        {
            //Clears existing list, if needed.
            reservationList.Clear();

            //Get connection to DB, and executes queries

            //Fills the reservation objects, and adds to list.
            createFakeReservations();

            int listSize = reservationList.Count();

            for (int x = 0; x < listSize; x++)
            {
                String displayString = ("Reservation " + reservationList[x].ReservationID + " - Customer " + reservationList[x].CustomerID);
                listBox3.Items.Add(displayString);
            }
        }
        
        //Builds the room object list.
        private void roomListBuilder()
        {
            //Clears existing list, if needed.
            roomList.Clear();

            //Get connection to DB, and executes queries

            //Fills the room objects, and adds to list.
            //DEBUG
            createFakeRooms();

            int listSize = roomList.Count();

            for (int x = 0; x < listSize; x++)
            {
                String displayString = ("Room " + roomList[x].RoomNumber.ToString());
                listBox7.Items.Add(displayString);
            }
        }

        //Builds the bill object list.
        private void billListBuilder()
        {
            //Clears existing list, if needed.
            billList.Clear();

            //Get connection to DB, and executes queries

            //Fills the bill objects, and adds to list.
            //DEBUG
            createFakeBills();

            int listSize = billList.Count();

            for (int x = 0; x < listSize; x++)
            {
                String displayString = (billList[x].BillID + " - $" + billList[x].TotalPrice);
                listBox8.Items.Add(displayString);
            }
        }

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

        //Builds the employee object list.
        private void employeeListBuilder()
        {
            //Clears existing list, if needed.
            employeeList.Clear();

            //Get connection to DB, and executes queries

            //Fills the employee objects, and adds to list.
            //DEBUG
            createFakeEmployees();

            int listSize = employeeList.Count();

            for (int x = 0; x < listSize; x++)
            {
                String displayString = (employeeList[x].FirstName + " " + employeeList[x].LastName);
                listBox6.Items.Add(displayString);
            }
        }

        //Builds the room service object list.
        private void roomServiceListBuilder()
        {
            //Clears existing list, if needed.
            roomServiceList.Clear();

            //Get connection to DB, and executes queries

            //Fills the room service objects, and adds to list.
            //DEBUG
            createFakeRoomServices();

            int listSize = roomServiceList.Count();

            for (int x = 0; x < listSize; x++)
            {
                String displayString = ("Reservation " + reservationList[x].ReservationID.ToString());
                listBox4.Items.Add(displayString);
            }
        }


        //---------------------------DEBUG---------------------------\\

        //Fills the object lists with some placeholders until the DB is ready

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

        private void createFakeCustomers()
        {
            Customer fakeCustomer1 = new Customer(001, "Behn", "McIlwaine", "36 Beasley Ave.", "Charlottetown", "PEI", "C1A 5Z3");
            Customer fakeCustomer2 = new Customer(002, "Testy", "Testerson", "30 Morley Ave.", "Toronto", "ON", "C1A 2J4");
            Customer fakeCustomer3 = new Customer(003, "Michelle", "Testerson", "322 West Eastnorth St.", "Charlottetown", "PEI", "C1A 5Z3");

            customerList.Add(fakeCustomer1);
            customerList.Add(fakeCustomer2);
            customerList.Add(fakeCustomer3);
        }

        private void createFakeReservations()
        {
            Reservation fakeReservation1 = new Reservation(001, 001, "206", new DateTime(2015, 4, 10), new DateTime(2015, 4, 12));
            Reservation fakeReservation2 = new Reservation(002, 001, "304", new DateTime(2015, 5, 14), new DateTime(2015, 5, 15));
            Reservation fakeReservation3 = new Reservation(003, 001, "808", new DateTime(2015, 6, 05), new DateTime(2015, 6, 09));

            reservationList.Add(fakeReservation1);
            reservationList.Add(fakeReservation2);
            reservationList.Add(fakeReservation3);
        }

        private void createFakeBills()
        {
            Bill fakeBill1 = new Bill(1, 1, 1, true, 100.00);
            Bill fakeBill2 = new Bill(2, 2, 2, false, 85.23);
            Bill fakeBill3 = new Bill(3, 3, 3, false, 141.36);

            billList.Add(fakeBill1);
            billList.Add(fakeBill2);
            billList.Add(fakeBill3);
        }

        public void createFakeCreditCards()
        {
            CreditCard fakeCard1 = new CreditCard("1234123412341234", "1", "123", "09/17", "Behn McIlwaine", "Visa");
            CreditCard fakeCard2 = new CreditCard("5555555555555554", "2", "245", "10/18", "Testy Testerson", "Mastercard");
            CreditCard fakeCard3 = new CreditCard("8264924472662847", "3", "262", "03/17", "Michelle Testerson", "Discover");

            creditCardList.Add(fakeCard1);
            creditCardList.Add(fakeCard2);
            creditCardList.Add(fakeCard3);
        }

        public void createFakeEmployees()
        {
            Employee fakeEmployee1 = new Employee(001, "Adminny", "Adminnerson", "36 Beasley Ave.", "Charlottetown", "PEI", "C1A 5Z3", "Admin");
            Employee fakeEmployee2 = new Employee(001, "John", "Smith", "38 Beasley Ave.", "Charlottetown", "PEI", "C1A 5Z3", "User");
            Employee fakeEmployee3 = new Employee(001, "Greyson", "Nootenboom", "34 Beasley Ave.", "Charlottetown", "PEI", "C1A 5Z3", "User");

            employeeList.Add(fakeEmployee1);
            employeeList.Add(fakeEmployee2);
            employeeList.Add(fakeEmployee3);
        }

        public void createFakeRoomServices()
        {
            RoomService fakeRoomService1 = new RoomService(1, "French Fries", 001, 322, "Extra salty", 5.99, new DateTime(2015, 5, 14));
            RoomService fakeRoomService2 = new RoomService(2, "Hamburger", 002, 527, "Only ketchup", 8.99, new DateTime(2015, 5, 20));
            RoomService fakeRoomService3 = new RoomService(3, "Massage", 003, 422, "", 59.99, new DateTime(2015, 7, 11));

            roomServiceList.Add(fakeRoomService1);
            roomServiceList.Add(fakeRoomService2);
            roomServiceList.Add(fakeRoomService3);
        }
    }
}