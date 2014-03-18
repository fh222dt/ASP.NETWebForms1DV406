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

        //TODO fixa visningen

        //protected void Page_Load(object sender, EventArgs e)
        //{            
        //    IEnumerable<Decoritem> allItems = Service.GetDecorItems();
                        
        //    TableRow tRowHead = new TableRow();
        //    Table1.Rows.Add(tRowHead);

        //    TableHeaderCell tHead1 = new TableHeaderCell();
        //    tRowHead.Cells.Add(tHead1);
        //    tHead1.Text = "Inredningsföremål";

        //    TableHeaderCell tHead2 = new TableHeaderCell();
        //    tRowHead.Cells.Add(tHead2);
        //    tHead2.Text = "Inredningsyta";

        //    TableHeaderCell tHead3 = new TableHeaderCell();
        //    tRowHead.Cells.Add(tHead3);
        //    tHead3.Text = "Rum";

        //    //antal föremål per yta
        //    var itemsInArea = 4;
        //    //antal ytor per rum
        //    var areasInRoom = 2;
        //    //antal rum
        //    var rooms = 1;

        //    var totalRows = allItems.Count() -1;
        //    for (int rows = 0; rows <totalRows; rows++)         //för varje rad
        //    {
        //        // Create a new row and add it to the table.
        //        TableRow tRow = new TableRow();
        //        Table1.Rows.Add(tRow);

        //        var item = allItems.ElementAt(rows);
        //        //var lastItem = allItems.ElementAt(rows-1);

        //        //var arInRoom = allItems.Where(x => x.roomName == item.roomName);

        //        TableCell tCell = new TableCell();
        //        tRow.Cells.Add(tCell);
        //        tCell.Text = item.decorItemName;

        //        for (int cells = 0; cells < 9; cells++)     //9 inredningsytor
        //        {
        //            //TableCell tCell = new TableCell();
        //            tRow.Cells.Add(tCell);
        //            tCell.Text = item.decorAreaName;
        //        }
                    
        //    }
        //}

        public IEnumerable<Decoritem> SummaryListView_GetData()
        {            
            return Service.GetDecorItems();
        }
    }
}