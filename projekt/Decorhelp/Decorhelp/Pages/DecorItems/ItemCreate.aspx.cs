using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decorhelp.Model;

namespace Decorhelp.Pages.DecorItems
{
    public partial class ItemCreate : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //tar bort så man inte kan välja dummyyta
            DropDownList dropdown = (DropDownList)ItemCreateFormView.FindControl("AreaDropDownList");
            dropdown.Items.Remove(dropdown.Items.FindByValue("2"));
        }

        public IEnumerable<Decorarea> AreaDropDownList_GetData()
        {
            var areas = Service.GetDecorAreas();
            return areas;
        }

        public void ItemCreateFormView_InsertItem(Decoritem item)
        {   
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveDecorItem(item);

                    //dirigera om användaren  & visa rättmeddelande
                    Session["createItem"] = true;

                    Response.RedirectToRoute("DecorItemDetails", new { id = item.decorItemID });
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    throw; //ModelState.AddModelError(String.Empty, "Det blev fel när vi skulle uppdatera informationen");
                    //return null;
                }
            }
        }
    }
}