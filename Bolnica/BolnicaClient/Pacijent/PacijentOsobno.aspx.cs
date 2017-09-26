using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BolnicaClient.Pacijent
{
    public partial class PregledPacijenata : System.Web.UI.Page
    {

        BolnicaService.IService1 proxy;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TrenutniKorisnik"] != null)
            {
                hfPacijentID.Value = Session["TrenutniKorisnik"].ToString();
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                FillPacijent();

                FillGridViewTerapija();
                FillGridViewDoktor();
                FillDdlDrzava();
                btnUpdate.Enabled = true;
            }
        }

        private void FillPacijent()
        {
            try
            {


                int veza = Convert.ToInt32(hfPacijentID.Value);

                proxy = new BolnicaService.Service1Client();
                var korisnik = proxy.GetPacijentByID(veza);

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
                btnUpdate.Enabled = true;



            }
            catch (Exception ex)
            { 
            
                lblStatus.Text = ("Došlo je do greške: " + ex);
            }

        }

        private void FillGridViewDoktor()
        {
            try
            {

                proxy = new BolnicaService.Service1Client();
                GridViewDoktor.DataSource = proxy.GetDoktorByPacijent(Convert.ToInt32(hfPacijentID.Value));
                GridViewDoktor.DataBind();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
            }
        }

        private void FillGridViewTerapija()
        {
            proxy = new BolnicaService.Service1Client();
            GridViewTerapija.DataSource = proxy.GetPlanTerapije(Convert.ToInt32(hfPacijentID.Value));
            GridViewTerapija.DataBind();
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




                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = ("Operacija nije izvršena, greška u pristupu kod baze podataka: " + ex);


                        btnUpdate.Enabled = true;
                    }


                }
                catch (Exception ex)
                {
                    lblStatus.Text = ("Pogreška kod pristupa wfc service-u, greška: " + ex);
                }



                btnUpdate.Enabled = false;
            }
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


        protected void GridViewTerapija_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idTerapije = Convert.ToInt32(Convert.ToInt32(GridViewTerapija.DataKeys[GridViewTerapija.SelectedRow.RowIndex].Value));
                FillGridViewLijek(idTerapije);


                btnUpdate.Enabled = true;


            }
            catch (Exception ex)
            {


                lblStatus.Text = ("Došlo je do greške: " + ex);


            }

        }

        private void FillGridViewLijek(int idTerapije)
        {
            try
            {

                proxy = new BolnicaService.Service1Client();
                GridviewLijek.DataSource = proxy.GetLijekByTerapija(Convert.ToInt32(idTerapije));
                GridviewLijek.DataBind();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
            }

        }
        protected void GridviewLijek_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}