using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace General.Entites
{
    public class GeneralDbContext:DbContext
    {
        public GeneralDbContext(DbContextOptions<GeneralDbContext> options):base(options)
        {

        }

        public DbSet<Category.Category> Categories { get; set; }
        public DbSet<Role.RoleEntity> RoleEntities { get; set; }
    }
}
