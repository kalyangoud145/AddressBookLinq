using System;

namespace AddressBookLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            Management management = new Management();
            person.FirstName = "Ravi";
            person.LastName = "kumar";
            management.UpdateContact(person, "Address", "kachiguda");
            management.DeleteContact(person);
            management.GetAllContacts();
            person.City = "nlg";
            management.RetrieveByCity(person);
            person.State = "ts";
            management.RetrieveByState(person);
            management.CountByCity(person);
            management.CountByState(person);
            management.GetAllContactsInSortedOrderInCityOrderByName(person);
            management.AddAddressBookNameTypeColumn();
            management.GetCountByType();

        }
    }
}
