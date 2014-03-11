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

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Decorhelp.Model.Decorarea AreaDetailsFormView_GetItem([RouteData] int id)
        {
            try
            {
                Service service = new Service();
                var decorarea = service.GetDecorArea(id);
                if (string.IsNullOrEmpty(decorarea.decorAreaDescription)) 
                {
                    decorarea.decorAreaDescription = "Ingen kommentar";
                }

                return decorarea;

                
            }
            catch (Exception)
            {
                throw; //ModelState.AddModelError(String.Empty, "Det blev fel när vi skulle hämta informationen");
                //return null;
            }
        }
    }
}