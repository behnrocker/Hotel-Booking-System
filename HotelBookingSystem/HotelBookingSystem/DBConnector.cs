using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace HotelBookingSystem
{
    class DBConnector
    {

        //Needs to have new DB info for the Data Source
        private String sConnection = "Provider=Microsoft.ACE.OLEDB.12.0;"
                                   + "Data Source=..\\Debug\\CHANGEMEEEEE.accdb";
        private OleDbConnection dbConnection;
        private OleDbCommand dbCommand;
        private OleDbDataReader dbReader;

        //Needs query for all entries
        private String getAllEntriesSQL = "";


        public void getDBConnection()
        {
            dbConnection = new OleDbConnection(sConnection);
            dbConnection.Open();
            dbCommand = new OleDbCommand();
            dbCommand.Connection = dbConnection;
        }

        //Below will be for other actions with the DB, such as writing to different tables. May as well
        //keep everything DB-wise in this class. Waiting on DB to be delivered to start this (need table
        //info to properly interact).





    }
}
