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
    public partial class Form7 : Form
    {
        //Database Utility object.
        DBUtil dbUtil = new DBUtil();

        public Form7()
        {
            InitializeComponent();
        }

        //Save button
        private void button1_Click(object sender, EventArgs e)
        {
            String firstName = textBox1.Text;
            String lastName = textBox2.Text;
            String streetAddress = textBox3.Text;
            String city = textBox4.Text;
            String province = textBox5.Text;
            String postalCode = textBox6.Text;
            String title = comboBox1.Text;

            try
            {
                //Connects to DB
                dbUtil = new DBUtil();
                dbUtil.Open();

                //Gets next Employee number
                int employeeID = dbUtil.GetNewEmployeeID();

                //Creates Employee object
                Employee employee = new Employee(employeeID, firstName, lastName, streetAddress, city, province, postalCode, title);

                //Adds to DB
                dbUtil.InsertEmployee(employee);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                dbUtil.Close();
            }
        }

        //Clear button
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
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
