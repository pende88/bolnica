using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BolnicaClient.Admin
{
    public partial class Terapija : System.Web.UI.Page
    {
        BolnicaService.IService1 proxy;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGridView();
                FIllDdlBolesti();
                FillDdlLijek();

                btnSave.Enabled = true;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                ddlLijek.Enabled = false;
                btnDodaj.Enabled = false;
            }
        }

        private void FillDdlLijek()
        {
            try
            {
                proxy = new BolnicaService.Service1Client();
                ddlLijek.DataSource = proxy.GetLijekDDL();
                ddlLijek.DataBind();
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
                GridViewTerapija.DataSource = proxy.GetTerapija();
                GridViewTerapija.DataBind();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
            }
        }

        private void FIllDdlBolesti()
        {
            try
            {
                proxy = new BolnicaService.Service1Client();
                ddlBolesti.DataSource = proxy.GetBolestiDDL();
                ddlBolesti.DataBind();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
            }
        }

        protected void CustomValidatorOdabirBolesti_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlBolesti.SelectedValue.Equals(""))
            {
                args.IsValid = false;
            }
        }


        protected void GridViewTerapija_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIDTerapija.Text = GridViewTerapija.DataKeys[GridViewTerapija.SelectedRow.RowIndex].Value.ToString();
            txtNaziv.Text = (GridViewTerapija.SelectedRow.FindControl("lblNazivTerapija") as Label).Text;
            txtDaniTrajanja.Text = (GridViewTerapija.SelectedRow.FindControl("lblDaniTrajanja") as Label).Text;
            string proba = (GridViewTerapija.SelectedRow.FindControl("lblBolestID") as Label).Text.Trim();
            if (proba == "")
            {
                ddlBolesti.SelectedValue = "";
            }
            else
            {
                ddlBolesti.SelectedValue = (GridViewTerapija.SelectedRow.FindControl("lblBolestID") as Label).Text.Trim();
            }

            btnSave.Enabled = false;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            ddlLijek.Enabled = true;
            btnDodaj.Enabled = true;

            FillGridViewLijek();

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {

                try
                {
                    proxy = new BolnicaService.Service1Client();
                    BolnicaService.Terapija t = new BolnicaService.Terapija();


                    try
                    {
                        t.Naziv = txtNaziv.Text;
                        t.DaniTrajanja = Convert.ToInt32(txtDaniTrajanja.Text);
                        t.BolestID = Convert.ToInt32(ddlBolesti.SelectedValue);

                        proxy.AddTerapija(t);

                        lblStatus.Text = "Operacija uspješno spremljena";
                        FillGridView();

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
                    BolnicaService.Terapija t = new BolnicaService.Terapija();


                    try
                    {
                        t.IDTerapija = Convert.ToInt32(txtIDTerapija.Text);

                        t.Naziv = txtNaziv.Text;
                        t.DaniTrajanja = Convert.ToInt32(txtDaniTrajanja.Text);
                        t.BolestID = Convert.ToInt32(ddlBolesti.SelectedValue);

                        proxy.UpdateTerapija(t);

                        lblStatus.Text = "Operacija uspješno spremljena";
                        FillGridView();

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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDTerapija.Text);

            try
            {
                proxy.DeleteTerapija(id);
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

            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void ClearAll()
        {
            txtIDTerapija.Text = txtNaziv.Text = txtDaniTrajanja.Text = "";
            ddlBolesti.SelectedValue = "";

            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            ddlLijek.Enabled = false;
            btnDodaj.Enabled = false;

        }

        protected void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                proxy =  new BolnicaService.Service1Client();
                BolnicaService.TerapijaLijek tl = new BolnicaService.TerapijaLijek();


                tl.TerapijaID = Convert.ToInt32(GridViewTerapija.DataKeys[GridViewTerapija.SelectedRow.RowIndex].Value);
                tl.LijekID = Convert.ToInt32(ddlLijek.SelectedValue);
                proxy.AddTerapijaLijek(tl);
                lblStatusDodavanja.Text = "Lijek uspješno dodan terapiji";
                FillGridViewLijek();
            }
            catch (Exception ex)
            {
                lblStatusDodavanja.Text = ("Pogreška kod dodavanja lijeka u terapiju, greška: " + ex);
            }

        }





        private void FillGridViewLijek()
        {
            try
            {
                int idTerapija = Convert.ToInt32(GridViewTerapija.DataKeys[GridViewTerapija.SelectedRow.RowIndex].Value);
                proxy = new BolnicaService.Service1Client();
                GridViewLijek.DataSource = proxy.GetLijekByTerapija(idTerapija);
                GridViewLijek.DataBind();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
            }
        }

        protected void GridViewLijek_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridViewLijek.EditIndex)
            {
                (e.Row.Cells[4].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Jeste li sigurni?');";
            }
        }

        protected void lbDelete_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int veza = Convert.ToInt32(e.CommandArgument);

                proxy = new BolnicaService.Service1Client();
                proxy.DeleteTerapijaLijek(veza);
                lblStatus.Text = ("Uspješno izbrisano");
                FillGridViewLijek();

                btnSave.Enabled = true;
                btnDodaj.Enabled = false;
                btnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                lblStatus.Text = ("Došlo je do pogreške ili nije moguće obrisati podatke" + ex);
            }
        }
    }
}