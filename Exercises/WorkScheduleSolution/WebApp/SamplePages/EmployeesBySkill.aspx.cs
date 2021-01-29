using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using WorkScheduleSystem.DAL;
using WorkScheduleSystem.BLL;
using WorkScheduleSystem.ViewModels;
#endregion

namespace WebApp.SamplePages
{
    public partial class EmployeesBySkill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                //this is for the first time
                LoadSkillList();
            }
        }

        #region Code-behind for DropDownList in search area
        protected void LoadSkillList()
        {
            SkillController sysmgr = new SkillController();
            List<SelectionList> info = sysmgr.Skills_DDLLists();

            // lets assume the data collection needs to be sorted
            info.Sort((x, y) => x.DisplayField.CompareTo(y.DisplayField));

            //setup the ddl
            SkillListDDL.DataSource = info; //SkillList is the ID of the DropDownList
            //SkillList.DataTextField = "DisplayField";
            SkillListDDL.DataTextField = nameof(SelectionList.DisplayField); //nameof(object.property)
            SkillListDDL.DataValueField = nameof(SelectionList.ValueField); //nameof(object.property)
            SkillListDDL.DataBind();

            //prompt line
            SkillListDDL.Items.Insert(0, new ListItem("select ...", "0"));
        }
        #endregion

        #region Code-behind of Search click in search area
        protected void SearchEmployee_Click(object sender, EventArgs e)
        {
            if (SkillListDDL.SelectedIndex == 0)
            {
                // index 0 is physically pointing to the prompt line
                // Message.Text = "Select skill for the search.";
                MessageUserControl.ShowInfo("Warning!!!", "You need to select a skill.");
                EmployeeSkillGV.DataSource = null;
                EmployeeSkillGV.DataBind();
            }
            else
            {
                ////CODE WITHOUT MessageUserControl
                //EmployeeSkillController sysmgr = new EmployeeSkillController();
                //List<EmployeeSkillVM> info = sysmgr.Employees_GetEmployeesFromSkill(int.Parse(SkillListDDL.SelectedValue));
                ////Message.Text = "Here's the result";
                //EmployeeSkillGV.DataSource = info;
                //EmployeeSkillGV.DataBind();

                MessageUserControl.TryRun(() => {
                    EmployeeSkillController sysmgr = new EmployeeSkillController();
                    List<EmployeeSkillVM> info = sysmgr.Employees_GetEmployeesFromSkill(int.Parse(SkillListDDL.SelectedValue));
                    //Message.Text = "Here's the result";
                    EmployeeSkillGV.DataSource = info;
                    EmployeeSkillGV.DataBind();
                }, "Result", "Here's the list of Employees base from the Skill:");
            }
        }
        #endregion
    }
}