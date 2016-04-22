//Name: Behn McIlwaine, Marco Saad, Manon Miron
//Date: April 22, 2016
//Class: CIS-2261
//Final Project: Hotel Booking System
//Notes: The form to view reservation information

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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        //Close button
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Used to pass Room object to this form.
        internal void loadReservation(Reservation res)
        {
            //Fills textBox objects.
            textBox7.Text = res.ReservationID.ToString();
            textBox8.Text = res.CheckInDate.ToLongDateString();
            textBox9.Text = res.CheckOutDate.ToLongDateString();
            textBox10.Text = res.RoomNumber.ToString();

            if (res.IsCheckedIn)
            {
                checkBox1.Checked = true;
            } else
            {
                checkBox1.Checked = false;
            }

        }

        //Used to pass reservation object to this form.
        internal void loadCustomer(Customer cust)
        {
            //Fills textBox objects.
            textBox1.Text = cust.FirstName;
            textBox2.Text = cust.LastName;
            textBox3.Text = cust.StreetAddress;
            textBox4.Text = cust.City;
            textBox5.Text = cust.Province;
            textBox6.Text = cust.PostalCode;
        }
    }
}
