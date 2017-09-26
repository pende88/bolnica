<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PacijentOsobno.aspx.cs" Inherits="BolnicaClient.Pacijent.PregledPacijenata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">

        <br />
        <br />
        <asp:Label ID="lblPrezimeDoktora" runat="server" Text=""></asp:Label>
        <asp:HiddenField ID="hfPacijentID" runat="server" />
        <br />
        <br />
        <div class="col-md-8 col-md-offset-2">
            <fieldset>
                <legend>Osobni podaci</legend>

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

                        <asp:Button CssClass="btn btn-default" ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
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
                ID="GridViewTerapija"
                DataKeyNames="TerapijaID" runat="server"
                AutoGenerateColumns="False"
                OnSelectedIndexChanged="GridViewTerapija_SelectedIndexChanged">

                <Columns>

                    <asp:TemplateField HeaderText="ID Terapije">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblIDPlanTerapije" runat="server" Text='<%# Eval("IDPlanTerapije") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>



                    <asp:TemplateField HeaderText="ID Doktor">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblDoktorID" runat="server" Text='<%# Convert.ToString(Eval("DoktorID")) == null ? "Nema" : Eval("DoktorID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Pacijent ID">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblPacijentID" runat="server" Text='<%# Convert.ToString(Eval("PacijentID")) == null ? "Nema" : Eval("PacijentID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="ID Terapije">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblTerapijaID" runat="server" Text='<%# Convert.ToString(Eval("TerapijaID")) == null ? "Nema" : Eval("TerapijaID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Naziv Terapije">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblNazivTerapije" runat="server" Text='<%# Convert.ToString(Eval("NazivTerapije")) == null ? "Nema" : Eval("NazivTerapije") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                       <asp:TemplateField HeaderText="Datum Početka">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblDatumPocetka" runat="server" Text='<%# Convert.ToString(Eval("DatumPocetka")) == null ? "Nema" : Eval("DatumPocetka") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                   <asp:TemplateField HeaderText="Datum Zavrsetka">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblDatumZavrsetka" runat="server" Text='<%# Convert.ToString(Eval("DatumZavrsetka")) == null ? "Nema" : Eval("DatumZavrsetka") %>' />
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
         <asp:GridView CssClass="table table-hover table-striped table-responsive table-bordered" 
                ID="GridviewLijek" 
                DataKeyNames="LijekID" runat="server" AutoGenerateColumns="False" 
                OnSelectedIndexChanged="GridviewLijek_SelectedIndexChanged">

                <Columns>

                    <asp:TemplateField HeaderText="ID Lijek">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="IDLijek" runat="server" Text='<%# Eval("LijekID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Naziv lijeka">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblNazivLijeka" runat="server" Text='<%# Convert.ToString(Eval("NazivLijeka")) == null ? "Nema" : Eval("NazivLijeka") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                  
                   

                  

                </Columns>


            </asp:GridView>
        </div>
        <br />
        <br />

    <asp:GridView CssClass="table table-hover table-striped table-responsive table-bordered" 
                ID="GridViewDoktor" 
                DataKeyNames="PacijentKorisnickiRacunID" runat="server" AutoGenerateColumns="False" 
                >

                <Columns>

                    
                   

                    <asp:TemplateField HeaderText="ID Doktora">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblDoktorKorisnickiRacunID" runat="server" Text='<%# Eval("DoktorKorisnickiRacunID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Naziv Doktora">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblNazivDoktora" runat="server" Text='<%# Convert.ToString(Eval("NazivDoktora")) == null ? "Nema" : Eval("NazivDoktora") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                  
 

                </Columns>


            </asp:GridView>
        
        <br />
        <br />


        <div class="com-md-2"></div>
    
</asp:Content>
