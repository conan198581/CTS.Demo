using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Core.Data
{
    public interface IRepository<TEntity> where TEntity:class
    {
        DbContext RepositoryDbContext { get; }
        DbSet<TEntity> Entities { get; }
        IQueryable<TEntity> Table { get; }
        TEntity GetEntityById(object id);
        void InsertEntity(TEntity entity, bool isSave=true);
        void DeleteEntity(TEntity entity, bool isSave=true);
        void UpdateEntity(TEntity entity, bool isSave=true);
    }
}
