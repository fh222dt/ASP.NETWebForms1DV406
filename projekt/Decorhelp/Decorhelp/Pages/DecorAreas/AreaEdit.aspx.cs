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
        //kan man lägga detta i masterpage code behind???
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
                
                var decorarea = Service.GetDecorArea(id);
                //if (string.IsNullOrEmpty(decorarea.decorAreaDescription))
                //{
                //    decorarea.decorAreaDescription = "Ingen kommentar";
                //}

                return decorarea;


            }
            catch (Exception)
            {
                throw; //ModelState.AddModelError(String.Empty, "Det blev fel när vi skulle hämta informationen");
                //return null;
            }
        }

        public void AreaEditFormView_UpdateItem([RouteData]int id)
        {

            //TODO: rumsid funkar ej!
            try
            {
                var area = Service.GetDecorArea(id);
                if (area == null)
                {
                    // Hittar inte i db
                    ModelState.AddModelError(String.Empty,
                        String.Format("Inredningsytan hittades inte."));
                    return;
                }

                if (TryUpdateModel(area))
                {
                    //rummets namn till roomid
                    DropDownList dropdown = (DropDownList)AreaEditFormView.FindControl("RoomDropDownList");                    
                    var dropdownstring = dropdown.SelectedItem.ToString();

                   switch (dropdownstring)
                    {
                        case "Köket":
                            area.roomID = 2;
                            break;
                        case "Vardagsrummet":
                            area.roomID = 3;
                            break;
                        case "Sovrummet":
                            area.roomID = 4;
                            break;
                        case "Gästrummet":
                            area.roomID = 5;
                            break;
                        case "Hallen":
                            area.roomID = 6;
                            break;
                        case "Badrummet":
                            area.roomID = 7;
                            break;
                        case "Uterummet":
                            area.roomID = 8;
                            break;
                    } 

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