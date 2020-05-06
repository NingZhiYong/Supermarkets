using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketModel;
using System.Data;

namespace SupermarketDAL
{
    public class storeDal
    {
        /// <summary>
        /// 仓库管理查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static object storeSelect(int page, int limit)
        {
            string sql = string.Format("select * from (select ROW_NUMBER() OVER(ORDER BY StoreID desc) as rows,* from T_Store) o ");
            string sqlpages = sql + string.Format(" where o.rows   between ({0}-1)*{1}+1 and {2}*{3} ", page, limit, page, limit);

            //总查询记录
            var TabCount = DBHelper.Read(sql).Rows.Count;
            //分页后查询数据
            var TabPage = DBHelper.Read(sqlpages);
            List<T_Store> storelst = new List<T_Store>();
            foreach (DataRow item in TabPage.Rows)
            {
                T_Store store = new T_Store
                {
                    StoreID = Convert.ToInt32(item["StoreID"].ToString()),
                    Name = item["Name"].ToString(),
                    Status = Convert.ToInt32(item["Status"].ToString())
                };
                storelst.Add(store);
            }
            //定义匿名类型 接受供应商总数用于分页
            var obj = new
            {
                status = TabCount,
                lst = storelst
            };

            return obj;
        }

        /// <summary>
        /// 仓库编辑查询赋值
        /// </summary>
        /// <param name="StoreId"></param>
        /// <returns></returns>
        public static T_Store storeEditSelect(int StoreId)
        {
            string sql = string.Format("select * from T_Store where StoreID={0}", StoreId);
            var db = DBHelper.Read(sql).Rows[0];
            T_Store store = new T_Store
            {
                Name = db["Name"].ToString(),
                Status = Convert.ToInt32(db["Status"].ToString())
            };
            return store;
        }

        /// <summary>
        /// 新增仓库
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static bool storeAdd(T_Store store)
        {
            string sql = string.Format("insert T_Store(Name,Status) values('{0}',{1})", store.Name, store.Status);
            return DBHelper.Write(sql);
        }

        /// <summary>
        /// 修改仓库信息
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static bool storeEdit(T_Store store)
        {
            string sql = string.Format("update T_Store set Name='{0}',Status={1} where StoreID={2}", store.Name, store.Status, store.StoreID);
            return DBHelper.Write(sql);
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
            string sql = string.Format(@"select * from(select ROW_NUMBER() OVER(ORDER BY StoreProID desc) as rows, b.Name as ShopName,                    b.CostPrice,b.SalePrice,b.ShelfLife, a.Count as Count from 
                       T_StoreProduct a join T_Shop b on a.ShopID = b.ShopID
                       where StoreID = {0} and b.Name like '%{1}%') o", StoreID, ShopName);
            string sqlpages = sql + string.Format(" where o.rows  between ({0}-1)*{1}+1 and {2}*{3} ", page, limit, page, limit);
            //总查询记录
            var TabCount = DBHelper.Read(sql).Rows.Count;
            //分页后查询数据
            var TabPage = DBHelper.Read(sqlpages);
            List<T_StoreProduct> storeProductslst = new List<T_StoreProduct>();
            foreach (DataRow item in TabPage.Rows)
            {
                T_StoreProduct storeProduct = new T_StoreProduct
                {
                    Shop = new T_Shop
                    {
                        Name = item["ShopName"].ToString(),
                        CostPrice = Convert.ToDecimal(item["CostPrice"].ToString()),
                        SalePrice = Convert.ToDecimal(item["SalePrice"].ToString()),
                        ShelfLife = Convert.ToInt32(item["ShelfLife"].ToString())
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
        /// 仓库名称 仓库状态查询
        /// </summary>
        /// <param name="StoreId"></param>
        /// <returns></returns>
        public static T_Store StoreNameSelect(int StoreId)
        {
            string sql = string.Format("select * from T_Store where StoreID={0}", StoreId);
            var db = DBHelper.Read(sql).Rows[0];
            T_Store store = new T_Store
            {
                Name = db["Name"].ToString(),
                Status = Convert.ToInt32(db["Status"].ToString())
            };

            return store;
        }
    }
}
