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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        //Cancel button
        private void button2_Click(object sender, EventArgs e)
        {
            //Closes window.
            this.Close();
        }

        //Used to pass bill object to this form.
        internal void loadBill(Bill bill)
        {
            //Fills textBox objects.
            textBox1.Text = bill.BillID.ToString();
            textBox2.Text = "$" + bill.TotalPrice.ToString();
            textBox3.Text = bill.IsPaid.ToString();
        }

        //Used to pass customer object to this form.
        internal void loadCustomer(Customer cust)
        {
            //Fills textBox objects.
            textBox5.Text = cust.FirstName;
            textBox4.Text = cust.LastName;
            textBox6.Text = cust.StreetAddress;
            textBox8.Text = cust.City;
            textBox9.Text = cust.Province;
            textBox7.Text = cust.PostalCode;
        }

        //Used to pass room object to this form.
        internal void loadRoom(Room room)
        {
            //Fills textBox objects.
            textBox14.Text = room.RoomFloor.ToString();
            textBox15.Text = room.RoomFloor.ToString();
            textBox13.Text = room.RoomTypeString;
        }

        //Used to pass reservation object to this form.
        internal void loadReservation(Reservation res)
        {
            //Fills textBox objects.
            textBox11.Text = res.CheckInDate.ToString();
            textBox12.Text = res.CheckOutDate.ToString();
            textBox10.Text = res.ReservationID.ToString();
        }

        //Used to pass room service object to this form.
        internal void loadRoomService(RoomService rserv)
        {
            //Makes sure object isn't blank. If it's a blank object, nothing happens.
            if (rserv.RoomServiceID != 0)
            {
                //Fills textBox and checkBox objects.
                checkBox1.Checked = true;
                textBox17.Text = rserv.ItemOrdered;
                textBox16.Text = "$" + rserv.TotalPrice.ToString();
            }
        }
    }
}
