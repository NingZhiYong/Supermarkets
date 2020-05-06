using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using SupermarketBLL;
using SupermarketModel;

namespace Supermarket.Purchase
{
    /// <summary>
    /// purchase 的摘要说明
    /// </summary>
    public class purchase : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string act = context.Request.QueryString["act"];
            switch (act)
            {
                case "purchaseSelect":
                    this.purchaseSelect();
                    break;
                case "purchaseDel":
                    this.purchaseDel();
                    break;
                case "CreateShopSelect":
                    this.CreateShopSelect();
                    break;
                case "CreatePurchaseShop":
                    this.CreatePurchaseShop();
                    break;
                case "StoreSelect":
                    this.StoreSelect();
                    break;
                case "PurchaseEdit":
                    this.PurchaseEdit();
                    break;
                case "PurDetailedShopDel":
                    this.PurDetailedShopDel();
                    break;
                case "PurStartUpdate":
                    this.PurStartUpdate();
                    break;
                case "PurchaseDetailedCount":
                    this.PurchaseDetailedCount();
                    break;
                case "CgrkUpdate":
                    this.CgrkUpdate();
                    break;
            }
        }

        /// <summary>
        /// 采购入库
        /// </summary>
        private void CgrkUpdate()
        {
            string PurID = HttpContext.Current.Request.QueryString["PurID"];

            var obj = new
            {
                msg = "入库失败",
                success = "no"
            };
            if (purchaseBll.CgrkUpdate(PurID))
            {
                obj = new { msg = "入库成功", success = "yes" };
            }
            javaScriptSerializer(obj);
        }

        /// <summary>
        /// 查询采购订单里是否有商品
        /// </summary>
        private void PurchaseDetailedCount()
        {
            string PurID = HttpContext.Current.Request.QueryString["PurID"];
            int count = purchaseBll.PurchaseDetailedCount(PurID);
            javaScriptSerializer(count);
        }

        /// <summary>
        /// 采购订单入库审核
        /// </summary>
        private void PurStartUpdate()
        {
            int PurStart = Convert.ToInt32(HttpContext.Current.Request.QueryString["PurStart"]);
            string PurId = HttpContext.Current.Request.QueryString["PurId"];
            var obj = new
            {
                status = "no"
            };
            if (purchaseBll.PurStartUpdate(PurStart, PurId))
            {
                obj = new { status = "yes" };
            }
            javaScriptSerializer(obj);
        }

        /// <summary>
        /// 查询采购订单
        /// </summary>
        private void purchaseSelect()
        {
            string purId = HttpContext.Current.Request.QueryString["purId"];
            int page = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"]);
            int limit = Convert.ToInt32(HttpContext.Current.Request.QueryString["limit"]);

            object tab = purchaseBll.purchaseSelect(purId, page, limit);
            javaScriptSerializer(tab);
        }

        /// <summary>
        /// 删除采购订单
        /// </summary>
        private void purchaseDel()
        {
            string PurId = HttpContext.Current.Request.QueryString["PurId"];
            var obj = new
            {
                status = 200
            };
            if (purchaseBll.purchaseDel(PurId))
            {
                obj = new { status = 201 };
            }
            javaScriptSerializer(obj);
        }

        /// <summary>
        /// 新增采购订单时 查询商品表 
        /// </summary>
        private void CreateShopSelect()
        {
            int page = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"]);
            int limit = Convert.ToInt32(HttpContext.Current.Request.QueryString["limit"]);
            object tab = purchaseBll.CreateShopSelect(page, limit);
            javaScriptSerializer(tab);
        }

        /// <summary>
        /// 新增采购订单时 往订单里添加该采购订单的商品
        /// </summary>
        private void CreatePurchaseShop()
        {
            //当前登陆人
            T_Employee emp = HttpContext.Current.Cache["emp"] as T_Employee;
            string ListShopId = HttpContext.Current.Request.QueryString["ListShopId"];
            string ListNumber = HttpContext.Current.Request.QueryString["ListNumber"];
            string PurID = HttpContext.Current.Request.QueryString["PurID"];
            int StoreId = Convert.ToInt32(HttpContext.Current.Request.QueryString["StoreId"]);
            var obj = new
            {
                status = "error",
                code = 200,
                msg = "请正确填写需要采购商品的数量"
            };
            if (purchaseBll.CreatePurchaseShop(emp.EmployeeID, PurID, StoreId, ListShopId, ListNumber))
            {
                obj = new
                {
                    status = "success",
                    code = 201,
                    msg = "添加完成"
                };
            }
            javaScriptSerializer(obj);
        }

        /// <summary>
        /// 采购订单商品入库仓库--查询
        /// </summary>
        private void StoreSelect()
        {
            var db = purchaseBll.StoreSelect();
            javaScriptSerializer(db);
        }

        /// <summary>
        /// 采购订单详细--查询
        /// </summary>
        private void PurchaseEdit()
        {
            int page = Convert.ToInt32(HttpContext.Current.Request.QueryString["page"]);
            int limit = Convert.ToInt32(HttpContext.Current.Request.QueryString["limit"]);
            string purId = HttpContext.Current.Request.QueryString["purId"];
            object tab = purchaseBll.PurchaseEdit(purId, page, limit);
            javaScriptSerializer(tab);
        }

        /// <summary>
        ///  删除采购订单详细中单个商品数据
        /// </summary>
        private void PurDetailedShopDel()
        {
            int PurDetailedID = Convert.ToInt32(HttpContext.Current.Request.QueryString["PurDetailedID"]);
            var obj = new
            {
                status = 200
            };
            if (purchaseBll.PurDetailedShopDel(PurDetailedID))
            {
                obj = new { status = 201 };
            }
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