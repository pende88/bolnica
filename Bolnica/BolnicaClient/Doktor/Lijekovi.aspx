<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Lijekovi.aspx.cs" Inherits="BolnicaClient.Doktor.Lijekovi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row">

        <br />
        <br />
        <div class="col-md-8 col-md-offset-2">
            <fieldset>
                <legend>Lijek</legend>

                <div class="form-group">
                    <asp:Label ID="lblIDLijek" ControlStyle-CssClass="control-label  col-sm-2" runat="server">ID Proizvođača:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtIDLijek" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="txtNazivLijek" ID="lblLijek" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Naziv Lijeka:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtNazivLijek" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtNazivLijek"></asp:RequiredFieldValidator>
                    </div>
                </div>

                
                <div class="form-group">
                    <asp:Label AssociatedControlID="txtBrojOdobrenja" ID="Label1" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Broj odobrenja:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtBrojOdobrenja" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtBrojOdobrenja"></asp:RequiredFieldValidator>
                    </div>
                </div>

                 <div class="form-group">
                <asp:Label CssClass="control-label col-sm-2" ID="lblOdabirProizvodjaca" runat="server" Text="Odabir proizvođača:" AssociatedControlID="ddlProizvodjac"></asp:Label>
                <div class="col-sm-10">
                    <asp:DropDownList CssClass="btn btn-default" ID="ddlProizvodjac" runat="server" AppendDataBoundItems="true" AutoPostBack="false" DataValueField="IDProizvodjac" DataTextField="Naziv">
                        <Items>
                            <asp:ListItem Text="Odaberite Proizvođača" Value="" Selected="True"></asp:ListItem>
                        </Items>
                    </asp:DropDownList>
                    <asp:CustomValidator ID="CustomValidatorOdabirProizvodjaca" runat="server" ErrorMessage="Molimo odaberite proizvođača" OnServerValidate="CustomValidatorOdabirProizvodjaca_ServerValidate"></asp:CustomValidator>
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
            <asp:GridView CssClass="table table-hover table-striped table-responsive table-bordered" 
                ID="GridviewLijek" 
                DataKeyNames="IDLijek" runat="server" AutoGenerateColumns="False" 
                OnSelectedIndexChanged="GridviewLijek_SelectedIndexChanged">

                <Columns>

                    <asp:TemplateField HeaderText="ID Lijek">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="IDLijek" runat="server" Text='<%# Eval("IDLijek") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Naziv lijeka">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblNazivLijeka" runat="server" Text='<%# Convert.ToString(Eval("NazivLijeka")) == null ? "Nema" : Eval("NazivLijeka") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="Broj odobrenja">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblBrojOdobrenja" runat="server" Text='<%# Convert.ToString(Eval("BrojOdobrenja")) == null ? "Nema" : Eval("BrojOdobrenja") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="ID proizvođača">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblProizvodjacID" runat="server" Text='<%# Convert.ToString(Eval("ProizvodjacID")) == null ? "Nema" : Eval("ProizvodjacID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Naziv proizvođača">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblNazivProizvodjaca" runat="server" Text='<%# Convert.ToString(Eval("ProizvodjacNaziv")) == null ? "Nema" : Eval("ProizvodjacNaziv") %>' />
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
