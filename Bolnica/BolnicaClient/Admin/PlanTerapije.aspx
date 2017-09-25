<%@ Page Title="" UICulture="hr" Culture="hr-HR" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PlanTerapije.aspx.cs" Inherits="BolnicaClient.Admin.PlanTerapije" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">

        <br />
        <br />
        <div class="col-md-8 col-md-offset-2">
            <fieldset>
                <legend>Odabir Doktora i pacijenta</legend>



                <div class="form-group">
                    <asp:Label CssClass="control-label col-sm-2" ID="lblDoktor" runat="server" Text="Odaberite Doktora:" AssociatedControlID="ddlDoktor"></asp:Label>
                    <div class="col-sm-10">
                        <asp:DropDownList CssClass="btn btn-default" ID="ddlDoktor" runat="server" AppendDataBoundItems="true" AutoPostBack="true" 
                            DataValueField="IDKOrisnickiRacun" DataTextField="NazivDoktora" OnSelectedIndexChanged="ddlDoktor_SelectedIndexChanged">
                            <Items>
                                <asp:ListItem Text="Odaberite doktora" Value="" Selected="True"></asp:ListItem>
                            </Items>
                        </asp:DropDownList>
                    </div>
                </div>



                <br />
                <div class="row">
                    <div class="col-md-offset-2 col-md-8 ">
                        <asp:GridView CssClass="table table-hover table-striped table-responsive table-bordered"
                            ID="GridViewPacijent"
                            DataKeyNames="PacijentKorisnickiRacunID" runat="server" AutoGenerateColumns="False"
                            OnSelectedIndexChanged="GridViewPacijent_SelectedIndexChanged">

                            <Columns>

                                <asp:TemplateField HeaderText="ID Pacijenta">
                                    <ItemTemplate>
                                        <asp:Label nulldisplaytext="Null" ID="lblPacijent" runat="server" Text='<%# Eval("PacijentKorisnickiRacunID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Naziv Pacijenta">
                                    <ItemTemplate>
                                        <asp:Label nulldisplaytext="Null" ID="lblNazivPacijenta" runat="server" Text='<%# Convert.ToString(Eval("NazivPacijenta")) == null ? "Nema" : Eval("NazivPacijenta") %>' />
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
                </div>
            </fieldset>
        </div>
    </div>


                    <asp:Label ID="lblStatusPacijenti" runat="server" Text="" CssClass="col-md-offset-4"></asp:Label>


   
    <div class="row">

        <br />
        <br />
        <div class="col-md-8 col-md-offset-2">
            <fieldset>
                <legend>Terapije</legend>

                  <div class="form-group">
                    <asp:Label CssClass="control-label col-sm-2" ID="lblOdabirTerapije" runat="server" Text="Odaberite terapiju:" AssociatedControlID="ddlTerapija"></asp:Label>
                    <div class="col-sm-10">
                        <asp:DropDownList CssClass="btn btn-default" ID="ddlTerapija" runat="server" AppendDataBoundItems="true" AutoPostBack="true" DataValueField="IDTerapija" DataTextField="Naziv" >
                            <Items>
                                <asp:ListItem Text="Odaberite terapiju" Value="" Selected="True"></asp:ListItem>
                            </Items>
                        </asp:DropDownList>
                        <asp:CustomValidator ID="CustomValidatorTerapija" runat="server" ErrorMessage="Odabir terapije je obavezan" OnServerValidate="CustomValidatorTerapija_ServerValidate"></asp:CustomValidator>
                    </div>
                </div>

                 <div class="form-group">
                    <asp:Label AssociatedControlID="txtDatumPocetka" ID="lblDatumPocetka" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Datum Početka:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtDatumPocetka" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtDatumPocetka" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtDatumPocetka"></asp:RequiredFieldValidator>
                    </div>
                </div>





                <div class="form-group">
        <div class="col-sm-10 col-sm-offset-2">

            <asp:Button CssClass="btn btn-default" ID="btnDodaj" runat="server" Text="Dodaj" OnClick="btnDodaj_Click" />
            <asp:Button CssClass="btn btn-default" ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button CssClass="btn btn-default" ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="false" />
        </div>
    </div>

                <div class="col-md-offset-2 col-md-8 ">
                    <asp:GridView CssClass="table table-hover table-striped table-responsive table-bordered"
                        ID="GridViewTerapija"
                        DataKeyNames="IDPlanTerapije" runat="server" AutoGenerateColumns="False"
                        OnSelectedIndexChanged="GridViewTerapija_SelectedIndexChanged"
                        >

                        <Columns>

                            <asp:TemplateField HeaderText="ID Plan Terapije">
                                <ItemTemplate>
                                    <asp:Label nulldisplaytext="Null" ID="lblPlanTerapije" runat="server" Text='<%# Eval("IDPlanTerapije") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ID Doktora">
                                <ItemTemplate>
                                    <asp:Label nulldisplaytext="Null" ID="lblDoktorID" runat="server" Text='<%# Convert.ToString(Eval("DoktorID")) == null ? "Nema" : Eval("DoktorID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ID Pacijenta">
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
                                    <asp:Label nulldisplaytext="Null" ID="lblDatumPocetka" runat="server" Text='<%#Eval("DatumPocetka","{0:dd-MM-yyyy}")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Datum Završetka">
                                <ItemTemplate>
                                    <asp:Label nulldisplaytext="Null" ID="lblDatumZavrsetka" runat="server" Text='<%#Eval("DatumZavrsetka","{0:dd-MM-yyyy}")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Brisanje">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lbDelete" Text="Delete" CommandArgument='<%#Eval("IDPlanTerapije") %>'
                                OnCommand="lbDelete_Command" CausesValidation ="false">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>


                            <asp:TemplateField HeaderText="Odabir">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnSelect" class="btn btn-link" runat="server" CommandName="Select" Text="Select" CausesValidation="false" />
                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>


                    </asp:GridView>
            
                    </div>
               </fieldset>
        </div>
    </div>





    <div class="com-md-2"></div>




</asp:Content>
