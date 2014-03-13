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
        //TODO: ha rätt rum förvalt i dropdownen
        public Decorarea AreaEditFormView_GetItem([RouteData]int id)
        {
            try
            {
                var area = Service.GetDecorArea(id);
                //DropDownList dropdown = (DropDownList)AreaEditFormView.FindControl("RoomDropDownList");
                //dropdown.SelectedValue = area.roomID.ToString();

                return area;
            }
            catch (Exception)
            {
                throw; //ModelState.AddModelError(String.Empty, "Det blev fel när vi skulle hämta informationen");
                //return null;
            }
        }

        public void AreaEditFormView_UpdateItem([RouteData]int id)
        {
            try
            {
                var area = Service.GetDecorArea(id);                

                if (area == null)
                {
                    // Hittar inte i db
                    ModelState.AddModelError(String.Empty, String.Format("Inredningsytan hittades inte."));
                    return;
                }

                if (TryUpdateModel(area))
                {                    
                    DropDownList dropdown = (DropDownList)AreaEditFormView.FindControl("RoomDropDownList");
                    area.roomID = Convert.ToInt32(dropdown.SelectedValue);
                    
                    Service.SaveDecorArea(area);
                    
                    //dirigera om användaren
                    //TODO: lägg till rättmeddelande
                    Response.RedirectToRoute("DecorAreaDetails", new { id = area.decorAreaID });
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                throw; //ModelState.AddModelError(String.Empty, "Det blev fel när vi skulle uppdatera informationen");
                //return null;
            }
        }
    }
}