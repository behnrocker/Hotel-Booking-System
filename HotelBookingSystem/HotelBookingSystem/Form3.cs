﻿//Name: Behn McIlwaine, Marco Saad, Manon Miron
//Date: April 22, 2016
//Class: CIS-2261
//Final Project: Hotel Booking System
//Notes: The form to create new customers

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
            DBUtil dbUtil = new DBUtil();

            //Setting Customer variables from the text fields.
            String firstName = textBox1.Text;
            String lastName = textBox2.Text;
            String streetAddress = textBox3.Text;
            String city = textBox4.Text;
            String province = textBox5.Text;
            String postalCode = textBox6.Text;

            if (firstName == "" || lastName == "" || streetAddress == "" || city == "" || province == "" || postalCode == "")
            {
                MessageBox.Show("Please fill out all required fields.");
            }
            else
            {
                try
                {
                    dbUtil.Open();

                    //Gets new Customer ID
                    int customerID = dbUtil.GetNewCustomerID();

                    //Creates object
                    Customer customer = new Customer(customerID, firstName, lastName, streetAddress, city, province, postalCode);

                    //Writes to DB
                    dbUtil.insertCustomer(customer);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    MessageBox.Show("Customer successfully created.");

                    //Refreshes the customer list in the original form.
                    ((Form1)Application.OpenForms["Form1"]).updateAllLists();

                    dbUtil.Close();

                    this.Close();
                }
            }
            
            
            //Validate form. Credit card is optional.
            //Customer must be filled out.
            //If not all fields are filled out for Credit Card, error is thrown.
            //Expiry must be in correct format
            //Numbers only for CC.
            //3 numbers only for CSV
            //ComboBox must not be default.

            //Figure out next Customer ID.

            //String cardType = comboBox1.Text;
            //String cardholderName = textBox7.Text;
            //String cardNumber = textBox8.Text;
            //String csv = textBox9.Text;
            //String expiry = textBox10.Text;



            //Creating Customer object
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
