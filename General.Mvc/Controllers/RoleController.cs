using General.Core;
using General.Services.Role;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace General.Mvc.Controllers
{
    public class RoleController:Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            //this._roleService = EngineContext.Current.Resolve<IRoleService>();
            this._roleService = roleService;
        }
        public IActionResult Index()
        {
            var rolelist = _roleService.GetAll();
            var rolelistnum = rolelist.Count();
            return Content(rolelistnum.ToString());
        }
    }
}
