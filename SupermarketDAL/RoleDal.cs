using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketModel;
using System.Data;

namespace SupermarketDAL
{
    public class roleDal
    {
        /// <summary>
        /// 查询角色表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static object RoleSelect(int page, int limit)
        {
            string sql = string.Format("select * from(select ROW_NUMBER() OVER(ORDER BY RoleID desc) as row, * from T_Role) o ");
            string sqlPages = sql + string.Format(" where o.row  between ({0}-1)*{1}+1 and {2}*{3}", page, limit, page, limit);
            //总查询记录
            var roleTabCount = DBHelper.Read(sql).Rows.Count;
            //分页后查询数据
            var roleTabPage = DBHelper.Read(sqlPages);

            List<T_Role> roleLst = new List<T_Role>();
            foreach (DataRow item in roleTabPage.Rows)
            {
                string sqlRole = string.Format(@"select c.Name as RoleName from T_Role a
                     join T_RolePermissions b on a.RoleID = b.RoleID
                     join T_Power c on b.PowerID = c.PowerID
                     where a.RoleID = {0}", Convert.ToInt32(item["RoleID"].ToString()));
                var RoleNameLst = DBHelper.Read(sqlRole);
                string RoleName = "";
                foreach (DataRow RoleNameItem in RoleNameLst.Rows)
                {
                    RoleName += RoleNameItem["RoleName"].ToString() + ",";
                };

                T_Role role = new T_Role
                {
                    RoleID = Convert.ToInt32(item["RoleID"].ToString()),
                    Name = item["Name"].ToString(),
                    RoleRemake = item["RoleRemake"].ToString(),
                    RoleName = RoleName.Trim(',')
                };
                roleLst.Add(role);
            }
            var obj = new
            {
                status = roleTabCount,
                lst = roleLst
            };
            return obj;
        }
    }
}
