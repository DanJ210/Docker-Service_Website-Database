using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOCPLWebApplication.Models {
    public class Product {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductGroup { get; set; }
        public string Status { get; set; }
        public Server ProductServer { get; set; }
    }
}
