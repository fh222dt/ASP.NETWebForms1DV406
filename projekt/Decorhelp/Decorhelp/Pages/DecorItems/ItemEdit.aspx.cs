using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decorhelp.Model;
using System.Web.ModelBinding;

namespace Decorhelp.Pages.DecorItems
{
    public partial class ItemEdit : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList dropdown = (DropDownList)ItemEditFormView.FindControl("AreaDropDownList");
                //var dropdownstring = dropdown.SelectedItem.ToString();



                var areas = Service.GetDecorAreas();

                dropdown.DataSource = areas;
                dropdown.DataTextField = "decorAreaName";
                dropdown.DataValueField = "decorAreaID";
                dropdown.DataBind();
                dropdown.Items.Insert(0, new ListItem("Välj yta", "-1"));
                //TODO: visa inte dummyytan
            }

        }
                
        public Decorhelp.Model.Decoritem ItemEditFormView_GetItem([RouteData]int id)
        {
            try
            {
                DropDownList dropdown = (DropDownList)ItemEditFormView.FindControl("AreaDropDownList");
                var item = Service.GetDecorItem(id);
                //dropdown.SelectedValue = item.decorAreaID.ToString();
                return item;
                
            }
            catch (Exception)
            {
                throw; //ModelState.AddModelError(String.Empty, "Det blev fel när vi skulle hämta informationen");
                //return null;
            }
        }

        public void ItemEditFormView_UpdateItem([RouteData]int id)
        {
            //TODO: hantera att description kan vara tomt
            try
            {
                var item = Service.GetDecorItem(id);
                if (item == null)
                {
                    // Hittar inte i db
                    ModelState.AddModelError(String.Empty,
                        String.Format("Föremålet hittades inte."));
                    return;
                }

                if (TryUpdateModel(item))
                {
                    //TODO: hämta areaid
                    DropDownList dropdown = (DropDownList)ItemEditFormView.FindControl("AreaDropDownList");
                    var area = dropdown.SelectedItem.Value; // dropdown.SelectedValue;
                    int areaid = Convert.ToInt32(area);

                    //item.decorAreaID = areaid;
                    Service.SaveDecorItem(item);
                    
                    //dirigera om användaren
                    //TODO: lägg till rättmeddelande
                    Response.RedirectToRoute("DecorItemDetails", new { id = item.decorItemID });
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception)
            {
                throw; //ModelState.AddModelError(String.Empty, "Det blev fel när vi skulle uppdatera informationen");
                //return null;
            }
        }

        //protected void AreaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //vilken yta som är vald
        //    DropDownList dropdown = (DropDownList)ItemEditFormView.FindControl("AreaDropDownList");
        //    var area = dropdown.DataValueField;
        //    int areaid = Convert.ToInt32(area);
        //}
    }
}