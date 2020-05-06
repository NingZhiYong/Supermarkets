using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketModel
{
    public class RoleList
    {
        public string title { get; set; }
        public string id { get; set; }
        public List<RoleList> children { get; set; }
        public bool spread { get; set; }
    }
}
