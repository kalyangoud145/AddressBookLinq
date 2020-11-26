using System;

namespace AddressBookLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Management management = new Management();
            management.UpdateContact("anirudh", "repala", "Address", "uppal");
            management.GetAllContacts();

        }
    }
}
