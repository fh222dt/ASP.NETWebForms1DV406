using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Decorhelp.Pages.Shared
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: lägga in navbar funktionalitet

            //visa rättmeddelande
            if (Session["createArea"] as bool? == true) 
            {
                SuccessPlaceHolder.Visible = true;
                SuccessLiteral.Text = "Ny inredningsyta är sparad";
                Session.Remove("createArea");
            }

            if (Session["editArea"] as bool? == true)
            {
                SuccessPlaceHolder.Visible = true;
                SuccessLiteral.Text = "Inredningsytan är uppdaterad";
                Session.Remove("editArea");
            }

            if (Session["deleteArea"] as bool? == true)
            {
                SuccessPlaceHolder.Visible = true;
                SuccessLiteral.Text = "Inredningsytan är borttagen";
                Session.Remove("deleteArea");
            }

            if (Session["createItem"] as bool? == true)
            {
                SuccessPlaceHolder.Visible = true;
                SuccessLiteral.Text = "Nytt inredningsföremål är sparat";
                Session.Remove("createItem");
            }

            if (Session["editItem"] as bool? == true)
            {
                SuccessPlaceHolder.Visible = true;
                SuccessLiteral.Text = "Inredningsföremålet är uppdaterat";
                Session.Remove("editItem");
            }

            if (Session["deleteItem"] as bool? == true)
            {
                SuccessPlaceHolder.Visible = true;
                SuccessLiteral.Text = "Inredningsföremålet är borttaget";
                Session.Remove("deleteItem");
            }

            
        }
    }
}