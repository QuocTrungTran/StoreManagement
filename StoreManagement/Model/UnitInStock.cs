using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Model
{
    public class UnitInStock
    {
        public Material Material { get; set; }
        public int Number { get; set; }
        public int Count { get; set; }
    }
}
