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
            //TODO: rumsid funkar ej!
            //TODO: hantera att description kan vara tomt
            if (ModelState.IsValid)
            {
                try
                {
                    Service service = new Service();
                    
                    //rummets namn till roomid
                    DropDownList dropdown = (DropDownList)AreaCreateFormView.FindControl("RoomDropDownList");
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