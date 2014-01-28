using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Labb4Steg1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GuessButton_Click(object sender, EventArgs e)
        {   //gör något endast om sidan är validerad
            if (IsValid)
            {
                //gör resultatet synligt
                ResultPlaceHolder.Visible = true;

                //visa gissade tal 
                NumberResultLabel.Text = String.Format(NumberResultLabel.Text, "99");
                //visa feedback
                ResultatLabel.Text = String.Format(ResultatLabel.Text, "x");
            }
        }
    }
}