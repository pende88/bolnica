using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BolnicaClient.Admin
{
    public partial class Lijekovi : System.Web.UI.Page
    {
        BolnicaService.IService1 proxy;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGridView();
                FIllDdlProizvodjac();

                btnSave.Enabled = true;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }



        private void FIllDdlProizvodjac()
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

        private void FillGridView()
        {
            try
            {
                proxy = new BolnicaService.Service1Client();
                GridviewLijek.DataSource = proxy.GetLijek();
                GridviewLijek.DataBind();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
            }
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {

                try
                {
                    proxy = new BolnicaService.Service1Client();
                    BolnicaService.Lijek l = new BolnicaService.Lijek();


                    try
                    {
                        l.NazivLijeka = txtNazivLijek.Text;
                        l.BrojOdobrenja = txtBrojOdobrenja.Text;
                        l.ProizvodjacID = Convert.ToInt32(ddlProizvodjac.SelectedValue); 

                        proxy.AddLijek(l);

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
                    BolnicaService.Lijek l = new BolnicaService.Lijek();


                    try
                    {
                        l.IDLijek = Convert.ToInt32(txtNazivLijek.Text);
                        l.BrojOdobrenja = txtBrojOdobrenja.Text;
                        l.ProizvodjacID = Convert.ToInt32(ddlProizvodjac.SelectedValue);

                        proxy.UpdateLijek(l);

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
            int id = Convert.ToInt32(txtIDLijek.Text);

            try
            {
                proxy.DeleteLijek(id);
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
            txtIDLijek.Text = txtNazivLijek.Text = txtBrojOdobrenja.Text = "";
            ddlProizvodjac.SelectedValue = "";

            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }



        protected void CustomValidatorOdabirProizvodjaca_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlProizvodjac.SelectedValue.Equals(""))
            {
                args.IsValid = false;
            }
        }

        protected void GridviewLijek_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIDLijek.Text = GridviewLijek.DataKeys[GridviewLijek.SelectedRow.RowIndex].Value.ToString();
            txtNazivLijek.Text = (GridviewLijek.SelectedRow.FindControl("lblNazivLijeka") as Label).Text;
            txtBrojOdobrenja.Text = (GridviewLijek.SelectedRow.FindControl("lblBrojOdobrenja") as Label).Text;
            string probaProizvodjac = (GridviewLijek.SelectedRow.FindControl("lblProizvodjacID") as Label).Text.Trim();
            if (probaProizvodjac == "")
            {
                ddlProizvodjac.SelectedValue = "";
            }
            else
            {
                ddlProizvodjac.SelectedValue = (GridviewLijek.SelectedRow.FindControl("lblProizvodjacID") as Label).Text.Trim();
            }

            btnSave.Enabled = false;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
        }
    }
}