using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketModel;
using SupermarketDAL;

namespace SupermarketBLL
{
    public class supplierBll
    {
        /// <summary>
        /// 查询供应商表
        /// </summary>
        /// <param name="供应商名称"></param>
        /// <returns></returns>
        public static object SupplierSelect(string supplierName, int page, int limit)
        {
            return supplierDal.SupplierSelect(supplierName, page, limit);
        }

        /// <summary>
        /// 删除供应商
        /// <param name="">供应商ID</param>
        /// <returns></returns>
        public static bool SupplierDel(int SupplierID)
        {
            return supplierDal.SupplierDel(SupplierID);
        }

        /// <summary>
        /// 供应商编辑查询
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static T_Supplier SupplierEditSelect(int SupplierID)
        {
            return supplierDal.SupplierEditSelect(SupplierID);
        }

        /// <summary>
        /// 供应商信息修改
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static bool SupplierEdit(T_Supplier supplier)
        {
            return supplierDal.SupplierEdit(supplier);

        }

        /// <summary>
        /// 供应商新增
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static bool SupplierAdd(T_Supplier supplier)
        {
            return supplierDal.SupplierAdd(supplier);
        }
    }
}
