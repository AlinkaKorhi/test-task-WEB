using DataAccess.EntityFramework.Configurations;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class TestCoreTaskContext : DbContext, IDbContext
    {
        public DbSet<Comment> Comments { get; set; }

        public TestCoreTaskContext(DbContextOptions<TestCoreTaskContext> options)
            : base(options)
        {
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
        }
    }
}
