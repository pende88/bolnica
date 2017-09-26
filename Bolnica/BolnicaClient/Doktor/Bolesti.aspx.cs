using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BolnicaClient.Doktor
{
    public partial class Bolesti : System.Web.UI.Page
    {
        BolnicaService.IService1 proxy;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGridView();
                FillDdlOpasnosti();

                btnSave.Enabled = true;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        private void FillGridView()
        {

            {
                try
                {
                    proxy = new BolnicaService.Service1Client();
                    GridviewBolest.DataSource = proxy.GetBolest();
                    GridviewBolest.DataBind();
                }
                catch (Exception ex)
                {
                    lblStatus.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
                }
            }
        }

        private void FillDdlOpasnosti()
        {
            try
            {
                proxy = new BolnicaService.Service1Client();
                ddlOpasnosti.DataSource = proxy.GetOpasnostBolesti();
                ddlOpasnosti.DataBind();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
            }
        }

        protected void CustomValidatorOdabirOpasnosti_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlOpasnosti.SelectedValue.Equals(""))
            {
                args.IsValid = false;
            }
        }

        protected void GridviewBolest_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIDBolest.Text = GridviewBolest.DataKeys[GridviewBolest.SelectedRow.RowIndex].Value.ToString();
            txtNazivBolesti.Text = (GridviewBolest.SelectedRow.FindControl("lblNazivBolesti") as Label).Text;
            txtGodinaOtkrica.Text = (GridviewBolest.SelectedRow.FindControl("lblGodinaOtkrica") as Label).Text;
            string probaBolest = (GridviewBolest.SelectedRow.FindControl("lblOpasnostID") as Label).Text.Trim();
            if (probaBolest == "")
            {
                ddlOpasnosti.SelectedValue = "";
            }
            else
            {
                ddlOpasnosti.SelectedValue = (GridviewBolest.SelectedRow.FindControl("lblOpasnostID") as Label).Text.Trim();
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
                    BolnicaService.Bolest b = new BolnicaService.Bolest();


                    try
                    {
                        b.NazivBolesti= txtNazivBolesti.Text;
                        b.GodinaOtkrica= Convert.ToInt32(txtGodinaOtkrica.Text);
                        b.OpasnostID= Convert.ToInt32(ddlOpasnosti.SelectedValue);

                        proxy.AddBolest(b);

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
                    BolnicaService.Bolest b = new BolnicaService.Bolest();


                    try
                    {
                        b.IDBolest = Convert.ToInt32(txtIDBolest.Text);
                        b.NazivBolesti = txtNazivBolesti.Text;
                        b.GodinaOtkrica = Convert.ToInt32(txtGodinaOtkrica.Text);
                        b.OpasnostID = Convert.ToInt32(ddlOpasnosti.SelectedValue);

                        proxy.UpdateBolest(b);

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
            int id = Convert.ToInt32(txtIDBolest.Text);
            proxy = new BolnicaService.Service1Client();
            try
            {
                proxy.DeleteBolest(id);
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
            txtIDBolest.Text = txtNazivBolesti.Text = txtGodinaOtkrica.Text = "";
            ddlOpasnosti.SelectedValue = "";

            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }


    }
}