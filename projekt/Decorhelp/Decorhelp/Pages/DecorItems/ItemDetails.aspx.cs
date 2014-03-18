using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decorhelp.Model;

namespace Decorhelp.Pages.DecorItems
{
    public partial class ItemDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        public Decorhelp.Model.Decoritem ItemDetailsFormView_GetItem([RouteData] int id)
        {
            try
            {
                Service service = new Service();
                var decoritem = service.GetDecorItem(id);

                //om det inte finns ngn kommentar
                if (string.IsNullOrEmpty(decoritem.decorItemDescription))
                {
                    decoritem.decorItemDescription = "Ingen kommentar";
                }

                //sparar undan objektet för att kunna nyttja areaID
                Session["areaID"] = decoritem;

                return decoritem;


            }
            catch (Exception)
            {
                throw; //ModelState.AddModelError(String.Empty, "Det blev fel när vi skulle hämta informationen");
                //return null;
            }
        }

 
        protected void ContactTypeNameLabel_PreRender(object sender, EventArgs e)
        {
            //hämtar label att placera text i
            var label = (Label)ItemDetailsFormView.FindControl("ContactTypeNameLabel");
            if (label != null)
            {
                //hämtar objektet från sessionen
                Decoritem itemAreaID = (Decoritem)Session["areaID"];

                //hämtar från annan databastabell med alla ytor för att få tag i ytans namn
                Service service = new Service();
                var areaName = service.GetDecorAreas().FirstOrDefault(ar => ar.decorAreaID == itemAreaID.decorAreaID);

                label.Text = String.Format(label.Text, areaName.decorAreaName);
            }
        }
    }
}