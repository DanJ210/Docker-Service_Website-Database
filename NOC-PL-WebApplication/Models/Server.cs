﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOCPLWebApplication.Models {
    public class Server {
        public int Id { get; set; }
        public string ServerName { get; set; }
        public ICollection<Product> ProductsContained { get; set; }

    }
}
safds