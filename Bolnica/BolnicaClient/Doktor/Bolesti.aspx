<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Bolesti.aspx.cs" Inherits="BolnicaClient.Doktor.Bolesti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="row">

        <br />
        <br />
        <div class="col-md-8 col-md-offset-2">
            <fieldset>
                <legend>Bolesti</legend>

                <div class="form-group">
                    <asp:Label ID="l" ControlStyle-CssClass="control-label  col-sm-2" runat="server">ID Bolesti:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtIDBolest" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label AssociatedControlID="txtNazivBolesti" ID="lblBolest" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Naziv Bolesti:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtNazivBolesti" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtNazivBolesti"></asp:RequiredFieldValidator>
                    </div>
                </div>

                
                <div class="form-group">
                    <asp:Label AssociatedControlID="txtGodinaOtkrica" ID="Label1" ControlStyle-CssClass="control-label  col-sm-2" runat="server">Godina otkrića:</asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtGodinaOtkrica" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Obavezan unos" ControlToValidate="txtGodinaOtkrica"></asp:RequiredFieldValidator>
                    </div>
                </div>

                 <div class="form-group">
                <asp:Label CssClass="control-label col-sm-2" ID="lblOpasnostID" runat="server" Text="Skala opasnosti:" AssociatedControlID="ddlOpasnosti"></asp:Label>
                <div class="col-sm-10">
                    <asp:DropDownList CssClass="btn btn-default" ID="ddlOpasnosti" runat="server" AppendDataBoundItems="true" AutoPostBack="false" DataValueField="IDopasnost" DataTextField="Opasnost">
                        <Items>
                            <asp:ListItem Text="Odaberite opasnost" Value="" Selected="True"></asp:ListItem>
                        </Items>
                    </asp:DropDownList>
                    <asp:CustomValidator ID="CustomValidatorOdabirOpasnosti" runat="server" ErrorMessage="Molimo odaberite opasnost" OnServerValidate="CustomValidatorOdabirOpasnosti_ServerValidate"></asp:CustomValidator>
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
                ID="GridviewBolest" 
                DataKeyNames="IDBolest" runat="server" AutoGenerateColumns="False" 
                OnSelectedIndexChanged="GridviewBolest_SelectedIndexChanged">

                <Columns>

                    <asp:TemplateField HeaderText="ID Bolest">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="IDBolest" runat="server" Text='<%# Eval("IDBolest") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Naziv Bolesta">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblNazivBolesti" runat="server" Text='<%# Convert.ToString(Eval("NazivBolesti")) == null ? "Nema" : Eval("NazivBolesti") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                  <asp:TemplateField HeaderText="Godina otkrića">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblGodinaOtkrica" runat="server" Text='<%# Convert.ToString(Eval("GodinaOtkrica")) == null ? "Nema" : Eval("GodinaOtkrica") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="ID opasnosti">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblOpasnostID" runat="server" Text='<%# Convert.ToString(Eval("OpasnostID")) == null ? "Nema" : Eval("OpasnostID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Opasnost">
                        <ItemTemplate>
                            <asp:Label nulldisplaytext="Null" ID="lblOpasnost" runat="server" Text='<%# Convert.ToString(Eval("Opasnost")) == null ? "Nema" : Eval("Opasnost") %>' />
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
