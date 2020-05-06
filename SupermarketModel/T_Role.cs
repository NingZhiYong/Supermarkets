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
        public int RoleID { get; set; }
        public string Name { get; set; }

        //作角色管理权限展示用 无实际意义
        public string RoleName { get; set; }
    }
}
