using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketModel
{
    /// <summary>
    /// 员工信息表
    /// </summary>
    public class T_Employee
    {
        /// <summary>
        /// 员工编号(自增)
        /// </summary>
        public int EmployeeID { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Passwd { get; set; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Photo { get; set; }
        /// <summary>
        /// 角色编号
        /// </summary>
        //public int RoleID { get; set; }

        //public string RoleName { get; set; }

        /// <summary>
        /// 角色编号（外键）
        /// </summary>
        public T_Role Role { get; set; }
    }
}
