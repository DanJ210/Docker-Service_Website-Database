using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NOCPLWebApplication.Models {
    public class NocUnAuthorizeAttribute : AuthorizeAttribute {
        protected virtual void HandleUnauthorizedRequest(AuthorizationHandlerContext filterContext) {
            //if (filterContext.HasFailed) {
            //    filterContext.ht
            //}
        }
    }
}
