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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Send_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var sec = new SecretNumber();
                int input = int.Parse(Input.Text);
                

                sec.MakeGuess(input);
                
            }
        }
    }
}