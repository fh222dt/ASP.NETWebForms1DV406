using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decorhelp.Model;

namespace Decorhelp.Pages.DecorAreas
{
    public partial class DecorAreaCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void AreaCreateFormView_InsertItem(Decorarea area)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service service = new Service();
                    
                    DropDownList dropdown = (DropDownList)AreaCreateFormView.FindControl("RoomDropDownList");
                    area.roomID = Convert.ToInt32(dropdown.SelectedValue);

                    service.SaveDecorArea(area);

                    //dirigera om användaren
                    //TODO: lägg till rättmeddelande
                    
                    Response.RedirectToRoute("DecorAreaDetails", new { id = area.decorAreaID });
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