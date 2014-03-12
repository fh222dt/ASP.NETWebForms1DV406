using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Decorhelp.Model;

namespace Decorhelp.Pages
{
    public partial class listall : System.Web.UI.Page
    {
        //kan man lägga detta i masterpage code behind???
        private Service _service;

        private Service Service
        {            
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Decoritem> SummaryListView_GetData()
        {
            return Service.GetDecorItems();
        }
    }
}