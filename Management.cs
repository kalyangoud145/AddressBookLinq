using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AddressBookLinq
{
    class Management
    {
        // UC 1 Create a new DataTable
        DataTable table = new DataTable("AddressBook");
        /// <summary>
        /// UC2
        /// created constructor
        /// Adding columns by invoking constructor
        /// </summary>
        public Management()
        {
            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            table.Columns.Add("Address", typeof(string));
            table.Columns.Add("City", typeof(string));
            table.Columns.Add("State", typeof(string));
            table.Columns.Add("Zip", typeof(string));
            table.Columns.Add("PhoneNumber", typeof(string));
            table.Columns.Add("Email", typeof(string));
            // UC3 Inserting Data into Table
            table.Rows.Add("kalyan", "goud", "8-47", "nlg", "ts", "535501", "8975596720", "mkh@gmail.com");
            table.Rows.Add("bhanu", "nunna", "Sun nagar", "warangal", "ts", "546489", "8570456737", "ram@gmail.com");
            table.Rows.Add("Ravi", "kumar", "Rain colony", "Hyd", "ap", "546362", "9878678593", "ravi@gmail.com");
            table.Rows.Add("anirudh", "repala", "WhiteField", "Banglore", "Karnataka", "125445", "7206326427", "srinu@gmail.com");
        }
    }
}
