using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WorkScheduleSystem.Entities;
using WorkScheduleSystem.DAL;
using WorkScheduleSystem.ViewModels;
using System.ComponentModel; // to expose ODS wizard
#endregion

namespace WorkScheduleSystem.BLL
{
    [DataObject]
    public class EmployeeSkillController
    {
        #region Query used for EmployeesBySkill.aspx page
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<EmployeeSkillVM> Employees_GetEmployeesFromSkill(int skillid)
        {
            using (var context = new WorkScheduleContext())
            {
                IEnumerable<EmployeeSkillVM> results = from x in context.EmployeeSkills
                                                       where x.SkillID == skillid
                                                       select new EmployeeSkillVM
                                                       {
                                                           //FullName = x.Employee.FullName,
                                                           FullName = x.Employee.LastName + ", " + x.Employee.FirstName,
                                                           HomePhone = x.Employee.HomePhone,
                                                           Active = x.Employee.Active,
                                                           Level = x.Level,
                                                           YearsOfExperience = x.YearsOfExperience,
                                                           SkillID = x.SkillID
                                                       };
                return results.ToList();
            }
        }
        #endregion

        #region Queries used for ManageEmployeeSkills.aspx page for CRUD

        //query to return all data of the EmployeeSkills table

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<EmployeeSkillItem> EmployeesSkills_List()
        {
            using (var context = new WorkScheduleContext())
            {
                IEnumerable<EmployeeSkillItem> results = from x in context.EmployeeSkills
                                                         select new EmployeeSkillItem
                                                         {
                                                             EmployeeSkillID = x.EmployeeSkillID,
                                                             Employee = x.Employee.LastName + ", " + x.Employee.FirstName,
                                                             Skill = x.Skill.Description,
                                                             Level = x.Level,
                                                             YearsOfService = x.YearsOfExperience,
                                                             HourlyWage = x.HourlyWage
                                                         };
                return results.ToList();
            }
        }

        //query to look up an an EmployeeSkills record by PK(EmployeeSkillID)
         [DataObjectMethod(DataObjectMethodType.Select, false)]
         public EmployeeSkillItem EmployeesSkills_FindById(int employeeskillid) //this is just a single record thats why List<> and IEnumerable<> is not used
        {
            using (var context = new WorkScheduleContext())
            {
                // (...).FirstOrDefault will return either
                //      a) the first record matching the where condition
                //      b) a null value
                EmployeeSkillItem results = (from x in context.EmployeeSkills
                                            where x.EmployeeSkillID == employeeskillid
                                            select new EmployeeSkillItem
                                            {
                                                EmployeeSkillID = x.EmployeeSkillID,
                                                Employee = x.Employee.LastName + ", " + x.Employee.FirstName,
                                                Skill = x.Skill.Description,
                                                Level = x.Level,
                                                YearsOfService = x.YearsOfExperience,
                                                HourlyWage = x.HourlyWage
                                            }).FirstOrDefault();
                return results;
            }
        }
        #endregion

        #region Add, Update and Delete method

        // ADD
        [DataObjectMethod(DataObjectMethodType.Insert, false)]
        public int EmployeeSkill_Add(EmployeeSkillItem item) // this will return PK
        {
            using (var context = new WorkScheduleContext())
            {

                EmployeeSkill addItem = new EmployeeSkill
                {
                    //why no PK set?
                    //PK is an identity PK, no value is needed
                    //However, if PK is NOT an identity spec(Identity Specification = No in the DB), ADD PK here!!!
                    EmployeeID = item.EmployeeID,
                    SkillID = item.SkillID,
                    Level = item.Level,
                    YearsOfExperience = item.YearsOfService,
                    HourlyWage = item.HourlyWage
                };

                context.EmployeeSkills.Add(addItem);
                context.SaveChanges();

                return addItem.EmployeeSkillID;
            }
        }


        // UPDATE

        [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void EmployeeSkill_Update(EmployeeSkillItem item)
        {
            using (var context = new WorkScheduleContext())
            {
                EmployeeSkill updateItem = new EmployeeSkill
                {
                    //for an update, you need to supply your PK value
                    EmployeeSkillID = item.EmployeeSkillID,
                    EmployeeID = item.EmployeeID,
                    SkillID = item.SkillID,
                    Level = item.Level,
                    YearsOfExperience = item.YearsOfService,
                    HourlyWage = item.HourlyWage
                };
                context.Entry(updateItem).State = System.Data.Entity.EntityState.Modified;

                context.SaveChanges();
            }
        }


        // DELETE

        // overload EmployeeSkill_Delete method so so it receive a whole instance
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void EmployeeSkill_Delete(EmployeeSkillItem item)
        {
            EmployeeSkill_Delete(item.EmployeeSkillID);
        }

        public void EmployeeSkill_Delete(int employeeskillid)
        {
            using (var context = new WorkScheduleContext())
            {
                //example of a physical delete
                //retrieve the current entity instance based on the incoming parameter
                var exists = context.EmployeeSkills.Find(employeeskillid);
                //staged the remove
                context.EmployeeSkills.Remove(exists);
                //commit the remove
                context.SaveChanges();

                //a logical delete is actually an update of the instance
            }
        }
        #endregion
    }
}
