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
                if (string.IsNullOrEmpty(decoritem.decorItemDescription))
                {
                    decoritem.decorItemDescription = "Ingen kommentar";
                }

                return decoritem;


            }
            catch (Exception)
            {
                throw; //ModelState.AddModelError(String.Empty, "Det blev fel när vi skulle hämta informationen");
                //return null;
            }
        }
    }
}