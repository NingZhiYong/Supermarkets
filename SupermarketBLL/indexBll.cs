using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketDAL;
using SupermarketModel;
using System.Data;

namespace SupermarketBLL
{
    public class indexBll
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        public static DataTable EmpSelect(string Lgn, string Pwd)
        {
            return indexDal.EmpSelect(Lgn, Pwd);
        }

        /// <summary>
        /// 权限查询
        /// </summary>
        /// <param name="emp"></param>
        public static List<GetTree> PowerSelect(T_Employee emp)
        {
            return indexDal.PowerSelect(emp);
        }
    }
}
