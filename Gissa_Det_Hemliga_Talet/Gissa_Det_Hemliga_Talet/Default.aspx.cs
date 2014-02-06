using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gissa_Det_Hemliga_Talet.Model;

namespace Gissa_Det_Hemliga_Talet
{
    public partial class Default : System.Web.UI.Page
    {
        public SecretNumber secretNumber { get {
            if (Session["secretNumber"] == null)
            {
                Session["secretNumber"] = new SecretNumber();   
            }
            return Session["secretNumber"] as SecretNumber; } set { Session["secretNumber"] = value; } }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Send_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                int input = int.Parse(Input.Text);
                
                switch (secretNumber.MakeGuess(input))
                {
                    case Outcome.Indefinite:
                        break;
                    case Outcome.Low:
                        Label2.Text = "Gissningen var för låg!";
                        break;
                    case Outcome.High:
                        Label2.Text = "Gissningen var för Hög!";
                        break;
                    case Outcome.Correct:
                        Label2.Text = "Gissningen var rätt :)!";
                        break;
                    case Outcome.NoMoreGuesses:
                        break;
                    case Outcome.PreveiousGuess:
                        break;
                    default:
                        break;
                }
                
            }
        }
    }
}