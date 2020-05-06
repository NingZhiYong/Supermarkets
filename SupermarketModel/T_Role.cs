using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketModel
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class T_Role
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleID { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 角色说明
        /// </summary>
        public string RoleRemake { get; set; }

        //作角色管理权限展示用 无实际意义
        public string RoleName { get; set; }
    }
}
