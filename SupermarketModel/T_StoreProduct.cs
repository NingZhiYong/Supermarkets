using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketModel
{
    /// <summary>
    /// 仓库商品详细表
    /// </summary>
    public class T_StoreProduct
    {
        /// <summary>
        /// 仓库商品详情编号(自增)
        /// </summary>
        public int StoreProID { get; set; }
        /// <summary>
        /// 商品编号(外键 商品表)
        /// </summary>
        public T_Shop Shop { get; set; }
        /// <summary>
        /// 仓库编号
        /// </summary>
        public T_Store Store { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 不做实际操作 只用于页面展示接收数据使用
        /// </summary>
        public int StoreProNumber { get; set; }
    }
}
