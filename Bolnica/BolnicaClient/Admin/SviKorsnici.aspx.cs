using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BolnicaClient.Admin
{
    public partial class Doktori : System.Web.UI.Page
    {
        BolnicaService.IService1 proxy;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }

           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {

                try
                {
                    BolnicaService.Korisnik k = new BolnicaService.Korisnik();


                    try
                    {

                       

                        proxy.AddKorisnik(k);
                        lblStatus.Text = "Operacija uspješno spremljena";

                    }catch(Exception ex)
                    {
                        lblStatus.Text = ("Operacija nije izvršena, greška: " + ex);
                    }

                    


                    lblStatus.Text = "Operacija uspješno spremljena";

                    ClearAll();
                }catch(Exception ex)
                {
                    lblStatus.Text = ("Pogreška kod pristupa wfc service-u, greška: " + ex);
                }

                FillGridView();


            }
        }
}