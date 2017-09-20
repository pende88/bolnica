using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;


namespace BolnicaClient
{
    public partial class _default : System.Web.UI.Page
    {

        
    
      
        BolnicaService.IService1 proxy = new BolnicaService.Service1Client();//dodaj try catch

    

        
    

        protected void Page_Load(object sender, EventArgs e)
        {
            lblstatus.Text = Convert.ToString(this.Session["TrenutniKorisnik"]);

        }
    }
}