using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ConvertButton_Click(object sender, EventArgs e)
    {
        //kontroll så sidan validerar
        if (IsValid)
        {
            TempTable.Visible = true;       //flytta ner så den syns efter att tabellen fyllts på

            //gör så att inmatat data går att bearbeta
            int startTemp = int.Parse(StartTempTextBox.Text);

            int stopTemp = int.Parse(StopTempTextBox.Text);

            int tempStep = int.Parse(StepTextBox.Text);

            int rows = (stopTemp-startTemp)/tempStep +1;

            //vid val av C till F
            if (CRadioButton.Checked == true)
            {
                //skapa en Celsius-array
                int[] CArray = new int [rows];

                for (int i= 0; i < CArray.Length; i++) 
                {
                    CArray[i] = startTemp + (tempStep * i);
                }

                //skapa en Fahrenheit-array
                int[] FArray = new int[rows];

                for (int i = 0; i < FArray.Length; i++)
                {
                    for (int j = 0; j < CArray.Length; j++)
                    {
                        FArray[i] = TemperatureConverter.CelsiusToFahrenheit(j);
                    }
                }

                Col1.Text = "°C";
                Col2.Text = "°F";

                GenerateTable(rows, 2, tempStep, CArray);
            }

            //Vid val av F till C
            if (FRadioButton.Checked == true)
            {
                Col1.Text = "°F";
                Col2.Text = "°C";

                //GenerateTable(rows, 2, tempStep);
            }
        }
    }

    protected void GenerateTable(int rows, int cols, int steps, int[] temps)
    {
        //TempTable
        for (int i = 0; i < rows; i++)
        {
            //skapa rader
            TableRow tRow = new TableRow();
            TempTable.Rows.Add(tRow);

            for (int j = 0; j < cols; j++)
            {
                //skapa celler
                TableCell tCell = new TableCell();                
                tRow.Cells.Add(tCell);

                //temperaturerna sätts in (stega igenom arreyerna)
                for (int t = 0; t < temps.Length; t++)
                {
                    tCell.Text = "hm " + temps[2];
                }
                
            }
        }


        //for (int i = 0; i < rows; i++)
        //{
        //    //TableRow myRow = new TableRow();
        //    TableCell[] arrayOfTableRowCells =
        //        new TableCell[cols];
        //    TableRow tRow = new TableRow();
            

        //    for (int j = 0; j < cols; j++)
        //    {
        //        TableCell tCell = new TableCell();     //bort??
        //        tCell.Text = String.Format("jasså");
        //        arrayOfTableRowCells[j] = tCell;

                
                
        //        //myCell. få in beräkningar här???
        //        //myRow.Cells.Add(myCell);        //bort???
        //        //myRow.Cells.AddRange();

        //       // myCell.Controls.Add(new LiteralControl();
        //    }
        //    TableCellCollection myTableCellCol = tRow.Cells;
        //    myTableCellCol.AddRange(arrayOfTableRowCells);
        //    TempTable.Rows.Add(tRow);
        //}
        
    }
}