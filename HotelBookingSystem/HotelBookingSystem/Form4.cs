//Name: Behn McIlwaine, Marco Saad, Manon Miron
//Date: April 22, 2016
//Class: CIS-2261
//Final Project: Hotel Booking System
//Notes: The form to view/edit customers

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
    public partial class Form4 : Form
    {
        Customer loadedCustomer;
        DBUtil dbUtil = new DBUtil();

        public Form4()
        {
            InitializeComponent();
        }

        //Edit button
        private void button2_Click(object sender, EventArgs e)
        {
            //Enables fields and save button.
            button1.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            textBox10.Enabled = true;
            textBox11.Enabled = true;

            //Disables edit button
            button2.Enabled = false;
        }

        //Cancel button
        private void button3_Click(object sender, EventArgs e)
        {
            //Closes window.
            this.Close();
        }

        //Save button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dbUtil.Open();

                //Creating customer for upload.
                Customer customer = new Customer(loadedCustomer.CustomerID, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);

                dbUtil.UpdateCustomer(customer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                MessageBox.Show("Successfully updated.");

                //Refreshes the lists in the original form.
                ((Form1)Application.OpenForms["Form1"]).updateAllLists();

                dbUtil.Close();
                this.Close();
            }         
            //Updates record in database.


            //Disables fields, and re-enables edit button
            button1.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            button2.Enabled = true;
        }

        //Used to pass customer object to this form.
        internal void loadCustomer(Customer cust)
        {
            textBox12.Text = cust.CustomerID.ToString();
            textBox1.Text = cust.FirstName;
            textBox2.Text = cust.LastName;
            textBox3.Text = cust.StreetAddress;
            textBox4.Text = cust.City;
            textBox5.Text = cust.Province;
            textBox6.Text = cust.PostalCode;
            loadedCustomer = cust;
        }

        //Used to pass credit card object to this form.
        internal void loadCreditCard(CreditCard card)
        {
            textBox7.Text = card.CardType;
            textBox8.Text = card.NameOnCard;
            textBox11.Text = card.CardNumber;
            textBox9.Text = card.CsvNumber.ToString();
            textBox10.Text = card.ExpiryDate.ToString();
        }
    }
}
