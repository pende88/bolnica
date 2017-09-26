<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Terapija.aspx.cs" Inherits="BolnicaClient.Doktor.Terapija" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row">

        <br />
        <br />
        <div class="col-md-8 col-md-offset-2">
            <fieldset>
                <legend>Terapija</legend>

                <div class="form-group">
                    <asp:Label ID="lblIDTerapija" ControlStyle-CssClass="control-label  col-sm-2" runat="server">ID terapije:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtIDTerapija" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="txtNaziv" ID="lblNaziv" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Naziv terapije:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtNaziv" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtNaziv"></asp:RequiredFieldValidator>
                    </div>
                </div>

                 <div class="form-group">
                <asp:Label CssClass="control-label col-sm-2" ID="lblOdabirBolesti" runat="server" Text="Odabir bolesti:" AssociatedControlID="ddlBolesti"></asp:Label>
                <div class="col-sm-10">
                    <asp:DropDownList CssClass="btn btn-default" ID="ddlBolesti" runat="server" AppendDataBoundItems="true" AutoPostBack="false" DataValueField="IDBolest" DataTextField="NazivBolesti">
                        <Items>
                            <asp:ListItem Text="Odaberite Bolest" Value="" Selected="True"></asp:ListItem>
                        </Items>
                    </asp:DropDownList>
                    <asp:CustomValidator ID="CustomValidatorOdabirBolesti" runat="server" ErrorMessage="Molimo odaberite bolest" OnServerValidate="CustomValidatorOdabirBolesti_ServerValidate"></asp:CustomValidator>
                </div>
            </div>
                
                <div class="form-group">
                    <asp:Label AssociatedControlID="txtDaniTrajanja" ID="Label1" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Dani trajanja:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtDaniTrajanja" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtDaniTrajanja"></asp:RequiredFieldValidator>
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
                ID="GridViewTerapija" 
                DataKeyNames="IDTerapija" runat="server" AutoGenerateColumns="False" 
                OnSelectedIndexChanged="GridViewTerapija_SelectedIndexChanged">

                <Columns>

                    <asp:TemplateField HeaderText="ID Terapija">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblIDTerapija" runat="server" Text='<%# Eval("IDTerapija") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Naziv terapije">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblNazivTerapija" runat="server" Text='<%# Convert.ToString(Eval("Naziv")) == null ? "Nema" : Eval("Naziv") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="Bolest ID">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblBolestID" runat="server" Text='<%# Convert.ToString(Eval("BolestID")) == null ? "Nema" : Eval("BolestID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Naziv bolesti">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblNazivBolesti" runat="server" Text='<%# Convert.ToString(Eval("NazivBolesti")) == null ? "Nema" : Eval("NazivBolesti") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Dani trajanja">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblDaniTrajanja" runat="server" Text='<%# Convert.ToString(Eval("DaniTrajanja")) == null ? "Nema" : Eval("DaniTrajanja") %>' />
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
         <div class="form-group">
                <asp:Label CssClass="control-label col-sm-2" ID="lblOdabirLijeka" runat="server" Text="Odabir lijeka:" AssociatedControlID="ddlLijek"></asp:Label>
                <div class="col-sm-10">
                    <asp:DropDownList CssClass="btn btn-default" ID="ddlLijek" runat="server" AppendDataBoundItems="true" 
                        AutoPostBack="true" DataValueField="IDLijek" DataTextField="NazivLijeka"
                        OnSelectedIndexChanged="ddlLijek_SelectedIndexChanged"
                        >
                        <Items>
                            <asp:ListItem Text="Odaberite Lijek" Value="" Selected="True"></asp:ListItem>
                        </Items>
                    </asp:DropDownList>
                    <asp:CustomValidator ID="CustomValidatorOdabiraLijeka" runat="server" ErrorMessage="Pa nemoš dodat prazan lijek" OnServerValidate="CustomValidatorOdabiraLijeka_ServerValidate"  ></asp:CustomValidator>
                </div>
            </div>

          <asp:Button CssClass="btn btn-default" ID="btnDodaj" runat="server" Text="Dodaj" OnClick="btnDodaj_Click" CausesValidation ="true" />

        <asp:Label ID="lblStatusDodavanja" runat="server" Text="" CssClass="col-md-offset-4"></asp:Label>
    <br />
    <div class="row">
        <div class="col-md-offset-2 col-md-8 ">
            <asp:GridView CssClass="table table-hover table-striped table-responsive table-bordered" 
                ID="GridViewLijek" 
                DataKeyNames="IDTerapijaLijek" runat="server" AutoGenerateColumns="False" 
                ShowHeaderWhenEmpty="true"
                    >
              
                
                <Columns>

                    <asp:TemplateField HeaderText="ID Terapija Lijek">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblIDTerapijaLijek" runat="server" Text='<%# Eval("IDTerapijaLijek") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ID Terapija">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblTerapijaID" runat="server" Text='<%# Convert.ToString(Eval("TerapijaID")) == null ? "Nema" : Eval("TerapijaID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="ID Lijek">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblLIjekID" runat="server" Text='<%# Convert.ToString(Eval("LijekID")) == null ? "Nema" : Eval("LijekID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Naziv Lijeka">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblNazivLijeka" runat="server" Text='<%# Convert.ToString(Eval("NazivLijeka")) == null ? "Nema" : Eval("NazivLijeka") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Komanda">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lbDelete" Text="Delete" CommandArgument='<%#Eval("IDTerapijaLijek") %>'
                                OnCommand="lbDelete_Command">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>


            </asp:GridView>
        </div>


     

        <div class="com-md-2"></div>
    </div>
        </div>
</asp:Content>
