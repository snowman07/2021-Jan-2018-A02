<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MultiViewSetup.aspx.cs" Inherits="WebApp.SamplePages.MultiViewSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>MultiView Control Setup</h1>
    <div class="row">
        <div class="offset-1">
            <asp:Label ID="Label1" runat="server" Text="Common data or controls on the web page independent of the multiview control">

            </asp:Label>
        </div>
    </div>

   <%-- START OF MENU AREA --%>
    <div class="row">
        <div class="offset-1">
            <asp:Menu ID="Menu1" runat="server"
                 Font-Size="Large"
                 Orientation="Horizontal"
                 CssClass="tabs"
                 StaticSelectedStyle-CssClass="selectedTab"
                 StaticSelectedStyle-BackColor="LightBlue"
                 StaticMenuItemStyle-HorizontalPadding="50px" OnMenuItemClick="Menu1_MenuItemClick">

                <Items>
                    <asp:MenuItem Text="Page 1" Value="0" Selected="True"></asp:MenuItem>
                    <asp:MenuItem Text="Page 2" Value="1"></asp:MenuItem>
                    <asp:MenuItem Text="Page 3" Value="2"></asp:MenuItem>
                </Items>
            </asp:Menu>
        </div>
    </div>
    <%-- END OF MENU AREA --%>

    <%-- START OF MULTIVIEW AREA --%>
    <div class="row">
        <div class="offset-1">
            <asp:MultiView ID="MultiView1" runat="server"
                 ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    <asp:TextBox ID="IODataV1" runat="server"></asp:TextBox>
                    <asp:Button ID="SendTo2From1" runat="server" Text="Send To 2 From 1" OnClick="SendTo2From1_Click" />
                    <asp:Button ID="SendTo3From1" runat="server" Text="Send To 3 From 1" OnClick="SendTo3From1_Click" />
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    <asp:TextBox ID="IODataV2" runat="server"></asp:TextBox>
                    <asp:Button ID="SendTo1From2" runat="server" Text="Send To 1 From 2" OnClick="SendTo1From2_Click" />
                    <asp:Button ID="SendTo3From2" runat="server" Text="Send To 3 From 2" OnClick="SendTo3From2_Click" />
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    <asp:TextBox ID="IODataV3" runat="server"></asp:TextBox>
                    <asp:Button ID="SendTo1From3" runat="server" Text="Send To 1 From 3" OnClick="SendTo1From3_Click" />
                    <asp:Button ID="SendTo2From3" runat="server" Text="Send To 2 From 3" OnClick="SendTo2From3_Click" />
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
    <%-- END OF MULTIVIEW AREA --%>



    <%-- START OF PANEL VIEW --%>
    <br/><br/><br/>
    <div class="row">
        <div class="col-md-12">
            <ul class="nav nav-tabs">
                <li class="active">
                    <a href="#shopping" data-toggle="tab" id="shoppingOpen">Continue Shopping</a>
                </li>
                <li>
                    <a href="#shoppingcart" data-toggle="tab" id="cartOpen">View Cart</a>               
                </li>
                <li>
                    <a href="#checkout" data-toggle="tab" id="checkoutOpen">Checkout</a>
                </li>
            </ul>
            <br/>

            <div class="tab-content">
                <div class="tab-pane active" id="shopping">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label5" runat="server" Text="Continue Shopping"></asp:Label>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            <asp:Button ID="Add" runat="server" Text="Add to 2nd tab" OnClick="Add_Click"/>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="tab-pane" id="shoppingcart">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label6" runat="server" Text="View Cart"></asp:Label>
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            <asp:Button ID="Checkout" runat="server" Text="Send to checkout 3rd tab" OnClick="Checkout_Click"/>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="tab-pane" id="checkout">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Label7" runat="server" Text="Checkout"></asp:Label>
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    
    <%-- END OF PANEL VIEW --%>

    <script>
        function openCart() {
            $('#cartOpen').trigger('click')
            return false;
        }
        function openShopping() {
            $('#shoppingOpen').trigger('click')
        }
        function openCheckout() {
            $('#checkoutOpen').trigger('click')
        }
    </script>

</asp:Content>
