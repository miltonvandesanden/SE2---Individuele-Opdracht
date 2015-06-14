<%@ Page Title="" Language="C#" MasterPageFile="~/InterfaceLayer/Masterpage.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="SE2___Individuele_Opdracht.InterfaceLayer.CreateAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h1>Account Creation</h1>
    </div>
    <div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Text="Username: " Width="100%"/>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="tbAccountCreationUsername" runat="server" Width="100%" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Text="Password: " Width="100%"/>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="tbAccountCreationPassword" runat="server" Width="100%"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Text="Email: " Width="100%"/>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="tbAccountCreationEmail" runat="server" Width="100%"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Text="PhoneNumber" Width="100%"/>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="tbAccountCreationPhone" runat="server" Width="100%"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Text="Postalcode" Width="100%"/>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="tbAccountCreationPostalcode" runat="server" Width="100%"/>
            </div>
        </div>
    </div>
    <div>
        <div class="row">
            <div class="col-md-4">
                <asp:Button ID="btnAccountCreationCreate" runat="server" Text="Create Account" Width="100%" CssClass="btn btn-primary" OnClick="btnAccountCreationCreate_Click" />
            </div>
        </div>
    </div>
</asp:Content>
