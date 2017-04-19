using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NocWebUtilityApp.Models {
    public class TableDataVM {
        public int Id { get; set; }
        public ICollection<Product> TableProducts { get; set; }
        public ICollection<Server> TableServers { get; set; }
    }
}
