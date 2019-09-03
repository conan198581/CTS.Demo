using General.Entites.Role;
using System;
using System.Collections.Generic;
using System.Text;

namespace General.Services.Role
{
    public interface IRoleService
    {
        List<RoleEntity> GetAll();
    }
}
