using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketDAL;
using SupermarketModel;

namespace SupermarketBLL
{
    public class roleBll
    {
        /// <summary>
        /// 查询角色表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static object RoleSelect(int page, int limit)
        {
            return roleDal.RoleSelect(page, limit);
        }
    }
}
