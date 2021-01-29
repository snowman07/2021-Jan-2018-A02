<%@ Page Title="Test Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="WebApp.SamplePages.TestPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>This is a Test Page</h1>
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectDataSource2" DataTextField="ValueField" DataValueField="ValueField"></asp:DropDownList>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Skills_DDLLists" TypeName="WorkScheduleSystem.BLL.SkillController"></asp:ObjectDataSource>

    <div class="row">
        <div class="offset-3">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
                <Columns>
                    <asp:TemplateField HeaderText="FullName" SortExpression="FullName">
                        <EditItemTemplate>
                            <asp:TextBox runat="server" Text='<%# Bind("FullName") %>' ID="TextBox1"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Bind("FullName") %>' ID="Label1"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="HomePhone" SortExpression="HomePhone">
                        <EditItemTemplate>
                            <asp:TextBox runat="server" Text='<%# Bind("HomePhone") %>' ID="TextBox2"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Bind("HomePhone") %>' ID="Label2"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Active" SortExpression="Active">
                        <EditItemTemplate>
                            <asp:CheckBox runat="server" Checked='<%# Bind("Active") %>' ID="CheckBox1"></asp:CheckBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" Checked='<%# Bind("Active") %>' Enabled="false" ID="CheckBox1"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Level" SortExpression="Level">
                        <EditItemTemplate>
                            <asp:TextBox runat="server" Text='<%# Bind("Level") %>' ID="TextBox3"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Bind("Level") %>' ID="Label3"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="YearsOfExperience" SortExpression="YearsOfExperience">
                        <EditItemTemplate>
                            <asp:TextBox runat="server" Text='<%# Bind("YearsOfExperience") %>' ID="TextBox4"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Bind("YearsOfExperience") %>' ID="Label4"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SkillID" SortExpression="SkillID">
                        <EditItemTemplate>
                            <asp:TextBox runat="server" Text='<%# Bind("SkillID") %>' ID="TextBox5"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Bind("SkillID") %>' ID="Label5"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Employees_GetEmployeesFromSkill" TypeName="WorkScheduleSystem.BLL.EmployeeSkillController">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" PropertyName="SelectedValue" Name="skillid" Type="Int32" DefaultValue="select...">

                    </asp:ControlParameter>
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
