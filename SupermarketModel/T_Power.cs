using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketModel
{
    /// <summary>
    /// 权限表
    /// </summary>
    public class T_Power
    {
        /// <summary>
        /// 权限编号
        /// </summary>
        public string PowerID { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 父级权限编号(自连接)
        /// </summary>
        public string ParentID { get; set; }
    }
}
