<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SviKorsnici.aspx.cs" Inherits="BolnicaClient.Admin.SviKorisnici" %>

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
                    <asp:Label AssociatedControlID="txtUserName" ID="lblUsername" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Username:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtUserName" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="txtPassword" ID="lblPassword" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Password:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtPassword" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>

                    </div>
                </div>

                 <div class="form-group">
                    <asp:Label CssClass="control-label col-sm-2" ID="Label1" runat="server" Text="Grupa:" AssociatedControlID="ddlGrupa"></asp:Label>
                    <div class="col-sm-10">
                        <asp:DropDownList CssClass="btn btn-default" ID="ddlGrupa" runat="server" AppendDataBoundItems="true" AutoPostBack="false" DataValueField="IDKorisnickaGrupa" DataTextField="Grupa">
                            <Items>
                                <asp:ListItem Text="Odaberi grupu korisnika" Value="" Selected="True"></asp:ListItem>
                            </Items>
                        </asp:DropDownList>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Molimo odaberite grupu" OnServerValidate="validatorDdlGrupa_ServerValidate"></asp:CustomValidator>

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

                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="txtTelefon" ID="lblTelefon" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Telefon:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtTelefon" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtTelefon"></asp:RequiredFieldValidator>

                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="txtEmail" ID="lblEmail" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Email:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtEmail" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>

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
                    <asp:Label AssociatedControlID="txtPTT" ID="lblPTT" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Poštanski broj:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtPTT" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtPTT"></asp:RequiredFieldValidator>

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
                        <%--<asp:Button CssClass="btn btn-default" ID="btnSave" runat="server" Text="Save" />--%>
                        <asp:Button CssClass="btn btn-default" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"  />
                        <asp:Button CssClass="btn btn-default" ID="btnUpdate" runat="server" Text="Update"  />
                        <asp:Button CssClass="btn btn-default" ID="btnDelete" runat="server" Text="Delete" OnClientClick="return ShowConfirm(this.id);" OnClick="btnDeleteFull_Click" CausesValidation="false" />
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
            <asp:GridView CssClass="table table-hover table-striped table-responsive table-bordered" ID="GridViewKlijent" DataKeyNames="id" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewKlijent_SelectedIndexChanged">

                <Columns>

                    <asp:TemplateField HeaderText="IDKorisnickiRacun">
                        <ItemTemplate>
                            <asp:Label ID="lblKlijent" runat="server" Text='<%#Eval("IDKorisnickiRacun") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="IDKorisnickaGrupa">
                        <ItemTemplate>
                            <asp:Label ID="lblIme" runat="server" Text='<%#Eval("IDKorisnickaGrupa") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Grupa">
                        <ItemTemplate>
                            <asp:Label ID="lblPrezime" runat="server" Text='<%#Eval("Grupa") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Username">
                        <ItemTemplate>
                            <asp:Label ID="lblAdresa" runat="server" Text='<%#Eval("Username") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Password">
                        <ItemTemplate>
                            <asp:Label ID="lblGrad" runat="server" Text='<%#Eval("Password") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Ime">
                        <ItemTemplate>
                            <asp:Label ID="lblGrad" runat="server" Text='<%#Eval("Ime") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Prezime">
                        <ItemTemplate>
                            <asp:Label ID="lblGrad" runat="server" Text='<%#Eval("Prezime") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="OIB">
                        <ItemTemplate>
                            <asp:Label ID="lblGrad" runat="server" Text='<%#Eval("OIB") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Telefon">
                        <ItemTemplate>
                            <asp:Label ID="lblGrad" runat="server" Text='<%#Eval("Telefon") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label ID="lblGrad" runat="server" Text='<%#Eval("Email") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Adresa">
                        <ItemTemplate>
                            <asp:Label ID="lblGrad" runat="server" Text='<%#Eval("Adresa") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="PTTbroj">
                        <ItemTemplate>
                            <asp:Label ID="lblGrad" runat="server" Text='<%#Eval("PTTbroj") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Grad">
                        <ItemTemplate>
                            <asp:Label ID="lblGrad" runat="server" Text='<%#Eval("Grad") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="IDDrzava">
                        <ItemTemplate>
                            <asp:Label ID="lblGrad" runat="server" Text='<%#Eval("IDDrzava") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Drzava">
                        <ItemTemplate>
                            <asp:Label ID="lblGrad" runat="server" Text='<%#Eval("Drzava") %>' />
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

        <div class="com-md-2"></div>
    </div>
</asp:Content>
