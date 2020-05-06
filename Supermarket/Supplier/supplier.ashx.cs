using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using SupermarketModel;
using SupermarketBLL;
namespace Supermarket.Supplier
{
    /// <summary>
    /// supplier 的摘要说明
    /// </summary>
    public class supplier : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string act = context.Request.QueryString["act"];
            switch (act)
            {
                case "supplierSelect":
                    this.supplierSelect();
                    break;
                case "supplierDel":
                    this.supplierDel();
                    break;
                case "SupplierEditSelect":
                    this.SupplierEditSelect();
                    break;
                case "SupplierEdit":
                    this.SupplierEdit();
                    break;
                case "SupplierAdd":
                    this.SupplierAdd();
                    break;
            }
        }

        /// <summary>
        /// 查询供应商表
        /// </summary>
        private void supplierSelect()
        {
            string supplierName = HttpContext.Current.Request.QueryString["supplierName"];
            int page = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"]);
            int limit = Convert.ToInt32(HttpContext.Current.Request.QueryString["limit"]);


            object tab = supplierBll.SupplierSelect(supplierName, page, limit);

            JavaScriptSerializer js = new JavaScriptSerializer();
            var str = js.Serialize(tab);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 删除供应商
        /// </summary>
        private void supplierDel()
        {
            int SupplierID = Convert.ToInt32(HttpContext.Current.Request.QueryString["SupplierID"]);
            var obj = new
            {
                status = 200
            };
            if (supplierBll.SupplierDel(SupplierID))
            {
                obj = new { status = 201 };
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(obj);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 供应商编辑查询
        /// </summary>
        private void SupplierEditSelect()
        {
            int SupplierID = Convert.ToInt32(HttpContext.Current.Request.QueryString["SupplierID"]);
            var db = supplierBll.SupplierEditSelect(SupplierID);
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(db);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 供应商编辑
        /// </summary>
        private void SupplierEdit()
        {
            T_Supplier supplier = new T_Supplier
            {
                SupplierID = Convert.ToInt32(HttpContext.Current.Request.Form["SupplierID"]),
                SupplierName = HttpContext.Current.Request.Form["SupplierName"].ToString(),
                LinkMan = HttpContext.Current.Request.Form["LinkMan"].ToString(),
                Address = HttpContext.Current.Request.Form["Address"].ToString(),
                Mobile = HttpContext.Current.Request.Form["Mobile"].ToString(),
                Status = Convert.ToInt32(HttpContext.Current.Request.Form["Status"].ToString())
            };

            var obj = new { status = 200, msg = "no" };
            if (supplierBll.SupplierEdit(supplier))
            {
                obj = new { status = 201, msg = "yes" };
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(obj);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 新增供应商
        /// </summary>
        private void SupplierAdd()
        {
            T_Supplier supplier = new T_Supplier
            {
                SupplierName = HttpContext.Current.Request.Form["SupplierName"].ToString(),
                LinkMan = HttpContext.Current.Request.Form["LinkMan"].ToString(),
                Address = HttpContext.Current.Request.Form["Address"].ToString(),
                Mobile = HttpContext.Current.Request.Form["Mobile"].ToString(),
                Status = Convert.ToInt32(HttpContext.Current.Request.Form["Status"])
            };
            var obj = new { status = 200, msg = "no" };
            if (supplierBll.SupplierAdd(supplier))
            {
                obj = new { status = 201, msg = "yes" };
            }
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