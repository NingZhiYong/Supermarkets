using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketModel
{
    /// <summary>
    /// 角色权限详细表
    /// </summary>
    public class T_RolePermissions
    {
        /// <summary>
        /// 角色权限编号
        /// </summary>
        public int Role_permissionsID { get; set; }
        /// <summary>
        /// 权限编号(外键)
        /// </summary>
        public string PowerID { get; set; }
        /// <summary>
        /// 角色编号(外键)
        /// </summary>
        public int RoleID { get; set; }
    }
}
