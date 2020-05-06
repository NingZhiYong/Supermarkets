using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketDAL;
using SupermarketModel;

namespace SupermarketBLL
{
    public class purchaseBll
    {
        /// <summary>
        /// 查询采购订单
        /// </summary>
        /// <param name="PurId"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static object purchaseSelect(string PurId, int page, int limit)
        {
            return purchaseDal.purchaseSelect(PurId, page, limit);
        }

        /// <summary>
        /// 删除采购订单
        /// </summary>
        /// <param name="PurId"></param>
        /// <returns></returns>
        public static bool purchaseDel(string PurId)
        {
            return purchaseDal.purchaseDel(PurId);
        }

        /// <summary>
        /// 新增采购订单时 查询商品表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static object CreateShopSelect(int page, int limit)
        {
            return purchaseDal.CreateShopSelect(page, limit);
        }

        /// <summary>
        /// 新增采购订单时 往订单里添加该采购订单的商品---新增
        /// </summary>
        /// <param name="empID"></param>
        /// <param name="PurID"></param>
        /// <param name="StoreId"></param>
        /// <param name="ListShopId"></param>
        /// <param name="ListNumber"></param>
        /// <returns></returns>
        public static bool CreatePurchaseShop(int empID, string PurID, int StoreId, string ListShopId, string ListNumber)
        {
            return purchaseDal.CreatePurchaseShop(empID, PurID, StoreId, ListShopId, ListNumber); ;
        }

        /// <summary>
        /// 采购订单的商品入库到具体仓库--查询
        /// </summary>
        /// <returns></returns>
        public static List<T_Store> StoreSelect()
        {
            return purchaseDal.StoreSelect();
        }


        /// <summary>
        /// 采购订单详细--查询
        /// </summary>
        /// <param name="PurCode"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static object PurchaseEdit(string PurCode, int page, int limit)
        {
            return purchaseDal.PurchaseEdit(PurCode, page, limit);
        }

        /// <summary>
        /// 删除采购订单详细中单个商品数据
        /// </summary>
        /// <param name="PurDetailedID"></param>
        /// <returns></returns>
        public static bool PurDetailedShopDel(int PurDetailedID)
        {
            return purchaseDal.PurDetailedShopDel(PurDetailedID);
        }

        /// <summary>
        /// 采购入库审核
        /// </summary>
        /// <param name="PurStart"></param>
        /// <param name="PurId"></param>
        /// <returns></returns>
        public static bool PurStartUpdate(int PurStart, string PurId)
        {
            return purchaseDal.PurStartUpdate(PurStart, PurId);
        }

        /// <summary>
        /// 查询采购订单里是否有商品
        /// </summary>
        /// <param name="PurId"></param>
        /// <returns></returns>
        public static int PurchaseDetailedCount(string PurId)
        {
            return purchaseDal.PurchaseDetailedCount(PurId);
        }

        /// <summary>
        /// 采购订单商品入库 采购订单状态修改
        /// </summary>
        /// <param name="PurId"></param>
        /// <returns></returns>
        public static bool CgrkUpdate(string PurId)
        {
            return purchaseDal.CgrkUpdate(PurId);
        }
    }
}
