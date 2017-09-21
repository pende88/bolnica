<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PacijentiPoDoktorima.aspx.cs" Inherits="BolnicaClient.Admin.PacijentiPoDoktorima" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />

      <fieldset>
            <legend>Pacijenti po doktorima</legend>
            <div class="form-group">
                <asp:Label CssClass="control-label col-sm-2" ID="lblOdabirDoktora" runat="server" Text="Odabir Doktora:" AssociatedControlID="ddlOdabirDoktora"></asp:Label>
                <div class="col-sm-10">
                    <asp:DropDownList CssClass="btn btn-default" ID="ddlOdabirDoktora" runat="server" AppendDataBoundItems="true" AutoPostBack="true" DataValueField="IDKOrisnickiRacun" DataTextField="NazivDoktora" OnSelectedIndexChanged="ddlOdabirDoktora_SelectedIndexChanged" ViewStateMode="Enabled">
                        <Items>
                            <asp:ListItem Text="Odaberite doktora" Value=null Selected="True"></asp:ListItem>
                        </Items>
                    </asp:DropDownList>
                    <asp:CustomValidator ID="CustomValidatorOdabirDoktora" runat="server" ErrorMessage="Molimo odaberite doktora" OnServerValidate="CustomValidatorOdabirDoktora_ServerValidate"></asp:CustomValidator>
                </div>
            </div>

          <div class="form-group">
                <asp:Label CssClass="control-label col-sm-2" ID="lblOdabirPacijenta" runat="server" Text="Odabir Pacijenta:" AssociatedControlID="ddlOdabirPacijenta"></asp:Label>
                <div class="col-sm-10">
                    <asp:DropDownList CssClass="btn btn-default" ID="ddlOdabirPacijenta" runat="server" AppendDataBoundItems="true" AutoPostBack="false" DataValueField="IDKOrisnickiRacun" DataTextField="NazivPacijenta" OnSelectedIndexChanged="ddlOdabirPacijenta_SelectedIndexChanged">
                        <Items>
                            <asp:ListItem Text="Odaberite Pacijenta" Value="" Selected="True"></asp:ListItem>
                        </Items>
                    </asp:DropDownList>
                    <asp:CustomValidator ID="CustomValidatorOdabirPacijenta" runat="server" ErrorMessage="Molimo odaberite pacijenta" OnServerValidate="CustomValidatorOdabirPacijenta_ServerValidate"></asp:CustomValidator>
                </div>
            </div>


            <%-- dodaj tipke za dodavanje pacijenta u listu --%>
          <div class="form-group">
                    <div class="col-sm-10 col-sm-offset-2">

                        <asp:Button CssClass="btn btn-default" ID="btnDodaj" runat="server" Text="Dodaj pacijenta" OnClick="btnDodaj_Click" CausesValidation="false"/>
                        
                    </div>
                </div>
</fieldset>
    <fieldset>
        <legend>Dodavanje novog bolesnika odabranom doktoru</legend>
        <%-- u kodu kod dodavanja ovog pacijenta treba postaviti grupu na broj 3 --%>

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
                        <asp:TextBox TextMode="Password" PasswordChar='*' ID="txtPassword" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ControlToValidate="txtPassword" ID="RegularExpressionValidatorPassword" runat="server" ValidationExpression="^[\s\S]{,}$" runat="server" ErrorMessage="Minimum 6 znakova je potrebno."></asp:RegularExpressionValidator>
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
                    <asp:Label CssClass="control-label col-sm-2" ID="lblDrzava" runat="server" Text="Drzava:" AssociatedControlID="ddlDrzava"></asp:Label>
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

                        <asp:Button CssClass="btn btn-default" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button CssClass="btn btn-default" ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                       <%-- provjeri dali može ista metoda (vjerojatno ću morat iz drugih polja dobivat vrijednosti --%>
                        <asp:Button CssClass="btn btn-default" ID="btnDodaj2" runat="server" Text="Dodaj" OnClick="btnDodaj_Click" />
                        <asp:Button CssClass="btn btn-default" ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="false" />
                    </div>
                </div>


        </fieldset>


     <asp:Label ID="lblStatus" runat="server" Text="" CssClass="col-md-offset-4"></asp:Label>
    <br />
    <div class="row">
        <div class="col-md-offset-2 col-md-8 ">
            <asp:GridView CssClass="table table-hover table-striped table-responsive table-bordered" ID="GridViewPacijentiByDoktor" ShowHeaderWhenEmpty="True"
                DataKeyNames="PacijentKorisnickiRacunID" runat="server" AutoGenerateColumns="False" 
                OnSelectedIndexChanged="GridViewPacijentiByDoktor_SelectedIndexChanged"
                OnRowCommand="GridViewPacijentiByDoktor_RowCommand"
                OnRowDataBound="GridViewPacijentiByDoktor_RowDataBound"
                OnRowDeleted="GridViewPacijentiByDoktor_RowDeleted"
                OnRowDeleting="GridViewPacijentiByDoktor_RowDeleting"

                >
                <%-- ispitaj da li trebaju svi ovi eventi --%>
                <Columns>

                   
                    



                     <asp:TemplateField HeaderText="IDPacijentDoktorVeza">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblPacijentDoktorVeza" runat="server" Text='<%# Eval("IDPacijentDoktorVeza") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="DoktorKorisnickiRacunID">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblDoktorKorisnickiRacunID" runat="server" Text='<%# Eval("DoktorKorisnickiRacunID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="PacijentKorisnickiRacunID">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblPacijentKorisnickiRacunID" runat="server" Text='<%# Eval("PacijentKorisnickiRacunID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="NazivPacijenta">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblNazivPacijenta" runat="server" Text='<%# Eval("NazivPacijenta") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnSelect" class="btn btn-link" runat="server" CommandName="Select" Text="Select" CausesValidation="false"  OnClick="GridViewPacijentiByDoktor_SelectedIndexChanged"/>
                        </ItemTemplate>
                    </asp:TemplateField>

<%--                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnDelete" class="btn btn-link" runat="server" CommandName="Delete" Text="Delete" CausesValidation="false" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>


                </Columns>


            </asp:GridView>
        </div>
        </div>


</asp:Content>
