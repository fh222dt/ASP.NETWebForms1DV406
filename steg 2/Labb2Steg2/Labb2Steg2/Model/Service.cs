using Labb2Steg2.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Labb2Steg2.Model
{
    public class Service
    {
        //fält
        private ContactDAL _contactDAL;

        //egenskaper
        private ContactDAL ContactDAL 
        { 
            get {return _contactDAL ?? (_contactDAL = new ContactDAL()); } 
        }

        //Metoder

        //public void DeleteContact(Contact contact)
        //{
        //    ContactDAL.DeleteContact(contact);
        //}

        public void DeleteContact(int contactId)
        {
            ContactDAL.DeleteContact(contactId);
        }

        public Contact GetContact(int contactId)
        {
            return ContactDAL.GetContactById(contactId);
        }

        public IEnumerable<Contact> GetContacts()
        {
            return ContactDAL.GetContacts();
        }

        //TODO:
        public IEnumerable<Contact> GetContactsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            throw  new NotImplementedException();
        }
        
        //måste valideras!
        public void SaveContact(Contact contact)
        {
            if (contact.ContactId == 0) // Ny post om contactID är 0
            {
                ContactDAL.InsertContact(contact);
            }
            else
            {
                ContactDAL.UpdateContact(contact);
            }
        }

    }
}