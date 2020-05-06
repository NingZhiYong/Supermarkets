using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketModel
{
    /// <summary>
    /// 退货详细表
    /// </summary>
    public class T_SaleReturn
    {
        /// <summary>
        /// 编号(自增)
        /// </summary>
        public int SaleRtnID { get; set; }
        /// <summary>
        /// 退货订单编号（外键）
        /// </summary>
        public T_Return Return { get; set; }
        /// <summary>
        /// 商品ID(外键)
        /// </summary>
        public T_Shop Shop { get; set; }
        /// <summary>
        /// 退货数量
        /// </summary>
        public int RtnNumber { get; set; }
    }
}
