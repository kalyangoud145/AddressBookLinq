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
        }
    }
}
