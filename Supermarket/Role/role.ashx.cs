using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using SupermarketModel;
using SupermarketBLL;

namespace Supermarket.Role
{
    /// <summary>
    /// role 的摘要说明
    /// </summary>
    public class role : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string act = HttpContext.Current.Request.QueryString["act"];
            switch (act)
            {
                case "RoleSelect":
                    this.RoleSelect();
                    break;
                case "RoleTreeUpdate":
                    this.RoleTreeUpdate();
                    break;
            }
        }

        private void RoleTreeUpdate()
        {
            JavaScriptSerializer Serializer = new JavaScriptSerializer();
            var checkedData = HttpContext.Current.Request.Form["checkedData"];
            List<RoleList> roleList = Serializer.Deserialize<List<RoleList>>(checkedData);
        }

        /// <summary>
        /// 查询角色表
        /// </summary>
        private void RoleSelect()
        {
            int page = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"]);
            int limit = Convert.ToInt32(HttpContext.Current.Request.QueryString["limit"]);
            var obj = roleBll.RoleSelect(page, limit);
            javaScriptSerializer(obj);
        }

        private void javaScriptSerializer(object obj)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(obj);
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