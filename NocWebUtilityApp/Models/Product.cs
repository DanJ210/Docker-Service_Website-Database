using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NocWebUtilityApp.Models {
    public class Product {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductGroup { get; set; }
        public Server PrimaryProductServer { get; set; }
        public Server SecondaryProductServer { get; set; }
    }
}
