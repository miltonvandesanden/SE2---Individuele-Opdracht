<%@ Page Title="" Language="C#" MasterPageFile="~/InterfaceLayer/Masterpage.Master" AutoEventWireup="true" CodeBehind="PageAdvertControl.aspx.cs" Inherits="SE2___Individuele_Opdracht.InterfaceLayer.PageAdvertControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="row">
            <h1>My Adverts</h1>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Text="My Adverts: " Width="100%"/>
            </div>
            <div class="col-md-2">
                <asp:DropDownList ID="dropdownAdvertControlMyAdvertsAdverts" runat="server" Width="100%" OnSelectedIndexChanged="dropdownAdvertControlMyAdvertsAdverts_SelectedIndexChanged"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Text="Title: " Width="100%"/>
            </div>
            <div class="col-md-2">
                <asp:Label ID="lblAdvertControlMyAdvertsTitle" runat="server" Width="100%" Text="placeholder"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Text="CreationDate: " Width="100%"/>
            </div>
            <div class="col-md-2">
                <asp:Label ID="lblAdvertControlMyAdvertsCreationDate" runat="server" Width="100%" Text="placeholder"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Text="views: " Width="100%"/>
            </div>
            <div class="col-md-2">
                <asp:Label ID="lblAdvertControlMyAdvertsViews" runat="server" Width="100%" Text="-1"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Width="100%" Text="Category: "/>
            </div>
            <div class="col-md-2">
                <asp:Label ID="lblAdvertControlMyAdvertsCategory" runat="server" Width="100%" Text="placeholder"/>
            </div>
        </div>        
    </div>
    
    <div>
        <div class="row">
            <div class="col-md-4">
                <h1>New Service</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Width="100%" Text="title: "/>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="tbAdvertControlNewServiceTitle" runat="server" Width="100%" Text="placeholder"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Width="100%" Text="Category: "/>
            </div>
            <div class="col-md-2">
                <asp:DropDownList ID="dropdownAdvertControlNewServiceCategory" runat="server" Width="100%"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Width="100%" Text="Experience: "/>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="tbAdvertControlNewServiceExperience" runat="server" Width="100%" Text="placeholder"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Width="100%" Text="Employees: "/>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="tbAdvertControlNewServiceEmployees" runat="server" Width="100%" Text="placeholder"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Width="100%" Text="CompanyType: "/>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="tbAdvertControlNewServiceCompanyType" runat="server" Width="100%" Text="placeholder"/>
            </div>
        </div>
    </div>
        <div>
        <div class="row">
            <div class="col-md-4">
                <h1>New Good</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Width="100%" Text="title: "/>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="tbAdvertControlNewGoodTitle" runat="server" Width="100%" Text="placeholder"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Width="100%" Text="Category: "/>
            </div>
            <div class="col-md-2">
                <asp:DropDownList ID="dropdownAdvertControlNewGoodCategory" runat="server" Width="100%"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Width="100%" Text="Experience: "/>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="TextBox2" runat="server" Width="100%" Text="placeholder"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Width="100%" Text="Employees: "/>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="TextBox3" runat="server" Width="100%" Text="placeholder"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label runat="server" Width="100%" Text="CompanyType: "/>
            </div>
            <div class="col-md-2">
                <asp:TextBox ID="TextBox4" runat="server" Width="100%" Text="placeholder"/>
            </div>
        </div>
    </div>
</asp:Content>
