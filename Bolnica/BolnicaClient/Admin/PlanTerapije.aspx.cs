using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BolnicaClient.Admin
{
    public partial class PlanTerapije : System.Web.UI.Page
    {

        BolnicaService.IService1 proxy;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FIllDdlDoktor();
                
                btnUpdate.Enabled = false;
                ddlTerapija.Enabled = false;
                ddlDoktor.Enabled = false;
                btnDodaj.Enabled = false;

            }
        }


        private void FIllDdlDoktor()
        {
            try
            {
                proxy = new BolnicaService.Service1Client();
                ddlDoktor.DataSource = proxy.GetDoktor();
                ddlDoktor.DataBind();
            }
            catch (Exception ex)
            {
                lblStatusPacijenti.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
            }
        }

        protected void GridviewPacijent_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGridViewTerapija();
        }

        private void FillGridViewTerapija()
        {
            try
            {
                int idPacijent = Convert.ToInt32(GridViewPacijent.DataKeys[GridViewPacijent.SelectedRow.RowIndex].Value);
                proxy = new BolnicaService.Service1Client();
                GridViewTerapija.DataSource = proxy.GetPlanTerapije(idPacijent);
                GridViewTerapija.DataBind();
            }
            catch (Exception ex)
            {
                lblStatusPacijenti.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
            }
        }

        protected void GridViewTerapija_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        protected void CustomValidatorTerapija_ServerValidate(object source, ServerValidateEventArgs args)
        {

        }

        protected void btnDodaj_Click(object sender, EventArgs e)
        {

        }

        protected void lbDelete_Command(object sender, CommandEventArgs e)
        {

        }
    }


}