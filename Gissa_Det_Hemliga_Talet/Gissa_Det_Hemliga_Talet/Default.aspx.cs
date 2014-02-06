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
        public SecretNumber secretNumber { 
            get {

            if (Session["secretNumber"] == null)
            {
                Session["secretNumber"] = new SecretNumber();   
            }
            return Session["secretNumber"] as SecretNumber; } 
            
            set { Session["secretNumber"] = value; } 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Input.Focus();
        }

        protected void Send_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                int input = int.Parse(Input.Text);
                PlaceHolder1.Visible = true;
              
                
                switch (secretNumber.MakeGuess(input))
                {
                    case Outcome.Indefinite:
                        break;
                    case Outcome.Low:
                        Label2.Text = "   Gissningen var för låg!";
                        break;
                    case Outcome.High:
                        Label2.Text = "   Gissningen var för Hög!";
                        break;
                    case Outcome.Correct:
                        Label2.Text = "   Gissningen var rätt :)!";
                        Send.Enabled = false;
                        Input.Enabled = false;
                        ButtonHolder.Visible = true;
                        //Session.Clear();
                        break;
                    case Outcome.NoMoreGuesses:
                        Send.Enabled = false;
                        Input.Enabled = false;
                        ButtonHolder.Visible = true;
                        Label2.Text = String.Format("Slut på gissningar! Talet var {0}", secretNumber.Number);
                        //Session.Clear();
                        break;
                    case Outcome.PreveiousGuess:
                        Label2.Text = "   Dummer, du har redan gissat på det här talet";
                        break;
                    default:
                        break;
                }
                Label3.Text = String.Join(", ", secretNumber.PreviousGuesses);
            }
        }
        protected void NewNumber_Click(object sender, EventArgs e)
        {
            secretNumber.Initialize();
        }
    }
}