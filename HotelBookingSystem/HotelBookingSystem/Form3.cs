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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        //Save button
        private void button1_Click(object sender, EventArgs e)
        {
            //Validate form. Credit card is optional.
            //Customer must be filled out.
            //If not all fieldz are filled out for Credit Card, error is thrown.
            //Expiry must be in correct format
            //Numbers only for CC.
            //3 numbers only for CSV
            //ComboBox must not be default.

            //Figure out next Customer ID. Convert to String

            //DEBUG
            String customerID = "9";

            //Setting Customer variables from the text fields.
            String firstName = textBox1.Text;
            String lastName = textBox2.Text;
            String streetAddress = textBox3.Text;
            String city = textBox4.Text;
            String province = textBox5.Text;
            String postalCode = textBox6.Text;

            String cardType = comboBox1.Text;
            String cardholderName = textBox7.Text;
            String cardNumber = textBox8.Text;
            String csv = textBox9.Text;
            String expiry = textBox10.Text;



            //Creating Customer and Credit Card objects
            CreditCard creditCard = new CreditCard(cardNumber, customerID, csv, expiry, cardholderName, cardType);

        }

        //Clear button.
        private void button2_Click(object sender, EventArgs e)
        {
            //Clear all fields. Sets comboBox index back to 0.
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            comboBox1.SelectedIndex = 0;
        }

        //Cancel button
        private void button3_Click(object sender, EventArgs e)
        {
            //Closes window.
            this.Close();
        }

    }
}
