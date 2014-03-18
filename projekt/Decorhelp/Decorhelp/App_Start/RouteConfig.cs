using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Decorhelp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("DecorAreas", "ytor", "~/Pages/listall.aspx");
            routes.MapPageRoute("DecorAreaCreate", "yta/ny", "~/Pages/DecorAreas/AreaCreate.aspx");
            routes.MapPageRoute("DecorAreaDetails", "yta/{id}", "~/Pages/DecorAreas/AreaDetails.aspx");
            routes.MapPageRoute("DecorAreaEdit", "yta/{id}/edit", "~/Pages/DecorAreas/AreaEdit.aspx");
            routes.MapPageRoute("DecorAreaDelete", "yta/{id}/delete", "~/Pages/DecorAreas/AreaDelete.aspx");

            routes.MapPageRoute("DecorItems", "foremal", "~/Pages/DecorItems/allitems.aspx");
            routes.MapPageRoute("DecorItemCreate", "foremal/ny", "~/Pages/DecorItems/ItemCreate.aspx");
            routes.MapPageRoute("DecorItemDetails", "foremal/{id}", "~/Pages/DecorItems/ItemDetails.aspx");
            routes.MapPageRoute("DecorItemEdit", "foremal/{id}/edit", "~/Pages/DecorItems/ItemEdit.aspx");
            routes.MapPageRoute("DecorItemDelete", "foremal/{id}/delete", "~/Pages/DecorItems/ItemDelete.aspx");            

            routes.MapPageRoute("Error", "serverfel", "~/Pages/Shared/errorPage.html");

            routes.MapPageRoute("Default", "", "~/Pages/listall.aspx");

            routes.MapPageRoute("PeriodList", "planeringslista", "~/Pages/allItemsPeriod.aspx");
        }
    }
}

