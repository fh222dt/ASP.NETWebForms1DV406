using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decorhelp.Model;
using System.Web.ModelBinding;

namespace Decorhelp.Pages.DecorItems
{
    public partial class ItemEdit : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //tar bort så man inte kan välja dummyyta som kommer med fr db
            DropDownList dropdown = (DropDownList)ItemEditFormView.FindControl("AreaDropDownList");
            dropdown.Items.Remove(dropdown.Items.FindByValue("2"));
        }

        public IEnumerable<Decorarea> AreaDropDownList_GetData()
        {
            return Service.GetDecorAreas();
        }
                
        public Decorhelp.Model.Decoritem ItemEditFormView_GetItem([RouteData]int id)
        {
            try
            {
                return Service.GetDecorItem(id);                
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Det blev fel när vi skulle hämta informationen");
                return null;
            }
        }

        public void ItemEditFormView_UpdateItem([RouteData]int id)
        {
            try
            {
                var item = Service.GetDecorItem(id);
                if (item == null)
                {
                    // om man inte hittar i db
                    ModelState.AddModelError(String.Empty,String.Format("Föremålet hittades inte."));
                    return;
                }

                if (TryUpdateModel(item))
                {                                        
                    Service.SaveDecorItem(item);

                    //dirigera om användaren  & visa rättmeddelande
                    Session["editItem"] = true;

                    Response.RedirectToRoute("DecorItemDetails", new { id = item.decorItemID });
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Det blev fel när vi skulle uppdatera informationen");
            }
        }
    }
}