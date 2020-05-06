using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using SupermarketBLL;
using SupermarketModel;

namespace Supermarket.Allot
{
    /// <summary>
    /// Allot 的摘要说明
    /// </summary>
    public class Allot : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string act = HttpContext.Current.Request.QueryString["act"];
            switch (act)
            {
                case "StoreProductList":
                    this.StoreProductList();
                    break;
                case "StoreProductDB":
                    this.StoreProductDB();
                    break;
            }
        }

        /// <summary>
        /// 仓库商品调拨操作
        /// </summary>
        private void StoreProductDB()
        {

            string ListShopId = HttpContext.Current.Request.QueryString["ListShopId"]; //调拨商品ID
            string dbListNumber = HttpContext.Current.Request.QueryString["dbListNumber"]; //调拨数量
            string ListNumber = HttpContext.Current.Request.QueryString["ListNumber"];  //库存数量
            string ListStoreId = HttpContext.Current.Request.QueryString["ListStoreId"]; //被调拨仓库Id
            int StoreId = Convert.ToInt32(HttpContext.Current.Request.QueryString["StoreId"]);//调拨到仓库Id
            var obj = new
            {
                code = 201,
                msg = AllotBll.StoreProductDB(ListShopId, dbListNumber, ListNumber, ListStoreId, StoreId)
            };
            javaScriptSerializer(obj);
        }


        /// <summary>
        /// 库存调拨查询List
        /// </summary>
        private void StoreProductList()
        {
            int page = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"]);
            int limit = Convert.ToInt32(HttpContext.Current.Request.QueryString["limit"]);
            string ShopName = HttpContext.Current.Request.QueryString["ShopName"];
            object tab = AllotBll.StoreProductList(page, limit, ShopName);
            javaScriptSerializer(tab);
        }

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