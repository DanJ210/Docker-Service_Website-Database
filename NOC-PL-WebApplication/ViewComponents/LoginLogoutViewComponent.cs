﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NOCPLWebApplication.Views.ViewComponents {
    public class LoginLogoutViewComponent : ViewComponent {
        public IViewComponentResult Invoke() {
            return View();
        }
    }
}