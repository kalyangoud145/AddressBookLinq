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
        public void UpdateContact(Person person, string columnName, string newValue)
        {
            DataRow updateContact = table.Select("FirstName = '" + person.FirstName + "' and LastName = '" + person.LastName + "'").FirstOrDefault();
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
                Console.WriteLine("\n" + "FirstName:- " + dr.Field<string>("FirstName")
                    + "\n" + "lastName:- " + dr.Field<string>("LastName")
                    + "\n" + "Address:- " + dr.Field<string>("Address")
                    + "\n" + "City:- " + dr.Field<string>("City")
                    + "\n" + "State:- " + dr.Field<string>("State")
                    + "\n" + "zip:- " + dr.Field<string>("Zip")
                    + "\n" + "phoneNumber:- " + dr.Field<string>("phoneNumber")
                    + "\n" + "eMail:- " + dr.Field<string>("Email")
                    );
            }

        }
        /// <summary>
        /// UC 5 
        /// Deletes a specific contact.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        public void DeleteContact(Person person)
        {
            DataRow deleteContact = table.Select("FirstName = '" + person.FirstName + "' and LastName = '" + person.LastName + "'").FirstOrDefault();
            table.Rows.Remove(deleteContact);
        }
        /// <summary>
        /// UC 6 Retrieves the contact by city
        /// </summary>
        /// <param name="city">The city.</param>
        public void RetrieveByCity(Person person1)
        {
            var contact = from person in table.AsEnumerable()
                          where person.Field<string>("City") == person1.City
                          select person;
            foreach (DataRow dr in contact)
            {
                Console.WriteLine("\n" + "FirstName:- " + dr.Field<string>("FirstName")
                    + "\n" + "lastName:- " + dr.Field<string>("LastName")
                    + "\n" + "Address:- " + dr.Field<string>("Address")
                    + "\n" + "City:- " + dr.Field<string>("City")
                    + "\n" + "State:- " + dr.Field<string>("State")
                    + "\n" + "zip:- " + dr.Field<string>("Zip")
                    + "\n" + "phoneNumber:- " + dr.Field<string>("phoneNumber")
                    + "\n" + "eMail:- " + dr.Field<string>("Email")
                    );
            }
        }
        /// <summary>
        /// Retrieves the contact by state
        /// </summary>
        /// <param name="state">The state.</param>
        public void RetrieveByState(Person person1)
        {
            var contact = from person in table.AsEnumerable()
                          where person.Field<string>("State") == person1.State
                          select person;
            foreach (DataRow dr in contact)
            {
                Console.WriteLine("\n" + "FirstName:- " + dr.Field<string>("FirstName")
                    + "\n" + "lastName:- " + dr.Field<string>("LastName")
                    + "\n" + "Address:- " + dr.Field<string>("Address")
                    + "\n" + "City:- " + dr.Field<string>("City")
                    + "\n" + "State:- " + dr.Field<string>("State")
                    + "\n" + "zip:- " + dr.Field<string>("Zip")
                    + "\n" + "phoneNumber:- " + dr.Field<string>("phoneNumber")
                    + "\n" + "eMail:- " + dr.Field<string>("Email")
                    );
            }
        }
        /// <summary>
        /// UC 7 
        /// Count contact by  city
        /// </summary>
        /// <param name="city">The city.</param>
        public void CountByCity(Person person1)
        {
            var contact = from person in table.AsEnumerable()
                          where person.Field<string>("City") == person1.City
                          select person;
            Console.WriteLine("Count of contacts in City :{0} is {1}", person1.City, contact.Count());
        }
        /// <summary>
        /// Count contact by state 
        /// </summary>
        /// <param name="city">The state.</param>
        public void CountByState(Person person1)
        {
            var contact = from person in table.AsEnumerable()
                          where person.Field<string>("State") == person1.State
                          select person;
            Console.WriteLine("Count of contacts in State :{0} is {1}", person1.State, contact.Count());
        }
        /// UC 8
        /// <summary>
        /// Gets all contacts in sorted order by persons name for a given city 
        /// </summary>
        /// <param name="city">The city.</param>
        public void GetAllContactsInSortedOrderInCityOrderByName(Person person)
        {
            var contact = from contacts in table.AsEnumerable()
                          where contacts.Field<string>("City") == person.City
                          orderby contacts.Field<string>("FirstName")
                          select contacts;
            foreach (DataRow dr in contact)
            {
                Console.WriteLine("\n" + "FirstName:- " + dr.Field<string>("FirstName")
                    + "\n" + "lastName:- " + dr.Field<string>("LastName")
                    + "\n" + "Address:- " + dr.Field<string>("Address")
                    + "\n" + "City:- " + dr.Field<string>("City")
                    + "\n" + "State:- " + dr.Field<string>("State")
                    + "\n" + "zip:- " + dr.Field<string>("Zip")
                    + "\n" + "phoneNumber:- " + dr.Field<string>("phoneNumber")
                    + "\n" + "eMail:- " + dr.Field<string>("Email")
                    );
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
        /// UC 10
        /// <summary>
        /// Get Count by ContactType
        /// </summary>
        /// <param name="type"></param>
        public void GetCountByType()
        {
            var element = from contact in table.AsEnumerable()
                          group contact by contact.Field<string>("ContactType") into data
                          select new { typename = data.Key, Count = data.Count() };

            element.ToList().ForEach(element => Console.WriteLine($"ContactType : {element.typename} \t Count = {element.Count}"));
        }
        /// <summary>
        /// Sort the contacts according to first name
        /// </summary>
        public void SortByName()
        {
            var element = from p in table.AsEnumerable()
                          orderby p.Field<string>("FirstName")
                          select p;
            foreach (DataRow dr in element)
            {
                Console.WriteLine("\n" + "FirstName:- " + dr.Field<string>("FirstName")
                    + "\n" + "lastName:- " + dr.Field<string>("LastName")
                    + "\n" + "Address:- " + dr.Field<string>("Address")
                    + "\n" + "City:- " + dr.Field<string>("City")
                    + "\n" + "State:- " + dr.Field<string>("State")
                    + "\n" + "zip:- " + dr.Field<string>("Zip")
                    + "\n" + "phoneNumber:- " + dr.Field<string>("phoneNumber")
                    + "\n" + "eMail:- " + dr.Field<string>("Email")
                    );
            }
        }
    }
}
