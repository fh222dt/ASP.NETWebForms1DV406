using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decorhelp.Model;

namespace Decorhelp.Pages.DecorItems
{
    public partial class ItemDelete : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DeleteLinkButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var id = int.Parse(e.CommandArgument.ToString());
                Service.DeleteDecorItem(id);

                //dirigera om användaren
                //TODO: lägg till rättmeddelande
                Response.RedirectToRoute("DecorAreas");
                Context.ApplicationInstance.CompleteRequest();

            }
            catch (Exception)
            {
                throw; // ModelState.AddModelError(String.Empty, "Det blev fel när vi skulle ta bort informationen");
            }
        }
    }
}