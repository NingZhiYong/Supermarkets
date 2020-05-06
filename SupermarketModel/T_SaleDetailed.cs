using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketModel
{
    /// <summary>
    /// 销售订单详细表
    /// </summary>
    public class T_SaleDetailed
    {
        /// <summary>
        /// 编号（自增）
        /// </summary>
        public int SaleDetaileID { get; set; }
        /// <summary>
        /// 销售订单编号（外键）
        /// </summary>
        public T_SaleOrder SaleOrder { get; set; }
        /// <summary>
        /// 商品ID（外键）
        /// </summary>
        public T_Shop Shop { get; set; }
        /// <summary>
        /// 销售数量
        /// </summary>
        public int SaleNumber { get; set; }
    }
}
