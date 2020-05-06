using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketModel;

namespace SupermarketDAL
{
    public class supplierDal
    {
        /// <summary>
        /// 查询供应商表
        /// </summary>
        /// <param name="">供应商名称</param>
        /// <returns></returns>
        public static object SupplierSelect(string supplierName, int page, int limit)
        {
            string sql = string.Format("select * from (select  ROW_NUMBER() OVER(ORDER BY SupplierID desc) as row,* from T_Supplier) as o where SupplierName like '%{0}%'", supplierName);

            string sqlpages = sql + string.Format(" and  o.row between ({0}-1)*{1}+1 and {2}*{3}", page, limit, page, limit);

            //总查询记录
            var supplierTabCount = DBHelper.Read(sql).Rows.Count;
            //分页后查询数据
            var supplierTabPage = DBHelper.Read(sqlpages);

            List<T_Supplier> supplierlst = new List<T_Supplier>();
            foreach (DataRow item in supplierTabPage.Rows)
            {
                T_Supplier supplier = new T_Supplier
                {
                    SupplierID = Convert.ToInt32(item["SupplierID"].ToString()),
                    SupplierName = item["SupplierName"].ToString(),
                    Address = item["Address"].ToString(),
                    LinkMan = item["LinkMan"].ToString(),
                    Mobile = item["Mobile"].ToString(),
                    Status = Convert.ToInt32(item["Status"].ToString())
                };
                supplierlst.Add(supplier);
            }

            //定义匿名类型 接受供应商总数用于分页
            var obj = new
            {
                status = supplierTabCount,
                lst = supplierlst
            };

            return obj;
        }

        /// <summary>
        /// 删除供应商
        /// <param name="">供应商ID</param>
        /// <returns></returns>
        public static bool SupplierDel(int SupplierID)
        {
            string sql = string.Format("DELETE FROM T_Supplier where SupplierID={0}", SupplierID);
            return DBHelper.Write(sql);
        }

        /// <summary>
        /// 供应商编辑查询
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static T_Supplier SupplierEditSelect(int SupplierID)
        {
            string sql = string.Format("select * from T_Supplier where SupplierID={0}", SupplierID);
            var db = DBHelper.Read(sql);
            T_Supplier supplier = new T_Supplier
            {
                SupplierName = db.Rows[0]["SupplierName"].ToString(),
                LinkMan = db.Rows[0]["LinkMan"].ToString(),
                Mobile = db.Rows[0]["Mobile"].ToString(),
                Address = db.Rows[0]["Address"].ToString(),
                Status =Convert.ToInt32(db.Rows[0]["Status"].ToString()),
            };
            return supplier;
        }

        /// <summary>
        /// 供应商信息修改
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static bool SupplierEdit(T_Supplier supplier)
        {
            string sql = string.Format("update T_Supplier SET SupplierName='{0}',LinkMan='{1}',Mobile='{2}',[Address]='{3}',[Status]='{4}' where SupplierID={5}", supplier.SupplierName, supplier.LinkMan, supplier.Mobile, supplier.Address, supplier.Status, supplier.SupplierID);
            return DBHelper.Write(sql);
        }

        /// <summary>
        /// 供应商新增
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static bool SupplierAdd(T_Supplier supplier)
        {
            string sql = string.Format("insert T_Supplier(SupplierName,[LinkMan],[Mobile],[Address],[Status]) values('{0}','{1}','{2}','{3}','{4}')", supplier.SupplierName, supplier.LinkMan, supplier.Mobile, supplier.Address, supplier.Status);
            return DBHelper.Write(sql);
        }
    }
}
