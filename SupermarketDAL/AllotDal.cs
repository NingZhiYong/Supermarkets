using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketModel;

namespace SupermarketDAL
{
    public class AllotDal
    {
        /// <summary>
        /// 库存调拨查询List
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static object StoreProductList(int page, int limit, string ShopName)
        {
            string sql = string.Format(@"select * from(select ROW_NUMBER() OVER(ORDER BY StoreProID desc) as rows,a.StoreProID, b.ShopID, b.Name as ShopName,b.CostPrice,b.SalePrice,b.ShelfLife,b.Number,c.StoreID,c.Name as StoreName,c.Status as StoreStatus,Count
              from T_StoreProduct a join T_Shop b on a.ShopID = b.ShopID join T_Store c on a.StoreID = c.StoreID) o where ShopName like '%{0}%'", ShopName);
            string sqlpages = sql + string.Format(" and  o.rows  between ({0}-1)*{1}+1 and {2}*{3} ", page, limit, page, limit);
            //总查询记录
            var TabCount = DBHelper.Read(sql).Rows.Count;
            //分页后查询数据
            var TabPage = DBHelper.Read(sqlpages);
            List<T_StoreProduct> storeProductslst = new List<T_StoreProduct>();
            foreach (DataRow item in TabPage.Rows)
            {
                T_StoreProduct storeProduct = new T_StoreProduct
                {
                    StoreProID = Convert.ToInt32(item["StoreProID"].ToString()),
                    Shop = new T_Shop
                    {
                        ShopID = Convert.ToInt32(item["ShopID"].ToString()),
                        Name = item["ShopName"].ToString(),
                        CostPrice = Convert.ToDecimal(item["CostPrice"].ToString()),
                        SalePrice = Convert.ToDecimal(item["SalePrice"].ToString()),
                        ShelfLife = Convert.ToInt32(item["ShelfLife"].ToString())
                    },
                    Store = new T_Store
                    {
                        StoreID = Convert.ToInt32(item["StoreID"].ToString()),
                        Name = item["StoreName"].ToString(),
                        Status = Convert.ToInt32(item["StoreStatus"].ToString())
                    },
                    Count = Convert.ToInt32(item["Count"].ToString())
                };
                storeProductslst.Add(storeProduct);
            }
            //定义匿名类型 接受供应商总数用于分页
            var obj = new
            {
                status = TabCount,
                lst = storeProductslst
            };

            return obj;
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
            //用于判断是否执行成功
            int count = 0;

            int[] _shopIdArrInt;   //调拨商品ID
            int[] _dbNumberArrInt; //调拨数量
            int[] _NumberArrInt;   //库存数量
            int[] _storeIdArrInt;  //被调拨仓库Id
            //将数据转成 Int[]类型 并防止转换过程出现异常
            try
            {
                _shopIdArrInt = Array.ConvertAll<string, int>(ListShopId.Split(','), s => int.Parse(s));
                _dbNumberArrInt = Array.ConvertAll<string, int>(dbListNumber.Split(','), s => int.Parse(s));
                _NumberArrInt = Array.ConvertAll<string, int>(ListNumber.Split(','), s => int.Parse(s));
                _storeIdArrInt = Array.ConvertAll<string, int>(ListStoreId.Split(','), s => int.Parse(s));
            }
            catch (Exception)
            {
                return "请输入正确的调拨数量";
            }

            //判断输入数量是否少于等于库存现有数量
            for (int i = 0; i < _shopIdArrInt.Length; i++)
            {
                if (_dbNumberArrInt[i] > _NumberArrInt[i])
                {
                    return "调拨数量必须小于仓库库存数量";
                }
            }

            //执行调拨操作
            for (int i = 0; i < _shopIdArrInt.Length; i++)
            {
                if (_dbNumberArrInt[i] > 0)  //调拨数量为0或小于0时 不做操作
                {
                    string sqlReduce;
                    //判断调拨数量是否与库存数量相等
                    if (_dbNumberArrInt[i] == _NumberArrInt[i])
                    {
                        //删除
                        sqlReduce = string.Format("delete from T_StoreProduct where StoreID={0} and ShopID={1}", _storeIdArrInt[i], _shopIdArrInt[i]);
                    }
                    else
                    {
                        //修改
                        sqlReduce = string.Format("update T_StoreProduct set Count=Count-{0} where StoreID={1} and ShopID={2}", _dbNumberArrInt[i], _storeIdArrInt[i], _shopIdArrInt[i]);
                    }
                    DBHelper.Write(sqlReduce);

                    //查询调拨到的仓库是否有该商品
                    string sqlShopSelect = string.Format("select * from T_StoreProduct where StoreID={0} and ShopID={1}", StoreId, _shopIdArrInt[i]);
                    int storeProCount = DBHelper.Read(sqlShopSelect).Rows.Count;
                    string sqlAdd;
                    if (storeProCount > 0)
                    {
                        //有 修改
                        sqlAdd = string.Format("update T_StoreProduct set Count=Count+{0} where StoreID={1} and ShopID={2}", _dbNumberArrInt[i], StoreId, _shopIdArrInt[i]);
                    }
                    else
                    {
                        //无 新增
                        sqlAdd = string.Format("insert T_StoreProduct(ShopID,StoreID,Count) values({0},{1},{2})", _shopIdArrInt[i], StoreId, _dbNumberArrInt[i]);
                    }
                    DBHelper.Write(sqlAdd);
                    count++;
                }
                else
                {
                    continue;
                }
            }

            if (count > 0)
            {
                return "调拨完成";
            }
            else
            {
                return "请输入调拨数量";
            }
        }
    }
}
