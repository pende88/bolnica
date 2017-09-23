using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BolnicaClient.Admin
{
    public partial class Proizvodjaci : System.Web.UI.Page
    {
        

            BolnicaService.IService1 proxy;


            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    FillGridView();
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
                    GridViewProizvodjac.DataSource = proxy.GetProizvodjac();
                    GridViewProizvodjac.DataBind();
                }
                catch (Exception ex)
                {
                    lblStatus.Text = ("Pogreška pri učitavanju podataka, greška: " + ex);
                }

            }

            protected void GridViewProizvodjac_SelectedIndexChanged(object sender, EventArgs e)
            {
                txtIDProizvodjac.Text = GridViewProizvodjac.DataKeys[GridViewProizvodjac.SelectedRow.RowIndex].Value.ToString();

                txtNazivProizvodjac.Text = (GridViewProizvodjac.SelectedRow.FindControl("lblNazivProizvodjac") as Label).Text;

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
                        BolnicaService.Proizvodjac p = new BolnicaService.Proizvodjac();


                        try
                        {
                            p.Naziv = txtNazivProizvodjac.Text;
                            proxy.AddProizvodjac(p);
                            FillGridView();


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
                        BolnicaService.Proizvodjac p = new BolnicaService.Proizvodjac();


                        try
                        {
                            p.IDProizvodjac = Convert.ToInt32(txtIDProizvodjac.Text);
                            p.Naziv = txtNazivProizvodjac.Text;
                            proxy.UpdateProizvodjac(p);
                            FillGridView();

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
                int id = Convert.ToInt32(txtIDProizvodjac.Text);

                try
                {
                    proxy.DeleteProizvodjac(id);
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
                txtIDProizvodjac.Text = txtNazivProizvodjac.Text = "";
            }
        
    }
}