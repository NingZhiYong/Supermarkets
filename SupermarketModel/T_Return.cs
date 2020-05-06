using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketModel
{
    /// <summary>
    /// 退货表
    /// </summary>
    public class T_Return
    {
        /// <summary>
        /// 退货订单编号（年月日时分秒）
        /// </summary>
        public string RtnID { get; set; }
        /// <summary>
        /// 退货日期
        /// </summary>
        public System.DateTime RtnTime { get; set; }
        /// <summary>
        /// 退货说明
        /// </summary>
        public string RtnExplain { get; set; }
        /// <summary>
        /// 退货审核(外键)
        /// </summary>
        public T_Audit Audit { get; set; }
    }
}
