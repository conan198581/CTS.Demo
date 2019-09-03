using General.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Entites
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity:class
    {
        private readonly GeneralDbContext generalDbContext;
        public EfRepository(GeneralDbContext _generalDbContext)
        {
            this.generalDbContext = _generalDbContext;
        }
        public DbContext RepositoryDbContext
        {
            get
            {
                return generalDbContext;
            }
        }

        public DbSet<TEntity> Entities
        {
            get
            {
                return generalDbContext.Set<TEntity>();
            }
        }

        public IQueryable<TEntity> Table
        {
            get
            {
                return generalDbContext.Set<TEntity>();
            }
        }


        public void DeleteEntity(TEntity entity, bool isSave = true)
        {
            Entities.Remove(entity);
            if (isSave)
            {
                RepositoryDbContext.SaveChanges();
            }
        }

        public TEntity GetEntityById(object id)
        {
            return Entities.Find(id);
        }

        public void InsertEntity(TEntity entity, bool isSave = true)
        {
            Entities.Add(entity);
            if (isSave)
            {
                RepositoryDbContext.SaveChanges();
            }
        }

        public void UpdateEntity(TEntity entity, bool isSave = true)
        {
            if (isSave)
            {
                RepositoryDbContext.SaveChanges();
            }
        }
    }
}
