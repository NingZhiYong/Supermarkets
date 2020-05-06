using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketModel
{
    /// <summary>
    /// 商品表
    /// </summary>
    public class T_Shop
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int ShopID { get; set; }
        /// <summary>
        /// 商品条形码
        /// </summary>
        public string ShopCode { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 商品图片
        /// </summary>
        public string Images { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public T_Supplier Supplier { get; set; }
        /// <summary>
        /// 商品进价
        /// </summary>
        public decimal CostPrice { get; set; }
        /// <summary>
        /// 商品售价
        /// </summary>
        public decimal SalePrice { get; set; }
        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? BothTime { get; set; }
        /// <summary>
        /// 保质期
        /// </summary>
        public int? ShelfLife { get; set; }
        /// <summary>
        /// 商品类型编号(外键)
        /// </summary>
        public T_ShopType ShopType { get; set; }


        /// <summary>
        /// 特殊字段 用来完成采购 销售 入库的数量 不做实际操作
        /// </summary>
        public int Number { get; set; }
    }
}
