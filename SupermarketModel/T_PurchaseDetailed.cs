using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketModel
{
    /// <summary>
    /// 采购入库详细表
    /// </summary>
    public class T_PurchaseDetailed
    {
        /// <summary>
        /// 编号（自增）
        /// </summary>
        public int PurDetailedID { get; set; }
        /// <summary>
        /// 采购入库订单编号（外键）
        /// </summary>
        public T_Purchase Purchase { get; set; }
        /// <summary>
        /// 商品ID(外键)
        /// </summary>
        public T_Shop Shop { get; set; }
        /// <summary>
        /// 采购入库仓库（外键）
        /// </summary>
        public T_Store Store { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int PurNumber { get; set; }
    }
}
