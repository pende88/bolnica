<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Drzave.aspx.cs" Inherits="BolnicaClient.Admin.Drzave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">

        <br />
        <br />
        <div class="col-md-8 col-md-offset-2">
            <fieldset>
                <legend>Države</legend>

                <div class="form-group">
                    <asp:Label ID="IDProizvodjac" ControlStyle-CssClass="control-label  col-sm-2" runat="server">ID Države:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtIDProizvodjac" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="txtNazivProizvodjac" ID="lblProizvodjac" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Naziv Države:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtNazivProizvodjac" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtNazivProizvodjac"></asp:RequiredFieldValidator>
                    </div>
                </div>

                


                <div class="form-group">
                    <div class="col-sm-10 col-sm-offset-2">

                        <asp:Button CssClass="btn btn-default" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button CssClass="btn btn-default" ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                        <asp:Button CssClass="btn btn-default" ID="btnDelete" runat="server" Text="Delete" OnClientClick="return ShowConfirm(this.id);" OnClick="btnDelete_Click" CausesValidation="false" />
                        <asp:Button CssClass="btn btn-default" ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="false" />
                    </div>
                </div>


            </fieldset>
        </div>
    </div>

    <br />

    <asp:Label ID="lblStatus" runat="server" Text="" CssClass="col-md-offset-4"></asp:Label>
    <br />
    <div class="row">
        <div class="col-md-offset-2 col-md-8 ">
            <asp:GridView CssClass="table table-hover table-striped table-responsive table-bordered" ID="GridViewDrzave" 
                DataKeyNames="IDProizvodjac" runat="server" AutoGenerateColumns="False" 
                OnSelectedIndexChanged="GridViewDrzave_SelectedIndexChanged">

                <Columns>

                    <asp:TemplateField HeaderText="ID Države">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="IDProizvodjac" runat="server" Text='<%# Eval("IDProizvodjac") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Naziv Države">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblNazivDrzave" runat="server" Text='<%# Convert.ToString(Eval("Naziv")) == null ? "Nema" : Eval("Naziv") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                 

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnSelect" class="btn btn-link" runat="server" CommandName="Select" Text="Select" CausesValidation="false" />
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>


            </asp:GridView>
        </div>
        <br />
        <br />

     

        <div class="com-md-2"></div>
    </div>




</asp:Content>
