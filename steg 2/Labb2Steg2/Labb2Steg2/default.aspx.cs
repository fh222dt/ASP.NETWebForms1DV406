using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Labb2Steg2.Model;

namespace Labb2Steg2
{
    public partial class _default : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            //Lazy initialization av objekt
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Contact> ContactListView_GetData()
        {
            return Service.GetContacts();
        }

        public void ContactListView_InsertItem(Contact contact)
        {
            try
            {
                Service.SaveContact(contact);
            }
            catch (Exception)
            {
                throw;//ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kontaktuppgiften skulle läggas till.");
            }
        }

        public void ContactListView_UpdateItem(int contactId)
        {
            try
            {
                var contact = Service.GetContact(contactId);
                if (contact == null)
                {
                    ModelState.AddModelError(String.Empty, String.Format("Kontakten med id {0} hittades inte.", contactId));
                    return;
                }

                if (TryUpdateModel(contact))
                {
                    Service.SaveContact(contact);
                }
            }

            catch(Exception)
            {
                throw;// ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kontaktuppgiften skulle uppdateras.");
            }
        }

        public void ContactListView_DeleteItem(int contactId)
        {
            try
            {
                Service.DeleteContact(contactId);
            }

            catch (Exception)
            {
                throw;//ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kontaktuppgiften skulle tas bort.");
            }
        }
    }
}