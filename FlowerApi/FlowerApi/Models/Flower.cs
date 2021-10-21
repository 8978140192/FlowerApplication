using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerApi.Models
{
    public class Flower
    {
        
        public int id { get; set; }
        public string name { get; set; }
        public string discription { get; set; }
        public int price { get; set; }
        public int qty { get; set; }
    }
}
