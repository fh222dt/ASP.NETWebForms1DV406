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
            if (Session["insert"] as bool? == true)
            {
                InsertPlaceHolder.Visible = true;
                Session.Remove("insert");
            }

            else if (Session["edit"] as bool? == true)
            {
                EditPlaceHolder.Visible = true;
                Session.Remove("edit");
            }
            else if (Session["delete"] as bool? == true)
            {
                DeletePlaceHolder.Visible = true;
                Session.Remove("delete");
            }
        }
                
        public IEnumerable<Contact> ContactListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            try
            {
                return Service.GetContactsPageWise(maximumRows, startRowIndex, out totalRowCount);
            }

            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kontaktuppgiften skulle läggas till.");
                totalRowCount = 0;
                return null;
            }
        }

        public void ContactListView_InsertItem(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveContact(contact);
                    Session["insert"] = true;
                    Response.Redirect("~");

                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kontaktuppgiften skulle läggas till.");
                }
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
                    Session["edit"] = true;
                    Response.Redirect("~");
                }
            }

            catch(Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kontaktuppgiften skulle uppdateras.");
            }
        }

        public void ContactListView_DeleteItem(int contactId)
        {
            try
            {
                Service.DeleteContact(contactId);
                Session["delete"] = true;
                Response.Redirect("~");
            }

            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kontaktuppgiften skulle tas bort.");
            }
        }
                
    }
}