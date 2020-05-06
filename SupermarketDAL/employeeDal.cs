using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketModel;
using System.Data;


namespace SupermarketDAL
{
    public class employeeDal
    {
        /// <summary>
        /// 用户管理--查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static object employeeSelect(int page, int limit)
        {
            string sql = string.Format(@"select * from(select ROW_NUMBER() OVER(ORDER BY employeeId desc) as row,
                        EmployeeID,Login, Passwd, T_Employee.Name as empName,
                        Sex, Telephone, T_Role.Name as RoleName from
                        T_Employee join T_Role on T_Employee.RoleID = T_Role.RoleID) o");

            string sqlPages = sql + string.Format(" where o.row between ({0}-1)*{1}+1 and {2}*{3} ", page, limit, page, limit);
            //总查询记录
            var employeeTabCount = DBHelper.Read(sql).Rows.Count;
            //分页后查询数据
            var employeeTabPage = DBHelper.Read(sqlPages);
            List<T_Employee> employeelst = new List<T_Employee>();

            foreach (DataRow item in employeeTabPage.Rows)
            {
                T_Employee employee = new T_Employee
                {
                    EmployeeID = Convert.ToInt32(item["EmployeeID"].ToString()),
                    Login = item["Login"].ToString(),
                    Passwd = item["Passwd"].ToString(),
                    Name = item["empName"].ToString(),
                    Sex = Convert.ToInt32(item["Sex"].ToString()),
                    Telephone = item["Telephone"].ToString(),
                    Role = new T_Role
                    {
                        Name = item["RoleName"].ToString()
                    }
                };
                employeelst.Add(employee);
            }

            var obj = new
            {
                status = employeeTabCount,
                lst = employeelst
            };
            return obj;
        }

        /// <summary>
        /// 新增用户 角色select
        /// </summary>
        /// <returns></returns>
        public static List<T_Role> RoleSelect()
        {
            string sql = "select * from T_Role";
            var db = DBHelper.Read(sql);

            List<T_Role> rolelst = new List<T_Role>();
            foreach (DataRow item in db.Rows)
            {
                T_Role role = new T_Role
                {
                    Name = item["Name"].ToString(),
                    RoleID = Convert.ToInt32(item["RoleID"].ToString())
                };
                rolelst.Add(role);
            }
            return rolelst;
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static bool employeeAdd(T_Employee emp)
        {
            string sql = string.Format("insert T_Employee(Login,Passwd,Name,Sex,Telephone,RoleID) values('{0}','{1}','{2}','{3}','{4}',{5})", emp.Login, emp.Passwd, emp.Name, emp.Sex, emp.Telephone, emp.Role.RoleID);
            return DBHelper.Write(sql);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public static bool employeeDel(int empId)
        {
            string sql = string.Format("delete from T_Employee where EmployeeID={0}", empId);
            return DBHelper.Write(sql);
        }

        /// <summary>
        /// 编辑用户查询
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public static T_Employee empEditSelect(int empId)
        {
            string sql = string.Format("select * from T_Employee where EmployeeID={0}", empId);
            var db = DBHelper.Read(sql);
            T_Employee employee = new T_Employee
            {
                EmployeeID = Convert.ToInt32(db.Rows[0]["EmployeeID"].ToString()),
                Name = db.Rows[0]["Name"].ToString(),
                Login = db.Rows[0]["Login"].ToString(),
                Passwd = db.Rows[0]["Passwd"].ToString(),
                Sex = Convert.ToInt32(db.Rows[0]["Sex"].ToString()),
                Telephone = db.Rows[0]["Telephone"].ToString(),
                Role = new T_Role
                {
                    RoleID = Convert.ToInt32(db.Rows[0]["RoleID"])
                }
            };

            return employee;
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public static bool employeeEdit(T_Employee emp)
        {
            string sql = string.Format("update T_Employee set Name='{0}', [Login]='{1}',Passwd='{2}',Sex={3},Telephone='{4}',RoleID={5} where EmployeeID={6}", emp.Name, emp.Login, emp.Passwd, emp.Sex, emp.Telephone, emp.Role.RoleID,emp.EmployeeID);
            return DBHelper.Write(sql);
        }
    }
}
