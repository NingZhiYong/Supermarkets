using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketModel;
using SupermarketDAL;

namespace SupermarketBLL
{
    public class storeBll
    {
        /// <summary>
        /// 仓库管理查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static object storeSelect(int page, int limit)
        {
            return storeDal.storeSelect(page, limit);
        }

        /// <summary>
        /// 仓库编辑查询赋值
        /// </summary>
        /// <param name="StoreId"></param>
        /// <returns></returns>
        public static T_Store storeEditSelect(int StoreId)
        {
            return storeDal.storeEditSelect(StoreId);

        }

        /// <summary>
        /// 新增仓库
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static bool storeAdd(T_Store store)
        {
            return storeDal.storeAdd(store);
        }

        /// <summary>
        /// 修改仓库信息
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static bool storeEdit(T_Store store)
        {
            return storeDal.storeEdit(store);
        }

        /// <summary>
        /// 仓库详细查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="StoreID"></param>
        /// <param name="ShopName"></param>
        /// <returns></returns>
        public static object StoreProductList(int page, int limit, int StoreID, string ShopName)
        {
            return storeDal.StoreProductList(page, limit, StoreID, ShopName);
        }

        /// <summary>
        /// 仓库名称 仓库状态查询
        /// </summary>
        /// <param name="StoreId"></param>
        /// <returns></returns>
        public static T_Store StoreNameSelect(int StoreId)
        {
            return storeDal.StoreNameSelect(StoreId);
        }
    }
}
