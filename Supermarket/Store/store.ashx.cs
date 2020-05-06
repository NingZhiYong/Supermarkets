using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SupermarketModel;
using SupermarketBLL;
using System.Web.Script.Serialization;

namespace Supermarket.Store
{
    /// <summary>
    /// store 的摘要说明
    /// </summary>
    public class store : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string act = HttpContext.Current.Request.QueryString["act"];
            switch (act)
            {
                case "storeSelect":
                    this.storeSelect();
                    break;
                case "storeEditSelect":
                    this.storeEditSelect();
                    break;
                case "StoreAdd":
                    this.storeAdd();
                    break;
                case "StoreEdit":
                    this.StoreEdit();
                    break;
                case "StoreProductList":
                    this.StoreProductList();
                    break;
                case "StoreNameSelect":
                    this.StoreNameSelect();
                    break;
            }
        }

        /// <summary>
        /// 仓库名称 仓库状态
        /// </summary>
        private void StoreNameSelect()
        {
            int StoreId = Convert.ToInt32(HttpContext.Current.Request.QueryString["StoreId"]);
            var db = storeBll.StoreNameSelect(StoreId);
            javaScriptSerializer(db);
        }

        /// <summary>
        /// 仓库详细查询
        /// </summary>
        private void StoreProductList()
        {
            int page = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"]);
            int limit = Convert.ToInt32(HttpContext.Current.Request.QueryString["limit"]);
            int StoreId = Convert.ToInt32(HttpContext.Current.Request.QueryString["StoreId"]);
            string ShopName = HttpContext.Current.Request.QueryString["ShopName"];
            object tab = storeBll.StoreProductList(page, limit, StoreId, ShopName);
            javaScriptSerializer(tab);
        }

        /// <summary>
        /// 编辑仓库信息
        /// </summary>
        private void StoreEdit()
        {
            T_Store store = new T_Store
            {
                StoreID = Convert.ToInt32(HttpContext.Current.Request.Form["StoreId"]),
                Name = HttpContext.Current.Request.Form["Name"],
                Status = Convert.ToInt32(HttpContext.Current.Request.Form["Status"])
            };
            var obj = new
            {
                code = 200,
                status = "no",
                msg = "编辑失败"
            };
            if (storeBll.storeEdit(store))
            {
                obj = new
                {
                    code = 201,
                    status = "yes",
                    msg = "编辑成功"
                };
            }
            javaScriptSerializer(obj);
        }

        /// <summary>
        /// 新增仓库
        /// </summary>
        private void storeAdd()
        {
            T_Store store = new T_Store
            {
                Name = HttpContext.Current.Request.Form["Name"],
                Status = Convert.ToInt32(HttpContext.Current.Request.Form["Status"])
            };
            var obj = new
            {
                code = 200,
                status = "no",
                msg = "新增失败"
            };
            if (storeBll.storeAdd(store))
            {
                obj = new
                {
                    code = 201,
                    status = "yes",
                    msg = "新增成功"
                };
            }
            javaScriptSerializer(obj);
        }

        /// <summary>
        /// 仓库编辑查询赋值
        /// </summary>
        private void storeEditSelect()
        {
            int storeId = Convert.ToInt32(HttpContext.Current.Request.QueryString["StoreId"]);
            object tab = storeBll.storeEditSelect(storeId);

            javaScriptSerializer(tab);
        }

        /// <summary>
        /// 仓库管理查询
        /// </summary>
        private void storeSelect()
        {
            int page = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"]);
            int limit = Convert.ToInt32(HttpContext.Current.Request.QueryString["limit"]);
            object tab = storeBll.storeSelect(page, limit);

            javaScriptSerializer(tab);
        }

        /// <summary>
        /// 序列化方法
        /// </summary>
        /// <param name="tab"></param>
        public void javaScriptSerializer(object tab)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var str = js.Serialize(tab);
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