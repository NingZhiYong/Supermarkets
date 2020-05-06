using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketModel
{
    /// <summary>
    /// 销售订单表
    /// </summary>
    public class T_SaleOrder
    {
        /// <summary>
        /// 销售订单编号（年月日时分秒）
        /// </summary>
        public string SaleID { get; set; }
        /// <summary>
        /// 销售日期
        /// </summary>
        public DateTime SaleTime { get; set; }
        /// <summary>
        /// 销售员工（外键）
        /// </summary>
        public T_Employee SaleEmp { get; set; }
    }
}
