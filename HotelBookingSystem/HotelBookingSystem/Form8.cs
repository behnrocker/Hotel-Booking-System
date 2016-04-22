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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        //Cancel button
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Clear button
        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            textBox1.Text = "";
        }

        //Save button
        private void button1_Click(object sender, EventArgs e)
        {
            DBUtil dbUtil = new DBUtil();
            String roomType = comboBox1.Text;
            String floorString = textBox1.Text;
            int floor = Int32.Parse(floorString);
            int roomTypeID = 0;

            if(comboBox1.SelectedIndex == -1 || textBox1.Text == "")
            {
                MessageBox.Show("Please enter all required information.");
            }
            else
            {
                try
                {
                    //Opens DB
                    dbUtil.Open();

                    //Gets room type ID
                    if(comboBox1.SelectedIndex == 0)
                    {
                        roomTypeID = 0;
                    } else if(comboBox1.SelectedIndex == 1)
                    {
                        roomTypeID = 1;
                    } else if(comboBox1.SelectedIndex == 2)
                    {
                        roomTypeID = 2;
                    }

                    //Gets new room number
                    int roomNumber = dbUtil.GetNewRoomNumber();

                    //Creates object
                    Room room = new Room(roomNumber, roomTypeID, floor);

                    //Writes to DB
                    dbUtil.InsertRoom(room);

                    MessageBox.Show("Saved successfully");
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
        }
    }
}
