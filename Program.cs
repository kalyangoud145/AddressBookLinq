using System;

namespace AddressBookLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Management management = new Management();
            management.UpdateContact("anirudh", "repala", "Address", "uppal");
            management.DeleteContact("Ravi", "Kumar");
            management.GetAllContacts();
            management.RetrieveByCity("Banglore");
            management.RetrieveByState("ts");
            management.CountByCity("nlg");
            management.CountByState("ts");
            management.GetAllContactsInSortedOrderInCityOrderByName("nlg");

        }
    }
}
