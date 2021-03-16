<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MultiViewSetup.aspx.cs" Inherits="WebApp.SamplePages.MultiViewSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>MultiView Control Setup</h1>
    <div class="row">
        <div class="offset-1">
            <asp:Label ID="Label1" runat="server" Text="Common data or controls on the web page independent">

            </asp:Label>
        </div>
    </div>

    <div class="row">
        <div class="offset-1">
            <asp:Menu ID="Menu1" runat="server">

            </asp:Menu>
        </div>
    </div>
</asp:Content>
