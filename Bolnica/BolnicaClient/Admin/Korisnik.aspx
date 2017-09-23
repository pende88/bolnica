<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Korisnik.aspx.cs" Inherits="BolnicaClient.Admin.Korisnik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">

        <br />
        <br />
        <div class="col-md-8 col-md-offset-2">
            <fieldset>
                <legend>Korisnici</legend>

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
                        <asp:RegularExpressionValidator ControlToValidate="txtPassword" ID="RegularExpressionValidatorPassword" runat="server" ValidationExpression="^[\s\S]{,}$"  ErrorMessage="Minimum 6 znakova je potrebno."></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label CssClass="control-label col-sm-2" ID="lblGrupa" runat="server" Text="Grupa:" AssociatedControlID="ddlGrupa"></asp:Label>
                    <div class="col-sm-10">
                        <asp:DropDownList CssClass="btn btn-default" ID="ddlGrupa" runat="server" AppendDataBoundItems="true" AutoPostBack="false" DataValueField="IDKorisnickaGrupa" DataTextField="KorisnickaGrupaNaziv">
                            <Items>
                                <asp:ListItem Text="Odaberi grupu korisnika" Value="" Selected="True"></asp:ListItem>
                            </Items>
                        </asp:DropDownList>
                        <asp:CustomValidator ID="validatorDdlGrupa" runat="server" ErrorMessage="Molimo odaberite grupu" OnServerValidate="validatorDdlGrupa_ServerValidate"></asp:CustomValidator>

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
            <asp:GridView CssClass="table table-hover table-striped table-responsive table-bordered" ID="GridViewKorisnik" 
                DataKeyNames="IDKorisnickiRacun" runat="server" AutoGenerateColumns="False" 
                OnSelectedIndexChanged="GridViewKorisnik_SelectedIndexChanged">

                <Columns>

                    <asp:TemplateField HeaderText="IDKorisnickiRacun">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblIDKorisnickiRacun" runat="server" Text='<%# Eval("IDKorisnickiRacun") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="IDKorisnickaGrupa">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblIDKorisnickaGrupa" runat="server" Text='<%# Convert.ToString(Eval("IDKorisnickaGrupa")) == null ? "Nema" : Eval("IDKorisnickaGrupa") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Grupa">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblGrupa" runat="server" Text='<%# Convert.ToString(Eval("Grupa")) == null ? "Nema" : Eval("Grupa") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Username">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblUsername" runat="server" Text='<%# Convert.ToString(Eval("Username")) == null ? "Nema" : Eval("Username") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Password">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblPassword" runat="server" Text='<%# Convert.ToString(Eval("Password")) == null ? "Nema" : Eval("Password") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Ime">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblIme" runat="server" Text='<%# Convert.ToString(Eval("Ime")) == null ? "Nema" : Eval("Ime") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Prezime">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblPrezime" runat="server" Text='<%# Convert.ToString(Eval("Prezime")) == null ? "Nema" : Eval("Prezime") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="OIB">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblOIB" runat="server" Text='<%# Convert.ToString(Eval("OIB")) == null ? "Nema" : Eval("OIB") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Telefon">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblTelefon" runat="server" Text='<%# Convert.ToString(Eval("Telefon")) == null ? "Nema" : Eval("Telefon") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblEmail" runat="server" Text='<%# Convert.ToString(Eval("Email")) == null ? "Nema" : Eval("Email") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Adresa">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblAdresa" runat="server" Text='<%# Convert.ToString(Eval("Adresa")) == null ? "Nema" : Eval("Adresa") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="PTTbroj">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblPTTbroj" runat="server" Text='<%# Convert.ToString(Eval("PTTbroj")) == null ? "Nema" : Eval("PTTbroj") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Grad">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblGrad" runat="server" Text='<%# Convert.ToString(Eval("Grad")) == null ? "Nema" : Eval("Grad") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ID Države">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblDrzavaID" runat="server" Text='<%# Convert.ToString(Eval("DrzavaID")) == null ? "Nema" : Eval("DrzavaID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Država">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblDrzava" runat="server" Text='<%# Convert.ToString(Eval("Drzava")) == null ? "Nema" : Eval("Drzava") %>' />
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
