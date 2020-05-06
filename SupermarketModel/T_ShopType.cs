using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketModel
{
    /// <summary>
    /// 商品类型表
    /// </summary>
    public class T_ShopType
    {
        /// <summary>
        /// 商品类型编号(自增)
        /// </summary>
        public int TypeID { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string Name { get; set; }
    }
}
