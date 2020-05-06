using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketModel
{
    /// <summary>
    /// 采购入库表
    /// </summary>
    public class T_Purchase
    {
        /// <summary>
        /// 采购订单编号（年月日时分秒）
        /// </summary>
        public string PurID { get; set; }
        /// <summary>
        /// 采购日期
        /// </summary>
        public DateTime PurTime { get; set; }
        /// <summary>
        /// 采购员工（外键）
        /// </summary>
        public T_Employee Employee { get; set; }
        /// <summary>
        /// 默认（0）0=待审核，1已审核，2=待入库，3=已入库
        /// </summary>
        public int PurStart { get; set; }
    }
}
