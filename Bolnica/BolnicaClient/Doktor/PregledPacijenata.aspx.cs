using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BolnicaClient.Doktor
{
    public partial class PregledPacijenata : System.Web.UI.Page
    {

        BolnicaService.IService1 proxy;

        protected void Page_Load(object sender, EventArgs e)
        {
           lblPrezimeDoktora.Text =  "Dobrodošli doktore " + Convert.ToString(Session["Prezime"]);
           if(Session["TrenutniKorisnik"]!= null)
            {
                hfDoktorID.Value = Session["TrenutniKorisnik"].ToString();
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                FillGridView();
                FillDdlDrzava();
                FillDdlPacijent();
                btnSave.Enabled = true;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                btnDodaj.Enabled = false;
            }
        }

        private void FillDdlPacijent()
        {
            try
            {
                proxy = new BolnicaService.Service1Client();
                ddlPacijent.DataSource = proxy.GetPacijent();
                ddlPacijent.DataBind();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
            }
        }

        private void FillGridView()
        {
            try
            {
                
                proxy = new BolnicaService.Service1Client();
                GridViewKorisnik.DataSource = proxy.GetPacijentByDoktorID(Convert.ToInt32(hfDoktorID.Value));
                GridViewKorisnik.DataBind();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
            }

        }

        private void FillDdlDrzava()
        {
            try
            {
                proxy = new BolnicaService.Service1Client();
                ddlDrzava.DataSource = proxy.GetDrzava();
                ddlDrzava.DataBind();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
            }

        }


        protected void GridViewKorisnik_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int veza = Convert.ToInt32(Convert.ToInt32(GridViewKorisnik.DataKeys[GridViewKorisnik.SelectedRow.RowIndex].Value));
                proxy = new BolnicaService.Service1Client();
                var korisnik = proxy.GetPacijentByVeza(veza);

                foreach (var kor in korisnik)
                {
                    txtIDKorisnickiRacun.Text = Convert.ToString(kor.IDKorisnickiRacun);

                    txtUsername.Text = kor.Username;

                    txtPassword.Text = kor.Password;

                    txtIme.Text = kor.Ime;

                    txtPrezime.Text = kor.Prezime;

                    txtOIB.Text = kor.OIB;

                    txtTelefon.Text = kor.Telefon;

                    txtEmail.Text = kor.Email;

                    txtAdresa.Text = kor.Adresa;

                    txtGrad.Text = kor.Grad;

                    txtPTTbroj.Text = kor.PTTBroj;

                    ddlDrzava.SelectedValue = kor.DrzavaID.ToString();



                }
                btnSave.Enabled = false;
                
                btnUpdate.Enabled = true;


            }
            catch (Exception ex)
            {


                lblStatus.Text = ("Došlo je do greške: " + ex);


            }


            //txtIDKorisnickiRacun.Text = GridViewKorisnik.DataKeys[GridViewKorisnik.SelectedRow.RowIndex].Value.ToString();

            //txtUsername.Text = (GridViewKorisnik.SelectedRow.FindControl("lblUsername") as Label).Text;

            //txtPassword.Text = (GridViewKorisnik.SelectedRow.FindControl("lblPassword") as Label).Text;



            //txtIme.Text = (GridViewKorisnik.SelectedRow.FindControl("lblIMe") as Label).Text;

            //txtPrezime.Text = (GridViewKorisnik.SelectedRow.FindControl("lblPrezime") as Label).Text;

            //txtOIB.Text = (GridViewKorisnik.SelectedRow.FindControl("lblOIB") as Label).Text;

            //txtTelefon.Text = (GridViewKorisnik.SelectedRow.FindControl("lblTelefon") as Label).Text;

            //txtEmail.Text = (GridViewKorisnik.SelectedRow.FindControl("lblEmail") as Label).Text;

            //txtAdresa.Text = (GridViewKorisnik.SelectedRow.FindControl("lblAdresa") as Label).Text;

            //txtGrad.Text = (GridViewKorisnik.SelectedRow.FindControl("lblGrad") as Label).Text;

            //txtPTTbroj.Text = (GridViewKorisnik.SelectedRow.FindControl("lblPTTbroj") as Label).Text;

            //string probaProizvodjac = (GridViewKorisnik.SelectedRow.FindControl("lblDrzavaID") as Label).Text.Trim();
            //if (probaProizvodjac == "")
            //{
            //    ddlDrzava.SelectedValue = "";
            //}
            //else
            //{
            //    ddlDrzava.SelectedValue = (GridViewKorisnik.SelectedRow.FindControl("lblDrzavaID") as Label).Text.Trim();

            //}

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

                    BolnicaService.PacijentDoktor pd = new BolnicaService.PacijentDoktor();



                    try
                    {
                        k.Username = txtUsername.Text;
                        k.Password = txtPassword.Text;
                        k.IDKorisnickaGrupa = 3;
                        k.Ime = txtIme.Text;
                        k.Prezime = txtPrezime.Text;
                        k.OIB = txtOIB.Text;
                        k.Telefon = txtTelefon.Text;
                        k.Email = txtEmail.Text;
                        k.Adresa = txtAdresa.Text;
                        k.Grad = txtGrad.Text;
                        k.PTTBroj = txtPTTbroj.Text;
                        k.DrzavaID = Convert.ToInt32(ddlDrzava.SelectedValue);

                        pd.DoktorKorisnickiRacunID = Convert.ToInt32(hfDoktorID);
                

                        pd.PacijentKorisnickiRacunID = proxy.AddKorisnik(k);
                        proxy.AddPacijentDoktorVeza(pd);

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
                        k.IDKorisnickaGrupa = 3;
                        k.Ime = txtIme.Text;
                        k.Prezime = txtPrezime.Text;
                        k.OIB = txtOIB.Text;
                        k.Telefon = txtTelefon.Text;
                        k.Email = txtEmail.Text;
                        k.Adresa = txtAdresa.Text;
                        k.Grad = txtGrad.Text;
                        k.PTTBroj = txtPTTbroj.Text;
                        k.DrzavaID = Convert.ToInt32(ddlDrzava.SelectedValue);

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
            catch (Exception ex)
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

            ddlDrzava.SelectedValue = "";
        }

        protected void validatorDdlDrzava_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlDrzava.SelectedValue.Equals(""))
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

            if (kontrolni == Convert.ToInt32(oib.Substring(10, 1)))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void lbDodajTerapija_Command(object sender, CommandEventArgs e)
        {
            int idPacijenta = Convert.ToInt32(e.CommandArgument);
            int idDoktora = Convert.ToInt32(hfDoktorID.Value);

           Response.Redirect("~/Doktor/PlaniranjeTerapije.aspx?idDoktora=" + idDoktora + "&idPacijenta=" + idPacijenta); 

            
        
        }

        protected void lbDelete_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int veza = Convert.ToInt32(e.CommandArgument);

                proxy = new BolnicaService.Service1Client();
                proxy.DeletePacijentDoktorVeza(veza);
                lblStatus.Text = ("Uspješno izbrisano");
                FillGridView();


                btnSave.Enabled = false;
                btnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                lblStatus.Text = ("Došlo je do pogreške ili nije moguće obrisati podatke" + ex);
            }
        }

        protected void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                proxy = new BolnicaService.Service1Client();
                BolnicaService.PacijentDoktor p = new BolnicaService.PacijentDoktor();


                p.PacijentKorisnickiRacunID = Convert.ToInt32(ddlPacijent.SelectedValue);
                p.DoktorKorisnickiRacunID = Convert.ToInt32(hfDoktorID.Value);

                proxy.AddPacijentDoktorVeza(p);
                lblStatus.Text = "Pacijent dodan";
                FillGridView();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ("Pogreška kod dodavanja terapije, greška: " + ex);
            }
        }

        protected void ddlPacijent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPacijent.SelectedValue != "")
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