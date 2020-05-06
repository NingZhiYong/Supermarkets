using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketModel;
using SupermarketDAL;

namespace SupermarketBLL
{
    public class AllotBll
    {
        /// <summary>
        /// 库存调拨查询List
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static object StoreProductList(int page, int limit, string ShopName)
        {
            return AllotDal.StoreProductList(page, limit, ShopName);
        }

        /// <summary>
        /// 库存调拨
        /// </summary>
        /// <param name="ListShopId">调拨商品ID</param>
        /// <param name="dbListNumber">调拨数量</param>
        /// <param name="ListNumber">库存数量</param>
        /// <param name="ListStoreId">被调拨仓库Id</param>
        /// <param name="StoreId">调拨到仓库Id</param>
        /// <returns></returns>
        public static string StoreProductDB(string ListShopId, string dbListNumber, string ListNumber, string ListStoreId, int StoreId)
        {
            return AllotDal.StoreProductDB(ListShopId, dbListNumber, ListNumber, ListStoreId, StoreId);
        }
    }
}
