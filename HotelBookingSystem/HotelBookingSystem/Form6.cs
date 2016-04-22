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
    public partial class Form6 : Form
    {
        Bill passedBill = new Bill();
        RoomService passedRoomService = new RoomService();

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        //Cancel button
        private void button2_Click(object sender, EventArgs e)
        {
            //Closes window.
            this.Close();
        }

        //Submit button
        private void button1_Click(object sender, EventArgs e)
        {
            String cardType = comboBox1.SelectedIndex.ToString();
            String cardNumber = textBox1.Text;
            String csvNumber = textBox2.Text;
            String nameOnCard = textBox3.Text;
            String expiration = textBox5.Text;
            String totalPrice = textBox4.Text;

            PaymentProcessor paymentProcessor = new PaymentProcessor(passedBill, passedBill.BillID, passedBill.TotalPrice, cardNumber, Int32.Parse(csvNumber), nameOnCard, cardType);

            if (paymentProcessor.WasSuccessful)
            {
                MessageBox.Show("Payment successful");
                this.Close();
            } else
            {
                MessageBox.Show("There was an error processing. Please check the information, and try again.");
            }
        }

        internal void loadBill(Bill bill)
        {
            //Sets object, and fills textBox with price.
            passedBill = bill;
        }

        internal void loadRoomService(RoomService service)
        {
            //Sets object
            passedRoomService = service;

            //Displays correct price.
            if(passedRoomService.RoomServiceID != 0)
            {
                textBox4.Text = "$" + (passedBill.TotalPrice + passedRoomService.TotalPrice).ToString();
            } else
            {
                textBox4.Text = "$" + passedBill.TotalPrice.ToString();
            }
        }
    }
}
