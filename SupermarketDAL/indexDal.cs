using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketModel;

namespace SupermarketDAL
{
    public class indexDal
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="Lgn">账号</param>
        /// <param name="Pwd">密码</param>
        /// <returns></returns>
        public static DataTable EmpSelect(string Lgn, string Pwd)
        {
            string sql = string.Format("select * from T_Employee where Login='{0}' and Passwd='{1}'", Lgn, Pwd);
            return DBHelper.Read(sql);
        }

        /// <summary>
        /// 权限查询
        /// </summary>
        /// <param name="emp">登录的账号信息</param>
        /// <returns></returns>
        public static List<GetTree> PowerSelect(T_Employee emp)
        {
            //将导航标所有数据添加到List集合中
            string sql_list = string.Format("select * from T_Navigation");
            DataTable Navigation_table = DBHelper.Read(sql_list);
            List<T_Navigation> lst = new List<T_Navigation>();  //所有数据
            foreach (DataRow item in Navigation_table.Rows)
            {
                T_Navigation navigation = new T_Navigation
                {
                    NavigationID = Convert.ToInt32(item["NavigationID"].ToString()),
                    Name = item["Name"].ToString(),
                    Url = item["Url"].ToString(),
                    CodeID = item["CodeID"].ToString(),
                    ParentID = Convert.ToInt32(item["ParentID"].ToString())
                };
                lst.Add(navigation);
            }

            //将导航表所有父级添加到List集合中
            //string lst_Navigation = string.Format("select * from T_Navigation where ParentID=0");
            //DataTable Navigation = DBHelper.Read(lst_Navigation);
            //List<T_Navigation> fj = new List<T_Navigation>();  //所有父级数据
            //foreach (DataRow item in Navigation.Rows)
            //{
            //    T_Navigation navigation = new T_Navigation
            //    {
            //        NavigationID = Convert.ToInt32(item["NavigationID"].ToString()),
            //        Name = item["Name"].ToString(),
            //        Url = item["Url"].ToString(),
            //        CodeID = item["CodeID"].ToString(),
            //        ParentID = Convert.ToInt32(item["ParentID"].ToString())
            //    };
            //    fj.Add(navigation);
            //}

            var fj = lst.Where(c => c.ParentID == 0).ToList();

            //导航分级 = >
            //一级导航
            List<GetTree> return_list = new List<GetTree>();

            //查询权限
            string sql_RolePermissions = string.Format("select * from T_RolePermissions where RoleID={0}", emp.Role.RoleID);
            DataTable RolePermissions = DBHelper.Read(sql_RolePermissions);
            List<T_RolePermissions> lst_RolePermissions = new List<T_RolePermissions>();
            foreach (DataRow item in RolePermissions.Rows)
            {
                T_RolePermissions rolePermissions = new T_RolePermissions
                {
                    Role_permissionsID = Convert.ToInt32(item["Role_permissionsID"].ToString()),
                    PowerID = item["PowerID"].ToString(),
                    RoleID = Convert.ToInt32(item["RoleID"].ToString())
                };
                lst_RolePermissions.Add(rolePermissions);
            }

            foreach (var item in fj)
            {
                GetTree getTree = new GetTree
                {
                    id = item.NavigationID,
                    text = item.Name,
                    url = item.Url,
                    children = new List<GetTree>()
                };

                var child = lst
                    .Where(c => c.ParentID == item.NavigationID)
                    .Select(c => new GetTree
                    {
                        id = c.NavigationID,
                        text = c.Name,
                        url = c.Url
                    });
                //判断当前用户是否拥有该导航的权限
                if (lst_RolePermissions.Exists(c => c.PowerID == item.CodeID))
                {
                    getTree.children.AddRange(child); //二级添加
                    return_list.Add(getTree); //一级添加
                }
            }
            return return_list;

        }
        
    }
}
