<%@ Page Title="Employees By Skill" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesBySkill.aspx.cs" Inherits="WebApp.SamplePages.EmployeesBySkill" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>This is a page for Employees By Skill</h1><br /><br />
    <%-- search area --%>
    <div class="row">
        <div class="offset-3">
            <asp:Label ID="Label1" runat="server" Text="Select a Skill:">

            </asp:Label> &nbsp;&nbsp;
            <asp:DropDownList ID="SkillListDDL" runat="server">

            </asp:DropDownList> &nbsp;&nbsp;
            <asp:LinkButton ID="SearchEmployee" runat="server" OnClick="SearchEmployee_Click">
                Search
            </asp:LinkButton>
        </div>
    </div>
    <br /><br />
    <%-- END of search area --%>

    <%-- area for messages --%>
    <div class="row">
        <div class="offset-3">
            <%--<asp:Label ID="Message" runat="server"></asp:Label>--%>
            <uc1:messageusercontrol runat="server" id="MessageUserControl" /> <br/><br/>
        </div>
    </div>
    <%-- END OF area for messages --%>

    <%-- gridview and ODS area --%>
    <div class="row">
        <div class="offset-3">
            <asp:GridView ID="EmployeeSkillGV" runat="server"
                AutoGenerateColumns="False"
                AllowPaging="True"
                CssClass="table table-striped"
                BorderStyle="Ridge">

                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("FullName") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phone">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("HomePhone") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Active">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server"
                                 Checked='<%# Eval("Active") %>'/>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center">
                        </ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SkillLevel">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" 
                                Text='<%# Eval("Level").ToString() == "1" ? "Novice" :
                                    Eval("Level").ToString() == "2" ? "Proficient" :
                                    Eval("Level").ToString() == "3" ? "Expert" :
                                    Eval("Level")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left">
                        </ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="YOE">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("YearsOfExperience") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left">
                        </ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="EmployeeSkillODS" runat="server" 
                OldValuesParameterFormatString="original_{0}" 
                SelectMethod="Skills_DDLLists" 
                TypeName="WorkScheduleSystem.BLL.SkillController">
            </asp:ObjectDataSource>
        </div>
    </div>
    <%-- END OF gridview and ODS area --%>

</asp:Content>
