using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using SupermarketBLL;
using SupermarketModel;

namespace Supermarket.Employee
{
    /// <summary>
    /// employee 的摘要说明
    /// </summary>
    public class employee : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string act = HttpContext.Current.Request.QueryString["act"];
            switch (act)
            {
                case "employeeSelect":
                    this.employeeSelect();
                    break;
                case "RoleSelect":
                    this.RoleSelect();
                    break;
                case "employeeAdd":
                    this.employeeAdd();
                    break;
                case "employeeDel":
                    this.employeeDel();
                    break;
                case "empEditSelect":
                    this.empEditSelect();
                    break;
                case "employeeEdit":
                    this.employeeEdit();
                    break;
            }
        }

        /// <summary>
        /// 新增一个用户
        /// </summary>
        private void employeeAdd()
        {
            string Login = HttpContext.Current.Request.Form["Login"];
            string Passwd = HttpContext.Current.Request.Form["Passwd"];
            string Name = HttpContext.Current.Request.Form["Name"];
            int Sex = Convert.ToInt32(HttpContext.Current.Request.Form["sex"]);
            string Telephone = HttpContext.Current.Request.Form["Telephone"];
            int RoleId = Convert.ToInt32(HttpContext.Current.Request.Form["Role"]);
            T_Employee employe = new T_Employee
            {
                Login = Login,
                Name = Name,
                Passwd = Passwd,
                Sex = Sex,
                Telephone = Telephone,
                Role = new T_Role
                {
                    RoleID = RoleId
                }
            };
            var obj = new { code = 200, status = "no", msg = "失败" };
            if (employeeBll.employeeAdd(employe))
            {
                obj = new { code = 201, status = "yes", msg = "成功" };
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(obj);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 用户管理--查询
        /// </summary>
        private void employeeSelect()
        {
            int page = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"]);
            int limit = Convert.ToInt32(HttpContext.Current.Request.QueryString["limit"]);

            var tab = employeeBll.employeeSelect(page, limit);
            JavaScriptSerializer js = new JavaScriptSerializer();
            var str = js.Serialize(tab);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 用户新增时 角色查询
        /// </summary>
        private void RoleSelect()
        {
            var tab = employeeBll.RoleSelect();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(tab);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 删除一个用户
        /// </summary>
        private void employeeDel()
        {
            int empId = Convert.ToInt32(HttpContext.Current.Request.Form["empId"]);
            var obj = new { code = 200, status = "no", msg = "删除失败" };
            if (employeeBll.employeeDel(empId))
            {
                obj = new { code = 201, status = "yes", msg = "删除成功" };
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(obj);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 编辑用户查询
        /// </summary>
        private void empEditSelect()
        {
            int empId = Convert.ToInt32(HttpContext.Current.Request.QueryString["empId"]);
            var db = employeeBll.empEditSelect(empId);
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(db);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        private void employeeEdit()
        {
            T_Employee emp = new T_Employee
            {
                EmployeeID = Convert.ToInt32(HttpContext.Current.Request.Form["EmployeeID"]),
                Name = HttpContext.Current.Request.Form["Name"],
                Login = HttpContext.Current.Request.Form["Login"],
                Passwd = HttpContext.Current.Request.Form["Passwd"],
                Sex = Convert.ToInt32(HttpContext.Current.Request.Form["sex"]),
                Telephone = HttpContext.Current.Request.Form["Telephone"],
                Role = new T_Role
                {
                    RoleID = Convert.ToInt32(HttpContext.Current.Request.Form["Role"]),
                }
            };

            var obj = new { code = 200, status = "no", msg = "失败" };
            if (employeeBll.employeeEdit(emp))
            {
                obj = new { code = 201, status = "yes", msg = "成功" };
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            var str = js.Serialize(obj);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}