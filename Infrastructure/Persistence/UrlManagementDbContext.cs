using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class UrlManagementDbContext:DbContext
    {
        public UrlManagementDbContext(DbContextOptions<UrlManagementDbContext> options) : base(options) { }


        public DbSet<Url> Url { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var infrastructureAssembly = typeof(IAssemblyMarker).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(infrastructureAssembly);
        }
    }
}
