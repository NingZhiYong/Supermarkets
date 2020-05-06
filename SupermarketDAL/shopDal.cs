using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketModel;

namespace SupermarketDAL
{
    public class shopDal
    {
        /// <summary>
        /// 查询商品表
        /// </summary>
        /// <param name="shopName">商品名称</param>
        /// <returns></returns>
        public static object ShopSelect(string shopName, int page, int limit)
        {
            string sql = string.Format(@"select * from (select  ROW_NUMBER() OVER(ORDER BY ShopId desc) as row , T_Shop.ShopID as ShopID ,T_Shop.ShopCode as ShopCode,T_Shop.name as ShopName,T_Supplier.SupplierName as SupplierName, T_Shop.CostPrice as CostPrice, T_Shop.SalePrice as SalePrice,T_Shop.BothTime as BothTime, T_Shop.ShelfLife as ShelfLife, T_ShopType.Name as TypeName
              from T_Shop join T_Supplier
              on T_Shop.SupplierID = T_Supplier.SupplierID join T_ShopType
              on T_Shop.ShopTypeID = T_ShopType.TypeID) o where ShopName like '%{0}%' ", shopName);

            string sqlpages = sql + string.Format("and  o.row between ({0}-1)*{1}+1 and {2}*{3}", page, limit, page, limit);

            var shopTabCount = DBHelper.Read(sql).Rows.Count;

            var shopTabPage = DBHelper.Read(sqlpages);

            List<T_Shop> shoplst = new List<T_Shop>();
            foreach (DataRow item in shopTabPage.Rows)
            {
                T_Shop shop = new T_Shop
                {
                    ShopID = Convert.ToInt32(item["ShopID"].ToString()),
                    ShopCode = item["ShopCode"].ToString(),
                    Name = item["ShopName"].ToString(),
                    Supplier = new T_Supplier
                    {
                        SupplierName = item["SupplierName"].ToString()
                    },
                    CostPrice = Convert.ToDecimal(item["CostPrice"].ToString()),
                    SalePrice = Convert.ToDecimal(item["SalePrice"].ToString()),
                    //BothTime = Convert.ToDateTime(item["BothTime"].ToString()),
                    ShelfLife = Convert.ToInt32(item["ShelfLife"].ToString()),
                    ShopType = new T_ShopType
                    {
                        Name = item["TypeName"].ToString()
                    }
                };
                shoplst.Add(shop);
            }

            //定义匿名类型 接受商品总数用于分页
            var obj = new
            {
                status = shopTabCount,
                lst = shoplst
            };

            return obj;
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="shopID">商品ID</param>
        /// <returns></returns>
        public static bool ShopDel(int shopID)
        {
            string sql = string.Format("DELETE FROM T_Shop where ShopID={0}", shopID);
            return DBHelper.Write(sql);
        }

        /// <summary>
        /// 查询供应商
        /// </summary>
        /// <returns></returns>
        public static List<T_Supplier> SupplierSelect()
        {
            string sql = string.Format("select * from T_Supplier");
            var db = DBHelper.Read(sql);
            List<T_Supplier> lst = new List<T_Supplier>();
            foreach (DataRow item in db.Rows)
            {
                T_Supplier supplier = new T_Supplier
                {
                    SupplierID = Convert.ToInt32(item["SupplierID"].ToString()),
                    SupplierName = item["SupplierName"].ToString(),
                    Status = Convert.ToInt32(item["Status"].ToString())
                };
                lst.Add(supplier);
            }
            return lst;
        }

        /// <summary>
        /// 查询商品类型
        /// </summary>
        /// <returns></returns>
        public static List<T_ShopType> ShopTypeSelect()
        {
            string sql = string.Format("select * from T_ShopType");
            var db = DBHelper.Read(sql);
            List<T_ShopType> lst = new List<T_ShopType>();
            foreach (DataRow item in db.Rows)
            {
                T_ShopType shopType = new T_ShopType
                {
                    TypeID = Convert.ToInt32(item["TypeID"].ToString()),
                    Name = item["Name"].ToString()
                };
                lst.Add(shopType);
            }
            return lst;
        }

        /// <summary>
        /// 商品编辑查询
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public static T_Shop shopEditSelect(int shopId)
        {
            string sql = string.Format(@"select ShopCode,T_Shop.Name as ShopName,T_Supplier.SupplierID as SupplierID,SupplierName,CostPrice,SalePrice,ShelfLife,ShopTypeID,T_ShopType.Name as TypeName
from T_Shop join T_Supplier on T_Shop.SupplierID = T_Supplier.SupplierID join T_ShopType on T_Shop.ShopTypeID = T_ShopType.TypeID where ShopID={0}", shopId);
            var db = DBHelper.Read(sql);
            T_Shop shop = new T_Shop
            {
                ShopCode = db.Rows[0]["ShopCode"].ToString(),
                Name = db.Rows[0]["ShopName"].ToString(),
                Supplier = new T_Supplier
                {
                    SupplierID = Convert.ToInt32(db.Rows[0]["SupplierID"].ToString()),
                    SupplierName = db.Rows[0]["SupplierName"].ToString(),
                },
                CostPrice = Convert.ToDecimal(db.Rows[0]["CostPrice"].ToString()),
                SalePrice = Convert.ToDecimal(db.Rows[0]["SalePrice"].ToString()),
                ShelfLife = Convert.ToInt32(db.Rows[0]["ShelfLife"].ToString()),
                ShopType = new T_ShopType
                {
                    TypeID = Convert.ToInt32(db.Rows[0]["ShopTypeID"].ToString()),
                    Name = db.Rows[0]["TypeName"].ToString()
                }
            };
            return shop;
        }

        /// <summary>
        /// 商品信息修改
        /// </summary>
        /// <param name="shop"></param>
        /// <returns></returns>
        public static bool shopEdit(T_Shop shop)
        {
            string sql = string.Format("update T_Shop set ShopCode='{0}', Name='{1}', SupplierID={2},CostPrice={3},SalePrice={4},ShelfLife={5},ShopTypeID={6} where ShopID={7}", shop.ShopCode, shop.Name, shop.Supplier.SupplierID, shop.CostPrice, shop.SalePrice, shop.ShelfLife, shop.ShopType.TypeID, shop.ShopID);
            return DBHelper.Write(sql);
        }

        /// <summary>
        /// 新增商品信息
        /// </summary>
        /// <param name="shop"></param>
        /// <returns></returns>
        public static bool shopAdd(T_Shop shop)
        {
            string sql = string.Format("insert T_Shop(ShopCode,Name,SupplierID,CostPrice,SalePrice,ShelfLife,ShopTypeID) values('{0}','{1}',{2},{3},{4},{5},{6})", shop.ShopCode, shop.Name, shop.Supplier.SupplierID, shop.CostPrice, shop.SalePrice, shop.ShelfLife, shop.ShopType.TypeID);
            return DBHelper.Write(sql);
        }
    }
}
