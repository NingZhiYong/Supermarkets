using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketModel
{
    /// <summary>
    /// 导航表
    /// </summary>
    public class T_Navigation
    {
        /// <summary>
        /// 导航编号(自增)
        /// </summary>
        public int NavigationID { get; set; }
        /// <summary>
        /// 导航名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 导航地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 权限编号
        /// </summary>
        public string CodeID { get; set; }
        /// <summary>
        /// 父级编号(自连)
        /// </summary>
        public int ParentID { get; set; }
    }
}
