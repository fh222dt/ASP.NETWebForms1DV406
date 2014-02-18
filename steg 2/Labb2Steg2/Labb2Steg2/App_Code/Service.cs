using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labb2Steg2.App_Code
{
    public class Service
    {
        //fält
        private ContactDAL _contactDAL;

        //egenskaper osäker på private????????????????
        private ContactDAL ContactDAL { get; }

        //Metoder
        public void DeleteContact(Contact contact)
        {
        }

        public void DeleteContact(int contactId)
        {
        }

        public Contact GetContact(int contactId)
        {
            return Contact;
        }

        public IEnumerable<Contact> GetContacts()
        {
            return Contact;
        }

        public IEnumerable<Contact> GetContactsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            return Contact;
        }

        public void SaveContact(Contact contact)
        {
        }

    }
}