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
            //gör aktuell sida aktiv i navigeringsmenyn, men det blev en nödlösning

            if (Page.AppRelativeVirtualPath == "~/Pages/listall.aspx")
            {
                navhome.Attributes["class"] = "active";
            }

            else if (Page.AppRelativeVirtualPath == "~/Pages/DecorAreas/AreaCreate.aspx")
            {
                navarea.Attributes["class"] = "active";
            }

            else if (Page.AppRelativeVirtualPath == "~/Pages/DecorItems/ItemCreate.aspx")
            {
                navitem.Attributes["class"] = "active";
            }

            else if (Page.AppRelativeVirtualPath == "~/Pages/allItemsPeriod.aspx")
            {
                navlist.Attributes["class"] = "active";
            }

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