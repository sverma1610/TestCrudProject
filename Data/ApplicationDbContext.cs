using CRUD.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CRUD.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //try
            //{
            //    var DatabaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabase;
            //    if (DatabaseCreator != null)
            //    {
            //        if (!DatabaseCreator.CanConnect()) DatabaseCreator.Create();
            //        if (!DatabaseCreator.HasTables()) DatabaseCreator.CreateTables();

            //    }
            //}
            //catch 
            //{
            //}

        }
        public DbSet<Product> Products { get; set; }
    }
}
