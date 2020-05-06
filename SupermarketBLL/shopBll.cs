using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketModel;
using SupermarketDAL;

namespace SupermarketBLL
{
    public class shopBll
    {
        /// <summary>
        /// 查询商品表
        /// </summary>
        /// <param name="商品名称"></param>
        /// <returns></returns>
        public static object ShopSelect(string shopName, int page, int limit)
        {
            return shopDal.ShopSelect(shopName, page, limit);
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="shopID">商品ID</param>
        /// <returns></returns>
        public static bool ShopDel(int shopID)
        {
            return shopDal.ShopDel(shopID);
        }

        /// <summary>
        /// 查询供应商
        /// </summary>
        /// <returns></returns>
        public static List<T_Supplier> SupplierSelect()
        {
            return shopDal.SupplierSelect();
        }

        /// <summary>
        /// 查询商品类型
        /// </summary>
        /// <returns></returns>
        public static List<T_ShopType> ShopTypeSelect()
        {
            return shopDal.ShopTypeSelect();
        }

        /// <summary>
        /// 商品编辑查询
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public static T_Shop shopEditSelect(int shopId)
        {
            return shopDal.shopEditSelect(shopId);
        }

        /// <summary>
        /// 商品信息修改
        /// </summary>
        /// <param name="shop"></param>
        /// <returns></returns>
        public static bool shopEdit(T_Shop shop)
        {
            return shopDal.shopEdit(shop);
        }

        /// <summary>
        /// 商品新增
        /// </summary>
        /// <param name="shop"></param>
        /// <returns></returns>
        public static bool shopAdd(T_Shop shop)
        {
            return shopDal.shopAdd(shop);
        }
    }
}
