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

        }
                
        public Decorhelp.Model.Decoritem ItemEditFormView_GetItem([RouteData]int id)
        {
            try
            {

                var decoritem = Service.GetDecorItem(id);
                //if (string.IsNullOrEmpty(decorarea.decorAreaDescription))
                //{
                //    decorarea.decorAreaDescription = "Ingen kommentar";
                //}

                return decoritem;


            }
            catch (Exception)
            {
                throw; //ModelState.AddModelError(String.Empty, "Det blev fel när vi skulle hämta informationen");
                //return null;
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ItemEditFormView_UpdateItem([RouteData]int id)
        {
            //TODO: rumsid funkar ej!
            //TODO: hantera att description kan vara tomt
            try
            {
                var item = Service.GetDecorItem(id);
                if (item == null)
                {
                    // Hittar inte i db
                    ModelState.AddModelError(String.Empty,
                        String.Format("Föremålet hittades inte."));
                    return;
                }

                if (TryUpdateModel(item))
                {
                    //TODO: samma problem som i create
                    DropDownList dropdown = (DropDownList)ItemEditFormView.FindControl("AreaDropDownList");                    
                    var dropdownstring = dropdown.SelectedItem.ToString();

                   //switch (dropdownstring)
                   // {
                   //     case "Köket":
                   //         item.roomID = 2;
                   //         break;
                   //     case "Vardagsrummet":
                   //         item.roomID = 3;
                   //         break;
                   //     case "Sovrummet":
                   //         item.roomID = 4;
                   //         break;
                   //     case "Gästrummet":
                   //         item.roomID = 5;
                   //         break;
                   //     case "Hallen":
                   //         item.roomID = 6;
                   //         break;
                   //     case "Badrummet":
                   //         item.roomID = 7;
                   //         break;
                   //     case "Uterummet":
                   //         item.roomID = 8;
                   //         break;
                   // } 

                    Service.SaveDecorItem(item);
                    
                    //dirigera om användaren
                    //TODO: lägg till rättmeddelande
                    Response.RedirectToRoute("DecorItemDetails", new { id = item.decorItemID });
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