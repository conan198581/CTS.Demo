using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Core.Data;
using General.Entites;
using General.Entites.Role;

namespace General.Services.Role
{
    public class RoleService : IRoleService
    {
        /*
        public GeneralDbContext _generalDbContext;
        public RoleService(GeneralDbContext  generalDbContext)
        {
            this._generalDbContext = generalDbContext;
        }
        */
        private readonly IRepository<RoleEntity> _repository;
        public RoleService(IRepository<RoleEntity> repository)
        {
            _repository = repository;
        }
        public List<RoleEntity> GetAll()
        {
            return _repository.Table.ToList();
        }
    }
}
