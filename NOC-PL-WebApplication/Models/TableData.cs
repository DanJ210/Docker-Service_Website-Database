using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NOCPLWebApplication.Models {
    public class TableData {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public ICollection<Product> TableProducts { get; set; }
        public ICollection<Server> TableServers { get; set; }
    }
}
