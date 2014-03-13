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
        //kan man lägga detta i masterpage code behind???
        private Service _service;

        private Service Service
        {            
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ////antal föremål per yta
            //var itemsInArea = 5;
            ////antal ytor per rum
            //var areasInRoom = 3;
            ////antal rum
            //var rooms = 4;

            //IEnumerable<Decoritem> allItems = Service.GetDecorItems();

            //// Total number of rows.
            //int rows;
            //// Current row count.
            //int rowCtr = 1;
            //// Total number of cells per row (columns).
            //int cells;
            //// Current cell counter.
            //int cellCnt;

            ////    <tr>
            ////        <td rowspan="4">Köket</td>
            ////        <td rowspan="4">Skänken</td>
            ////        <td>Skål</td>

            ////        <tr><td>Blomma</td></tr>
            ////        <tr><td>tavla</td></tr>
            ////        <tr><td>duk</td></tr>
            ////    </tr>

            //for (rows = 1; rows <= rooms*itemsInArea; rows++)
            //{
            //    // Create a new row and add it to the table.
            //    TableRow tRow = new TableRow();
            //    Table1.Rows.Add(tRow);

                

            //    for (cells = 1; cells <= itemsInArea; cells++)
            //    {
            //        // Create a new cell and add it to the row.
            //        TableCell tCell = new TableCell();
            //        tRow.Cells.Add(tCell);
            //        //tCell.RowSpan = areasInRoom;
            //        tCell.Text = "rumsnamn";

            //        // Create a new cell and add it to the row.
            //        TableCell tCell2 = new TableCell();
            //        tRow.Cells.Add(tCell2);
            //        //tCell2.RowSpan = itemsInArea;
            //        tCell2.Text = "ytans namn";

            //        if (rows >= 3)
            //        {
            //            // Create a new row and add it to the table.
            //            TableRow tRow2 = new TableRow();
            //            Table1.Rows.Add(tRow2);

            //            // Create a new cell and add it to the row.
            //            TableCell tCell5 = new TableCell();
            //            tRow2.Cells.Add(tCell);
            //            //tCell5.RowSpan = areasInRoom;
            //            tCell5.Text = "föremål m egen rad";
            //        }

            //        else
            //        {
            //            // Create a new cell and add it to the row.
            //            TableCell tCell3 = new TableCell();
            //            tRow.Cells.Add(tCell3);
            //            //tCell3.RowSpan = areasInRoom;
            //            tCell3.Text = "föremål";
            //        }
                    

            //        // Add a literal text as control.
            //        //tCell.Controls.Add(new LiteralControl("Buy: "));

            //        // Create a Hyperlink Web server control and add it to the cell.
            //        //System.Web.UI.WebControls.HyperLink h = new HyperLink();
            //        //h.Text = "rumsnamn";
            //        //h.NavigateUrl = "http://www.microsoft.com/net";
            //        //tCell3.Controls.Add(h);
            //    }
            //}

        }

        public IEnumerable<Decoritem> SummaryListView_GetData()
        {
            //TODO: visa inte dummy
            return Service.GetDecorItems();
        }
    }
}