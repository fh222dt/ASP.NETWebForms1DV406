using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Labb4Steg1.App_Code;

namespace Labb4Steg1
{
    public partial class Default : System.Web.UI.Page
    {
        //här ska vara privat egenskap m session

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void GuessButton_Click(object sender, EventArgs e)
        {   //gör något endast om sidan är validerad
            if (IsValid)
            {
                //gör så att inmatat data går att bearbeta
                int guess = int.Parse(GuessNumberTextBox.Text);

                SecretNumber SecNo = new SecretNumber();

                var answer = SecNo.MakeGuess(guess);
                var userHelp = "";

                if (answer == Outcome.High)
                {
                    userHelp = "för högt";
                }

                if (answer == Outcome.Low)
                {
                    userHelp = "för lågt";
                }

                if (answer == Outcome.PreviousGuesses)
                {
                    userHelp = "Du har redan gissat på talet";
                }

                if (answer == Outcome.Correct)
                {
                    userHelp = "Du gissade rätt! Du klarade det på " + SecNo.Count;
                }

                //gör resultatet synligt
                ResultPlaceHolder.Visible = true;

                //visa gissade tal 
                NumberResultLabel.Text = String.Format(NumberResultLabel.Text, userHelp);
                //visa feedback
                ResultatLabel.Text = String.Format(ResultatLabel.Text, "x");
            }
        }
    }
}