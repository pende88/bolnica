﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PregledPacijenata.aspx.cs" Inherits="BolnicaClient.Doktor.PregledPacijenata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">

        <br />
        <br />
        <asp:Label ID="lblPrezimeDoktora" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="hfDoktorID" runat="server" />
        <br />
        <br />
        <div class="col-md-8 col-md-offset-2">
            <fieldset>
                <legend>Pacijenti</legend>

                <div class="form-group">
                    <asp:Label ID="lblIDKorisnickiRacun" ControlStyle-CssClass="control-label  col-sm-2" runat="server">ID Korisničkog Računa:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtIDKorisnickiRacun" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="txtUsername" ID="lblUsername" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Username:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtUsername" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtUsername"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="txtPassword" ID="lblPassword" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Password:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox PasswordChar='*' ID="txtPassword" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ValidationExpression="^[\s\S]{6,}$" Display="Dynamic" ID="RegularExpressionValidator1" runat="server" ErrorMessage="minimum 6 znakova" ControlToValidate="txtPassword"></asp:RegularExpressionValidator>
                    </div>
                </div>




                <div class="form-group">
                    <asp:Label AssociatedControlID="txtIme" ID="lblIme" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Ime:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtIme" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtIme"></asp:RequiredFieldValidator>

                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="txtPrezime" ID="lblPrezime" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Prezime:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtPrezime" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtPrezime"></asp:RequiredFieldValidator>

                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="txtOIB" ID="lblOIB" ControlStyle-CssClass="control-label  col-sm-2" runat="server">OIB:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtOIB" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtOIB"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="validatorOIB" runat="server" ErrorMessage="OIB nije ispravan, molimo provjerite svaku brojku" OnServerValidate="validatorOIB_ServerValidate"></asp:CustomValidator>

                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="txtTelefon" ID="lblTelefon" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Telefon:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtTelefon" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtTelefon"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ControlToValidate="txtTelefon" ID="RegularExpressionValidatorTelefon" runat="server" ErrorMessage="Unesite broj u obliku 1-(123)-123-1234 ili 123 123 1234" ValidationExpression="^([0-9]( |-)?)?(\(?[0-9]{3}\)?|[0-9]{3})( |-)?([0-9]{3}( |-)?[0-9]{4}|[a-zA-Z0-9]{7})$"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="txtEmail" ID="lblEmail" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Email:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtEmail" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ControlToValidate="txtEmail" ID="RegularExpressionValidatorEmail" runat="server" ErrorMessage="Niste unijeli ispravan oblik email-a" ValidationExpression="^(?(&quot;)(&quot;.+?(?<!\\)&quot;@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="txtAdresa" ID="lblAdresa" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Adresa:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtAdresa" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtAdresa"></asp:RequiredFieldValidator>

                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="txtGrad" ID="lblGrad" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Grad:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtGrad" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtGrad"></asp:RequiredFieldValidator>

                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="txtPTTbroj" ID="lblPTTbroj" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Poštanski broj:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtPTTbroj" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtPTTbroj"></asp:RequiredFieldValidator>

                    </div>
                </div>



                <div class="form-group">
                    <asp:Label CssClass="control-label col-sm-2" ID="lblIDDrzava" runat="server" Text="Proizvodjac:" AssociatedControlID="ddlDrzava"></asp:Label>
                    <div class="col-sm-10">
                        <asp:DropDownList CssClass="btn btn-default" ID="ddlDrzava" runat="server" AppendDataBoundItems="true" AutoPostBack="false" DataValueField="IDDrzava" DataTextField="Naziv">
                            <Items>
                                <asp:ListItem Text="Odaberi državu" Value="" Selected="True"></asp:ListItem>
                            </Items>
                        </asp:DropDownList>
                        <asp:CustomValidator ID="validatorDdlDrzava" runat="server" ErrorMessage="Molimo odaberite drzavu" OnServerValidate="validatorDdlDrzava_ServerValidate"></asp:CustomValidator>

                    </div>
                </div>


                <div class="form-group">
                    <div class="col-sm-10 col-sm-offset-2">

                        <asp:Button CssClass="btn btn-default" ID="btnSave" runat="server" Text="Save i Dodaj" OnClick="btnSave_Click" />
                        <asp:Button CssClass="btn btn-default" ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                        <asp:Button CssClass="btn btn-default" ID="btnDelete" runat="server" Text="Delete" OnClientClick="return ShowConfirm(this.id);" OnClick="btnDelete_Click" CausesValidation="false" />
                        <asp:Button CssClass="btn btn-default" ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="false" />
                    </div>
                </div>

                  <div class="form-group">
                    <asp:Label CssClass="control-label col-sm-2" ID="lblPacijent" runat="server" Text="Odabir pacijenta:" AssociatedControlID="ddlPacijent"></asp:Label>
                    <div class="col-sm-10">
                        <asp:DropDownList CssClass="btn btn-default" ID="ddlPacijent" runat="server" 
                            AppendDataBoundItems="true" AutoPostBack="true" DataValueField="IDKOrisnickiRacun"
                            DataTextField="NazivPacijenta"
                            OnSelectedIndexChanged="ddlPacijent_SelectedIndexChanged">

                            <Items>
                                <asp:ListItem Text="Odaberi pacijenta" Value="" Selected="True"></asp:ListItem>
                            </Items>
                        </asp:DropDownList>
                         <asp:Button CssClass="btn btn-default" ID="btnDodaj" runat="server" Text="Dodaj" OnClick="btnDodaj_Click" CausesValidation="false"/>

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
            <asp:GridView CssClass="table table-hover table-striped table-responsive table-bordered" ID="GridViewKorisnik"
                DataKeyNames="PacijentKorisnickiRacunID" runat="server" AutoGenerateColumns="False"
                OnSelectedIndexChanged="GridViewKorisnik_SelectedIndexChanged">

                <Columns>

                    <asp:TemplateField HeaderText="ID veze">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblIDPacijentDoktorVeza" runat="server" Text='<%# Eval("IDPacijentDoktorVeza") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>



                    <asp:TemplateField HeaderText="ID Doktor">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblDoktorKorisnickiRacunID" runat="server" Text='<%# Convert.ToString(Eval("DoktorKorisnickiRacunID")) == null ? "Nema" : Eval("DoktorKorisnickiRacunID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ID Pacijent">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblPacijentKorisnickiRacunID" runat="server" Text='<%# Convert.ToString(Eval("PacijentKorisnickiRacunID")) == null ? "Nema" : Eval("PacijentKorisnickiRacunID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Naziv Pacijenta">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblNazivPacijenta" runat="server" Text='<%# Convert.ToString(Eval("NazivPacijenta")) == null ? "Nema" : Eval("NazivPacijenta") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>



                    <asp:TemplateField HeaderText="Dodavanje terapije">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lbDodajTerapija" Text="Dodaj terapiju" CommandArgument='<%#Eval("PacijentKorisnickiRacunID") %>'
                                OnCommand="lbDodajTerapija_Command" CausesValidation="false">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                       <asp:TemplateField HeaderText="Brisanje">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lbDelete" Text="Delete" CommandArgument='<%#Eval("IDPacijentDoktorVeza") %>'
                                OnCommand="lbDelete_Command" CausesValidation ="false">
                            </asp:LinkButton>
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
