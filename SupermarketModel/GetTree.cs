using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketModel
{
    public class GetTree
    {
        public int id { get; set; }
        public string text { get; set; }
        public string url { get; set; }
        public List<GetTree> children { get; set; }
    }
}
