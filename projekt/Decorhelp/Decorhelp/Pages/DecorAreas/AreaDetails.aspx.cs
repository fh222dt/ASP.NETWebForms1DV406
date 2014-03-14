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
    public partial class AreaDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public Decorhelp.Model.Decorarea AreaDetailsFormView_GetItem([RouteData] int id)
        {
            try
            {
                Service service = new Service();
                var decorarea = service.GetDecorArea(id);
                
                //om det inte finns ngn kommentar om ytan
                if (string.IsNullOrEmpty(decorarea.decorAreaDescription)) 
                {
                    decorarea.decorAreaDescription = "Ingen kommentar";
                }

                //spara undan rumsid för att kunna visa rummets namn (endast id fås fr db)
                Session["roomID"] = decorarea.roomID;

                
                return decorarea;

                
            }
            catch (Exception)
            {
                throw; //ModelState.AddModelError(String.Empty, "Det blev fel när vi skulle hämta informationen");
                //return null;
            }
        }

        protected void AreaDetailsFormView_PreRender(object sender, EventArgs e)
        {
            //rumsnamn ist för rumsid
            var roomLiteral = (Literal)AreaDetailsFormView.FindControl("RoomLiteral");            
            int roomID = (int)Session["roomID"];

            switch (roomID)
            {
                case 2:
                    roomLiteral.Text = "Köket";
                    break;
                case 3:
                    roomLiteral.Text = "Vardagsrummet";
                    break;
                case 4:
                    roomLiteral.Text = "Sovrummet";
                    break;
                case 5:
                    roomLiteral.Text = "Gästrummet";
                    break;
                case 6:
                    roomLiteral.Text = "Hallen";
                    break;
                case 7:
                    roomLiteral.Text = "Badrummet";
                    break;
                case 8:
                    roomLiteral.Text = "Uterummet";
                    break;
            }
        }
    }
}