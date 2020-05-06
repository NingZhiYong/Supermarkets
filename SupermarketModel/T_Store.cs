using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketModel
{
    /// <summary>
    /// 仓库表
    /// </summary>
    public class T_Store
    {
        /// <summary>
        /// 仓库编号(自增)
        /// </summary>
        public int StoreID { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 仓库状态(1=正常、2=已满、3=停用)
        /// </summary>
        public int Status { get; set; }
    }
}
