using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketModel
{
    /// <summary>
    /// 审核表
    /// </summary>
    public class T_Audit
    {
        /// <summary>
        /// 审核ID
        /// </summary>
        public int AuditID { get; set; }
        /// <summary>
        /// 审核状态（未审核 1，待审核 2，已审核 3）
        /// </summary>
        public string AuditState { get; set; }
    }
}
