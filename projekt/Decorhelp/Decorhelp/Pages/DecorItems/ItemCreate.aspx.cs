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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ItemCreateFormView_InsertItem(Decoritem item)
        {   //TODO: går ej att testa ännu
            //TODO: tillhör yta dropdownen ska hämta fr db
            //TODO: hantera att description kan vara tomt
            if (ModelState.IsValid)
            {
                try
                {
                    Service service = new Service();

                    //detta behövs kanske inte?
                    DropDownList dropdown = (DropDownList)ItemCreateFormView.FindControl("AreaDropDownList");
                    var dropdownstring = dropdown.SelectedItem.ToString();

                    switch (dropdownstring)
                    {
                        case "Köket":
                            item.decorAreaID = 2;
                            break;
                        case "Vardagsrummet":
                            item.decorAreaID = 3;
                            break;
                        case "Sovrummet":
                            item.decorAreaID = 4;
                            break;
                        case "Gästrummet":
                            item.decorAreaID = 5;
                            break;
                        case "Hallen":
                            item.decorAreaID = 6;
                            break;
                        case "Badrummet":
                            item.decorAreaID = 7;
                            break;
                        case "Uterummet":
                            item.decorAreaID = 8;
                            break;
                    }

                    service.SaveDecorItem(item);

                    //dirigera om användaren
                    //TODO: lägg till rättmeddelande
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