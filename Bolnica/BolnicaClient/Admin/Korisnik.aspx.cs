using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BolnicaClient.Admin
{
    public partial class Korisnik : System.Web.UI.Page
    {
        BolnicaService.IService1 proxy;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGridView();
                FillddlGrupa();
                FillddlProizvodjac();

                btnSave.Enabled = true;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }




        }

        

        private void FillGridView()
        {
            try
            {
                proxy = new BolnicaService.Service1Client();
                GridViewKorisnik.DataSource = proxy.GetKorisnik();
                GridViewKorisnik.DataBind();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
            }

        }

        private void FillddlGrupa()
        {
            try
            {
                proxy = new BolnicaService.Service1Client();
                ddlGrupa.DataSource = proxy.GetGrupa();
                ddlGrupa.DataBind();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
            }

        }

        private void FillddlProizvodjac()
        {
            try
            {
                proxy = new BolnicaService.Service1Client();
                ddlProizvodjac.DataSource = proxy.GetProizvodjac();
                ddlProizvodjac.DataBind();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
            }

        }



       

        protected void GridViewKorisnik_SelectedIndexChanged(object sender, EventArgs e)
        {



            txtIDKorisnickiRacun.Text = GridViewKorisnik.DataKeys[GridViewKorisnik.SelectedRow.RowIndex].Value.ToString();

            txtUsername.Text = (GridViewKorisnik.SelectedRow.FindControl("lblUsername") as Label).Text;

            txtPassword.Text = (GridViewKorisnik.SelectedRow.FindControl("lblPassword") as Label).Text;

            string probaGrupa = (GridViewKorisnik.SelectedRow.FindControl("lblGrupa") as Label).Text.Trim();
            if (probaGrupa == "")
            {
                ddlGrupa.SelectedValue = "";
            }
            else
            {
                ddlGrupa.SelectedValue = (GridViewKorisnik.SelectedRow.FindControl("lblIDKorisnickaGrupa") as Label).Text.Trim();

            }

            txtIme.Text = (GridViewKorisnik.SelectedRow.FindControl("lblIMe") as Label).Text;

            txtPrezime.Text = (GridViewKorisnik.SelectedRow.FindControl("lblPrezime") as Label).Text;

            txtOIB.Text = (GridViewKorisnik.SelectedRow.FindControl("lblOIB") as Label).Text;

            txtTelefon.Text = (GridViewKorisnik.SelectedRow.FindControl("lblTelefon") as Label).Text;

            txtEmail.Text = (GridViewKorisnik.SelectedRow.FindControl("lblEmail") as Label).Text;

            txtAdresa.Text = (GridViewKorisnik.SelectedRow.FindControl("lblAdresa") as Label).Text;

            txtGrad.Text = (GridViewKorisnik.SelectedRow.FindControl("lblGrad") as Label).Text;

            txtPTTbroj.Text = (GridViewKorisnik.SelectedRow.FindControl("lblPTTbroj") as Label).Text;

            string probaProizvodjac = (GridViewKorisnik.SelectedRow.FindControl("lblProizvodjac") as Label).Text.Trim();
            if (probaProizvodjac == "")
            {
                ddlProizvodjac.SelectedValue = "";
            }
            else
            {
                ddlProizvodjac.SelectedValue = (GridViewKorisnik.SelectedRow.FindControl("lblIDProizvodjac") as Label).Text.Trim();

            }

            btnSave.Enabled = false;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {

                try
                {
                    proxy = new BolnicaService.Service1Client();
                    BolnicaService.Korisnik k = new BolnicaService.Korisnik();


                    try
                    {
                        k.Username = txtUsername.Text;
                        k.Password = txtPassword.Text;
                        k.IDKorisnickaGrupa = Convert.ToInt32(ddlGrupa.SelectedValue);
                        k.Ime = txtIme.Text;
                        k.Prezime = txtPrezime.Text;
                        k.OIB = txtOIB.Text;
                        k.Telefon = txtTelefon.Text;
                        k.Email = txtEmail.Text;
                        k.Adresa = txtAdresa.Text;
                        k.Grad = txtGrad.Text;
                        k.PTTBroj = txtPTTbroj.Text;
                        k.IDProizvodjac = Convert.ToInt32(ddlProizvodjac.SelectedValue);

                        proxy.AddKorisnik(k);

                        lblStatus.Text = "Operacija uspješno spremljena";

                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = ("Operacija nije izvršena, greška: " + ex);
                    }



                    ClearAll();
                }
                catch (Exception ex)
                {
                    lblStatus.Text = ("Pogreška kod pristupa wfc service-u, greška: " + ex);
                }

                FillGridView();

                btnSave.Enabled = true;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                try
                {
                    proxy = new BolnicaService.Service1Client();
                    BolnicaService.Korisnik k = new BolnicaService.Korisnik();


                    try
                    {
                        k.IDKorisnickiRacun = Convert.ToInt32(txtIDKorisnickiRacun.Text);
                        k.Username = txtUsername.Text;
                        k.Password = txtPassword.Text;
                        k.IDKorisnickaGrupa = Convert.ToInt32(ddlGrupa.SelectedValue);
                        k.Ime = txtIme.Text;
                        k.Prezime = txtPrezime.Text;
                        k.OIB = txtOIB.Text;
                        k.Telefon = txtTelefon.Text;
                        k.Email = txtEmail.Text;
                        k.Adresa = txtAdresa.Text;
                        k.Grad = txtGrad.Text;
                        k.PTTBroj = txtPTTbroj.Text;
                        k.IDProizvodjac = Convert.ToInt32(ddlProizvodjac.SelectedValue);

                        proxy.UpdateKorisnik(k);

                        lblStatus.Text = "Podaci uspješno izmjenjeni";

                        ClearAll();

                        btnSave.Enabled = true;
                        btnDelete.Enabled = false;
                        btnUpdate.Enabled = false;

                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = ("Operacija nije izvršena, greška u pristupu kod baze podataka: " + ex);

                        btnSave.Enabled = false;
                        btnDelete.Enabled = true;
                        btnUpdate.Enabled = true;
                    }

                    
                }
                catch (Exception ex)
                {
                    lblStatus.Text = ("Pogreška kod pristupa wfc service-u, greška: " + ex);
                }

                FillGridView();
                btnSave.Enabled = true;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDKorisnickiRacun.Text);

            try
            {
                proxy.DeleteKorisnik(id);
                lblStatus.Text = "Svi podaci uspješno izbrisani";
                ClearAll();
                FillGridView();

                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                
            }
            catch(Exception ex)
            {
                lblStatus.Text = ("Podaci nisu izbrisani zbog greške: " + ex);

               
            }
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();

            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }


        private void ClearAll()
        {
            txtIDKorisnickiRacun.Text = txtUsername.Text = txtPassword.Text
           = txtIme.Text = txtPrezime.Text = txtOIB.Text = txtTelefon.Text = txtEmail.Text =
            txtAdresa.Text = txtGrad.Text = txtPTTbroj.Text = "";

            ddlGrupa.SelectedValue = "";
            ddlProizvodjac.SelectedValue = "";
        }

        protected void validatorDdlGrupa_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlGrupa.SelectedValue.Equals(""))
            {
                args.IsValid = false;
            }
        }

        protected void validatorDdlProizvodjac_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlProizvodjac.SelectedValue.Equals(""))
            {
                args.IsValid = false;
            }
        }

        protected void validatorOIB_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string oib = txtOIB.Text;

            if (oib.Length != 11)
            {
                args.IsValid = false;
                return;
            }

            long b;
            if (!long.TryParse(oib, out b))
            {
                args.IsValid = false;
                return;
            }

            int a = 10;
            for (int i = 0; i < 10; i++)
            {
                a = a + Convert.ToInt32(oib.Substring(i, 1));
                a = a % 10;
                if (a == 0) a = 10;
                a *= 2;
                a = a % 11;
            }
            int kontrolni = 11 - a;
            if (kontrolni == 10) kontrolni = 0;

          if( kontrolni == Convert.ToInt32(oib.Substring(10, 1)))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        
    }
}