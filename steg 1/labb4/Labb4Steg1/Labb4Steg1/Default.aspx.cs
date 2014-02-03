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
        private SecretNumber Sn
        {
            get { return Session["secret"] as SecretNumber; }
            set { Session["secret"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {   //sätt fokus på textboxen
            GuessNumberTextBox.Focus();

            //endast vid första besöket av sidan skapas ett nytt objekt
            if (!IsPostBack)
            {
                Sn = new SecretNumber();
            }
        }

        protected void GuessButton_Click(object sender, EventArgs e)
        {   //gör något endast om sidan är validerad
            if (IsValid)
            {
                

                //gör så att inmatat data går att bearbeta
                int guess = int.Parse(GuessNumberTextBox.Text);                

                var answer = Sn.MakeGuess(guess);
                var userHelp = "";

                if (Sn.CanMakeGuess)
                {

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
                }

                else
                {
                    if (answer == Outcome.Correct)
                    {
                        userHelp = "Du gissade rätt! Du klarade det på " + Sn.Count + " försök";
                    }

                    if (answer == Outcome.NoMoreGuesses)
                    {
                        userHelp = "Du har inga gissningar kvar. Det hemliga talet var " + Sn.Number;
                    }

                    //visa knapp för ny gissning & sätt fokus
                    NewGuessPlaceHolder.Visible = true;
                    NewGuessButton.Focus();
                    
                    //disable textfält & gissa-knapp
                    GuessNumberTextBox.Enabled = false;
                    GuessButton.Enabled = false;
                }

                //gör resultatet synligt
                ResultPlaceHolder.Visible = true;
                
                var pg = "";
                foreach (int i in Sn.PreviousGuesses)
                {
                    pg += i.ToString()+", ";
                }
                
                //visa gissade tal & hjälptext
                ResultLabel.Text = String.Format(ResultLabel.Text, pg, userHelp);
                
            }
        }

        protected void NewGuessButton_Click(object sender, EventArgs e)
        {
            Sn.Initialize();
        }
    }
}