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
                        FArray[i] = TemperatureConverter.CelsiusToFahrenheit(CArray[i]);
                }

                Col1.Text = "°C";
                Col2.Text = "°F";

                GenerateTable(rows, 2, tempStep, CArray, FArray);
            }

            //Vid val av F till C
            if (FRadioButton.Checked == true)
            {
                //skapa en Fahrenheit-array
                int[] FArray = new int[rows];

                for (int i = 0; i < FArray.Length; i++)
                {
                    FArray[i] = startTemp + (tempStep * i);
                }

                //skapa en Celsius-array
                int[] CArray = new int[rows];

                for (int i = 0; i < CArray.Length; i++)
                {                    
                    CArray[i] = TemperatureConverter.FahrenheitToCelsius(FArray[i]);
                }                

                Col1.Text = "°F";
                Col2.Text = "°C";

                GenerateTable(rows, 2, tempStep, FArray, CArray);
            }
        }
    }

    protected void GenerateTable(int rows, int cols, int steps, int[] right, int[] left)
    {
        //TempTable
        for (int i = 0; i < rows; i++)
        {
            //skapa rad
            TableRow tRow = new TableRow();
            TempTable.Rows.Add(tRow);

            for (int j = 0; j < cols; j++)
            {
                //skapa cell
                TableCell tCell = new TableCell();                
                tRow.Cells.Add(tCell);
                if (j == 0)
                {
                    tCell.Text = "" + right[i];
                }
                if (j == 1)
                {
                    tCell.Text = "" + left[i];
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