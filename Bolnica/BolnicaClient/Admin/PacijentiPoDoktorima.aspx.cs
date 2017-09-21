using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BolnicaClient.Admin
{
    public partial class PacijentiPoDoktorima : System.Web.UI.Page
    {
        BolnicaService.IService1 proxy;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDdlOdabirDoktora();
                FillDdlOdabirPacijenta();
            }
        }

        private void FillDdlOdabirDoktora()
        {
            try
            {
                proxy = new BolnicaService.Service1Client();
                ddlOdabirDoktora.DataSource = proxy.GetDoktor();
                ddlOdabirDoktora.DataBind();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
            }
        }

        private void FillDdlOdabirPacijenta()
        {
            try
            {
                proxy = new BolnicaService.Service1Client();
                ddlOdabirPacijenta.DataSource = proxy.GetPacijent();
                ddlOdabirPacijenta.DataBind();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
            }
        }








        protected void CustomValidatorOdabirDoktora_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlOdabirDoktora.SelectedValue.Equals(""))
            {
                args.IsValid = false;
            }
        }

        protected void CustomValidatorOdabirPacijenta_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlOdabirPacijenta.SelectedValue.Equals(""))
            {
                args.IsValid = false;
            }
        }




        protected void GridViewPacijentiByDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                proxy = new BolnicaService.Service1Client();
                

                int veza = Convert.ToInt32((GridViewPacijentiByDoktor.SelectedRow.FindControl("IDPacijentDoktorVeza") as Label).Text);



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

                    ddlDrzava.SelectedValue = kor.IDDrzava.ToString();
                }


            }
            catch (Exception ex)
            {
                lblStatus.Text = ("Operacija nije izvršena, greška: " + ex);
            }


        }

        protected void GridViewPacijentiByDoktor_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridViewPacijentiByDoktor_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridViewPacijentiByDoktor_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void GridViewPacijentiByDoktor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }



        protected void btnDodaj_Click(object sender, EventArgs e)
        {

            try
            {
                proxy = new BolnicaService.Service1Client();
                BolnicaService.PacijentDoktor pd = new BolnicaService.PacijentDoktor();
                pd.DoktorKorisnickiRacunID = Convert.ToInt32(ddlOdabirDoktora.SelectedValue);
                pd.PacijentKorisnickiRacunID = Convert.ToInt32(ddlOdabirPacijenta.SelectedValue);

                proxy.AddPacijentDoktorVeza(pd);

                lblStatus.Text = "Dodavanje uspješno izvršeno";

                FillGridViewPacijentiByDoktor();

            }
            catch (Exception ex)
            {
                lblStatus.Text = ("Operacija nije izvršena, greška: " + ex);
            }
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
                        k.IDKorisnickaGrupa = 3;
                        k.Ime = txtIme.Text;
                        k.Prezime = txtPrezime.Text;
                        k.OIB = txtOIB.Text;
                        k.Telefon = txtTelefon.Text;
                        k.Email = txtEmail.Text;
                        k.Adresa = txtAdresa.Text;
                        k.Grad = txtGrad.Text;
                        k.PTTBroj = txtPTTbroj.Text;
                        k.IDDrzava = Convert.ToInt32(ddlDrzava.SelectedValue);

                        proxy.AddKorisnik(k);

                        lblStatus.Text = "Operacija uspješno spremljena";

                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = ("Operacija nije izvršena, greška: " + ex);
                    }



                    // ClearAll();
                }
                catch (Exception ex)
                {
                    lblStatus.Text = ("Pogreška kod pristupa wfc service-u, greška: " + ex);
                }
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
                        k.IDDrzava = Convert.ToInt32(ddlDrzava.SelectedValue);

                        proxy.UpdateKorisnik(k);

                        lblStatus.Text = "Podaci uspješno izmjenjeni";

                        // ClearAll();

                        btnSave.Enabled = true;
                        btnUpdate.Enabled = false;

                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = ("Operacija nije izvršena, greška u pristupu kod baze podataka: " + ex);

                        btnSave.Enabled = false;
                        btnUpdate.Enabled = true;
                    }


                }
                catch (Exception ex)
                {
                    lblStatus.Text = ("Pogreška kod pristupa wfc service-u, greška: " + ex);
                }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }




        protected void ddlOdabirPacijenta_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void FillGridViewPacijentiByDoktor()
        {
            try
            {
                proxy = new BolnicaService.Service1Client();
                int IDdoktor = Convert.ToInt32(ddlOdabirDoktora.SelectedValue);
                GridViewPacijentiByDoktor.DataSource = proxy.GetPacijentByDoktorID(IDdoktor);
                GridViewPacijentiByDoktor.DataBind();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
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

        protected void validatorDdlDrzava_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlDrzava.SelectedValue.Equals(""))
            {
                args.IsValid = false;
            }
        }


        protected void ddlOdabirDoktora_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGridViewPacijentiByDoktor();
        }
    }
}