using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketModel
{
    /// <summary>
    /// 供应商表
    /// </summary>
    public class T_Supplier
    {
        /// <summary>
        /// 供应商ID
        /// </summary>
        public int SupplierID { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName { get; set; }
        /// <summary>
        /// 供应商联系人
        /// </summary>
        public string LinkMan { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 供应商地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
    }
}
