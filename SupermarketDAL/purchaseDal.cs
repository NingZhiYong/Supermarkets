using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketModel;

namespace SupermarketDAL
{
    public class purchaseDal
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
            string sql = string.Format("select row,PurID,PurTime,Name,PurStart from(select  ROW_NUMBER() OVER(ORDER BY PurId desc) as row,* from T_Purchase join T_Employee on T_Purchase.PurProID=T_Employee.EmployeeID) o where PurID like '%{0}%'", PurId);

            string sqlPages = sql + string.Format("and  o.row between ({0}-1)*{1}+1 and {2}*{3}", page, limit, page, limit);

            //总查询记录
            var purchaseTabCount = DBHelper.Read(sql).Rows.Count;
            //分页后查询数据
            var purchaseTabPage = DBHelper.Read(sqlPages);
            List<T_Purchase> purchaseLst = new List<T_Purchase>();
            foreach (DataRow item in purchaseTabPage.Rows)
            {
                T_Purchase purchase = new T_Purchase
                {
                    PurID = item["PurID"].ToString(),
                    PurTime = Convert.ToDateTime(item["PurTime"].ToString()),
                    Employee = new T_Employee
                    {
                        Name = item["Name"].ToString()
                    },
                    PurStart = Convert.ToInt32(item["PurStart"].ToString())
                };
                purchaseLst.Add(purchase);
            }

            var obj = new
            {
                status = purchaseTabCount,
                lst = purchaseLst
            };

            return obj;
        }

        /// <summary>
        /// 删除采购订单
        /// </summary>
        /// <param name="PurId"></param>
        /// <returns></returns>
        public static bool purchaseDel(string PurId)
        {
            string purchaseDel = string.Format("delete from T_Purchase where PurID ='{0}'", PurId);
            string purchaseDetailed = string.Format("delete from T_PurchaseDetailed where PurCode='{0}'", PurId);
            //删除采购订单详细表数据
            DBHelper.Write(purchaseDetailed);
            //删除采购订单表
            return DBHelper.Write(purchaseDel);
        }

        /// <summary>
        /// 新增采购订单时 查询商品表 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static object CreateShopSelect(int page, int limit)
        {
            string sql = string.Format(@"select *from(select ROW_NUMBER() OVER(ORDER BY ShopId desc) as row , ShopID,ShopCode,T_Shop.Name as ShopName,SupplierName,CostPrice,SalePrice,ShelfLife,T_ShopType.Name as ShopTypeName from T_Shop 
              join T_Supplier on T_Shop.SupplierID=T_Supplier.SupplierID 
              join T_ShopType on T_Shop.ShopTypeID=T_ShopType.TypeID) o ");

            string sqlpages = sql + string.Format("where o.row between ({0}-1)*{1}+1 and {2}*{3}", page, limit, page, limit);

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
                    ShelfLife = Convert.ToInt32(item["ShelfLife"].ToString()),
                    ShopType = new T_ShopType
                    {
                        Name = item["ShopTypeName"].ToString()
                    }
                    //Number = Convert.ToInt32(item["Number"].ToString())
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
            //用于保证当前采购单号至少有一条商品数据
            int count = 0;
            string purIdSelect = string.Format("select * from T_Purchase where PurID='{0}'", PurID);
            var purIdCount = DBHelper.Read(purIdSelect).Rows.Count;
            //查询采购订单编号是否存在 若不存在则新增该采购订单编号
            if (purIdCount == 0)
            {
                //订单生成时间
                var time = DateTime.Now.ToLocalTime().ToString();
                string purIdAdd = string.Format("insert T_Purchase(PurID,PurTime,PurProID) values('{0}','{1}',{2})", PurID, time, empID);
                DBHelper.Write(purIdAdd);
            }
            string[] _shopIdArrString = ListShopId.Split(',');
            string[] _numberArrString = ListNumber.Split(',');
            for (int i = 0; i < _shopIdArrString.Length; i++)
            {
                //预防前端输入数量错误
                try
                {
                    int _numberArrInt = Convert.ToInt32(_numberArrString[i]);
                    int _shopIdArrInt = Convert.ToInt32(_shopIdArrString[i]);
                    if (_numberArrInt <= 0)
                    {
                        continue;
                    }
                    else
                    {
                        string purDetailedAdd = string.Format("insert T_PurchaseDetailed(PurCode,ShopID,PurStoreID,PurNumber) values('{0}',{1},{2},{3})", PurID, _shopIdArrInt, StoreId, _numberArrInt);
                        DBHelper.Write(purDetailedAdd);
                        count++;
                    }
                }
                catch (Exception)
                {
                    count = 0;
                }

            }

            if (count > 0)
            {
                return true;
            }
            else
            {
                string purIdDel = string.Format("delete from T_Purchase where PurID='{0}'", PurID);
                DBHelper.Write(purIdDel);
                return false;
            }
        }

        /// <summary>
        /// 采购订单商品入库仓库--查询
        /// </summary>
        /// <returns></returns>
        public static List<T_Store> StoreSelect()
        {
            string sql = string.Format("select * from T_Store");
            var db = DBHelper.Read(sql);
            List<T_Store> lst = new List<T_Store>();
            foreach (DataRow item in db.Rows)
            {
                T_Store store = new T_Store
                {
                    StoreID = Convert.ToInt32(item["StoreID"].ToString()),
                    Name = item["Name"].ToString(),
                    Status = Convert.ToInt32(item["Status"].ToString())
                };
                lst.Add(store);
            }
            return lst;
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
            string sql = string.Format(@"select * from
                     (select ROW_NUMBER() OVER(ORDER BY PurDetailedID desc) as row,PurDetailedID, T_Shop.Name as ShopName, SupplierName, PurNumber, CostPrice,SalePrice, ShelfLife,T_ShopType.Name as ShopTypeName, T_Store.Name as StoreName from T_PurchaseDetailed
                       join T_Shop on T_PurchaseDetailed.ShopID = T_Shop.ShopID
                       join T_Store on T_PurchaseDetailed.PurStoreID = T_Store.StoreID
                       join T_ShopType on T_Shop.ShopTypeID = T_ShopType.TypeID
                       join T_Supplier on T_Shop.SupplierID = T_Supplier.SupplierID where PurCode = '{0}') o", PurCode);

            string sqlPages = sql + string.Format(" where o.row between ({0}-1)*{1}+1 and {2}*{3}", page, limit, page, limit);

            //总查询记录
            var PurchaseDetailedTabCount = DBHelper.Read(sql).Rows.Count;
            //分页后查询的数据
            var PurchaseDetailedTabPage = DBHelper.Read(sqlPages);

            List<T_PurchaseDetailed> purchaseDetailedLst = new List<T_PurchaseDetailed>();
            foreach (DataRow item in PurchaseDetailedTabPage.Rows)
            {
                T_PurchaseDetailed purchaseDetailed = new T_PurchaseDetailed
                {
                    PurDetailedID = Convert.ToInt32(item["PurDetailedID"].ToString()),
                    Store = new T_Store
                    {
                        Name = item["StoreName"].ToString()
                    },
                    Shop = new T_Shop
                    {
                        Name = item["ShopName"].ToString(),
                        CostPrice = Convert.ToDecimal(item["CostPrice"].ToString()),
                        SalePrice = Convert.ToDecimal(item["SalePrice"].ToString()),
                        ShelfLife = Convert.ToInt32(item["ShelfLife"].ToString()),
                        ShopType = new T_ShopType
                        {
                            Name = item["ShopTypeName"].ToString()
                        },
                        Supplier = new T_Supplier
                        {
                            SupplierName = item["SupplierName"].ToString()
                        }
                    },
                    PurNumber = Convert.ToInt32(item["PurNumber"].ToString())
                };
                purchaseDetailedLst.Add(purchaseDetailed);
            }
            //定义匿名类型 接受商品总数用于分页
            var obj = new
            {
                status = PurchaseDetailedTabCount,
                lst = purchaseDetailedLst
            };

            return obj;
        }

        /// <summary>
        /// 删除采购订单详细中单个商品数据
        /// </summary>
        /// <param name="PurDetailedID"></param>
        /// <returns></returns>
        public static bool PurDetailedShopDel(int PurDetailedID)
        {
            string sql = string.Format("delete from T_PurchaseDetailed where PurDetailedID={0}", PurDetailedID);
            return DBHelper.Write(sql);
        }

        /// <summary>
        /// 采购入库审核
        /// </summary>
        /// <param name="PurStart"></param>
        /// <param name="PurId"></param>
        /// <returns></returns>
        public static bool PurStartUpdate(int PurStart, string PurId)
        {
            string sql = string.Format("update T_Purchase set PurStart={0} where PurID='{1}'", PurStart, PurId);
            return DBHelper.Write(sql);
        }

        /// <summary>
        /// 查询采购订单里是否有商品
        /// </summary>
        /// <param name="PurId"></param>
        /// <returns></returns>
        public static int PurchaseDetailedCount(string PurId)
        {
            string sql = string.Format("select * from T_PurchaseDetailed where PurCode='{0}'", PurId);
            return DBHelper.Read(sql).Rows.Count;
        }

        /// <summary>
        /// 采购订单商品入库 采购订单状态修改
        /// </summary>
        /// <param name="PurId"></param>
        /// <returns></returns>
        public static bool CgrkUpdate(string PurId)
        {
            //计数
            int Count = 0;
            string sqlPurId = string.Format("select * from T_PurchaseDetailed where PurCode='{0}'", PurId);
            var purIdList = DBHelper.Read(sqlPurId);
            //根据商品Id、入库仓库 先查询该仓库是否有该商品 有-修改 无-新增
            foreach (DataRow item in purIdList.Rows)
            {
                string sqlShopId = string.Format("select * from T_StoreProduct where ShopID={0} and StoreID={1}", Convert.ToInt32(item["ShopID"].ToString()), Convert.ToInt32(item["PurStoreID"].ToString()));
                int ShopCount = DBHelper.Read(sqlShopId).Rows.Count;

                string sqlStoreShop = string.Format("insert T_StoreProduct(ShopID,StoreID,Count) values({0},{1},{2})", Convert.ToInt32(item["ShopID"].ToString()), Convert.ToInt32(item["PurStoreID"].ToString()), Convert.ToInt32(item["PurNumber"].ToString()));
                if (ShopCount > 0) //仓库有该商品 修改
                {
                    sqlStoreShop = string.Format("update T_StoreProduct set Count=Count+{0} where ShopID={1} and StoreID={2}", Convert.ToInt32(item["PurNumber"].ToString()), Convert.ToInt32(item["ShopID"].ToString()), Convert.ToInt32(item["PurStoreID"].ToString()));
                }
                //执行 新增或修改仓库数量操作
                if (DBHelper.Write(sqlStoreShop))
                {
                    Count++;
                }
            }

            if (Count > 0)
            {
                string sqlPurStart = string.Format("update T_Purchase set PurStart=2 where PurID='{0}'", PurId);
                return DBHelper.Write(sqlPurStart);
            }

            return false;
        }
    }
}
