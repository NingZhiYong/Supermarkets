using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketModel;
using SupermarketDAL;

namespace SupermarketBLL
{
    public class employeeBll
    {
        /// <summary>
        /// 用户管理--查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static object employeeSelect(int page, int limit)
        {
            return employeeDal.employeeSelect(page, limit);
        }

        /// <summary>
        /// 新增用户 角色select
        /// </summary>
        /// <returns></returns>
        public static List<T_Role> RoleSelect()
        {
            return employeeDal.RoleSelect();
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static bool employeeAdd(T_Employee emp)
        {
            return employeeDal.employeeAdd(emp);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public static bool employeeDel(int empId)
        {
            return employeeDal.employeeDel(empId);
        }

        /// <summary>
        /// 编辑用户查询
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public static T_Employee empEditSelect(int empId)
        {
            return employeeDal.empEditSelect(empId);
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <returns></returns>
        public static bool employeeEdit(T_Employee emp)
        {
            return employeeDal.employeeEdit(emp);
        }
    }
}
