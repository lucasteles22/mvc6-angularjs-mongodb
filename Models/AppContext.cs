using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using System.Collections.Generic;
using System.Linq;


namespace WebApi.Models
{
    public class AppContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Todo>().Key(a => a.Name);
            
            base.OnModelCreating(builder);
        }
        
        protected override void OnConfiguring(EntityOptionsBuilder options)
        {
            options.UseInMemoryStore(persist: true);
        }
        
    }
}