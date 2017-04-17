using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NOCPLWebApplication.ViewComponents
{
    public class ModalWindowViewComponent : ViewComponent 
    {
    public IViewComponentResult Invoke() 
    {
        return View();
    }
}
}
