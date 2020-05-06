using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using SupermarketBLL;
using SupermarketModel;

namespace Supermarket.Shop
{
    /// <summary>
    /// shop 的摘要说明
    /// </summary>
    public class shop : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string act = context.Request.QueryString["act"];
            switch (act)
            {
                case "shopSelect":
                    this.shopSelect();
                    break;
                case "shopDel":
                    this.shopDel();
                    break;
                case "SupplierSelect":
                    this.SupplierSelect();
                    break;
                case "ShopTypeSelect":
                    this.ShopTypeSelect();
                    break;
                case "shopEditSelect":
                    this.shopEditSelect();
                    break;
                case "ShopEdit":
                    this.ShopEdit();
                    break;
                case "ShopAdd":
                    this.ShopAdd();
                    break;
            }
        }

        /// <summary>
        /// 商品查询
        /// </summary>
        private void shopSelect()
        {
            string shopName = HttpContext.Current.Request.QueryString["shopName"];
            int page = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"]);
            int limit = Convert.ToInt32(HttpContext.Current.Request.QueryString["limit"]);
            object tab = shopBll.ShopSelect(shopName, page, limit);
            JavaScriptSerializer js = new JavaScriptSerializer();
            var str = js.Serialize(tab);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        private void shopDel()
        {
            int shopID = Convert.ToInt32(HttpContext.Current.Request.QueryString["shopID"]);
            var obj = new
            {
                status = 200
            };
            if (shopBll.ShopDel(shopID))
            {
                obj = new { status = 201 };
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(obj);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 供应商查询
        /// </summary>
        private void SupplierSelect()
        {
            var lst = shopBll.SupplierSelect();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(lst);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 商品类型查询
        /// </summary>
        private void ShopTypeSelect()
        {
            var lst = shopBll.ShopTypeSelect();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(lst);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 编辑商品查询
        /// </summary>
        private void shopEditSelect()
        {
            int shopID = Convert.ToInt32(HttpContext.Current.Request.QueryString["shopID"]);
            var db = shopBll.shopEditSelect(shopID);
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(db);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 编辑商品信息
        /// </summary>
        private void ShopEdit()
        {
            T_Shop shop = new T_Shop
            {
                ShopID = Convert.ToInt32(HttpContext.Current.Request.Form["shopId"]),
                Supplier = new T_Supplier
                {
                    SupplierID = Convert.ToInt32(HttpContext.Current.Request.Form["Supplier"])
                },
                ShopType = new T_ShopType
                {
                    TypeID = Convert.ToInt32(HttpContext.Current.Request.Form["shopType"])
                },
                ShopCode = HttpContext.Current.Request.Form["ShopCode"].ToString(),
                Name = HttpContext.Current.Request.Form["ShopName"].ToString(),
                CostPrice = Convert.ToDecimal(HttpContext.Current.Request.Form["CostPrice"]),
                SalePrice = Convert.ToDecimal(HttpContext.Current.Request.Form["SalePrice"]),
                ShelfLife = Convert.ToInt32(HttpContext.Current.Request.Form["ShelfLife"]),
            };
            var obj = new { status = 200, msg = "no" };
            if (shopBll.shopEdit(shop))
            {
                obj = new { status = 201, msg = "yes" };
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            string str = js.Serialize(obj);
            HttpContext.Current.Response.Write(str);
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 新增商品
        /// </summary>
        private void ShopAdd()
        {
            T_Shop shop = new T_Shop
            {
                Supplier = new T_Supplier
                {
                    SupplierID = Convert.ToInt32(HttpContext.Current.Request.Form["Supplier"])
                },
                ShopType = new T_ShopType
                {
                    TypeID = Convert.ToInt32(HttpContext.Current.Request.Form["shopType"])
                },
                ShopCode = HttpContext.Current.Request.Form["ShopCode"].ToString(),
                Name = HttpContext.Current.Request.Form["ShopName"].ToString(),
                CostPrice = Convert.ToDecimal(HttpContext.Current.Request.Form["CostPrice"]),
                SalePrice = Convert.ToDecimal(HttpContext.Current.Request.Form["SalePrice"]),
                ShelfLife = Convert.ToInt32(HttpContext.Current.Request.Form["ShelfLife"]),
            };
            var obj = new { status = 200, msg = "no" };
            if (shopBll.shopAdd(shop))
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