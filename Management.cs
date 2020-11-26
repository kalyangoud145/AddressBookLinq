using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            table.Rows.Add("Ravi", "kumar", "Rain colony", "nlg", "ap", "546362", "9878678593", "ravi@gmail.com");
            table.Rows.Add("anirudh", "repala", "WhiteField", "Banglore", "Karnataka", "125445", "7206326427", "srinu@gmail.com");
        }
        /// <summary>
        /// UC4
        /// Updates Existing contact takes first name and last name for selecting row
        /// Column name for selecting particular column and new value for updating the data
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="columnName"></param>
        /// <param name="newValue"></param>
        public void UpdateContact(string firstName, string lastName, string columnName, string newValue)
        {
            DataRow updateContact = table.Select("FirstName = '" + firstName + "' and LastName = '" + lastName + "'").FirstOrDefault();
            updateContact[columnName] = newValue;
            Console.WriteLine("Updated Contact");
        }
        /// <summary>
        /// This method prints all contacts in DataTable
        /// </summary>
        public void GetAllContacts()
        {
            foreach (DataRow dr in table.AsEnumerable())
            {
                Console.WriteLine("\n");
                Console.WriteLine("FirstName:- " + dr.Field<string>("FirstName"));
                Console.WriteLine("lastName:- " + dr.Field<string>("LastName"));
                Console.WriteLine("Address:- " + dr.Field<string>("Address"));
                Console.WriteLine("City:- " + dr.Field<string>("City"));
                Console.WriteLine("State:- " + dr.Field<string>("State"));
                Console.WriteLine("zip:- " + dr.Field<string>("Zip"));
                Console.WriteLine("phoneNumber:- " + dr.Field<string>("phoneNumber"));
                Console.WriteLine("eMail:- " + dr.Field<string>("Email"));
            }

        }
        /// <summary>
        /// UC 5 
        /// Deletes a specific contact.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        public void DeleteContact(string firstName, string lastName)
        {
            DataRow deleteContact = table.Select("FirstName = '" + firstName + "' and LastName = '" + lastName + "'").FirstOrDefault();
            table.Rows.Remove(deleteContact);
        }
        /// <summary>
        /// UC 6 Retrieves the contact by city
        /// </summary>
        /// <param name="city">The city.</param>
        public void RetrieveByCity(string city)
        {
            var contact = from person in table.AsEnumerable()
                          where person.Field<string>("City") == city
                          select person;
            foreach (DataRow dr in contact)
            {
                Console.WriteLine("\n");
                Console.WriteLine("FirstName:- " + dr.Field<string>("FirstName"));
                Console.WriteLine("lastName:- " + dr.Field<string>("LastName"));
                Console.WriteLine("Address:- " + dr.Field<string>("Address"));
                Console.WriteLine("City:- " + dr.Field<string>("City"));
                Console.WriteLine("State:- " + dr.Field<string>("State"));
                Console.WriteLine("zip:- " + dr.Field<string>("Zip"));
                Console.WriteLine("phoneNumber:- " + dr.Field<string>("phoneNumber"));
                Console.WriteLine("eMail:- " + dr.Field<string>("Email"));
            }
        }
        /// <summary>
        /// Retrieves the contact by state
        /// </summary>
        /// <param name="state">The state.</param>
        public void RetrieveByState(string state)
        {
            var contact = from person in table.AsEnumerable()
                          where person.Field<string>("State") == state
                          select person;
            foreach (DataRow dr in contact)
            {
                Console.WriteLine("\n");
                Console.WriteLine("FirstName:- " + dr.Field<string>("FirstName"));
                Console.WriteLine("lastName:- " + dr.Field<string>("LastName"));
                Console.WriteLine("Address:- " + dr.Field<string>("Address"));
                Console.WriteLine("City:- " + dr.Field<string>("City"));
                Console.WriteLine("State:- " + dr.Field<string>("State"));
                Console.WriteLine("zip:- " + dr.Field<string>("Zip"));
                Console.WriteLine("phoneNumber:- " + dr.Field<string>("phoneNumber"));
                Console.WriteLine("eMail:- " + dr.Field<string>("Email"));
            }
        }
        /// <summary>
        /// UC 7 
        /// Count contact by  city
        /// </summary>
        /// <param name="city">The city.</param>
        public void CountByCity(string city)
        {
            var contact = from person in table.AsEnumerable()
                          where person.Field<string>("City") == city
                          select person;
            Console.WriteLine("Count of contacts in City :{0} is {1}", city, contact.Count());
        }
        /// <summary>
        /// Count contact by state 
        /// </summary>
        /// <param name="city">The state.</param>
        public void CountByState(string state)
        {
            var contact = from person in table.AsEnumerable()
                          where person.Field<string>("State") == state
                          select person;
            Console.WriteLine("Count of contacts in State :{0} is {1}", state, contact.Count());
        }
        /// UC 8
        /// <summary>
        /// Gets all contacts in sorted order by persons name for a given city 
        /// </summary>
        /// <param name="city">The city.</param>
        public void GetAllContactsInSortedOrderInCityOrderByName(string city)
        {
            var contact = from c in table.AsEnumerable()
                          where c.Field<string>("City") == city
                          orderby c.Field<string>("FirstName")
                          select c;
            foreach (DataRow dr in contact)
            {
                Console.WriteLine("\n");
                Console.WriteLine("FirstName:- " + dr.Field<string>("FirstName"));
                Console.WriteLine("lastName:- " + dr.Field<string>("LastName"));
                Console.WriteLine("Address:- " + dr.Field<string>("Address"));
                Console.WriteLine("City:- " + dr.Field<string>("City"));
                Console.WriteLine("State:- " + dr.Field<string>("State"));
                Console.WriteLine("zip:- " + dr.Field<string>("Zip"));
                Console.WriteLine("phoneNumber:- " + dr.Field<string>("phoneNumber"));
                Console.WriteLine("eMail:- " + dr.Field<string>("Email"));
                Console.WriteLine("phoneNumber:- " + dr.Field<string>("phoneNumber"));
                Console.WriteLine("eMail:- " + dr.Field<string>("Email"));
            }
        }
        /// <summary>
        /// UC 9
        /// Add address book name and type column to data table
        /// </summary>
        public void AddAddressBookNameTypeColumn()
        {
            // Added addressbook name column
            DataColumn column;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "AddressBookName";
            column.AllowDBNull = false;
            column.DefaultValue = "Kalyan";
            table.Columns.Add(column);
            // Added contact type column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ContactType";
            column.AllowDBNull = false;
            column.DefaultValue = "Friends";
            table.Columns.Add(column);
        }
    }
}
