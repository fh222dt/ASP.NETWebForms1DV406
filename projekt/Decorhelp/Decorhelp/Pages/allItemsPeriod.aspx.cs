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
                        
        }
        //TODO: kanske visa att det inte finns ngn kommentar

        //Returnerar lista med utvalda föremåls-objekt
        private IEnumerable<Decoritem> GetSpecificItems(int period)
        {
            try
            {
                //hämtar alla föremål för vald period
                var allPlaced = Service.GetAllPlaced(period);

                //skapar en lista med periodens decorItemIDs
                var decorItemIDs = new List<int>(100);

                foreach (var item in allPlaced)
                {
                    decorItemIDs.Add(item.decorItemID);
                }

                decorItemIDs.TrimExcess();

                //hämtar alla decoritems och sorterar ut de vi vill ha
                var allItems = Service.GetDecorItems();

                //skapar en lista med alla objekt som hör till perioden
                var specificDecorItems = new List<Decoritem>(100);

                foreach (var item in decorItemIDs)
                {
                    specificDecorItems.Add(allItems.ElementAt(item));
                }

                specificDecorItems.TrimExcess();

                return specificDecorItems;
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Det blev fel när vi skulle hämta informationen");
                return null;
            }
        }

        public IEnumerable<Decoritem> ListView1_GetData()
        {
            try
            {
                //om inget val gjorts visas period 1
                var i = 1;

                //om man valt en period att visa, hämta period fr sessionen
                if (IsPostBack)
                {
                    i = (int)Session["periodID"];
                }

                var placed = GetSpecificItems(i);
                return placed;
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Det blev fel när vi skulle hämta informationen");
                return null;
            }
        }

        protected void PeriodButton_Click(object sender, EventArgs e)
        {
            //hämta vald period
            var period = Convert.ToInt32(PeriodDropDownList.SelectedValue);
            //spara undan för att kunna hämta rätt föremål
            Session["periodID"] = period;
        }

        //fyller på literal med namn för vald period
        protected void ListView1_PreRender(object sender, EventArgs e)
        {
            var periodLiteral = (Literal)ListView1.FindControl("PeriodLiteral");
            
            //om inget val har gjorts
            if (!IsPostBack)
            {
                periodLiteral.Text = String.Format(periodLiteral.Text, "Påsk");
            }

            //om val har gjorts
            else
            {
                periodLiteral.Text = String.Format(periodLiteral.Text, PeriodDropDownList.SelectedItem);
            }
        }
    }
}