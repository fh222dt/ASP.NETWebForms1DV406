using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decorhelp.Model;

namespace Decorhelp.Pages
{
    public partial class allItemsPeriod : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Literal periodLiteral = (Literal)ListView1.FindControl("PeriodLiteral");
            //periodLiteral.Text = PeriodDropDownList.SelectedItem.ToString;

            

            

            //anropas metod som hämtar utvalda föremål
            //var placedItems = GetSpecificItems(allDecorItems);
            //Session["placed"] = placedItems;
        }

        //Returnerar ny lista med utvalda föremål
        private IEnumerable<Decoritem> GetSpecificItems(int period)
        {
            //hämtar alla föremål för vald period
            var allPlaced = Service.GetAllPlaced(period);

            var allDecorItems = new List<int>(100);

            //skapar en lista med deras decorItemIDs
            foreach (var item in allPlaced)
            {
                allDecorItems.Add(item.decorItemID);
            }

            allDecorItems.TrimExcess();

            var specificDecorItems = new List<Decoritem>(100);

            foreach (var item in allDecorItems)
            {
                specificDecorItems.Add(Service.GetDecorItem(item));
            }

            specificDecorItems.TrimExcess();


            return specificDecorItems;
        }

        //TODO: period blir null varje gång
        public IEnumerable<Decoritem> ListView1_GetData()
        {
            var i = 1;
            if (IsPostBack)
            {
                i = (int)Session["periodID"];
            }

            var placed = GetSpecificItems(i);
            return placed;

            //if (IsPostBack)
            //{
            //    var placed = GetSpecificItems(1);
            //    return placed;
            //}
            //else
            //{
            //    if (period == null)
            //    {

            //        i = 1;
            //    }
            //    else
            //    {
            //        i = Convert.ToInt32(period);
            //    }
            //    var placed = GetSpecificItems(i);
            //    return placed;
            //}
        }

        protected void PeriodButton_Click(object sender, EventArgs e)
        {
            var period = Convert.ToInt32(PeriodDropDownList.SelectedValue);
            Session["periodID"] = period;
        }
    }
}