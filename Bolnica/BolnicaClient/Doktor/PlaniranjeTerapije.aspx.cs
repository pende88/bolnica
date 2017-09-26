using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BolnicaClient.Doktor
{
    public partial class PlaniranjeTerapije : System.Web.UI.Page
    {
        BolnicaService.IService1 proxy;


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                btnUpdate.Enabled = false;
                ddlTerapija.Enabled = false;
                btnDodaj.Enabled = false;
                txtDatumPocetka.Enabled = false;

            }

            //ubaci u postback
            if (this.Request.Params["idPacijenta"] != null && Request.Params["idDoktora"] != null)
                {
                    txtDoktor.Text = Request.Params["idDoktora"];
                    txtPacijent.Text = Request.Params["idPacijenta"];
                    FillDdlTerapija();
                    ddlTerapija.Enabled = true;
                    txtDatumPocetka.Enabled = true;
                }
                else
                {
                    txtDoktor.Text = Session["TrenutniKorisnik"].ToString();
                    FillGridViewPacijent();
                }

            


        }

        

      

        private void FillGridViewPacijent()
        {
            try
            {
                
                proxy = new BolnicaService.Service1Client();
                GridViewPacijent.DataSource = proxy.GetPacijentByDoktorID(Convert.ToInt32(txtDoktor.Text));
                GridViewPacijent.DataBind();

            }
            catch (Exception ex)
            {
                lblStatusPacijenti.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
            }
        }

        protected void GridViewPacijent_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDdlTerapija();

            FillGridViewTerapija();
            ddlTerapija.Enabled = true;
            btnUpdate.Enabled = false;
            btnDodaj.Enabled = true;
            txtDatumPocetka.Enabled = true;
        }




        private void FillGridViewTerapija()
        {
            int idPacijent;
            try
            {
                if(Request.Params["idPacijenta"] != null)
                {
                    idPacijent = Convert.ToInt32(txtPacijent.Text);
                }
                else
                {
                 idPacijent = Convert.ToInt32(GridViewPacijent.DataKeys[GridViewPacijent.SelectedRow.RowIndex].Value);

                }
                proxy = new BolnicaService.Service1Client();
                GridViewTerapija.DataSource = proxy.GetPlanTerapije(idPacijent);
                GridViewTerapija.DataBind();
            }
            catch (Exception ex)
            {
                lblStatusPacijenti.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
            }
        }


        private void FillDdlTerapija()
        {
            try
            {
                proxy = new BolnicaService.Service1Client();
                ddlTerapija.DataSource = proxy.GetTerapijaDDL();
                ddlTerapija.DataBind();
            }
            catch (Exception ex)
            {
                lblStatusPacijenti.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
            }
        }



        //dodaj ddlTerapija selectedindex changed za enablanje dodaj tipke

        protected void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                proxy = new BolnicaService.Service1Client();
                BolnicaService.PlanTerapije pt = new BolnicaService.PlanTerapije();


               if(Request.Params["idDoktora"] != null)
                {
                    pt.PacijentID = Convert.ToInt32(txtPacijent.Text);
                }
                else
                {
                    pt.PacijentID = Convert.ToInt32(GridViewPacijent.DataKeys[GridViewPacijent.SelectedRow.RowIndex].Value);

                }


                pt.DoktorID = Convert.ToInt32(txtDoktor.Text);
                pt.TerapijaID = Convert.ToInt32(ddlTerapija.SelectedValue);
                pt.DatumPocetka = Convert.ToDateTime(txtDatumPocetka.Text);

                proxy.AddPlanTerapije(pt);
                lblStatusPacijenti.Text = "Terapija dodana";
                FillGridViewTerapija();
                ddlTerapija.SelectedValue = "";
                txtDatumPocetka.Text = "";
            }
            catch (Exception ex)
            {
                lblStatusPacijenti.Text = ("Pogreška kod dodavanja terapije, greška: " + ex);
            }
        }


        protected void CustomValidatorTerapija_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlTerapija.SelectedValue.Equals(""))
            {
                args.IsValid = false;
            }
        }


        protected void lbDelete_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int veza = Convert.ToInt32(e.CommandArgument);

                proxy = new BolnicaService.Service1Client();
                proxy.DeletePlanTerapije(veza);
                lblStatusPacijenti.Text = ("Uspješno izbrisano");
                FillGridViewTerapija();


                btnDodaj.Enabled = false;
                btnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                lblStatusPacijenti.Text = ("Došlo je do pogreške ili nije moguće obrisati podatke" + ex);
            }
        }

        private void ClearAll()
        {
            txtDatumPocetka.Text = "";
            

            btnDodaj.Enabled = false;
            btnUpdate.Enabled = false;



        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                try
                {
                    proxy = new BolnicaService.Service1Client();
                    BolnicaService.PlanTerapije pt = new BolnicaService.PlanTerapije();


                    try
                    {
                        pt.IDPlanTerapije = Convert.ToInt32(GridViewTerapija.DataKeys[GridViewTerapija.SelectedRow.RowIndex].Value);

                        pt.PacijentID = Convert.ToInt32(GridViewPacijent.DataKeys[GridViewPacijent.SelectedRow.RowIndex].Value);
                        pt.DoktorID = Convert.ToInt32(txtDoktor.Text);
                        pt.TerapijaID = Convert.ToInt32(ddlTerapija.SelectedValue);
                        pt.DatumPocetka = Convert.ToDateTime(txtDatumPocetka.Text);

                        proxy.UpdatePlanTerapije(pt);

                        lblStatusPacijenti.Text = "Operacija uspješno spremljena";
                        FillGridViewTerapija();

                    }
                    catch (Exception ex)
                    {
                        lblStatusPacijenti.Text = ("Operacija nije izvršena, greška: " + ex);
                    }



                    ClearAll();
                }
                catch (Exception ex)
                {
                    lblStatusPacijenti.Text = ("Pogreška kod pristupa wfc service-u, greška: " + ex);
                }

                FillGridViewTerapija();

                btnDodaj.Enabled = true;

                btnUpdate.Enabled = false;

            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
            btnUpdate.Enabled = false;
            btnDodaj.Enabled = false;

            lblStatusPacijenti.Text = "";

            GridViewTerapija.DataSource = null;
            GridViewTerapija.DataBind();
        }

        protected void GridViewTerapija_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTerapija.SelectedValue = (GridViewTerapija.SelectedRow.FindControl("lblTerapijaID") as Label).Text;
            txtDatumPocetka.Text = (GridViewTerapija.SelectedRow.FindControl("lblDatumPocetka") as Label).Text;

            btnDodaj.Enabled = false;
            btnUpdate.Enabled = true;
        }

        protected void ddlTerapija_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlTerapija.SelectedValue != "")
            {

            btnDodaj.Enabled = true;
            }
            else
            {
                btnDodaj.Enabled = false;
            }
        }
    }
}