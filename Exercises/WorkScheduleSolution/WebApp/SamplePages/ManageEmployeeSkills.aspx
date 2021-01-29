<%@ Page Title="Manage Employee Skills" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageEmployeeSkills.aspx.cs" Inherits="WebApp.SamplePages.ManageEmployeeSkills" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Manage Employee Skills</h1>
    <div class="row">
        <div class="offset-2">

        </div>
    </div> 
    <%--END OF row--%>

    <%--ListView area--%>
    <div class="row">
        <div class="offset-2">

            <%-- REMINDER: to use the attribute DataKeyNames to get the
            DELETE function of your ListView CRUD to work
            
            The DataKeyNames attribute is set to your PK field--%>
            <asp:ListView ID="EmployeeSkillLV" runat="server" 
                DataSourceID="EmployeeSkillODS" 
                InsertItemPosition="FirstItem"
                 DataKeyNames="EmployeeSkillID">

                <AlternatingItemTemplate>
                    <tr style="background-color: #FFFFFF; color: #284775;">
                        <td>
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                        </td>
                        <td>
                            <asp:Label Text='<%# Eval("EmployeeSkillID") %>' runat="server" ID="EmployeeSkillIDLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("EmployeeID") %>' runat="server" ID="EmployeeIDLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("Employee") %>' runat="server" ID="EmployeeLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("SkillID") %>' runat="server" ID="SkillIDLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("Skill") %>' runat="server" ID="SkillLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("Level") %>' runat="server" ID="LevelLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("YearsOfService") %>' runat="server" ID="YearsOfServiceLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("HourlyWage") %>' runat="server" ID="HourlyWageLabel" /></td>
                    </tr>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <tr style="background-color: #999999;">
                        <td>
                            <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# Bind("EmployeeSkillID") %>' runat="server" ID="EmployeeSkillIDTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("EmployeeID") %>' runat="server" ID="EmployeeIDTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("Employee") %>' runat="server" ID="EmployeeTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("SkillID") %>' runat="server" ID="SkillIDTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("Skill") %>' runat="server" ID="SkillTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("Level") %>' runat="server" ID="LevelTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("YearsOfService") %>' runat="server" ID="YearsOfServiceTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("HourlyWage") %>' runat="server" ID="HourlyWageTextBox" /></td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# Bind("EmployeeSkillID") %>' runat="server" ID="EmployeeSkillIDTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("EmployeeID") %>' runat="server" ID="EmployeeIDTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("Employee") %>' runat="server" ID="EmployeeTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("SkillID") %>' runat="server" ID="SkillIDTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("Skill") %>' runat="server" ID="SkillTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("Level") %>' runat="server" ID="LevelTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("YearsOfService") %>' runat="server" ID="YearsOfServiceTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("HourlyWage") %>' runat="server" ID="HourlyWageTextBox" /></td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="background-color: #E0FFFF; color: #333333;">
                        <td>
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                        </td>
                        <td>
                            <asp:Label Text='<%# Eval("EmployeeSkillID") %>' runat="server" ID="EmployeeSkillIDLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("EmployeeID") %>' runat="server" ID="EmployeeIDLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("Employee") %>' runat="server" ID="EmployeeLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("SkillID") %>' runat="server" ID="SkillIDLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("Skill") %>' runat="server" ID="SkillLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("Level") %>' runat="server" ID="LevelLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("YearsOfService") %>' runat="server" ID="YearsOfServiceLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("HourlyWage") %>' runat="server" ID="HourlyWageLabel" /></td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table runat="server" id="itemPlaceholderContainer" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                    <tr runat="server" style="background-color: #E0FFFF; color: #333333;">
                                        <th runat="server"></th>
                                        <th runat="server">EmployeeSkillID</th>
                                        <th runat="server">EmployeeID</th>
                                        <th runat="server">Employee</th>
                                        <th runat="server">SkillID</th>
                                        <th runat="server">Skill</th>
                                        <th runat="server">Level</th>
                                        <th runat="server">YearsOfService</th>
                                        <th runat="server">HourlyWage</th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder"></tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF">
                                <asp:DataPager runat="server" ID="DataPager1">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                        <asp:NumericPagerField></asp:NumericPagerField>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <tr style="background-color: #E2DED6; font-weight: bold; color: #333333;">
                        <td>
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                        </td>
                        <td>
                            <asp:Label Text='<%# Eval("EmployeeSkillID") %>' runat="server" ID="EmployeeSkillIDLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("EmployeeID") %>' runat="server" ID="EmployeeIDLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("Employee") %>' runat="server" ID="EmployeeLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("SkillID") %>' runat="server" ID="SkillIDLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("Skill") %>' runat="server" ID="SkillLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("Level") %>' runat="server" ID="LevelLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("YearsOfService") %>' runat="server" ID="YearsOfServiceLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("HourlyWage") %>' runat="server" ID="HourlyWageLabel" /></td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>
            <asp:ObjectDataSource ID="EmployeeSkillODS" runat="server" 
                DataObjectTypeName="WorkScheduleSystem.ViewModels.EmployeeSkillItem" 
                DeleteMethod="EmployeeSkill_Delete" 
                InsertMethod="EmployeeSkill_Add" 
                SelectMethod="EmployeesSkills_List" 
                UpdateMethod="EmployeeSkill_Update"
                OldValuesParameterFormatString="original_{0}" 
                TypeName="WorkScheduleSystem.BLL.EmployeeSkillController" >
            </asp:ObjectDataSource>
        </div>
    </div>
    <%--END OF ListView area--%>
</asp:Content>
