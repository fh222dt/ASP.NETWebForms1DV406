using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decorhelp.Model;
using System.Web.UI.HtmlControls;

namespace Decorhelp.Pages
{
    public partial class listall : System.Web.UI.Page
    {
        
        private Service _service;

        private Service Service
        {            
            get { return _service ?? (_service = new Service()); }
        }        

        public IEnumerable<Decoritem> SummaryListView_GetData()
        {
            try
            {
                return Service.GetDecorItems();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Det blev fel när vi skulle hämta informationen");
                return null;
            }
        }
    }
}