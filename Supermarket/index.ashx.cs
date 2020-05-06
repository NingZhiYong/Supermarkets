using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SupermarketBLL;
using SupermarketModel;
using System.Web.Script.Serialization;

namespace Supermarket
{
    /// <summary>
    /// index 的摘要说明
    /// </summary>
    public class index : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string act = context.Request.QueryString["act"];
            switch (act)
            {
                case "indexLogin":
                    this.indexLogin();
                    break;
                case "indexIdx":
                    this.indexIdx();
                    break;
                case "indexUser":
                    this.indexUser();
                    break;
            }
        }

        /// <summary>
        /// 登录页面
        /// </summary>
        private void indexLogin()
        {
            string lgn = HttpContext.Current.Request.Form["lgn"];
            string pwd = HttpContext.Current.Request.Form["pwd"];
            var user = indexBll.EmpSelect(lgn, pwd);

            var obj = new { status = "error" };
            if (user.Rows.Count > 0)
            {
                //缓存
                T_Employee employee = new T_Employee
                {
                    EmployeeID = Convert.ToInt32(user.Rows[0]["EmployeeID"].ToString()),
                    Login = user.Rows[0]["Login"].ToString(),
                    Passwd = user.Rows[0]["Passwd"].ToString(),
                    Name = user.Rows[0]["Name"].ToString(),
                    Photo = user.Rows[0]["Photo"].ToString(),
                    Sex =Convert.ToInt32(user.Rows[0]["Sex"].ToString()),
                    Telephone = user.Rows[0]["Telephone"].ToString(),
                    Role = new T_Role
                    {
                        RoleID = Convert.ToInt32(user.Rows[0]["RoleID"].ToString())
                    }
                };

                HttpContext.Current.Cache["emp"] = employee;
                obj = new { status = "success" };
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(obj);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 根据登录员工权限显示对应功能
        /// </summary>
        private void indexIdx()
        {
            //获取登录员工的信息
            T_Employee emp = HttpContext.Current.Cache["emp"] as T_Employee;
            //获取权限信息
            var power = indexBll.PowerSelect(emp);
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(power);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 显示用户信息
        /// </summary>
        public void indexUser()
        {
            T_Employee emp = HttpContext.Current.Cache["emp"] as T_Employee;
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(emp);
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