using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decorhelp.Model;
using System.Web.ModelBinding;

namespace Decorhelp.Pages.DecorAreas
{
    public partial class AreaEdit : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        public Decorarea AreaEditFormView_GetItem([RouteData]int id)
        {
            try
            {
                var area = Service.GetDecorArea(id);               

                //spara undan rumsid för att kunna visa rummets namn (endast rumsid fås fr db)
                Session["roomID"] = area.roomID;

                return area;
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Det blev fel när vi skulle hämta informationen");
                return null;
            }
        }

        public void AreaEditFormView_UpdateItem([RouteData]int id)
        {
            try
            {
                var area = Service.GetDecorArea(id);                

                if (area == null)
                {
                    // om man inte hittar i db
                    ModelState.AddModelError(String.Empty, String.Format("Inredningsytan hittades inte."));
                    return;
                }

                if (TryUpdateModel(area))
                {   
                    //hämtar ut valt rumsid fr dropdown
                    DropDownList dropdown = (DropDownList)AreaEditFormView.FindControl("RoomDropDownList");
                    area.roomID = Convert.ToInt32(dropdown.SelectedValue);
                    
                    Service.SaveDecorArea(area);
                    
                    //dirigera om användaren & visa rättmeddelande                    
                    Session["editArea"] = true;

                    Response.RedirectToRoute("DecorAreaDetails", new { id = area.decorAreaID });
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Det blev fel när vi skulle uppdatera informationen");
            }
        }

        protected void AreaEditFormView_PreRender(object sender, EventArgs e)
        {
            //hämtar sparat rumsid fr sessionen
            int roomID = (int)Session["roomID"];

            //sätter valt rum utifrån rumsid i dropdown så det stämmer överrens med tidigare sparade uppgifter 
            DropDownList dropdown = (DropDownList)AreaEditFormView.FindControl("RoomDropDownList");
            dropdown.Items.FindByValue(roomID.ToString()).Selected = true;
        }
    }
}